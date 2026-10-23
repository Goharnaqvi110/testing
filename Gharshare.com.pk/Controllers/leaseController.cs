using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using Gharshare.CommonHelper;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using IronPdf;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Encodings.Web;
using System.Text;
using System.Net;
using SixLabors.ImageSharp.PixelFormats;
using MailKit.Search;
using System.Reflection;
using System.Web.Helpers;
using ServiceStack;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Gharshare.com.pk.Controllers
{
    public class leaseController : Controller
    {
        private IUnitofWork _unitofWork;
        private Utility _utility;
        private readonly EmailSender _emailSender1;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IEmailSender _emailSender;
        public leaseController(IUnitofWork iUnitofWork, Utility utility,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore, IEmailSender emailSender,
            EmailSender emailSender1)
        {
            _unitofWork = iUnitofWork;
            _utility = utility;
            _userManager = userManager;
            _emailStore = GetEmailStore();
            _emailSender1 = emailSender1;
            _emailSender = emailSender;
        }
        public JsonResult renewLease(LeaseAgreement lease)
        {
            try
            {
                if (lease != null)
                {
                    var leaseDb = _unitofWork.LeaseAgreement.Get(la =>
                    la.ID == lease.ID);
                    leaseDb.From = lease.From;
                    leaseDb.To = lease.To;
                    leaseDb.WeeklyRent = lease.WeeklyRent;
                    leaseDb.PeriodicRent = lease.PeriodicRent;
                    leaseDb.MonthlyRent = lease.MonthlyRent;
                    leaseDb.IsPeriodicAgreement = lease.IsPeriodicAgreement;
                    leaseDb.UpdatedbyUserId = HttpContext.Session.GetString("_UserId");
                    leaseDb.UpdatedOn = DateTime.Now;
                    leaseDb.SignedByLandlord = false; ;
                    leaseDb.SignedByTenant = false;
                    leaseDb.LandlordSign = null;
                    leaseDb.TenantlordSign = null;
                    leaseDb.Sent2Tenant = true;
                    _unitofWork.LeaseAgreement.update(leaseDb);
                    _unitofWork.Save();
                    if (lease.sendupdatedlease)
                    {
                        CreateSendNewPDFLease(leaseDb.ID, leaseDb.PropertyID);
                    }

                }
            }
            catch (Exception exp)
            {

            }
            return Json("success");
        }

        private async void CreateSendNewPDFLease(Int64 leaseId, Int64 propId)
        {
            Byte[] file = null;
            try
            {
                #region Generate new PDF of lease agreement                 
                Property property;
                var lease = _unitofWork.LeaseAgreement.Get(l => l.ID == leaseId, includeProperties:
                    "PrimaryTenant,");
                LeaseViewVM leaseView = new LeaseViewVM
                {
                    Property = _unitofWork.Property.Get(x => x.ID == propId, includeProperties: "Owner,Applications,State,City"),
                    PrimaryTenant = lease.PrimaryTenant,
                    AdditionalTenants = _unitofWork.LeaseTenant.GetAll(x => x.LeaseID ==
                    leaseId && x.isPrimaryTenant == false, includeProperties: "Tenant").ToList(),
                    leaseAgreement = lease
                };
                string html = null;
                string filename = null;
                try
                {
                    html = await _utility.RenderViewToStringAsync("leasePdf", leaseView, ControllerContext);
                    filename = _utility.GenerateFileName("leaseagreement.pdf", @"assets/pdfdocs/lease");
                    string filePath = @"wwwroot/assets/pdfdocs/lease/" + filename;
                    file = _utility.GeneratePdfByiText7(html, filePath);
                    SendLeaseAgreement2Tenants(leaseView, file);

                }

                catch (Exception exp)
                {
                    LogErrorDetail(exp, "lease/createlease/GeneratePdfByiText7");
                    Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    // return Json("error occured generating pdf of lease agreement.");
                }
                #endregion

                #region update documents with new lease agreement pdf                
                var doc = _unitofWork.Document.Get(d => d.LeaseAgreementID == leaseId &&
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
                #endregion
            }
            catch (Exception exp)
            {

            }
        }
        public IActionResult loadlease2renew(Int64 leaseId)
        {
            LeaseAgreement lease = null;
            try
            {
                lease = _unitofWork.LeaseAgreement.Get(l => l.ID == leaseId,
                    "Property");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
            return View(lease);
        }
        public async Task<IActionResult> list()
        {
            List<LeaseAgreement> leaseAgreements = null;
            try
            {
                leaseAgreements = LeaseList();
                #region apply paging on properties
                int pageSize = Pager.GetPageSize();
                var currentPage = 1;
                int recsCount = leaseAgreements.Count();
                int recSkip = (currentPage - 1) * pageSize;
                leaseAgreements = leaseAgreements.Skip(recSkip).Take(pageSize).ToList();
                var pager = new Pager(recsCount, currentPage, "", "", pageSize, "", "", leaseAgreements.Count(),
                    "getLeases", 1);
                ViewBag.Pager = pager;
                #endregion
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
            return View(leaseAgreements);
        }
        private List<LeaseAgreement> LeaseList()
        {
            var userId = HttpContext.Session.GetString("_UserId");
            var leaseAgreements = _unitofWork.LeaseAgreement.GetAll(la => la.Property.Owner.Id == userId,
                includeProperties: "Property,PrimaryTenant").ToList();
            return leaseAgreements;
        }
        public JsonResult GetLeaseList(int currentPage, string searchText, int? sortOrderNo = 1)
        {
            var leases = LeaseList();
            #region apply paging on properties
            int pageSize = Pager.GetPageSize();
            if (currentPage < 1)
                currentPage = 1;
            int recsCount = leases.Count();
            int recSkip = (currentPage - 1) * pageSize;
            leases = leases.Skip(recSkip).Take(pageSize).ToList();
            var pager = new Pager(recsCount, currentPage, "", "", pageSize, searchText, "", leases.Count(),
                "getLeases", (int)sortOrderNo);
            ViewBag.Pager = pager;
            #endregion
            // Create a new list to hold the transformed documents
            List<object> transformedLeaseList = new List<object>();

            //// Loop through each document and transform it
            foreach (var lease in leases)
            {
                var Lease = new
                {
                    ID = lease.ID,
                    UID = lease.uid,
                    Address = lease.Property.Address,
                    TenantName = lease.PrimaryTenant.FirstName,
                    TenantEmail = lease.PrimaryTenant.Email,
                    Mobile = lease.PrimaryTenant.Mobile,
                    From = lease.From,
                    To = lease.To,
                    LeaseStatus = lease.LeaseStatus,
                    AgreementType = lease.AgreementType,
                    CreatedOn = lease.CreatedOn,
                };
                transformedLeaseList.Add(Lease);
            }
            // Create a JSON object to hold the transformed documents and any other required data
            var result = new
            {
                Leases = transformedLeaseList,
                Pager = pager,
            };

            // Return the JSON result
            return new JsonResult(result);
        }
        [HttpPost]
        public async Task<JsonResult> signLease(LeaseAgreement leaseAgreement)
        {
            try
            {
                #region save tenant sig & update lease
                var lease = _unitofWork.LeaseAgreement.Get(la => la.ID == leaseAgreement.ID,
                    includeProperties: "PrimaryTenant");
                lease.landlordagree2sign = leaseAgreement.landlordagree2sign;
                lease.LandlordSign = Convert.FromBase64String(leaseAgreement.LandlorsigData);
                lease.SignedByLandlord = true;
                lease.LandlordSignedOn = leaseAgreement.LandlordSignedOn;
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
                    LogErrorDetail(exp, "lease/signLease/GeneratePdfByiText7");
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
                    LogErrorDetail(exp, "lease/signlease/GeneratePdfByiText7");
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
        public async Task<IActionResult> testleasepdf()
        {
            LeaseViewVM leaseView = new LeaseViewVM
            {
                Property = _unitofWork.Property.Get(x => x.ID == 17,
                includeProperties: "Owner,Applications,State,City"),
                PrimaryTenant = _unitofWork.Applicant.Get(a => a.ID == 63),
                AdditionalTenants = _unitofWork.LeaseTenant.GetAll(x => x.LeaseID == 11
                && x.isPrimaryTenant == false, includeProperties: "Tenant").ToList(),
                leaseAgreement = _unitofWork.LeaseAgreement.Get(la => la.ID == 11)
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
        public IActionResult download(string uid)
        {
            byte[] bytes;
            try
            {
                var lease = _unitofWork.LeaseAgreement.Get(la => la.uid == uid);
                Document LeasePdfDoc = _unitofWork.Document.Get(x => x.LeaseAgreementID == lease.ID
                && x.DocumentTypeID == 2);
                string filepath = _utility.GetRootPath() + LeasePdfDoc.FilePath;
                FileStream fs = new System.IO.FileStream(filepath, FileMode.Open, FileAccess.Read);
                bytes = _utility.ReadStream(fs);
                Response.Headers.Add("Content-Disposition", "attachment ;filename=LeaseAgreement.pdf");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
            return File(bytes, "text /plain", "LeaseAgreement.pdf");
        }
        private async Task<Byte[]> GeneratePDF(LeaseViewVM lease)
        {
            bool errorOccurred = false;
            Byte[] file = null;
            try
            {
                string htmlforPdf = await _utility.RenderViewToStringAsync("lease", lease, ControllerContext);
                var Renderer = new ChromePdfRenderer();
                Renderer.RenderingOptions.CreatePdfFormsFromHtml = true;
                var PDF = Renderer.RenderHtmlAsPdf(htmlforPdf);
                string filename = _utility.GenerateFileName("lease.pdf", @"wwwroot/assets/pdfdocs");
                string filenamewithPath = @"wwwroot/assets/pdfdocs/" + filename;
                PDF.SaveAs(filenamewithPath);
                file = PDF.BinaryData;
                await SaveDocumentRecord(lease.leaseAgreement.ID, lease.Property.ID, @"/assets/pdfdocs/" + filename, 2, "Lease agreement");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                errorOccurred = true;
            }
            if (errorOccurred)
                return null;
            else
                return file;
        }
        private async Task<IActionResult> SaveDocumentRecord(Int64 leaseId, Int64 propertyId, string filepath, Int64 docTypeID, string docName)
        {
            Document document;
            try
            {
                document = new Document
                {
                    uid = Guid.NewGuid().ToString(),
                    DocumentTypeID = docTypeID,
                    LeaseAgreementID = leaseId,
                    PropertyID = propertyId,
                    Name = docName,
                    FilePath = filepath,
                    CreatedbyUserID = HttpContext.Session.GetString("_UserId"),
                    FileType = "1",
                    CreatedOn = DateTime.Now,
                };
                _unitofWork.Document.Add(document);
                _unitofWork.Save();
            }
            catch (Exception exp)
            {
                LogErrorDetail(exp, "lease/createlease/SaveDocumentRecord");
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json("error occured saving lease pdf document record.");
            }
            return null;
        }
        private async Task<IActionResult> SaveLeaseTenantsRecord(LeaseVM leaseVM)
        {
            try
            {
                var loggedInUser = HttpContext.Session.GetString("_UserId");
                if (leaseVM.PrimaryTenant.ID == 0) //Primary tenant is selected from applicants for tenancy
                {

                    LeaseTenant leasePrimaryTenant = new LeaseTenant
                    {
                        LeaseID = leaseVM.leaseAgreement.ID,
                        uid = Guid.NewGuid().ToString(),
                        TenantID = leaseVM.leaseAgreement.PrimaryTenantID,
                        UserId = _unitofWork.Application
                        .Get(x => x.ApplicantID == leaseVM.leaseAgreement.PrimaryTenantID).UserID,
                        CreatedbyUserId = loggedInUser,
                        isPrimaryTenant = true
                    };
                    _unitofWork.LeaseTenant.Add(leasePrimaryTenant);
                }
                else // Primary tenant has been created by landlord
                {
                    LeaseTenant leasePrimaryTenant = new LeaseTenant
                    {
                        LeaseID = leaseVM.leaseAgreement.ID,
                        uid = Guid.NewGuid().ToString(),
                        TenantID = leaseVM.PrimaryTenant.ID,
                        UserId = leaseVM.PrimaryTenant.UserID,
                        CreatedbyUserId = loggedInUser,
                        isPrimaryTenant = true
                    };
                    _unitofWork.LeaseTenant.Add(leasePrimaryTenant);//add primary tenant to lease-tenant junction table.
                }
                if (leaseVM.AddtionalTenants != null) // if additional tenants exist, add them in lease-tenant junction table.
                {
                    leaseVM.AddtionalTenants.ForEach(x =>
                    {
                        LeaseTenant leaseAddtionalTenant = new LeaseTenant
                        {
                            LeaseID = leaseVM.leaseAgreement.ID,
                            TenantID = x.ID,
                            uid = Guid.NewGuid().ToString(),
                            UserId = x.UserID,
                            CreatedbyUserId = loggedInUser,
                            isPrimaryTenant = false
                        };
                        _unitofWork.LeaseTenant.Add(leaseAddtionalTenant);
                    }
                    );
                }
                _unitofWork.Save();
            }
            catch (Exception exp)
            {
                LogErrorDetail(exp, "lease/SaveLeaseTenantsRecord");
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json("error occured saving lease tenant record");
            }
            return RedirectToAction("list");
        }
        private async Task<ApplicationUser> CreateUser(Applicant? Tenant)
        {
            MailAddress address = null;
            if (Tenant.Email != null)
                address = new MailAddress(Tenant.Email);
            string userName = address.User;
            var user = CreateUser();
            if (user != null)
            {
                user.UserName = userName;
                user.Name = Tenant.FirstName;
                user.Address = Tenant.CurrentAddress;
                user.PostalCode = Tenant.PostCode;
                user.UserType = ApplicationUser.usertype.tenant;
                user.Email = Tenant.Email;
                try
                {
                    var result = await _userManager.CreateAsync(user, "Hum@12345");
                    if (result.Succeeded)
                    {
                        _userManager.AddToRoleAsync(user, WebSiteRoles.Role_Tenant).GetAwaiter().GetResult();                         
                    }
                    else
                    {
                        string errorMessage = "User creation failed.";
                        foreach (var error in result.Errors)
                        {
                            errorMessage += $" {error.Description}";
                        }
                        throw new Exception(errorMessage);
                    }
                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var returnUrl = "/";
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = $"{Request.Scheme}://{Request.Host}/confirmemail?userId={userId}&code={code}&returnUrl={WebUtility.UrlEncode(returnUrl)}";

                    await _emailSender1.SendEmailAsync(Tenant.Email, "Confirm your account",
                        $"Your user account has been created at smartpropertymanager.pk.<br>User name:{Tenant.Email}<br>Password:Hum@12345 <br>You can always rest your password by logging in to the application. <br>Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = ex.Message;
                    TempData["StackTrace"] = ex.StackTrace;
                    TempData["Source"] = ex.Source;
                    throw;
                }
                return user;
            }
            else
                return null;
        }
        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
                    $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }
        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }
        [HttpPost]
        public async Task<IActionResult> sendlease2Tenant(Int64 ID)
        {
            try
            {
                Property property;
                LeaseAgreement lease = _unitofWork.LeaseAgreement.Get(x => x.ID == ID,
                    includeProperties: "Property.Owner,PrimaryTenant");
                LeaseViewVM leaseView = new LeaseViewVM
                {
                    Property = _unitofWork.Property.Get(x => x.ID == lease.PropertyID,
                    includeProperties: "Owner,Applications,State,City"),
                    PrimaryTenant = lease.PrimaryTenant,
                    AdditionalTenants = _unitofWork.LeaseTenant.GetAll(x => x.LeaseID == lease.ID
                    && x.isPrimaryTenant == false, includeProperties: "Tenant").ToList(),
                    leaseAgreement = lease
                };
                var leaseDoc = _unitofWork.Document.Get(d => d.LeaseAgreementID == lease.ID
                && d.DocumentTypeID == 2);
                var docByteArray = _utility.getDocumentByteArray(leaseDoc.FilePath);
                //await SendLeaseAgreement2Tenants(leaseView, docByteArray);
                lease.Sent2Tenant = true;
                _unitofWork.LeaseAgreement.update(lease);
                _unitofWork.Save();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
            return Json("success");
        }
        [HttpGet]
        public IActionResult send(Int64 ID)
        {
            try
            {
                LeaseAgreement leaseAgreement = _unitofWork.LeaseAgreement.Get(x => x.ID == ID,
                    includeProperties: "Property.Owner,PrimaryTenant");
                LeaseViewVM leaseViewVM = new LeaseViewVM
                {
                    leaseAgreement = leaseAgreement,
                    LeasePdfDoc = _unitofWork.Document.Get(x => x.LeaseAgreementID == leaseAgreement.ID && x.DocumentTypeID == 2)
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
        public async Task<IActionResult> viewleasedoc(string uid)
        {
            try
            {
                LeaseAgreement leaseAgreement = _unitofWork.LeaseAgreement.Get(x => x.uid == uid,
                    includeProperties: "Property.Owner,PrimaryTenant");

                LeaseViewVM leaseViewVM = new LeaseViewVM
                {
                    leaseAgreement = leaseAgreement,
                    LeasePdfDoc = _unitofWork.Document.Get(x => x.LeaseAgreementID == leaseAgreement.ID
                    && x.DocumentTypeID == 2)
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
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> createlease(LeaseVM LeaseVM)
        {
            //return Json(6);
            if (ModelState.IsValid)
            {
                #region Create Lease Agreement
                if (LeaseVM.AddtionalTenants != null)
                {
                    LeaseVM.AddtionalTenants.ForEach(x => { x.isaddedbyLandlord = true; });
                }
                ApplicationUser user = null;
                if (LeaseVM.leaseAgreement.PrimaryTenantID == null
                    || LeaseVM.leaseAgreement.PrimaryTenantID == 0)
                {
                    try
                    {
                        user = await CreateUser(LeaseVM.PrimaryTenant);//create user for newly added primary tenant
                    }
                    catch (Exception exp)
                    {
                        LogErrorDetail(exp, "lease/createlease/createprimarytenantuser");
                        Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        return Json(exp.Message.ToString());
                    }
                    LeaseVM.PrimaryTenant.UserID = user.Id;
                    // LeaseVM.PrimaryTenant.ID = null;
                    _unitofWork.Applicant.Add(LeaseVM.PrimaryTenant);
                    try
                    {
                        _unitofWork.Save();
                    }
                    catch (Exception exp)
                    {

                    }
                    LeaseVM.leaseAgreement.PrimaryTenantID = LeaseVM.PrimaryTenant.ID;
                    Application primaryTenantApplication = new Application
                    {
                        ApplicantID = LeaseVM.PrimaryTenant.ID,
                        PropertyID = LeaseVM.Property.ID,
                        Rent = LeaseVM.leaseAgreement.MonthlyRent,
                        Status = 2,
                        isaddedbyLandlord = true,
                        UserID = user.Id,
                        UpdatedOn = DateTime.UtcNow,
                        uid = Guid.NewGuid().ToString()
                    };
                    _unitofWork.Application.Add(primaryTenantApplication);
                    _unitofWork.Save();
                }
                if (LeaseVM.AddtionalTenants != null)
                {
                    _unitofWork.Applicant.AddRange(LeaseVM.AddtionalTenants);
                    _unitofWork.Save();
                    List<Application> AddtionalTenantApplicationList = new List<Application>();

                    for (int i = 0; i < LeaseVM.AddtionalTenants.Count(); i++)
                    {
                        Applicant additionalTenant = LeaseVM.AddtionalTenants[i];
                        try
                        {
                            user = await CreateUser(additionalTenant); // create user for newly added addtional tenant
                        }
                        catch (Exception exp)
                        {
                            LogErrorDetail(exp, "lease/createlease/createadditionaltenantuser");
                            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            return Json("error occured creating user for additional tenant");
                        }
                        additionalTenant.UserID = user.Id;
                        try
                        {
                            _unitofWork.Applicant.update(additionalTenant);
                            _unitofWork.Save();
                        }
                        catch (Exception exp)
                        {
                            LogErrorDetail(exp, "lease/createlease/saveadditionaltenant");
                            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            return Json("error occured saving additional tenant");
                        }
                        Application AddtionalTenantApplication = new Application
                        {
                            ApplicantID = additionalTenant.ID,
                            PropertyID = LeaseVM.Property.ID,
                            Rent = LeaseVM.leaseAgreement.MonthlyRent,
                            Status = 2,
                            isaddedbyLandlord = true,
                            UserID = additionalTenant.UserID,
                            uid = Guid.NewGuid().ToString()
                        };
                        AddtionalTenantApplicationList.Add(AddtionalTenantApplication);
                    }
                    try
                    {
                        _unitofWork.Application.AddRange(AddtionalTenantApplicationList);
                        _unitofWork.Save();
                    }
                    catch (Exception exp)
                    {
                        LogErrorDetail(exp, "lease/createlease/addadditionaltenantapplication");
                        Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        return Json("error occured creating additional tenant application");
                    }
                }
                LeaseVM.leaseAgreement.PropertyID = LeaseVM.Property.ID;
                LeaseVM.leaseAgreement.BankName = LeaseVM.leaseAgreement.BankName;
                LeaseVM.leaseAgreement.Branch = LeaseVM.leaseAgreement.Branch;
                LeaseVM.leaseAgreement.AccountTitle = LeaseVM.leaseAgreement.AccountTitle;
                LeaseVM.leaseAgreement.AccountNo = LeaseVM.leaseAgreement.AccountNo;
                LeaseVM.leaseAgreement.uid = Guid.NewGuid().ToString();
                try
                {
                    _unitofWork.LeaseAgreement.Add(LeaseVM.leaseAgreement);
                    _unitofWork.Save();
                    calculateAndSaveRentalPayments(LeaseVM.leaseAgreement);
                }
                catch (Exception exp)
                {
                    LogErrorDetail(exp, "lease/createlease/savelease");
                    Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    return Json("error occured creating lease. please try again later.");
                }
                TempData["success"] = "Lease agreement successfully created !";
                #endregion
                #region SaveLeaseTenantsRecord
                try
                {
                    await SaveLeaseTenantsRecord(LeaseVM);
                }
                catch (Exception exp)
                {
                    LogErrorDetail(exp, "lease/SaveLeaseTenantsRecord");
                    Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    return Json("error occured saving lease tenant record");
                }
                #endregion
                #region Generate PDF of lease agreement                 
                Property property;
                LeaseViewVM leaseView = new LeaseViewVM
                {
                    Property = _unitofWork.Property
                    .Get(x => x.ID == LeaseVM.leaseAgreement.PropertyID
                    , includeProperties: "Owner,Applications,State,City"),
                    PrimaryTenant = LeaseVM.PrimaryTenant,
                    AdditionalTenants = _unitofWork.LeaseTenant
                    .GetAll(x => x.LeaseID == LeaseVM.leaseAgreement.ID
                    && x.isPrimaryTenant == false
                    , includeProperties: "Tenant").ToList(),
                    leaseAgreement = LeaseVM.leaseAgreement
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
                    LogErrorDetail(exp, "lease/createlease/GeneratePdfByiText7");
                    Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    return Json("error occured generating pdf of lease agreement.");
                }
                #endregion
                #region Save lease pdf in Documents                
                try
                {
                    await SaveDocumentRecord(leaseView.leaseAgreement.ID, leaseView.leaseAgreement.Property.ID,
                    @"/assets/pdfdocs/lease/" + filename, 2, "Lease agreement");
                }
                catch (Exception exp)
                {
                    LogErrorDetail(exp, "lease/createlease/SaveDocumentRecord");
                    Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    return Json("error occured saving lease pdf document record.");
                }
                #endregion                
            }
            #region Redirect to view the newly created lease agreement
            TempData["success"] = "Lease agreement successfully created !";
            return Json(LeaseVM.leaseAgreement.ID);
            #endregion
        }

        public void calculateAndSaveRentalPayments(LeaseAgreement lease)
        {
            try
            {
                //var lease = _unitofWork.LeaseAgreement.Get(x => x.ID == id); for testing 
                var totalDays = (int)Math.Round((lease.To - lease.From).Value.TotalDays);
                var noOfRentalPayments = 0;
                int period = 0;
                DateTime firstPaymentToDate;
                if (lease.PaymentFrequency == LeaseAgreement.Frequency.Monthly)
                {
                    noOfRentalPayments = (int)Math.Ceiling((double)totalDays / 30);
                    firstPaymentToDate = lease.From.AddDays(30);
                    period = 30;
                }
                else
                {
                    noOfRentalPayments = (int)Math.Round((double)totalDays / 15);
                    firstPaymentToDate = lease.From.AddDays(15);
                    period = 15;
                }

                List<RentalPayment> payments = new List<RentalPayment>
                {
                    new RentalPayment
                    {
                        uid=Guid.NewGuid().ToString(),
                        PropertyID=lease.PropertyID,
                        LeaseAgreementID=lease.ID,
                        DueDate=lease.FirstRentPaymentDueDate,
                        From=lease.From,
                        To=firstPaymentToDate,
                        AmountDue=(decimal)lease.PeriodicRent,
                        Outstanding=(decimal)lease.PeriodicRent,
                        paymentType=RentalPayment.type.rentalIncome,
                        Description="First rental payment",
                        PaymentStaus=RentalPayment.status.due,
                    }
                };
                DateTime fromDate = firstPaymentToDate.AddDays(1);
                DateTime toDate = fromDate.AddDays(period);

                for (int count = 1; count < noOfRentalPayments; count++)
                {
                    var rentalPayment = new RentalPayment
                    {
                        uid = Guid.NewGuid().ToString(),
                        PropertyID = lease.PropertyID,
                        LeaseAgreementID = lease.ID,
                        DueDate = fromDate,
                        From = fromDate,
                        To = toDate,
                        AmountDue = (decimal)lease.PeriodicRent,
                        Outstanding = (decimal)lease.PeriodicRent,
                        paymentType = RentalPayment.type.rentalIncome,
                        Description = "First rental payment",
                        PaymentStaus = RentalPayment.status.due,
                    };

                    payments.Add(rentalPayment);
                    fromDate = toDate.AddDays(1);
                    toDate = fromDate.AddDays(period);
                }
                _unitofWork.RentalPayment.AddRange(payments);
                _unitofWork.Save();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        [HttpGet]
        public IActionResult createlease(string ID, Int64? primaryTenantId)
        {
            try
            {
                Property property = _unitofWork.Property.Get(x => x.uid == ID,
                    includeProperties: "Owner,Applications");

                Applicant primaryTenant = null;
                LeaseAgreement newleaseAgreement = null;
                if (primaryTenantId != null)
                {
                    primaryTenant = _unitofWork.Applicant.Get(a => a.ID == primaryTenantId,
                        includeProperties: "User");
                    newleaseAgreement = new LeaseAgreement { PrimaryTenantID = primaryTenantId };
                }
                else
                {
                    primaryTenant = new Applicant();
                    newleaseAgreement = new LeaseAgreement();
                }
                var applicants = _unitofWork.Application.GetAll(x => x.PropertyID == property.ID
                  && x.Applicant != null, includeProperties: "Applicant").ToList();

                LeaseVM leaseVM = new LeaseVM
                {
                    leaseAgreement = newleaseAgreement,
                    Property = property,
                    States = _unitofWork.State.GetAll().OrderBy(s => s.Name).ToList().Select(s => new SelectListItem()
                    {
                        Text = s.Name,
                        Value = s.ID.ToString()
                    }),
                    Cities = _unitofWork.City.GetAll().OrderBy(c => c.Name).ToList().Select(c => new SelectListItem()
                    {
                        Text = c.Name,
                        Value = c.ID.ToString()
                    }),
                    AddtionalTenants = new List<Applicant>(),
                    PrimaryTenant = primaryTenant,
                };
                if (applicants != null & applicants.Count() > 0)
                    leaseVM.Applicants = applicants.Select(c => new SelectListItem()
                    {
                        Text = c.Applicant?.FirstName,
                        Value = c.ApplicantID.ToString()
                    });
                return View(leaseVM);
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
        public async Task<IActionResult> leasesummary(string ID)
        {
            try
            {
                LeaseAgreement leaseAgreement = _unitofWork.LeaseAgreement.Get(x => x.uid == ID);
                Property property = _unitofWork.Property
                    .Get(x => x.ID == leaseAgreement.PropertyID, includeProperties: "Owner,Applications,State,City");

                LeaseViewVM leaseViewVM = new LeaseViewVM
                {
                    leaseAgreement = leaseAgreement,
                    Property = property,
                    AdditionalTenants = _unitofWork.LeaseTenant.GetAll(x => x.LeaseID == leaseAgreement.ID && x.isPrimaryTenant == false, includeProperties: "Tenant").ToList(),
                    AllTenants = _unitofWork.LeaseTenant.GetAll(x => x.LeaseID == leaseAgreement.ID, includeProperties: "Tenant").Select(
                        x => new SelectListItem()
                        {
                            Text = x.Tenant.FirstName,
                            Value = x.Tenant.ID.ToString()
                        }
                        ).ToList(),
                    PrimaryTenant = _unitofWork.Applicant.Get(x => x.ID == leaseAgreement.PrimaryTenantID),
                    LeasePdfDoc = _unitofWork.Document.Get(x => x.LeaseAgreementID == leaseAgreement.ID && x.DocumentTypeID == 2)
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
        public async Task<IActionResult> lease(Int64 ID)
        {
            LeaseAgreement leaseAgreement = _unitofWork.LeaseAgreement.Get(x => x.ID == ID);
            Property property = _unitofWork.Property.Get(x => x.ID == leaseAgreement.PropertyID, includeProperties: "Owner,Applications,State,City");
            LeaseViewVM leaseViewVM = new LeaseViewVM
            {
                leaseAgreement = leaseAgreement,
                Property = property,
                AdditionalTenants = _unitofWork.LeaseTenant.GetAll(x => x.LeaseID == leaseAgreement.ID && x.isPrimaryTenant == false, includeProperties: "Tenant").ToList(),
                PrimaryTenant = _unitofWork.Applicant.Get(x => x.ID == leaseAgreement.PrimaryTenantID),
            };
            #region Generate and Send PDF of Lease agreement to tenants
            try
            {
                string html = await _utility.RenderViewToStringAsync("lease", leaseViewVM, ControllerContext);
                string filename = _utility.GenerateFileName("lease.pdf", @"assets/pdfdocs/lease");
                string filePath = @"wwwroot/assets/pdfdocs/lease/" + filename;
                Byte[] file = _utility.GeneratePdfByiText7(html, filePath);
                await SendLeaseAgreement2Tenants(leaseViewVM, file);
                await SaveDocumentRecord(leaseAgreement.ID, leaseAgreement.Property.ID,
                    @"/assets/pdfdocs/lease/" + filename, 2, "Lease agreement");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Error");
            }
            #endregion
            return View(leaseViewVM);
        }
        private async Task<bool> SendLeaseAgreement2Tenants(LeaseViewVM leaseViewVM, Byte[] file)
        {
            _emailSender1.Attachment = file;
            _emailSender1.FileName = "lease.pdf";
            try
            {
                if (leaseViewVM.PrimaryTenant != null)
                    await _emailSender1.SendEmailAsync(leaseViewVM.PrimaryTenant.Email, "Lease agreement", "<h1>Lease agreement has been created</h1>");
                if (leaseViewVM.AdditionalTenants != null)
                {
                    for (int i = 0; i < leaseViewVM.AdditionalTenants.Count(); i++)
                    {
                        await _emailSender1.SendEmailAsync(leaseViewVM.AdditionalTenants[i].Tenant.Email, "Lease agreement", "<h1>Lease agreement has been created</h1>");
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                throw;
            }
            return true;
        }
        public JsonResult LoadPrimaryTenant(Int64 applicantId)
        {
            Applicant primaryTenant = null;
            try
            {
                primaryTenant = _unitofWork.Applicant.Get(a => a.ID == applicantId);
            }
            catch (Exception exp)
            {
                LogErrorDetail(exp, "lease/LoadPrimaryTenant");
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json("error occured generating pdf of lease agreement.");
            }
            return Json(primaryTenant);
        }
        private void LogErrorDetail(Exception ex, string errorPath)
        {
            try
            {
                var errorLog = new ErrorLog
                {
                    uid = Guid.NewGuid().ToString(),
                    ErrorDetail = ex.Message,
                    ErrorSource = ex.Source,
                    StackTrace = ex.StackTrace,
                    ErrorPath = errorPath,
                    LoggedInUserId = HttpContext.Session.GetString("_UserId"),
                    status = ErrorLog.Status.Open,
                };
                _unitofWork.ErrorLog.Add(errorLog);
                _unitofWork.Save();
            }
            catch (Exception exp)
            {

                throw;
            }
        }
    }
}
