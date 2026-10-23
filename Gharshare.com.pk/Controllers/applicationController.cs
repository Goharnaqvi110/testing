using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using Gharshare.CommonHelper;
using Microsoft.EntityFrameworkCore;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;


namespace Gharshare.com.pk.Controllers
{
    public class applicationController : Controller
    {
        private IUnitofWork _unitofWork;
        private Utility _utility;
        public applicationController(IUnitofWork iUnitofWork, Utility utility)
        {
            _unitofWork = iUnitofWork;
            _utility = utility;
        }

        [HttpGet]
        public IActionResult list(string ID)
        {
            try
            {
                Property Property = _unitofWork.Property.Get(x => x.uid == ID);
                var applications = _unitofWork.Application.GetAll(x => x.PropertyID == Property.ID &&
                x.Applicant != null, includeProperties: "User,Property,Applicant");
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
        public JsonResult Loadapplicant(Int64 applicantId)
        {
            Applicant applicant = null;
            try
            {
                applicant = _unitofWork.Applicant.Get(x => x.ID == applicantId);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                LogErrorDetail(ex, "Property/Loadapplicant");
            }
            return new JsonResult(applicant);
        }
        public JsonResult updateApplicationStatus(Int32 statusId, Int64 applicationId)
        {
            try
            {
                Application application = _unitofWork.Application.Get(x => x.ID == applicationId);
                application.Status = statusId;
                application.UpdatedOn = DateTime.Now;
                application.UpdatedbyUserID = HttpContext.Session.GetString("_UserId");
                _unitofWork.Application.update(application);
                _unitofWork.Save();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                LogErrorDetail(ex, "Property/updateApplicationStatus");
            }
            return new JsonResult("success");
        }
        public JsonResult viewapplication(Int64 aid)
        {
            try
            {
                ApplicantDocument applicantDocument = _unitofWork.ApplicantDocument.
                    Get(x => x.ApplicationID == aid, includeProperties: "Application.Property");
                //var returnValues = new   //for reference only
                //{
                //    documentPath = applicantDocument.DocumentPath,
                //    applicationID = applicantDocument.ApplicationID,
                //    propertyId = applicantDocument.Application.Property.uid,
                //    applicantID = applicantDocument.Application.ID
                //};
                return Json(applicantDocument);
            }
            catch (Exception ex)
            {
                LogErrorDetail(ex, "/application/viewapplication/");
                return new JsonResult(new { error = true, message = ex.Message });
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
