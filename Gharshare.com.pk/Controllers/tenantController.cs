using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using System.Security.Claims;
//using Microsoft.AspNetCore.Hosting.IWebHosEnvironment;
using Gharshare.Views.Shared.Components.SearchBar;
using Gharshare.CommonHelper;
using IronPdf;
using iText.Kernel.Pdf;
using iText.Html2pdf;
using Gharshare.com.pk.Hubs;
using Microsoft.AspNetCore.SignalR;
using System.Net;
using System;

namespace Gharshare.com.pk.Controllers
{
    public class tenantController : Controller
    {
        private IUnitofWork _unitofWork;
        private Utility _utility;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHubContext<ChatHub> _chat;
        public tenantController(IUnitofWork iunitofWork, Utility utility,
            UserManager<ApplicationUser> userManager, IHubContext<ChatHub> chat)
        {
            _unitofWork = iunitofWork;
            _utility = utility;
            _userManager = userManager;
            _chat = chat;
        }
        [HttpGet]
        public IActionResult test()
        {
            return View();
        }
        public async Task<IActionResult> testleasepdf()
        {
            var lease = _unitofWork.LeaseAgreement.Get(la => la.ID == 6,
                includeProperties: "PrimaryTenant");
            LeaseViewVM leaseView = new LeaseViewVM
            {
                Property = _unitofWork.Property.Get(x => x.ID == 7,
                includeProperties: "Owner,Applications,State,City"),
                leaseAgreement = lease,
                PrimaryTenant = lease.PrimaryTenant,
                AdditionalTenants = _unitofWork.LeaseTenant.GetAll(x => x.LeaseID == 6
                && x.isPrimaryTenant == false, includeProperties: "Tenant").ToList(),
            };
            //return View("leasePdf", leaseView);
            string html = null;
            string filename = null;
            Byte[] file = null;
            try
            {
                html = await _utility.RenderViewToStringAsync("leasePdf", leaseView, ControllerContext);
                filename = _utility.GenerateFileName("leaseagreement.pdf", @"assets/pdfdocs/lease");
                string filePath = @"wwwroot/assets/pdfdocs/lease/" + filename;
                file = _utility.GeneratePdfByiText7(html, filePath);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Error");
            }
            return View("leasePdf", leaseView);
        }
        [HttpPost]
        public async Task<JsonResult> signLease(LeaseAgreement leaseAgreement)
        {
            try
            {
                #region save tenant sig & update lease
                var lease = _unitofWork.LeaseAgreement.Get(la => la.ID == leaseAgreement.ID,
                    includeProperties: "PrimaryTenant");
                lease.tenantagree2sign = leaseAgreement.tenantagree2sign;
                lease.TenantlordSign = Convert.FromBase64String(leaseAgreement.TenantsigData);
                lease.SignedByTenant = true;
                lease.TenantSignedOn = leaseAgreement.TenantSignedOn;
                lease.LeaseStatus = LeaseAgreement.status.Active;
                _unitofWork.LeaseAgreement.update(lease);
                _unitofWork.Save();
                #endregion

                #region re-generate & update lease agreement                
                Property property;
                LeaseViewVM leaseView = new LeaseViewVM
                {
                    Property = _unitofWork.Property.Get(x => x.ID == lease.PropertyID,
                    includeProperties: "Owner,Applications,State,City"),
                    PrimaryTenant = lease.PrimaryTenant,
                    AdditionalTenants = _unitofWork.LeaseTenant.GetAll(x => x.LeaseID ==
                    lease.ID && x.isPrimaryTenant == false, includeProperties: "Tenant").ToList(),
                    leaseAgreement = lease
                };
                string html = null;
                string filename = null;
                Byte[] file = null;
                try
                {
                    html = await _utility.RenderViewToStringAsync("leasePdf", leaseView, ControllerContext);
                    filename = _utility.GenerateFileName("leaseagreement.pdf", @"assets/pdfdocs/lease");
                    string filePath = @"wwwroot/assets/pdfdocs/lease/" + filename;
                    file = _utility.GeneratePdfByiText7(html, filePath);
                }
                catch (Exception exp)
                {
                    LogErrorDetail(exp, "tenant/signLease/GeneratePdfByiText7");
                    Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    return Json("error occured generating pdf of lease agreement.");
                }
                #endregion

                #region delete old lease from file sys & update doc object with new file path
                try
                {
                    var doc = _unitofWork.Document.Get(d => d.LeaseAgreementID == lease.ID &&
                    d.DocumentTypeID == 2);
                    if (doc.FilePath != "") //delte old lease agreement pdf
                    {
                        _utility.DeletFile(doc.FilePath);
                    }
                    doc.FilePath = @"/assets/pdfdocs/lease/" + filename;
                    doc.UpdatedbyUserID = HttpContext.Session.GetString("_UserId");
                    doc.UpdatedOn = DateTime.UtcNow;
                    _unitofWork.Document.update(doc);
                    _unitofWork.Save();
                }
                catch (Exception exp)
                {
                    LogErrorDetail(exp, "tenant/signlease/GeneratePdfByiText7");
                    Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    return Json("error occured saving document record.");
                }
                #endregion
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                //return RedirectToAction("Error", "Error");
            }
            return Json("success");
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> savereport(ConditionReportVm conditionReportVm)
        {
            //return new JsonResult("/assets/pdfdocs/conditionreport/5392e162-83fe-45a5-9664-5c4196645dbd-conditionreport.pdf");
            try
            {
                if (ModelState.IsValid)
                {
                    ConditionReport cReport = _unitofWork.ConditionReport.Get(x => x.ID ==
                    conditionReportVm.CondtionReport.ID);
                    if (conditionReportVm.CondtionReport.TenantsigData != null)
                    {
                        byte[] tenantSignatures = Convert.FromBase64String(conditionReportVm.CondtionReport.TenantsigData);
                        cReport.TenantSign = tenantSignatures;
                        cReport.status = ConditionReport.Status.SignedByTenant;
                        cReport.TenantSignedOn = conditionReportVm.CondtionReport.TenantSignedOn;
                    }
                    if (cReport.LandlordSign != null && cReport.SignedByLandlord == true &&
                        conditionReportVm.CondtionReport.TenantsigData != null)
                        cReport.status = ConditionReport.Status.Completed;
                    cReport.SignedByTenant = true;
                    cReport.UpdatedOn = DateTime.UtcNow;
                    _unitofWork.ConditionReport.update(cReport);
                    _unitofWork.Save();
                    List<CRItemDetail> itemDetail = new List<CRItemDetail>();
                    conditionReportVm.ReportItemDetail.ForEach(reportItemDetail =>
                    {
                        _unitofWork.CRItem.StopTracking(reportItemDetail.CRItem);
                        _unitofWork.CRItemDetail.StopTracking(reportItemDetail);
                        var crItemDetail = _unitofWork.CRItemDetail.Get(x =>
                        x.ID == reportItemDetail.ID);
                        crItemDetail.TenantComments = reportItemDetail.TenantComments;
                        crItemDetail.TenantAgreed = reportItemDetail.TenantAgreed;
                        itemDetail.Add(crItemDetail);
                    });
                    _unitofWork.CRItemDetail.UpdateRange(itemDetail);
                    _unitofWork.Save();
                    var photosbyTenant = conditionReportVm.ReportItemDetail.
                        Where(x => x.PhotoField == true).ToList();
                    #region Save images uploaded by tenant
                    List<CRItemImage> tenantPhotos = new List<CRItemImage>();
                    if (photosbyTenant.Count() > 0)
                    {
                        foreach (var item in photosbyTenant)
                        {
                            if (item.PhotosbyTenant != null)
                            {
                                foreach (var photo in item.PhotosbyTenant)
                                {
                                    var imgPath = "";
                                    if (photo.Length <= 100000)
                                    {
                                        imgPath = _utility.SaveFile(photo, @"assets/PropertyAreaImages");
                                    }
                                    else
                                    {
                                        imgPath = _utility.ResizeAndSaveImage(photo, "assets/PropertyAreaImages",
                                            100000, 300, 300);
                                    }
                                    tenantPhotos.Add(new CRItemImage
                                    {
                                        CRItemID = item.CRItemID,
                                        //ConditionReportID= conditionReportVm.CondtionReport.ID,
                                        AddedByTenant = true,
                                        AddedByLandlord = false,
                                        uid=Guid.NewGuid().ToString(),
                                        ImagePath = imgPath, // _utility.SaveFile(photo, @"assets/PropertyAreaImages"),
                                    });
                                    _unitofWork.CRItemImage.AddRange(tenantPhotos);
                                }
                            }
                        }
                        _unitofWork.Save();
                    }
                    #endregion
                    TempData["success"] = "Record successfully saved !";
                }
                else
                {
                    TempData["error"] = "error saving condition report";
                    RedirectToAction("index");
                }
                byte[] pdfBytes = await GeneratePdfByiText7(conditionReportVm.CondtionReport.ID);
                var updatedcReport = _unitofWork.ConditionReport.Get(cr =>
                cr.ID == conditionReportVm.CondtionReport.ID);
                return new JsonResult(updatedcReport.FilePath);
                //return RedirectToAction("conditionreport",
                //    new { id = conditionReportVm.CondtionReport.ID });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        private async Task<Byte[]> GeneratePdfByiText7(Int64 id)
        {
            try
            {
                #region create condition report view model
                ConditionReport conditionReport = _unitofWork.ConditionReport.Get(
                    x => x.ID == id, includeProperties: "Property");

                List<CRItem> reportItems = _unitofWork.CRItem.GetAll(
                    x => x.ConditionReportID == conditionReport.ID,
                    includeProperties: "CRItemImages").ToList();

                var reportItemIds = reportItems.Select(x => x.ID).ToList();

                List<CRItemDetail> itemDetail = _unitofWork.CRItemDetail.GetAll(
                    includeProperties: "AreaItem").Where(x =>
                    reportItemIds.Contains(x.CRItemID)).ToList();

                ConditionReportVm crVm = new ConditionReportVm
                {
                    CondtionReport = conditionReport,
                    ReportItemDetail = itemDetail,
                    Property = _unitofWork.Property.Get(x =>
                    x.ID == conditionReport.PropertyID && x.Lease.LeaseStatus == LeaseAgreement.status.Active
                    , includeProperties: "Owner,Lease.PrimaryTenant"),
                    ReportItems = reportItems
                };
                #endregion
                var oldConditionRptPath = conditionReport.FilePath;

                string htmlforPdf = await _utility.RenderViewToStringAsync("conditionreportPDF",
                    crVm, ControllerContext);
                string filename = _utility.GenerateFileName("conditionreport.pdf",
                    @"assets/pdfdocs/conditionreport");
                string filePath = @"wwwroot/assets/pdfdocs/conditionreport/" + filename;
                var result = _utility.GeneratePdfByiText7(htmlforPdf, filePath);
                //await SaveDocumentRecord(crVm.Property.Lease.ID, crVm.Property.ID,
                //    @"/assets/pdfdocs/conditionreport/" + filename, 3, "Condition Report");
                crVm.CondtionReport.FilePath = @"/assets/pdfdocs/conditionreport/" + filename;
                _unitofWork.ConditionReport.update(crVm.CondtionReport);
                _unitofWork.Save();
                await updateDocumentRecord(oldConditionRptPath, crVm.CondtionReport.FilePath);
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private async Task updateDocumentRecord(string oldFilePath, string newFilePath)
        {
            try
            {
                var document = _unitofWork.Document.Get(d => d.FilePath == oldFilePath);
                document.FilePath = newFilePath;
                document.UpdatedbyUserID = HttpContext.Session.GetString("_UserId");
                document.UpdatedOn = DateTime.UtcNow;
                _unitofWork.Document.update(document);
                _unitofWork.Save();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private async Task SaveDocumentRecord(Int64 leaseId, Int64 propertyId, string filepath, Int64 docTypeID, string docName)
        {
            try
            {
                Document document = new Document
                {
                    DocumentTypeID = docTypeID,
                    LeaseAgreementID = leaseId,
                    PropertyID = propertyId,
                    Name = docName,
                    FilePath = filepath,
                    CreatedbyUserID = HttpContext.Session.GetString("_UserId"),
                    FileType = "1",
                    CreatedOn = DateTime.Now,
                    uid=Guid.NewGuid().ToString()
                };
                _unitofWork.Document.Add(document);
                _unitofWork.Save();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> conditionreport(string id)
        {
            try
            {
                ConditionReport conditionReport = _unitofWork.ConditionReport.Get(
                    x => x.uid == id, includeProperties: "Property");

                List<CRItem> reportItems = _unitofWork.CRItem.GetAll(
                    x => x.ConditionReportID == conditionReport.ID,
                    includeProperties: "CRItemImages").ToList();

                var reportItemIds = reportItems.Select(x => x.ID).ToList();

                List<CRItemDetail> itemDetail = _unitofWork.CRItemDetail.GetAll(
                    includeProperties: "AreaItem").Where(x =>
                    reportItemIds.Contains(x.CRItemID)).ToList();

                ConditionReportVm conditionReportVm = new ConditionReportVm
                {
                    CondtionReport = conditionReport,
                    ReportItemDetail = itemDetail,
                    Property = _unitofWork.Property.Get(x =>
                    x.ID == conditionReport.PropertyID, includeProperties: "Owner,Lease"),
                    ReportItems = reportItems
                };
                return View(conditionReportVm);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }

        //conditionreportPDF is for testing 
        public async Task<IActionResult> conditionreportPDF(Int64 id)
        {
            ConditionReport conditionReport = _unitofWork.ConditionReport.Get(
                x => x.ID == id, includeProperties: "Property");

            List<CRItem> reportItems = _unitofWork.CRItem.GetAll(
                x => x.ConditionReportID == conditionReport.ID,
                includeProperties: "CRItemImages").ToList();

            var reportItemIds = reportItems.Select(x => x.ID).ToList();

            List<CRItemDetail> itemDetail = _unitofWork.CRItemDetail.GetAll(
                includeProperties: "AreaItem").Where(x =>
                reportItemIds.Contains(x.CRItemID)).ToList();

            ConditionReportVm crVm = new ConditionReportVm
            {
                CondtionReport = conditionReport,
                ReportItemDetail = itemDetail,
                Property = _unitofWork.Property.Get(x =>
                x.ID == conditionReport.PropertyID && x.Lease.LeaseStatus == LeaseAgreement.status.Active,
                includeProperties: "Owner,Lease.PrimaryTenant"),
                ReportItems = reportItems
            };
            string htmlforPdf = await _utility.RenderViewToStringAsync("conditionreportPDF",
                    crVm, ControllerContext);
            string filename = _utility.GenerateFileName("conditionreport.pdf",
                @"assets/pdfdocs/conditionreport");
            string filePath = @"wwwroot/assets/pdfdocs/conditionreport/" + filename;
            var result = _utility.GeneratePdfByiText7(htmlforPdf, filePath);
            return View(crVm);
        }
        public JsonResult GetMessages(string id)
        {
            List<Message> messages = null;
            try
            {
                var currentUserId = HttpContext.Session.GetString("_UserId");
                string landlordId = id;
                messages = _unitofWork.Message
                    .GetAll(x => (x.FromUserID == currentUserId && x.ToUserID == landlordId) ||
                (x.ToUserID == currentUserId && x.FromUserID == landlordId)
                && x.Type == Message.MessageType.WithUser,
                includeProperties: "FromUser,ToUser").ToList();
                
                messages.ForEach(msg =>
                {
                    if (msg.ToUserID == currentUserId && msg.Read == false)
                        msg.Read = true;
                });
                _unitofWork.Message.UpdateRange(messages);
                _unitofWork.Save();
            }
            catch (Exception ex)
            {
                LogErrorDetail(ex, "tenant/GetMessages");
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json("error getting message list");
            }
            return new JsonResult(messages);
        }
        [HttpGet]
        public async Task<IActionResult> chat(string id)
        {
            try
            {
                var currentUserId = HttpContext.Session.GetString("_UserId");
                string landlordId = id;
                var messages = _unitofWork.Message
                    .GetAll(x => (x.FromUserID == currentUserId && x.ToUserID == landlordId) ||
                (x.ToUserID == currentUserId && x.FromUserID == landlordId) 
                && x.Type == Message.MessageType.WithUser,
                includeProperties: "FromUser,ToUser").ToList();

                var landlord = await _userManager.FindByIdAsync(landlordId);
                ViewBag.Landlord = landlord;
                messages.ForEach(msg =>
                {
                    if (msg.ToUserID == currentUserId && msg.Read == false)
                        msg.Read = true;
                });
                _unitofWork.Message.UpdateRange(messages);
                _unitofWork.Save();
                return View(messages);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> chat(Message message)
        {
            try
            {
                _chat.Clients.All.SendAsync("ReceiveMsg", message.Text);
                return View();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }

        [HttpGet]
        public IActionResult conditionreportlist(string uid)
        {
            try
            {
                var lease = _unitofWork.LeaseAgreement.Get(la => la.uid == uid);
                List<ConditionReport> conditionReport = _unitofWork.ConditionReport
                    .GetAll(x => x.LeaseAgreementID == lease.ID & x.Sent2Tenant == true,
                    includeProperties: "Property").ToList();
                return View(conditionReport);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        public JsonResult viewapplication(Int64 AID)
        {
            ApplicantDocument applicantDocument = null;
            try
            {
                applicantDocument = _unitofWork.ApplicantDocument.Get(x => x.ApplicationID == AID,
                    includeProperties: "Application");
            }
            catch (Exception ex)
            {
                LogErrorDetail(ex, "UpdatePropertyImages");
            }
            return new JsonResult(applicantDocument);
        }
        private void LogErrorDetail(Exception ex, string errorPath)
        {
            try
            {
                var errorLog = new ErrorLog
                {
                    ErrorDetail = ex.Message,
                    ErrorSource = ex.Source,
                    StackTrace = ex.StackTrace,
                    ErrorPath = errorPath,
                    LoggedInUserId = HttpContext.Session.GetString("_UserId"),
                    status = ErrorLog.Status.Open,
                    uid = Guid.NewGuid().ToString()
                };
                _unitofWork.ErrorLog.Add(errorLog);
                _unitofWork.Save();
            }
            catch (Exception exp)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> viewleasedoc(string uid)
        {
            try
            {
                LeaseAgreement leaseAgreement = _unitofWork.LeaseAgreement.Get(x => x.uid == uid,
                    includeProperties: "Property.Owner,PrimaryTenant");
                LeaseViewVM leaseViewVM = new LeaseViewVM
                {
                    leaseAgreement = leaseAgreement,
                    LeasePdfDoc = _unitofWork.Document
                    .Get(x => x.LeaseAgreementID == leaseAgreement.ID && x.DocumentTypeID == 2)
                };
                return View(leaseViewVM);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }

        }
        [HttpGet]
        public IActionResult leaseoverview(string uid)
        {
            try
            {
                LeaseAgreement leaseAgreement = _unitofWork.LeaseAgreement.Get(x => x.uid == uid);
                Property property = _unitofWork.Property
                    .Get(x => x.ID == leaseAgreement.PropertyID, includeProperties: "Owner,Applications,State,City");
                LeaseViewVM leaseViewVM = new LeaseViewVM
                {
                    leaseAgreement = leaseAgreement,
                    Property = property,
                    LeasePdfDoc = _unitofWork.Document.Get(x => x.LeaseAgreementID == leaseAgreement.ID)
                };
                return View(leaseViewVM);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }

        }
        [HttpGet]
        public async Task<IActionResult> lease(string uid)
        {
            try
            {
                LeaseAgreement leaseAgreement = _unitofWork.LeaseAgreement.Get(x => x.uid == uid);
                Property property = _unitofWork.Property
                    .Get(x => x.ID == leaseAgreement.PropertyID, includeProperties: "Owner,Applications,State,City");
                LeaseViewVM leaseViewVM = new LeaseViewVM
                {
                    leaseAgreement = leaseAgreement,
                    Property = property,
                    LeasePdfDoc = _unitofWork.Document.Get(x => x.LeaseAgreementID == leaseAgreement.ID)
                };
                return View(leaseViewVM);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }

        }
        [HttpPost]
        public async Task<IActionResult> paymentmethod(UserAccountVM userAccount)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (userAccount.userBankAccount.IsSelectedForPayment == true)
                    {
                        List<UserBankAccount> userBankAccounts = null;
                        if (userAccount.userBankAccount.AccountType == UserBankAccount.acctype.bankaccount)
                        {
                            userBankAccounts = _unitofWork.UserBankAccount
                                .GetAll(x => x.AccountType == UserBankAccount.acctype.bankaccount)
                                .ToList();
                        }
                        else if (userAccount.userBankAccount.AccountType == UserBankAccount.acctype.creditcard)
                        {
                            userBankAccounts = _unitofWork.UserBankAccount
                                .GetAll(x => x.AccountType == UserBankAccount.acctype.creditcard)
                                .ToList();
                        }
                        userBankAccounts.ForEach(x => { x.IsSelectedForPayment = false; });
                        _unitofWork.UserBankAccount.UpdateRange(userBankAccounts);
                        _unitofWork.Save();
                    }
                    string _userId = HttpContext.Session.GetString("_UserId");
                    userAccount.userBankAccount.UserId = _userId;
                    userAccount.userBankAccount.uid = Guid.NewGuid().ToString();
                    _unitofWork.UserBankAccount.Add(userAccount.userBankAccount);
                    _unitofWork.Save();
                    if (userAccount.userBankAccount.AccountType == UserBankAccount.acctype.bankaccount)
                        TempData["success"] = "Bank account successfully saved !";
                    else if (userAccount.userBankAccount.AccountType == UserBankAccount.acctype.creditcard)
                        TempData["success"] = "Card successfully saved !";
                }
                return Redirect("paymentmethod");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }

        }
        [HttpGet]
        public async Task<IActionResult> paymentmethod()
        {
            try
            {
                string _userId = HttpContext.Session.GetString("_UserId");
                Applicant tenant = _unitofWork.Applicant.Get(x => x.UserID == _userId);
                UserAccountVM userAccount = new UserAccountVM
                {
                    Lease = _unitofWork.LeaseAgreement.Get(x => x.PrimaryTenantID == tenant.ID,
                    includeProperties: "Property"),
                    userBankAccount = new UserBankAccount()
                };
                return View(userAccount);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        [HttpGet]
        public IActionResult applicationlist()
        {
            try
            {
                string _userId = HttpContext.Session.GetString("_UserId");
                IEnumerable<Application> applications = _unitofWork.Application.GetAll(x => x.UserID == _userId, includeProperties: "User,Property,Applicant");
                return View(applications);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }

        }
        [HttpPost]
        public async Task<JsonResult> apply(Application application)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    application.ID = 0;
                    application.uid = Guid.NewGuid().ToString();
                    _unitofWork.Application.Add(application);
                    _unitofWork.Save();
                    Int64 applicationId = application.ID;
                    Byte[] file = await GenerateApplicationPDF(application);
                    TempData["success"] = "Tenancy application successfully submitted !";
                }
                else
                {
                    TempData["error"] = "Error submitting application !";
                }
                return new JsonResult("success");
                //return RedirectToAction("applications", new { UserId = HttpContext.Session.GetString("_UserId") });
            }
            catch (Exception ex)
            {
                LogErrorDetail(ex, "tenant/apply");
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json("error sending condition report to tenant dashboard");
            }
        }
        [Authorize(Roles = WebSiteRoles.Role_Tenant + "," + WebSiteRoles.Role_Admin + "," + WebSiteRoles.Role_Landlord)]
        [HttpGet]
        public IActionResult apply(Int64 id)
        {
            try
            {
                var userId = HttpContext.Session.GetString("_UserId");
                bool alreadyApplied = false;
                var pastApplication = _unitofWork.Application.
                    Get(a => a.UserID == userId && a.PropertyID == id);
                if (pastApplication != null)
                    alreadyApplied = true;
                Application application = new Application();
                application.PropertyID = id;
                application.ApplicantID = GetApplicantID();
                application.UserID = userId;
                ViewBag.AlreadyApplied = alreadyApplied;                
                return View(application);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        private long GetApplicantID()
        {
            try
            {
                string _userId = HttpContext.Session.GetString("_UserId");
                Applicant applicant = _unitofWork.Applicant.Get(x => x.UserID == _userId);
                Int64 _applicantId = applicant.ID;
                return _applicantId;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet]
        public IActionResult applications(string UserId)
        {
            try
            {
                List<Application> applications = _unitofWork.Application.GetAll(x => x.UserID == UserId
                && x.isaddedbyLandlord==false,includeProperties: "User,Property,Applicant").ToList();
                return View(applications);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }

        }
        public async Task<IActionResult> index()
        {
            try
            {
                string userId = HttpContext.Session.GetString("_UserId");
                bool applicantprofileExists = CheckProfile(userId);
                ViewBag.profileExists = applicantprofileExists;

                LeaseTenant leaseTenant = _unitofWork.LeaseTenant
                    .Get(x => x.UserId == userId
                    && (x.Lease.LeaseStatus == LeaseAgreement.status.Active ||
                    x.Lease.LeaseStatus == LeaseAgreement.status.Created),
                    includeProperties: "Lease,Tenant");
                LeaseAgreement leaseAgreement = null;
                if (leaseTenant != null)
                {
                    leaseAgreement = _unitofWork.LeaseAgreement
                       .Get(x => x.ID == leaseTenant.LeaseID,
                       includeProperties: "Property,PrimaryTenant");

                    var property = _unitofWork.Property.Get(x => x.ID == leaseAgreement.PropertyID);
                    var newConditionReportCount = _unitofWork.ConditionReport
                         .GetAll(cr => cr.LeaseAgreementID == leaseAgreement.ID
                         && cr.Sent2Tenant == true && cr.SignedByTenant == false)
                         .Count();

                    var newbills = _unitofWork.TenantBill.GetAll(b => b.IsPaidByTenant == false &&
                    b.BillTenantNow == true).Count();
                    ViewData["bills"] = newbills;
                    ViewData["conditionReportCount"] = newConditionReportCount;
                    HttpContext.Session.SetString("PropertyId", leaseAgreement.PropertyID.ToString());
                    HttpContext.Session.SetString("LandlordId", property.OwnerId);
                    HttpContext.Session.SetString("LandlordName", property.OwnerName);
                }
                return View(leaseAgreement);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        [HttpGet]
        public IActionResult viewprofile() //for testing pdf view
        {
            try
            {
                string userId = HttpContext.Session.GetString("_UserId");
                Applicant applicant = _unitofWork.Applicant.Get(x => x.UserID == userId,
                    includeProperties: "Dependents,Documents,Employers,History,Pets," +
                    "References,Vehicles,AdditionalIncome");
                ApplicationVm applicationVm = new ApplicationVm
                {
                    Applicant = applicant,
                    Application = _unitofWork.Application.Get(a => a.ID == 20013),//for testing
                };
                return View(applicationVm);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }

        }
        private async Task<Byte[]> GenerateApplicationPDF(Application application)
        {
            try
            {
                string userId = HttpContext.Session.GetString("_UserId");
                Applicant applicant = _unitofWork.Applicant.Get(x => x.UserID == userId,
                    includeProperties: "Dependents,Documents,Employers,History," +
                    "Pets,References,Vehicles,AdditionalIncome");
                ApplicationVm applicationVm = new ApplicationVm
                {
                    Applicant = applicant,
                    Application = application
                };
                string htmlforPdf = await _utility.RenderViewToStringAsync("viewprofile", applicationVm, ControllerContext);
                string filename = _utility.GenerateFileName("Application.pdf", @"assets/pdfdocs/applications");
                string filename_Path = @"wwwroot/assets/pdfdocs/applications/" + filename;
                Byte[] file = _utility.GeneratePdfByiText7(htmlforPdf, filename_Path);
                await SaveDocumentRecord(application.ID, applicant.ID, @"/assets/pdfdocs/applications/" + filename, 4);
                return file;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private async Task SaveDocumentRecord(Int64 applicationId, Int64 applicantId, string filepath, Int64 docTypeID)
        {
            try
            {
                ApplicantDocument document = new ApplicantDocument
                {
                    ApplicantID = applicantId,
                    uid = Guid.NewGuid().ToString(),
                    ApplicationID = applicationId,
                    DocumentTypeID = docTypeID,
                    DocumentPath = filepath,
                    CreatedbyUserId = HttpContext.Session.GetString("_UserId"),
                    CreatedOn = DateTime.Now,
                };
                _unitofWork.ApplicantDocument.Add(document);
                _unitofWork.Save();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpGet]
        public IActionResult propertiesviewed()
        {
            try
            {
                string userid = HttpContext.Session.GetString("_UserId");
                bool applicantprofileExists = CheckProfile(userid);
                ViewBag.profileExists = applicantprofileExists;
                List<PropertiesViewed> propertiesViewed = _unitofWork.PropertiesViewed.
                    GetAll(x => x.UserID == userid && x.IsFavourite==true,
                    includeProperties: "Property,User").ToList();
                return View(propertiesViewed);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }

        }

        private bool CheckProfile(string userid)
        {
            try
            {
                Applicant applicant = _unitofWork.Applicant.Get(x => x.UserID == userid);
                if (applicant != null)
                    _unitofWork.Applicant.Detach(applicant);
                if (applicant != null)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public JsonResult GetCities(int stateid)
        {
            List<City> states = null;
            try
            {
                states = _unitofWork.City.GetAll(c => c.StateID == stateid).OrderBy(c => c.Name).ToList();

            }
            catch (Exception ex)
            {
                LogErrorDetail(ex, "GetCities");
            }
            return new JsonResult(states);
        }
        private Applicant InitializeApplicant()
        {
            try
            {
                string userId = HttpContext.Session.GetString("_UserId");
                Applicant applicant = new Applicant();
                bool profileExists = CheckProfile(userId);
                if (!profileExists)
                {
                    ApplicationUser _user = _userManager.Users
                        .Where(_u => _u.Id == userId).FirstOrDefault();
                    applicant = new Applicant
                    {
                        UserID = _user.Id,
                        FirstName = _user.Name,
                        LastName = _user.SurName,
                        Email = _user.Email,
                        Mobile = _user.Mobile,
                        Gender = Convert.ToString(_user.Gender),
                    };
                }
                else
                {
                    applicant = _unitofWork.Applicant.Get(x => x.UserID == userId);
                }

                return applicant;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPost]
        public IActionResult deletedocument(ApplicantDocument applicantDocument)
        {
            try
            {
                if (applicantDocument.ID != null && applicantDocument.ID > 0)
                {
                    _utility.DeletFile(applicantDocument.DocumentPath);
                    _unitofWork.ApplicantDocument.Delete(applicantDocument);
                    _unitofWork.Save();
                    TempData["success"] = "Record successfully deleted !";
                }
                else
                {
                    TempData["error"] = "Problem deleting record !";
                }
                return RedirectToAction("profile");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        [HttpGet]
        public IActionResult deletedocument(Int64 ID)
        {
            try
            {
                ApplicantDocument applicantDocument = _unitofWork.ApplicantDocument.Get(x => x.ID == ID, includeProperties: "DocumentType");
                return View(applicantDocument);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }

        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult deletedependent(ApplicantDependent applicantDependent)
        {
            try
            {
                if (applicantDependent.ID != null && applicantDependent.ID > 0)
                {
                    _unitofWork.ApplicantDependent.Delete(applicantDependent);
                    _unitofWork.Save();
                    TempData["success"] = "Applicant dependent successfully deleted !";
                }
                else
                {
                    TempData["error"] = "Problem deleting record !";
                }
                return RedirectToAction("profile");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }

        }
        [HttpGet]
        public IActionResult deletedependent(Int64 id)
        {
            try
            {
                ApplicantDependent applicantDependent = _unitofWork.ApplicantDependent.Get(x => x.ID == id);
                return View(applicantDependent);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        [HttpGet]
        public IActionResult deletepet(Int64 id)
        {
            try
            {
                ApplicantPet applicantPet = _unitofWork.ApplicantPet.Get(x => x.ID == id);
                return View(applicantPet);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }

        }
        [HttpGet]
        public IActionResult deletevehicle(Int64 id)
        {
            try
            {
                ApplicantVehicle applicantVehicle = _unitofWork.ApplicantVehicle.Get(x => x.ID == id);
                return View(applicantVehicle);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }

        }

        [HttpGet]
        public IActionResult deleteemployer(Int64 id)
        {
            try
            {
                ApplicantEmployer applicantEmployer = _unitofWork.ApplicantEmployer.Get(x => x.ID == id);
                return View(applicantEmployer);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }

        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult deleteemployer(ApplicantEmployer applicantEmployer)
        {
            try
            {
                if (applicantEmployer.ID != null && applicantEmployer.ID > 0)
                {
                    _unitofWork.ApplicantEmployer.Delete(applicantEmployer);
                    _unitofWork.Save();
                    TempData["success"] = "Record successfully deleted !";
                }
                else
                {
                    TempData["error"] = "Problem deleting record !";
                }
                return RedirectToAction("profile");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }

        }
        [HttpGet]
        public IActionResult deletereference(Int64 id)
        {
            try
            {
                ApplicantReference applicantReference = _unitofWork.ApplicantReference.Get(x => x.ID == id);
                return View(applicantReference);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }

        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult deletereference(ApplicantReference applicantReference)
        {
            try
            {
                if (applicantReference.ID != null && applicantReference.ID > 0)
                {
                    _unitofWork.ApplicantReference.Delete(applicantReference);
                    _unitofWork.Save();
                    TempData["success"] = "Record successfully deleted !";
                }
                else
                {
                    TempData["error"] = "Problem deleting record !";
                }
                return RedirectToAction("profile");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        [HttpGet]
        public IActionResult deleteresidentialhistory(Int64 id)
        {
            try
            {
                ApplicantHistory applicantHistory = _unitofWork.ApplicantHistory.Get(x => x.ID == id);
                return View(applicantHistory);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult deleteresidentialhistory(ApplicantHistory applicantHistory)
        {
            try
            {
                if (applicantHistory.ID != null && applicantHistory.ID > 0)
                {
                    _unitofWork.ApplicantHistory.Delete(applicantHistory);
                    _unitofWork.Save();
                    TempData["success"] = "Record successfully deleted !";
                }
                else
                {
                    TempData["error"] = "Problem deleting record !";
                }
                return RedirectToAction("profile");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }

        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult deletevehicle(ApplicantVehicle applicantVehicle)
        {
            try
            {
                if (applicantVehicle.ID != null && applicantVehicle.ID > 0)
                {
                    _unitofWork.ApplicantVehicle.Delete(applicantVehicle);
                    _unitofWork.Save();
                    TempData["success"] = "Record successfully deleted !";
                }
                else
                {
                    TempData["error"] = "Problem deleting record !";
                }
                return RedirectToAction("profile");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }

        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult deletepet(ApplicantPet applicantPet)
        {
            try
            {
                if (applicantPet.ID != null && applicantPet.ID > 0)
                {
                    _unitofWork.ApplicantPet.Delete(applicantPet);
                    _unitofWork.Save();
                    TempData["success"] = "Record successfully deleted !";
                }
                else
                {
                    TempData["error"] = "Problem deleting record !";
                }
                return RedirectToAction("profile");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }

        //[Authorize(Roles = WebSiteRoles.Role_Admin + "," + WebSiteRoles.Role_Landlord + "," + WebSiteRoles.Role_Tenant)]
        public IActionResult profile()
        {
            try
            {
                string userid = HttpContext.Session.GetString("_UserId");
                vmTenancyApplication vmTA = new vmTenancyApplication();
                vmTA.Applicant = InitializeApplicant();
                List<ApplicantVehicle> av = null;

                if (vmTA.Applicant.ID > 0)
                    av = _unitofWork.ApplicantVehicle
                        .GetAll(x => x.ApplicantID == vmTA.Applicant.ID)
                        .ToList();
                //else
                //    av = new List<ApplicantVehicle> { new ApplicantVehicle { ID = 1 } };
                vmTA.ApplicantVehicles = av;

                List<ApplicantDependent> ad = null;
                if (vmTA.Applicant.ID > 0)
                    ad = _unitofWork.ApplicantDependent
                        .GetAll(x => x.ApplicantID == vmTA.Applicant.ID).ToList();
                //else
                //    ad = new List<ApplicantDependent> { new ApplicantDependent { ID = 1, FirstName = "NA", LastName = "NA", Age = null, Relationship = "NA", IsLivingWithYou = "Yes", IsReceivingChildSupport = "No" } };
                vmTA.ApplicantDependents = ad;

                List<ApplicantPet> ap = null;
                if (vmTA.Applicant.ID > 0)
                    ap = _unitofWork.ApplicantPet
                        .GetAll(x => x.ApplicantID == vmTA.Applicant.ID).ToList();
                ////else
                ////    ap = new List<ApplicantPet> { new ApplicantPet { ID = 1 } };
                vmTA.ApplicantPets = ap;

                List<ApplicantHistory> ah = null;
                if (vmTA.Applicant.ID > 0)
                    ah = _unitofWork.ApplicantHistory
                        .GetAll(x => x.ApplicantID == vmTA.Applicant.ID).ToList();
                //else
                //    ah = new List<ApplicantHistory> { new ApplicantHistory { ID = 1 } };
                vmTA.ApplicantHistory = ah;

                List<ApplicantReference> ar = null;
                if (vmTA.Applicant.ID > 0)
                    ar = _unitofWork.ApplicantReference.GetAll(x => x.ApplicantID == vmTA.Applicant.ID).ToList();
                //else
                //    ar = new List<ApplicantReference> { new ApplicantReference { ID = 1 } };
                vmTA.ApplicantReference = ar;

                List<ApplicantEmployer> ae = null;
                if (vmTA.Applicant.ID > 0)
                    ae = _unitofWork.ApplicantEmployer.GetAll(x => x.ApplicantID == vmTA.Applicant.ID).ToList();
                //else
                //    ae = new List<ApplicantEmployer> { new ApplicantEmployer { ID = 1 } };
                vmTA.ApplicantEmployer = ae;

                List<ApplicantDocument> adoc = _unitofWork.ApplicantDocument.GetAll(x => x.ApplicantID == vmTA.Applicant.ID && x.DocumentTypeID != 22, includeProperties: "DocumentType").ToList();
                vmTA.ApplicantDocument = adoc;
                List<ApplicantDocType> applicantDocType = _unitofWork.ApplicantDocType.GetAll().ToList();
                List<Int64> remainingDocIDs = applicantDocType.Select(x => x.ID).Except(adoc.Select(y => y.DocumentTypeID)).ToList();
                applicantDocType = applicantDocType.Where(x => remainingDocIDs.Contains(x.ID)).ToList();
                applicantDocType = applicantDocType.Where(x => x.ID != 22).ToList();
                vmTA.ApplicantDocType = applicantDocType;
                return View("profile", vmTA);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        [HttpPost]
        public IActionResult profile(vmTenancyApplication profile)
        {
            try
            {
                string userId = HttpContext.Session.GetString("_UserId");
                if (userId != null && ModelState.IsValid)
                {
                    bool profileExists = CheckProfile(userId);
                    if (!profileExists)
                    {
                        profile.Applicant.uid = Guid.NewGuid().ToString();
                        _unitofWork.Applicant.Add(profile.Applicant);
                    }
                    else
                        _unitofWork.Applicant.update(profile.Applicant);
                    _unitofWork.Save();
                    Int64 intApplicantID = profile.Applicant.ID;

                    if (profile.ApplicantDependents != null)
                    {
                        profile.ApplicantDependents.ToList().ForEach(d =>
                        {
                            if (d.FirstName == String.Empty)
                                profile.ApplicantDependents.Remove(d);
                            else
                                d.ApplicantID = intApplicantID;

                            if (d.uid == String.Empty || d.uid == null)
                            {
                                d.uid = Guid.NewGuid().ToString();
                                d.CreatedbyUserId = userId;
                            }
                            else
                            {
                                d.UpdatedOn = DateTime.UtcNow;
                                d.UpdatedbyUserId = userId;
                            }
                        });
                        if (profile.ApplicantDependents.Count() > 0)
                        {
                            _unitofWork.ApplicantDependent.UpdateRange(profile.ApplicantDependents);
                            _unitofWork.Save();
                        }
                    }
                    if (profile.ApplicantEmployer != null)
                    {
                        profile.ApplicantEmployer.ToList().ForEach(e =>
                        {
                            if (e.EmployerName == String.Empty)
                                profile.ApplicantEmployer.Remove(e);
                            else
                                e.ApplicantID = intApplicantID;
                            if (e.uid == String.Empty || e.uid == null)
                            {
                                e.uid = Guid.NewGuid().ToString();
                                e.CreatedbyUserId = userId;
                            }
                            else
                            {
                                e.UpdatedOn = DateTime.UtcNow;
                                e.UpdatedbyUserId = userId;
                            }
                        });
                        if (profile.ApplicantEmployer.Count() > 0)
                        {
                            _unitofWork.ApplicantEmployer.UpdateRange(profile.ApplicantEmployer);
                            _unitofWork.Save();
                        }
                    }
                    if (profile.ApplicantHistory != null)
                    {
                        profile.ApplicantHistory.ToList().ForEach(h =>
                        {
                            if (h.Address == String.Empty)
                                profile.ApplicantHistory.Remove(h);
                            else
                                h.ApplicantID = intApplicantID;
                            if (h.uid == String.Empty || h.uid == null)
                            {
                                h.uid = Guid.NewGuid().ToString();
                                h.CreatedbyUserId = userId;
                            }
                            else
                            {
                                h.UpdatedOn = DateTime.UtcNow;
                                h.UpdatedbyUserId = userId;
                            }
                        });
                        if (profile.ApplicantHistory.Count() > 0)
                        {
                            _unitofWork.ApplicantHistory.UpdateRange(profile.ApplicantHistory);
                            _unitofWork.Save();
                        }
                    }
                    if (profile.ApplicantVehicles != null)
                    {
                        profile.ApplicantVehicles.ToList().ForEach(v =>
                        {
                            if (v.Make == String.Empty)
                                profile.ApplicantVehicles.Remove(v);
                            else
                                v.ApplicantID = intApplicantID;
                            if (v.uid == String.Empty || v.uid == null)
                            {
                                v.uid = Guid.NewGuid().ToString();
                                v.CreatedbyUserId = userId;
                            }
                            else
                            {
                                v.UpdatedOn = DateTime.UtcNow;
                                v.UpdatedbyUserId = userId;
                            }
                        });
                        if (profile.ApplicantVehicles.Count() > 0)
                        {
                            _unitofWork.ApplicantVehicle.UpdateRange(profile.ApplicantVehicles);
                            _unitofWork.Save();
                        }
                    }
                    if (profile.ApplicantPets != null)
                    {
                        profile.ApplicantPets.ToList().ForEach(p =>
                        {
                            if (p.Name == String.Empty)
                                profile.ApplicantPets.Remove(p);
                            else
                                p.ApplicantID = intApplicantID;
                            if (p.Petpic != null)
                            {
                                if (p.Petpic.Length <= 100000)
                                    p.PicturePath = _utility.SaveFile(p.Petpic, "assets/ApplicantDocuments");
                                else
                                    p.PicturePath = _utility.ResizeAndSaveImage(p.Petpic, "assets/ApplicantDocuments", 100000, 300, 300);
                            }
                            if (p.uid == String.Empty || p.uid == null)
                            {
                                p.uid = Guid.NewGuid().ToString();
                                p.CreatedbyUserId = userId;
                            }
                            else
                            {
                                p.UpdatedOn = DateTime.UtcNow;
                                p.UpdatedbyUserId = userId;
                            }
                        });
                        if (profile.ApplicantPets.Count() > 0)
                        {
                            _unitofWork.ApplicantPet.UpdateRange(profile.ApplicantPets);
                            _unitofWork.Save();
                        }
                    }
                    if (profile.ApplicantReference != null)
                    {
                        profile.ApplicantReference.ToList().ForEach(r =>
                        {
                            if (r.FirstName == String.Empty)
                                profile.ApplicantReference.Remove(r);
                            else
                                r.ApplicantID = intApplicantID;

                            if (r.uid == String.Empty || r.uid == null)
                            {
                                r.uid = Guid.NewGuid().ToString();
                                r.CreatedbyUserId = userId;
                            }
                            else
                            {
                                r.UpdatedOn = DateTime.UtcNow;
                                r.UpdatedbyUserId = userId;
                            }
                        });
                        if (profile.ApplicantReference.Count() > 0)
                        {
                            _unitofWork.ApplicantReference.UpdateRange(profile.ApplicantReference);
                            _unitofWork.Save();
                        }
                    }
                    List<ApplicantDocType> selectedDocs = profile.ApplicantDocType.FindAll(x => x.isSelected == true);

                    List<ApplicantDocument> applicantDocs = new List<ApplicantDocument>();
                    selectedDocs.ForEach(sd =>
                    applicantDocs.Add(new ApplicantDocument
                    {
                        ApplicantID = intApplicantID,
                        uid = Guid.NewGuid().ToString(),
                        DocumentTypeID = sd.ID,
                        DocumentPath = _utility.SaveFile(sd.Document, @"assets/ApplicantDocuments"),
                        CreatedOn = DateTime.UtcNow,
                        CreatedbyUserId = userId
                    }));
                    if (applicantDocs.Count() > 0)
                        _unitofWork.ApplicantDocument.UpdateRange(applicantDocs);
                    _unitofWork.Save();
                    TempData["success"] = "Your profile for tenancy has been successfully saved !";
                }
                else
                {
                    TempData["error"] = "Error occured saving your profile";
                    Redirect("/Identity/Account/Manage/login");
                }
                return Redirect("/tenant/propertiesviewed");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
    }
}
