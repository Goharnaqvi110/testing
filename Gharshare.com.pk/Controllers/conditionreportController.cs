using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using Gharshare.CommonHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;

namespace Gharshare.com.pk.Controllers
{
    public class conditionreportController : Controller
    {
        private IUnitofWork _unitofWork;
        private Utility _utility;
        private readonly IEmailSender _emailSender;
        public conditionreportController(IUnitofWork iUnitofWork, Utility utility,
            IEmailSender emailSender)
        {
            _unitofWork = iUnitofWork;
            _utility = utility;
            _emailSender = emailSender;
        }
        [HttpGet]
        public IActionResult conditionreportlist(Int64 lid)
        {
            try
            {
                List<ConditionReport> conditionReport = _unitofWork.ConditionReport.GetAll(
                    x => x.LeaseAgreementID == lid, includeProperties: "Property").ToList();
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

        [HttpGet]
        public IActionResult list(string pid, string lid)
        {
            Property property = _unitofWork.Property.Get(x => x.uid == pid);
            var conditionVm = new ConditionReportVm
            {
                Property = property,
                ReportList = _unitofWork.ConditionReport
                .GetAll(x => x.PropertyID == property.ID, 
                includeProperties: "Property,PrimaryTenant").ToList(),
            };
            return View(conditionVm);
        }
        [HttpGet]
        public IActionResult conditionreportItems(string PID)
        {

            ConditionReportVm conditionReportVm = new ConditionReportVm();
            try
            {
                Property property = _unitofWork.Property.Get(x => x.uid == PID);
                List<PropertyArea> propertyArea = _unitofWork.PropertyArea.
                    GetAll(includeProperties: "PropertyAreaItems").ToList();
                conditionReportVm.Property = property;
                conditionReportVm.PropertyArea = propertyArea;
                conditionReportVm.PropertyTypes = LoadPropertyTypes();
                conditionReportVm.CondtionReport = new ConditionReport();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
            return View(conditionReportVm);
        }
        [HttpPost]
        public IActionResult createconditionreport(ConditionReportVm conditionReportVm)
        {
            List<PropertyArea> selectedAreas = conditionReportVm.PropertyArea.Where(x => x.isSelected == true && x.TotalNo > 0).ToList();

            List<List<PropertyAreaItem>> PropertyAreaItemslist = new List<List<PropertyAreaItem>>();
            for (int i = 0; i < selectedAreas.Count(); i++)
            {
                for (int j = 0; j < selectedAreas[i].TotalNo; j++)
                {
                    List<PropertyAreaItem> propertyAreaItem = _unitofWork.PropertyAreaItem.
                        GetAll(x => x.PropertyAreaID == selectedAreas[i].ID, includeProperties: "PropertyArea").ToList();
                    int count = 0;
                    if (propertyAreaItem.Count() > 0)
                    {
                        if (j == 0)
                            propertyAreaItem[0].AreaName = selectedAreas[i].Name;
                        else
                        {
                            count = j + 1;
                            string aname = selectedAreas[i].Name + "-" + count.ToString();
                            propertyAreaItem[0].AreaName = aname;
                        }
                        PropertyAreaItemslist.Add(propertyAreaItem);
                        _unitofWork.PropertyAreaItem.Detach(propertyAreaItem[0]);
                    }
                }
            }
            var property = _unitofWork.Property.Get(x => x.ID == conditionReportVm.Property.ID
                && (x.Lease != null && x.Lease.LeaseStatus == LeaseAgreement.status.Active
                || x.Lease.LeaseStatus == LeaseAgreement.status.Created),
                includeProperties: "Owner,Lease,Lease.PrimaryTenant");
            conditionReportVm.Property = property;
            IEnumerable<PropertyAreaItem> result = PropertyAreaItemslist.SelectMany(list => list.Distinct());
            conditionReportVm.PropertyAreaItem = result.ToList();
            conditionReportVm.CondtionReport = new ConditionReport();
            return View(conditionReportVm);
        }
        [HttpPost]
        public async Task<IActionResult> savereport(ConditionReportVm conditionReportVm)
        {
            //var crep = _unitofWork.ConditionReport.Get(cr => cr.ID == 4);
            //return new JsonResult(crep);//for testing 
            bool errorOccurred = false;
            if (ModelState.IsValid)
            {
                #region Create Condition report                
                string userID = HttpContext.Session.GetString("_UserId");
                var conditionReport = conditionReportVm.CondtionReport;
                var reportItems = conditionReportVm.PropertyAreaItem;
                var property = conditionReportVm.Property;
                conditionReport.PropertyID = property.ID;

                if (conditionReport.LandlorsigData != null)
                {
                    byte[] landLordSignatures = Convert.FromBase64String(conditionReport.LandlorsigData);
                    conditionReport.LandlordSign = landLordSignatures;
                    conditionReport.status = ConditionReport.Status.SignedByLandlord;
                    conditionReport.SignedByLandlord = true;
                }
                else
                {
                    conditionReport.status = ConditionReport.Status.Created;
                }
                try
                {
                    if (property.Lease != null)
                    {
                        conditionReport.PrimaryTenantID = property.Lease.PrimaryTenantID;
                        conditionReport.LeaseAgreementID = property.Lease.ID;
                    }
                    conditionReport.CreatedOn = DateTime.UtcNow;
                    conditionReport.CreatedbyUserId = userID;
                    conditionReport.uid = Guid.NewGuid().ToString();
                    _unitofWork.ConditionReport.Add(conditionReport);
                    _unitofWork.Save();
                }
                catch (Exception exp)
                {
                    LogErrorDetail(exp, "conditionreport/savereport/savereport");
                    Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    return Json("error occured saving condition report");
                }
                #endregion

                #region Save property section/area
                CRItem conditionReportItem = null;

                //Loop through each part of an area/section
                reportItems.ForEach(item =>
                {
                    if (item.AreaName != null)
                    {
                        conditionReportItem = new CRItem
                        {
                            ConditionReportID = conditionReport.ID,
                            PropertyAreaID = item.PropertyAreaID,
                            Name = item.AreaName,
                            Comments = item.AdditionalComments,
                            CreatedOn = DateTime.UtcNow,
                            CreatedbyUserId = userID,
                            uid = Guid.NewGuid().ToString()
                    };
                        try
                        {
                            _unitofWork.CRItem.Add(conditionReportItem);
                            _unitofWork.Save();
                        }
                        catch (Exception exp)
                        {
                            LogErrorDetail(exp, "conditionreport/savereport/Save property section/area");
                            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            //return Json("error occured saving condition report");
                            // errorOccurred = true;
                        }
                    }

                    #endregion

                #region  Save details of Property area/section
                    // Additional Comments are regarding CRItem(e.g. room etc)
                    // & not itemdetail e.g. walls/picture hooks etc
                    if (item.AddComments == true)
                    {
                        conditionReportItem.Comments = item.AdditionalComments;
                        _unitofWork.CRItem.update(conditionReportItem);
                        //_unitofWork.Save();                        
                    }
                    CRItemDetail crItemDetail = new CRItemDetail
                    {
                        CRItemID = conditionReportItem.ID,
                        AreaItemId = item.ID,
                        Clean = item.Clean,
                        Undamaged = item.Undamaged,
                        Working = item.Working,
                        LandlordComments = item.LandlordComments,
                        TenantAgreed = item.TenantAgreed,
                        True = item.isTrue,
                        DeadlineDate = item.DeadlineDate,
                        LastWorkedDate = item.LastWorkedDate,
                        Reading = item.Reading,
                        NormalField = item.NormalField,
                        PhotoField = item.PhotoField,
                        YesNoField = item.YesNoField,
                        MeterReadingField = item.MeterReadingField,
                        LastWorkedOnField = item.LastWorkedOnField,
                        TobedoneByField = item.TobedoneByField,
                        DeadlineDateField = item.DeadlineDateField,
                        LandlordPromise = item.LandlordPromise,
                        AddComments = item.AddComments,
                        AdditionalComments = item.AdditionalComments,
                        uid = Guid.NewGuid().ToString()
                };
                    try
                    {
                        _unitofWork.CRItemDetail.Add(crItemDetail);
                        _unitofWork.Save();
                    }
                    catch (Exception exp)
                    {
                        LogErrorDetail(exp, "conditionreport/savereport/savereport");
                        Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        errorOccurred = true;
                    }
                    #endregion

                #region Save images of Property area/section
                    List<CRItemImage> areaImages = new List<CRItemImage>();
                    if (item.Photos != null)
                    {
                        foreach (var photo in item.Photos)
                        {
                            var imgPath = "";
                            if (photo.Length <= 100000)
                            {
                                imgPath = _utility.SaveFile(photo, @"assets/PropertyAreaImages");
                            }
                            else
                            {
                                imgPath =_utility.ResizeAndSaveImage(photo, "assets/PropertyAreaImages", 
                                    100000, 300, 300);
                            }
                                areaImages.Add(new CRItemImage
                            {
                                CRItemID = conditionReportItem.ID,
                                uid = Guid.NewGuid().ToString(),
                            //ConditionReportID = conditionReportVm.CondtionReport.ID,
                            AddedByLandlord = true,
                                ImagePath = imgPath,//_utility.SaveFile(photo, @"assets/PropertyAreaImages"),
                            });
                        }
                        try
                        {
                            _unitofWork.CRItemImage.AddRange(areaImages);
                            _unitofWork.Save();
                            TempData["success"] = "Condition report successfully created !";
                        }
                        catch (Exception exp)
                        {
                            LogErrorDetail(exp, "conditionreport/savereport/savereport");
                            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            errorOccurred = true;
                        }
                    }
                    #endregion
                }); //loop end
                await GeneratePdfByiText7(conditionReport.ID);
                var cReport = _unitofWork.ConditionReport.Get(cr => cr.ID ==conditionReport.ID);
                var simplifiedReport = new
                {
                    ID = cReport.ID,
                    FilePath = cReport.FilePath,                     
                };
                return new JsonResult(simplifiedReport);
                //return new JsonResult(conditionReportVm.CondtionReport);
            }
            return Json("Invalid data. Failed saving condition report");
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
                string htmlforPdf = await _utility.RenderViewToStringAsync("conditionreportPDF",
                    crVm, ControllerContext);
                string filename = _utility.GenerateFileName("conditionreport.pdf",
                    @"assets/pdfdocs/conditionreport");
                string filePath = @"wwwroot/assets/pdfdocs/conditionreport/" + filename;
                var result = _utility.GeneratePdfByiText7(htmlforPdf, filePath);
                await SaveDocumentRecord(crVm.Property.Lease.ID, crVm.Property.ID,
                    @"/assets/pdfdocs/conditionreport/" + filename, 3, "Condition Report");
                crVm.CondtionReport.FilePath = @"/assets/pdfdocs/conditionreport/" + filename;
                _unitofWork.ConditionReport.update(crVm.CondtionReport);
                _unitofWork.Save();
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private async Task SaveDocumentRecord(Int64 leaseId, Int64 propertyId, 
            string filepath, Int64 docTypeID, string docName)
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
                    uid = Guid.NewGuid().ToString()
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
        public async Task<IActionResult> sendreport2tenant(Int64 reportid)
        {
            try
            {
                var conditionReport = _unitofWork.ConditionReport.Get(
                    x => x.ID == reportid, includeProperties: "Property");
                conditionReport.Sent2Tenant = true;
                _unitofWork.ConditionReport.update(conditionReport);
                _unitofWork.Save();
            }
            catch (Exception exp)
            {
                LogErrorDetail(exp, "conditionreport/sendreport2tenant");
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json("error sending condition report to tenant dashboard");
            }
            return Json("success");
        }
        [HttpGet]
        public async Task<IActionResult> viewconditionreport(Int64 id)
        {
            try
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
        private List<SelectListItem> LoadPropertyTypes()
        {
            IEnumerable<SelectListItem> PropertyTypes = _unitofWork.PropertyType.GetAll().ToList().Select(
                    x => new SelectListItem()
                    {
                        Text = x.Name,
                        Value = Convert.ToString(x.ID)
                    }
                    );
            return PropertyTypes.ToList();
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
                    uid = Guid.NewGuid().ToString(),
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
