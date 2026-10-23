using Gharshare.CommonHelper;
using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.DataAccessLayer.Data.Infrastructure.Repository;
using Gharshare.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Gharshare.com.pk.Controllers
{
    public class aboutController : Controller
    {
        private IUnitofWork _unitOfWork;
        private readonly IEmailSender _emailSender;
        public aboutController(IUnitofWork unitOfWork, IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
        }
        public IActionResult index()
        {
            return View();
        }
        [HttpGet("refertofriend", Name = "refertofriend")]
        public IActionResult refertofriend()
        {
            var referral = new Referral();
            return View(referral);
        }
        [HttpPost("refertofriend", Name = "refertofriend")]
        public IActionResult refertofriend(Referral referral)
        {
            if (ModelState.IsValid)
            {
                referral.ReferredbyUserID = HttpContext.Session.GetString("_UserId");
                referral.UId = Guid.NewGuid().ToString();
                _unitOfWork.Referral.Add(referral);
                _unitOfWork.Save();
                SendReferralEmailtoFriend(referral);
                TempData["success"] = "Referral email has been sent out to your friend successfully!";
            }
            else
            ModelState.AddModelError("", "There was an error with your submission.");
            ModelState.Clear();
            var newReferral = new Referral();
            return View(newReferral);
        }
        private async void SendReferralEmailtoFriend(Referral referral)
        {
            var emailTemplate = _unitOfWork.EmailTemplate.Get(t => t.Title == "referral");
            var emailTemplateString = emailTemplate.Template;
            var loggedinUserId= HttpContext.Session.GetString("_UserId");
            var loggedinUser = _unitOfWork.User.Get(u => u.Id == loggedinUserId);
            // Replace the placeholder with the actual friend's name and recipient name
            emailTemplateString = emailTemplateString.Replace("[FriendName]", loggedinUser.Name);
            emailTemplateString = emailTemplateString.Replace("[recipient]", referral.RecipientName);
            var subject = loggedinUser.Name + " referred to you to smartpropertymanager.pk";
            await _emailSender.SendEmailAsync(referral.Email, subject, emailTemplateString);
        }
        [HttpGet]
        public bool checkReferralStatus(string emailAddress)
        {
            var friendIsAlreadyReferred = false;
            try
            {                 
                if (!string.IsNullOrEmpty(emailAddress))
                {
                    var referral = _unitOfWork.Referral.Get(r => r.Email == emailAddress);
                    if (referral != null)
                    {
                        friendIsAlreadyReferred = true;
                        return friendIsAlreadyReferred;
                    }                       
                }
            }
            catch (Exception exp)
            {
                LogErrorDetail(exp, "home/checkUsername");
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return friendIsAlreadyReferred;
            }
            return friendIsAlreadyReferred;
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
                _unitOfWork.ErrorLog.Add(errorLog);
                _unitOfWork.Save();
            }
            catch (Exception exp)
            {

                throw;
            }
        }
    }
}
