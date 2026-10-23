using Gharshare.CommonHelper;
using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;

namespace Gharshare.com.pk.Controllers
{
    public class homeController : Controller
    {
        private IUnitofWork _unitofWork;
        private Utility _utility;
        private readonly TwilioService _twilioService;
        public homeController(IUnitofWork unitofWork, Utility utility, TwilioService twilioService)
        {
            _unitofWork = unitofWork;
            _utility = utility;
            _twilioService = twilioService;
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
        public bool checkUsername(string userName)
        {
            try
            {
                ApplicationUser user;
                int atIndex = userName.IndexOf("@");
                string usersub = userName.Substring(0, atIndex);                 
                if (!string.IsNullOrEmpty(userName))
                {
                    user = _unitofWork.User.Get(u => u.Email == userName.Trim() || u.UserName== usersub.Trim());
                    if (user != null)
                        return true;
                }
            }
            catch (Exception exp)
            {
                LogErrorDetail(exp, "home/checkUsername");
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return true;
            }
            return false;
        }
        private string GenerateOtp()
        {
            // generate a random OTP
            return new Random().Next(1000, 9999).ToString(); //+15075333943
        }

        public async Task<JsonResult> getProperties(int pg)
        {
            var _properties = _unitofWork.Property.GetAll
                    (x => x.IsActive == true && x.IsAdlive == true && x.blockedbyAdmin == false &&
                    x.CityID != null, includeProperties: "State,City")
                    .OrderByDescending(x => x.CreatedOn).ToList();
            int pageSize = Pager.GetPageSize();
            if (pg < 1)
                pg = 1;
            int recsCount = _properties.Count();
            int recSkip = (pg - 1) * pageSize;
            _properties = _properties.Skip(recSkip).Take(pageSize).ToList();             
            return new JsonResult(_properties);
        }
        public IActionResult index(int pg = 1)
        {            
            #region Test code for sending OTP
            //try
            //{
            //    string otp = GenerateOtp();

            //    // save the OTP to a database or cache for later verification

            //    // send the OTP via SMS using Twilio
            //    string message = $"Your OTP is {otp}.";
            //    _twilioService.SendSmsAsync("+923435289966", message);

            //    return Ok();
            //}
            //catch(Exception ex)
            //{

            //}
            #endregion 

            HomeVM homeVM = new HomeVM();
            try
            {
                var plans = _unitofWork.Plan.GetAll().ToList();
                var services = _unitofWork.Service.GetAll().ToList();
                var planservices = _unitofWork.PlanService.GetAll().ToList();

                var _content = _unitofWork.StaticContent.GetAll(sc => sc.ContentTypeID == 16);     
                
                var _properties = _unitofWork.Property.GetAll
                    (x => x.IsActive == true && x.IsAdlive == true && x.blockedbyAdmin==false &&
                    x.CityID != null,includeProperties: "State,City")
                    .OrderByDescending(x=>x.CreatedOn).ToList();               

                #region apply paging on properties
                int pageSize = Pager.GetPageSize();
                if (pg < 1)
                    pg = 1;
                int recsCount = _properties.Count();                
                int recSkip = (pg - 1) * pageSize;
                _properties=_properties.Skip(recSkip).Take(pageSize).ToList();                 
                var pager = new Pager(recsCount, pg, "home", "index", pageSize, null, "", _properties.Count(), "getProperties");
                ViewBag.Pager=pager;
                #endregion
                homeVM.StaticContent = _content;
                homeVM.Properties = _properties;
                homeVM.demoRequest = new DemoRequest();
                homeVM.Testimonials = _unitofWork.Testimonial.GetAll(t => t.IsShown == true)
                    .ToList();
                homeVM.Cities = LoadCities();
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("The action method"))
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("HttpStatusCodeHandler", "Error", new { statusCode = 404 });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
            return View(homeVM);
        }
        private List<SelectListItem> LoadCities()
        {
            IEnumerable<SelectListItem> Cities = _unitofWork.City.GetAll()
                .OrderBy(c => c.Name).ToList().OrderBy(c=>c.Name)
                .Select(x => new SelectListItem()
                    {
                        Text = x.Name,
                        Value = Convert.ToString(x.ID)
                    }
                    );
            return Cities.ToList();
        }
        public JsonResult SaveEnquiry(int about, string name, string email, string mobile,
           string pid, string message)
        {
            try
            {
                PropertyEnquiry enquiry = new PropertyEnquiry
                {
                    About = (PropertyEnquiry.Enquriy?)about,
                    Name = name,
                    Email = email,
                    Mobile = mobile,
                    Message = message,
                    PropertyID = Convert.ToInt64(pid),
                    EnquiryType = PropertyEnquiry.Type.TextMessage,
                    Status = PropertyEnquiry.EnquiryStatus.unread,
                    uid = Guid.NewGuid().ToString()
            };
                _unitofWork.PropertyEnquiry.Add(enquiry);
                _unitofWork.Save();
            }
            catch (Exception ex)
            {
                LogErrorDetail(ex, "home/SaveEnquiry");
            }
            return new JsonResult("success");
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult newenquiry(PropertyVM propertyvm)
        {
            try
            {
                if (propertyvm.Enquiry != null)
                {
                    propertyvm.Enquiry.UId = Guid.NewGuid().ToString();
                    _unitofWork.Enquiry.Add(propertyvm.Enquiry);
                    _unitofWork.Save();
                    TempData["success"] = "Enquiry sent. We will get back to you soon !";
                }
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("The action method"))
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("HttpStatusCodeHandler", "Error", new { statusCode = 404 });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult newenquiry()
        {
            PropertyEnquiry propertyEnquiry = new PropertyEnquiry();
            try
            {
                propertyEnquiry.PropertyID = Convert.ToInt64(HttpContext.Session.GetString("PropertyID"));
                propertyEnquiry.Status = PropertyEnquiry.EnquiryStatus.unread;
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("The action method"))
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("HttpStatusCodeHandler", "Error", new { statusCode = 404 });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
            return View(propertyEnquiry);
        }
    }
}
