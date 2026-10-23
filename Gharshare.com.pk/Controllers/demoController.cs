using Microsoft.AspNetCore.Mvc;
using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;

namespace Gharshare.com.pk.Controllers
{
    public class demoController : Controller
    {
        private IUnitofWork _unitofWork;
        public demoController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public JsonResult validateDemoRequest(string IP)
        {
            List<DemoRequest> demoRequests = new List<DemoRequest>();
            try
            {
                if (IP != null)
                {
                    demoRequests = _unitofWork.DemoRequest.
                    GetAll(ds=>ds.IPAddress==IP).ToList();
                }                 
            }
            catch (Exception ex)
            {
                LogErrorDetail(ex, "demo/validateDemoRequest");
            }
            int count = 0;
            if (demoRequests != null)
                count = demoRequests.Count();
            return new JsonResult(count);
        }
        public IActionResult registered()
        {
            try
            {
                DemoVM demoVM = new DemoVM
                {
                    Testimonials = _unitofWork.Testimonial.GetAll(t => t.IsShown == true)
                    .ToList(),
                    StaticContent = null,
                };
                return View(demoVM);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }

        }

        public JsonResult GetIP()
        {            
            try
            {
                var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
                return new JsonResult(ip);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public JsonResult SaveDemoRequest(string name, string email, string mobile,
            string? ip)
        {
            try
            {
                DemoRequest demoRequest = new DemoRequest
                {
                    Name = name,
                    Email = email,
                    Mobile = mobile,
                    IPAddress=ip,
                    uid = Guid.NewGuid().ToString()
            };
                _unitofWork.DemoRequest.Add(demoRequest);
                _unitofWork.Save();
            }
            catch (Exception ex)
            {
                LogErrorDetail(ex, "home/SaveDemoRequest");
            }
            return new JsonResult("success");
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
