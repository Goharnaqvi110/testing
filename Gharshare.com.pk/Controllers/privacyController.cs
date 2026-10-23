using Microsoft.AspNetCore.Mvc;
using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;

namespace Gharshare.com.pk.Controllers
{
    public class privacyController : Controller
    {
        private IUnitofWork _unitofWork;
        public privacyController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public IActionResult index()
        {
            try
            {
                StaticContent staticContent = _unitofWork.StaticContent.
                    Get(sc => sc.ContentTypeID == 1);
                return View(staticContent);
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
