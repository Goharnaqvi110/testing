using Microsoft.AspNetCore.Mvc;
using Gharshare.Models;
using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Gharshare.com.pk.Controllers
{
    public class toolkitController : Controller
    {
        private IUnitofWork _unitofWork;
        private readonly IEmailSender _emailSender;
        public toolkitController(IUnitofWork unitofWork, IEmailSender emailSender)
        {
            _unitofWork = unitofWork;
            _emailSender = emailSender;
        }
        public IActionResult index()
        {
            return View();
        }
        private async void SendEmail(Toolkit toolkit)
        {
            var settings = _unitofWork.Sitesetting.Get(s => s.ID != null);
            var adminEmail = string.Empty;
            if (settings != null)
                adminEmail = settings.Email;
            else adminEmail = "info@smartpropertymanager.pk";
            var messageToAdmin = "Dear Admin !<br>" + toolkit.OwnerName + "has requested for" + toolkit.Type +
                "Below is the detail:<br> + Email: " + toolkit.Email + "<br>" + "Phone: " + toolkit.Phone + "<br>" +
                "Property Address: " + toolkit.PropertyAddress + "<br> Thank you !<br>";
            await _emailSender.SendEmailAsync(adminEmail, "Toolkit", messageToAdmin);
        }
        [HttpGet]
        public IActionResult rentalestimate()
        {
            try
            {
                Toolkit toolkit = new Toolkit();
                toolkit.IPAddress = GetIP();
                toolkit.Type = "Rental estimate"; //Rental estimate, agent switch kit, e - book           
                return View(toolkit);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }

        }
        private string GetIP()
        {
            //var feature = HttpContext.Features.Get<IHttpConnectionFeature>();
            //var LocalIPAddr1 = feature?.RemoteIpAddress?.ToString();
            try
            {
                var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
                return ip;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult rentalestimate(Toolkit toolkit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var toolkits = _unitofWork.Toolkit.GetAll(tk => tk.IPAddress == toolkit.IPAddress &&
                    tk.Type == toolkit.Type && tk.PropertyAddress == toolkit.PropertyAddress);
                    if (toolkits.Count() == 0)
                    {
                        toolkit.uid = Guid.NewGuid().ToString();
                        toolkit.CreatedOn = DateTime.UtcNow;
                        _unitofWork.Toolkit.Add(toolkit);
                        _unitofWork.Save();
                        TempData["success"] = "The rental estimate report will be sent to you with in 24 hours.";
                        SendEmail(toolkit);
                    }
                    else
                    {
                        TempData["error"] = "Failed ! You have already placed rental estimate report request for this property.";
                    }
                }
                ModelState.Clear();
                Toolkit toolkitnew = new Toolkit();
                toolkitnew.Type = "Rental estimate";
                toolkitnew.IPAddress = GetIP();
                toolkitnew.NeedFor = "";
                return View(toolkitnew);
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
        public IActionResult agentswitchkit()
        {
            try
            {
                Toolkit toolkit = new Toolkit();
                toolkit.IPAddress = GetIP();
                toolkit.Type = "agent switch kit";
                toolkit.PropertyAddress = "NA";
                return View(toolkit);
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
        public IActionResult agentswitchkit(Toolkit toolkit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var toolkits = _unitofWork.Toolkit.GetAll(tk => tk.IPAddress == toolkit.IPAddress &&
                    tk.Type == toolkit.Type);

                    if (toolkits.Count() == 0)
                    {
                        toolkit.PropertyAddress = "NA";
                        toolkit.uid = Guid.NewGuid().ToString();
                        _unitofWork.Toolkit.Add(toolkit);
                        _unitofWork.Save();
                        TempData["success"] = "The agent switch kit will be sent to you within 24 hours.";
                        SendEmail(toolkit);
                    }
                    else
                    {
                        TempData["error"] = "Failed ! You have already placed request for agent switch kit. ";
                    }
                }
                ModelState.Clear();
                Toolkit toolkitnew = new Toolkit();
                toolkitnew.Type = "agent switch kit";
                toolkitnew.IPAddress = GetIP();
                return View(toolkitnew);
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
        public IActionResult ebook()
        {
            try
            {
                Toolkit toolkit = new Toolkit();
                toolkit.IPAddress = GetIP();
                toolkit.Type = "e-book";
                toolkit.PropertyAddress = "NA";
                return View(toolkit);
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
        public IActionResult ebook(Toolkit toolkit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var toolkits = _unitofWork.Toolkit.GetAll(tk => tk.IPAddress == toolkit.IPAddress &&
                    tk.Type == toolkit.Type);
                    if (toolkits.Count() == 0)
                    {
                        toolkit.PropertyAddress = "NA";
                        toolkit.uid = Guid.NewGuid().ToString();
                        _unitofWork.Toolkit.Add(toolkit);
                        _unitofWork.Save();
                        TempData["success"] = "E-book will be sent to you within 24 hours.";
                        SendEmail(toolkit);
                    }
                    else
                    {
                        TempData["error"] = "Failed ! You have already placed request for E-book.";
                    }
                }
                ModelState.Clear();
                Toolkit toolkitnew = new Toolkit();
                toolkitnew.Type = "e-book";
                toolkitnew.IPAddress = GetIP();
                return View(toolkitnew);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }

        }
        public IActionResult savingscalculator()
        {
            try
            {
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
        public JsonResult ValidateToolkitRequest(string IP, string toolkittype, string? address)
        {
            List<Toolkit> toolkits = new List<Toolkit>();
            try
            {
                if (address != null && address != string.Empty)
                {
                    toolkits = _unitofWork.Toolkit.GetAll(tk => tk.IPAddress == IP && tk.Type == toolkittype
                    && tk.PropertyAddress == address).ToList();
                }
                else
                {
                    toolkits = _unitofWork.Toolkit.GetAll(tk => tk.IPAddress == IP &&
                    tk.Type == toolkittype).ToList();
                }
            }
            catch (Exception ex)
            {
                LogErrorDetail(ex, "toolkit/ValidateToolkitRequest");
            }
            int count = 0;
            try
            {
                if (toolkits != null)
                    count = toolkits.Count();
            }
            catch (Exception ex)
            {
                LogErrorDetail(ex, "toolkit/ValidateToolkitRequest");
            }
            return new JsonResult(count);
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
