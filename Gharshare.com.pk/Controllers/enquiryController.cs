using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using Gharshare.CommonHelper;
using Microsoft.EntityFrameworkCore;
using static Gharshare.Models.PropertyEnquiry;
using System.Net;
using Gharshare.DataAccessLayer.Data.Infrastructure.Repository;
using System.Text.RegularExpressions;
using MailKit.Search;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using Microsoft.AspNetCore.Identity.UI.Services;


namespace Gharshare.com.pk.Controllers
{
    public class enquiryController : Controller
    {
        private IUnitofWork _unitofWork;
        private Utility _utility;
        private readonly IEmailSender _emailSender;
        public enquiryController(IUnitofWork iUnitofWork, Utility utility, IEmailSender emailSender)
        {
            _unitofWork = iUnitofWork;
            _utility = utility;
            _emailSender = emailSender;
        }
        [HttpPost]
        public JsonResult sendReply(int enqType, Int64 propertyId, string recepient,
            string sender, string reply, Int64 parentEnquiryId)
        {
            try
            {
                if (enqType != null & recepient != null & sender != null)
                {
                    Enquiry.EnquriyType enquiryType;
                    //In reply to an inspection enquiry,set enqyType
                    //to 'aboutproperty', so that in case of further messages,inspection schedule 
                    //is not created and shared on tenant log in. 
                    if (enqType == (int)Enquiry.EnquriyType.aboutinspection)
                    {
                        enquiryType = Enquiry.EnquriyType.aboutproperty;
                    }
                    else
                    {
                        enquiryType = (Enquiry.EnquriyType)enqType;
                    }
                    Enquiry enquiry = new Enquiry
                    {
                        Enquirytype = enquiryType,
                        ParentEnquiryId = parentEnquiryId,
                        PropertyID = propertyId,
                        FromUserID = sender,
                        ToUserID = recepient,
                        //Message = reply,
                        Message = Regex.Replace(reply, "<.*?>", string.Empty),
                        Enquirystatus = Enquiry.EnquiryStatus.unread,
                        CreatedOn = DateTime.UtcNow,
                        UId = Guid.NewGuid().ToString()
                    };
                    if (propertyId == 0)
                        enquiry.PropertyID = null;
                    _unitofWork.Enquiry.Add(enquiry);
                    var parentEnquiry = _unitofWork.Enquiry.Get(e => e.ID == parentEnquiryId);
                    if (parentEnquiry != null)
                        parentEnquiry.isReplied = true;
                    _unitofWork.Save();
                }
            }
            catch (Exception exp)
            {
                LogErrorDetail(exp, "enquiry/sendReply");
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { error = "failed" });
            }
            return new JsonResult("success");
        }
        [HttpGet]
        public IActionResult getPropertyInspections(Int64 propertyId, string recepient,
            string sender, string propAddress)
        {
            List<PropertyInspection> propertyInspections = null;
            string tableInspections = "";
            if (propAddress != "")
                propAddress = "for property at " + propAddress;
            try
            {
                propertyInspections = _unitofWork.PropertyInspection.
                    GetAll(pi => pi.PropertyID == propertyId && pi.isActive == true).ToList();
                if (propertyInspections.Any())
                {
                    tableInspections = $@"Dear {recepient},<br>Thank you for your interest. 
Below is the inspection schedule {propAddress}.<br>
<table class=""table table-responsive-md"">
    <thead>
        <tr>
            <th style=""width: 50px;""><strong>No</strong></th>
            <th style=""width: 100px;""><strong>             
                Inspection Date
            </strong></th>
            <th style=""width: 50px;""><strong>             
                From
            </strong></th>
            <th style=""width: 50px;""><strong>To</strong></th>
        </tr>
    </thead>
    <tbody>";
                    int count = 1;
                    foreach (var inspection in propertyInspections)
                    {
                        tableInspections += "<tr><td>" + count + "</td>";
                        tableInspections += "<td>" + Utility.ConvertToShortDateFormat(inspection.InspectionDate) + "</td>";
                        tableInspections += "<td>" + inspection.From + "</td>";
                        tableInspections += "<td>" + inspection.To + "</td></tr>";
                        count += 1;
                    }
                    tableInspections += "</tbody></table><br>";
                    tableInspections += "Please feel free to visit.<br>";
                    tableInspections += "Thank You,<br>";
                    tableInspections += sender;
                }
            }
            catch (Exception exp)
            {
                LogErrorDetail(exp, "message /getPropertyInspections");
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { error = "failed" });
            }
            return new JsonResult(tableInspections);
        }
        [HttpGet]
        public IActionResult loadenquiry(Int64 enquiryid)
        {
            var enquiry = _unitofWork.Enquiry.Get(e => e.ID == enquiryid,
                includeProperties: "FromUser,ToUser,Property");
            var loggedinUserId = HttpContext.Session.GetString("_UserId");
            try
            {
                if (enquiry != null)
                {
                    if (enquiry.Enquirystatus != Enquiry.EnquiryStatus.read &&
                        enquiry.FromUserID != loggedinUserId)
                    {
                        enquiry.Enquirystatus = Enquiry.EnquiryStatus.read;
                        _unitofWork.Enquiry.update(enquiry);
                        _unitofWork.Save();
                    }
                }
            }
            catch (Exception exp)
            {
                TempData["ErrorMessage"] = exp.Message;
                TempData["StackTrace"] = exp.StackTrace;
                TempData["Source"] = exp.Source;
                return RedirectToAction("Error", "Error");
            }
            return View("enquiry", enquiry);
        }
        [HttpGet]
        public IActionResult newEnquiry(Int64? propertyid)
        {
            Enquiry enquiry = null;
            try
            {
                enquiry = new Enquiry();
                var landLords = _unitofWork.User.GetAll(u =>
                u.UserType == ApplicationUser.usertype.landlord).OrderBy(u => u.Name).ToList()
                .Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id,
                });
                ViewBag.Landlords = landLords;
                var userType = HttpContext.Session.GetString("_UserType");
                var currentUserId = HttpContext.Session.GetString("_UserId");
                if (userType == "landlord")
                {
                    var properties = _unitofWork.Property.GetAllData(p => p.OwnerId == currentUserId,
                        includes: q => q.Include(p => p.Lease.LeaseTenants)
                        .ThenInclude(lt => lt.User));
                    var Tenants = new List<ApplicationUser>();
                    foreach (var property in properties)
                    {
                        if (property.Lease != null)
                        {
                            if (property.Lease.LeaseTenants != null)
                            {
                                foreach (var tenant in property.Lease.LeaseTenants)
                                {
                                    Tenants.Add(tenant.User);
                                }
                            }
                        }
                    }
                    if (Tenants.Count() > 0)
                    {
                        var tenants = Tenants.OrderBy(t => t.Name).Select(t =>
                        new SelectListItem
                        {
                            Text = t.Name,
                            Value = t.Id,
                        });
                        ViewBag.Tenants = tenants;
                    }
                }
                else
                {
                    var tenants = _unitofWork.User.GetAll(u =>
                    u.UserType == ApplicationUser.usertype.tenant).OrderBy(u => u.Name).ToList()
                    .Select(u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id,
                    });
                    ViewBag.Tenants = tenants;
                }
            }
            catch (Exception exp)
            {
                TempData["ErrorMessage"] = exp.InnerException?.Message;
                TempData["StackTrace"] = exp.StackTrace;
                TempData["Source"] = exp.Source;
                return RedirectToAction("Error", "Error");
            }
            return View("newenquiry", enquiry);
        }
        [HttpPost]
        public async Task<JsonResult> savenewEnquiry(Enquiry enquiry)
        {
            try
            {
                if (enquiry != null)
                {
                    var superAdmin = _unitofWork.User.Get(u => u.UserType ==
                    ApplicationUser.usertype.superadmin);
                    var userType = HttpContext.Session.GetString("_UserType");
                    if ((userType == "landlord" || userType == "tenant") && enquiry.sendto == "admin") //admin or super admin
                    {
                        enquiry.ToUserID = superAdmin.Id;
                    }
                    else if (userType == "tenant" && enquiry.sendto == "landlord")
                    {
                        enquiry.ToUserID = HttpContext.Session.GetString("LandlordId");
                    }
                    else if (userType == "tenant" && enquiry.sendto == "admin")
                    {
                        enquiry.ToUserID = superAdmin.Id;
                    }
                    else if ((userType == "admin" || userType == "superadmin") && enquiry.sendto == "landlord")
                    {
                        enquiry.ToUserID = enquiry.landlordId;
                    }
                    else if ((userType == "admin" || userType == "superadmin") && enquiry.sendto == "tenant")
                    {
                        enquiry.ToUserID = enquiry.tenantId;
                    }
                    if (userType == "landlord" && enquiry.sendto == "tenant")
                    {
                        enquiry.ToUserID = enquiry.tenantId;
                    }
                    enquiry.UId = Guid.NewGuid().ToString();
                    enquiry.Message = Regex.Replace(enquiry.Message, "<.*?>", string.Empty);
                    _unitofWork.Enquiry.Add(enquiry);
                    _unitofWork.Save();

                    #region Send message to the application admin
                    var fromUser = _unitofWork.User.Get(u => u.Id == enquiry.FromUserID);
                    var toUser = _unitofWork.User.Get(u => u.Id == enquiry.ToUserID);
                    var messageToAdmin = fromUser.Name + " with email " + fromUser.Email + " has sent a message to "
                        + toUser.Name + " with email" + fromUser.Email + ":<br>" + enquiry.Message;
                    var settings = _unitofWork.Sitesetting.Get(s => s.ID != null);
                    var adminEmail = string.Empty;
                    if (settings != null)
                        adminEmail = settings.Email;
                    else adminEmail = "info@smartpropertymanager.pk";
                    await _emailSender.SendEmailAsync(adminEmail, "Enquiry about Property", messageToAdmin);
                    #endregion  
                }
            }
            catch (Exception exp)
            {
                LogErrorDetail(exp, "message/sendmessage");
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { error = "failed" });
            }
            return new JsonResult("success");
        }
        public JsonResult updateEnquiryStatus(PropertyEnquiry.EnquiryStatus statusId, Int64 enquiryId)
        {
            try
            {
                PropertyEnquiry propertyEnquiry = _unitofWork.PropertyEnquiry.Get(x => x.ID == enquiryId);
                propertyEnquiry.Status = statusId;
                propertyEnquiry.UpdatedOn = DateTime.Now;
                _unitofWork.PropertyEnquiry.update(propertyEnquiry);
                _unitofWork.Save();
            }
            catch (Exception ex)
            {
                LogErrorDetail(ex, "enquiry/updateEnquiryStatus");
            }
            return new JsonResult("success");
        }
        [HttpGet]
        public IActionResult inbox(string type, int pg = 1, string? uid = "")
        {
            List<Enquiry> enquiries;
            var loggedinUser = HttpContext.Session.GetString("_UserId");
            try
            {
                if (type == "to")
                    enquiries = _unitofWork.Enquiry.GetAll(e => e.ToUserID == loggedinUser,
                        includeProperties: "FromUser")
                        .OrderByDescending(e => e.CreatedOn).ToList();
                else
                    enquiries = _unitofWork.Enquiry.GetAll(e => e.FromUserID == loggedinUser,
                        includeProperties: "FromUser")
                        .OrderByDescending(e => e.CreatedOn).ToList();
                Property property = null;
                if (uid != string.Empty && uid != null)
                    property = _unitofWork.Property.Get(p => p.uid == uid);
                Int64 pid = 0;
                if (property != null)
                    pid = property.ID;

                if (pid > 0)
                {
                    enquiries = enquiries.Where(e => e.PropertyID == pid).ToList();
                }
                #region apply paging on properties
                int pageSize = Pager.GetPageSize();
                var currentPage = 1;
                int recsCount = enquiries.Count();
                int recSkip = (currentPage - 1) * pageSize;
                enquiries = enquiries.Skip(recSkip).Take(pageSize).ToList();
                var pager = new Pager(recsCount, currentPage, "", "", pageSize, null, "", enquiries.Count(),
                    "getEnquiries", 2, type, uid);
                ViewBag.Pager = pager;
                #endregion

            }
            catch (Exception exp)
            {
                TempData["ErrorMessage"] = exp.Message;
                TempData["StackTrace"] = exp.StackTrace;
                TempData["Source"] = exp.Source;
                return RedirectToAction("Error", "Error");
            }
            return View(enquiries);
        }
        public JsonResult GetEnquiryList(int currentPage, string type, string porpertyUid,
             string searchText = "", int? sortOrderNo = 1)
        {
            List<Enquiry> enquiries;
            Pager pager = null;
            try
            {
                enquiries = GetEnquiries(currentPage, type, porpertyUid, searchText = "", sortOrderNo);
                #region apply paging
                int pageSize = Pager.GetPageSize();
                if (currentPage < 1)
                    currentPage = 1;
                int recsCount = enquiries.Count();
                int recSkip = (currentPage - 1) * pageSize;
                enquiries = enquiries.Skip(recSkip).Take(pageSize).OrderByDescending(e => e.CreatedOn).ToList();
                pager = new Pager(recsCount, currentPage, "", "", pageSize, searchText, "", enquiries.Count(),
                    "getEnquiries", (int)sortOrderNo, type, porpertyUid);
                ViewBag.Pager = pager;
                #endregion
            }
            catch (Exception ex)
            {
                LogErrorDetail(ex, "enquiry/GetEnquiryList");
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { error = "failed" });
            }
            // Create a JSON object to hold the transformed documents and any other required data
            var result = new
            {
                Enquiries = enquiries,
                Pager = pager,
            };

            // Return the JSON result
            return new JsonResult(result);
        }
        public JsonResult SortEnquiryList(int currentPage, string type, string porpertyUid,
             string searchText = "", int? sortOrderNo = 1)
        {
            List<Enquiry> enquiries;
            Pager pager = null;
            try
            {
                enquiries = GetEnquiries(currentPage, type, porpertyUid, searchText = "", sortOrderNo);
                int pageSize = Pager.GetPageSize();
                if (currentPage < 1)
                    currentPage = 1;
                int recsCount = enquiries.Count();
                int recSkip = (currentPage - 1) * pageSize;
                enquiries = enquiries.Skip(recSkip).Take(pageSize).ToList();

                switch (sortOrderNo)
                {
                    case 1:
                        enquiries = enquiries.OrderByDescending(e => e.CreatedOn).ToList();
                        sortOrderNo = 2;
                        break;
                    case 2:
                        enquiries = enquiries.OrderBy(e => e.CreatedOn).ToList();
                        sortOrderNo = 1;
                        break;
                    case 3:
                        sortOrderNo = 4;
                        break;
                    case 4:
                        sortOrderNo = 3;
                        break;
                }
                #region apply paging

                pager = new Pager(recsCount, currentPage, "", "", pageSize, searchText, "", enquiries.Count(),
                    "getEnquiries", (int)sortOrderNo, type, porpertyUid);
                ViewBag.Pager = pager;
                #endregion
            }
            catch (Exception ex)
            {
                LogErrorDetail(ex, "enquiry/GetEnquiryList");
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { error = "failed" });
            }
            // Create a JSON object to hold the transformed documents and any other required data
            var result = new
            {
                Enquiries = enquiries,
                Pager = ViewBag.Pager,
            };

            // Return the JSON result
            return new JsonResult(result);
        }

        private List<Enquiry> GetEnquiries(int currentPage, string type, string porpertyUid,
             string searchText = "", int? sortOrderNo = 1)
        {
            List<Enquiry> enquiries;
            Pager pager = null;
            var loggedinUser = HttpContext.Session.GetString("_UserId");
            if (type == "to")
                enquiries = _unitofWork.Enquiry.GetAll(e => e.ToUserID == loggedinUser,
                    includeProperties: "FromUser").ToList();
            else
                enquiries = _unitofWork.Enquiry.GetAll(e => e.FromUserID == loggedinUser,
                    includeProperties: "FromUser").ToList();
            Property property = null;
            if (porpertyUid != string.Empty && porpertyUid != null)
                property = _unitofWork.Property.Get(p => p.uid == porpertyUid);
            Int64 pid = 0;
            if (property != null)
                pid = property.ID;

            if (pid > 0)
            {
                enquiries = enquiries.Where(e => e.PropertyID == pid).ToList();
            }
            return (enquiries);
        }
        [HttpGet]
        public IActionResult list(Int64 ID)
        {
            try
            {
                List<PropertyEnquiry> propertyEnquiries = _unitofWork.PropertyEnquiry.
                    GetAll(x => x.PropertyID == ID).ToList();
                return View(propertyEnquiries);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
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
    }
}
