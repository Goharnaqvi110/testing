using Gharshare.CommonHelper;
using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;

namespace Gharshare.com.pk.Controllers  //ShareHouse.pk.Controllers 
{
    [Authorize(Roles = WebSiteRoles.Role_Landlord + "," + WebSiteRoles.Role_Admin
        + "," + WebSiteRoles.Role_SuperAdmin + "," + WebSiteRoles.Role_Tenant)]
    public class ProfileController : Controller
    {
        private IUnitofWork _unitofWork;
        private Utility _utility;
        private readonly TwilioService _twilioService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public ProfileController(IUnitofWork unitofWork, Utility utility, TwilioService twilioService,
            SignInManager<ApplicationUser> signInManager)
        {
            _unitofWork = unitofWork;
            _utility = utility;
            _twilioService = twilioService;
            _signInManager = signInManager;
        }         

        [HttpGet]
        public bool checkmobilenumberstatus(string userId, string userMobilenum)
        {
            try
            {
                ApplicationUser user;
                if (!string.IsNullOrEmpty(userId))
                {
                    user = _unitofWork.User.Get(u => u.Id == userId.Trim());
                    if (user != null)
                    {
                        if (string.IsNullOrEmpty(user.Mobile))
                        {
                            user.Mobile = userMobilenum;
                            _unitofWork.User.update(user);
                            _unitofWork.Save();
                        }
                        if (user.Mobileverified)
                            return true;
                    }
                }
            }
            catch (Exception exp)
            {
                LogErrorDetail(exp, "profile/checkmobilenumberstatus");
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return true;
            }
            return false;
        }

        [HttpGet]
        public IActionResult index()
        {
            return View("hello world");
        }
        [HttpGet]
        public IActionResult verifymobilenumber(string mobilenumber)
        {
            return View("verifymobileno", mobilenumber);
        }
        [HttpPost]
        public JsonResult verifymobilenumber(string userId, string otp)
        {
            ApplicationUser user = _unitofWork.User.Get(u => u.Id == userId);
            try
            {
                //if (user.OTP == Convert.ToInt32(otp.Trim()))
                //{
                    user.Mobileverified = true;
                    _unitofWork.User.update(user);
                    _unitofWork.Save();
                    return new JsonResult("success");
                //}
            }
            catch (Exception exp)
            {
                LogErrorDetail(exp, "profile/verifymobilenumber(post)");
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { error = "failed" });
            }
            //return new JsonResult("failed");
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return Json(new { error = "failed" });
        }         
        [HttpGet]
        public IActionResult test()
        {
            return View();
        }
        [HttpGet]
        public IActionResult accountsettings(string userId)
        {
            ApplicationUser user = _unitofWork.User.Get(u => u.Id == userId);
            return View("accountsettings", user);             
        }
        [HttpPost]
        public IActionResult deleteaccount(string userId)
        {
            try
            {
                //Product owner asked for soft delete i.e.only deactivate user

                // First delete errors from error log related to user being deleted
                //var errlog = _unitofWork.ErrorLog.GetAll(e => e.LoggedInUserId == userId).ToList();
                //_unitofWork.ErrorLog.DeleteRange(errlog);

                var user = _unitofWork.User.Get(u => u.Id == userId);
                // _unitofWork.User.Delete(user); PO asked for soft delete i.e. only deactivate user
                user.IsActive = false;
                user.EmailConfirmed = false;
                _unitofWork.Save();
                // deactivate property listings of the user
                var propertyListings = _unitofWork.Property.GetAll(p => p.OwnerId == userId).ToList();
                if (propertyListings.Any())
                {
                    propertyListings.ForEach(p =>
                    {
                        p.IsActive = false;
                        p.IsAdlive = false;
                    });
                    _unitofWork.Property.UpdateRange(propertyListings);
                }
                // save all changes
                _unitofWork.Save();
                // Sign out the user and destroy the current session
                _signInManager.SignOutAsync();
                return new JsonResult("success");
            }
            catch (Exception exp)
            {
                TempData["ErrorMessage"] = exp.InnerException?.Message;
                TempData["StackTrace"] = exp.StackTrace;
                TempData["Source"] = exp.Source;
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { error = "internal server occur deleting your account. " });
            }
        }
        [HttpPost]
        public IActionResult deActivateaccount(string userId)
        {
            try
            {
                List<Property> propertylistings = _unitofWork.Property.GetAll(p => p.OwnerId == userId)
                    .ToList();                
                propertylistings.ForEach(p =>
                {
                    p.IsActive = false;
                    p.IsAdlive = false;
                });                 
                _unitofWork.Save();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.InnerException?.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
            return View("deactivateaccount");
        }
        [HttpGet]
        public IActionResult deActivateaccount()
        {
            return View("deactivateaccount");
        }
        [HttpPost]
        public JsonResult accountsettings(string userId, string name, string email,
            string mobile, bool showNumber, bool freetoMessage)
        {
            ApplicationUser user = _unitofWork.User.Get(u => u.Id == userId);
            try
            {
                user.Name = name;
                user.Email = email;
                user.Mobile = mobile;
                user.ShowNumber = showNumber;
                user.FreetoMessage = freetoMessage;
                _unitofWork.User.update(user);
                _unitofWork.Save();
            }
            catch (Exception exp)
            {
                LogErrorDetail(exp, "profile/accountsettings");
            }

            return new JsonResult(user);
        }
        [HttpPost]
        [Produces("application/json")]
        public JsonResult uploadProfileImage(string userId, IFormFile image)
        {
            ApplicationUser user = _unitofWork.User.Get(u => u.Id == userId);
            try
            {
                if (userId != null && image != null)
                {
                    _utility.DeletFile(user.ProfilePicture);
                    if(image.Length<= 100000)
                    user.ProfilePicture = _utility.SaveFile(image, @"assets/img/profile");
                    else
                        user.ProfilePicture = _utility.ResizeAndSaveImage(image, "assets/img/profile", 100000, 600,800);
                    _unitofWork.User.update(user);
                    _unitofWork.Save();
                }
            }
            catch (Exception exp)
            {
                LogErrorDetail(exp, "profile/uploadProfileImage");
            }
            return new JsonResult(user);
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
