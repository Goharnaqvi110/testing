using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using Gharshare.CommonHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using Gharshare.com.pk.Hubs;


namespace Gharshare.com.pk.Controllers
{
    public class chatController : Controller
    {
        private IUnitofWork _unitofWork;
        private Utility _utility;
        private readonly IHubContext<ChatHub> _chat;
        public chatController(IUnitofWork iUnitofWork, Utility utility, IHubContext<ChatHub> chat)
        {
            _unitofWork = iUnitofWork;
            _utility = utility;
            _chat = chat;
        }

        [HttpGet]
        public IActionResult messages(string lid)
        {
            try
            {
                var lease = _unitofWork.LeaseAgreement.Get(la => la.uid == lid);
                var messages = GetMessages(lease.ID);
                return View(messages);
            }

            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        public JsonResult LoadMessages(Int64 lid)
        {
            var messages = GetMessages(lid);
            return new JsonResult(messages);
        }
        private List<Message> GetMessages(Int64 lid)
        {

            List<Message> messages = new List<Message>();
            var currentUserId = HttpContext.Session.GetString("_UserId");             
            var lease = _unitofWork.LeaseAgreement.GetwithAllObjects(x => x.ID == lid,
            includes: t => t.Include(t => t.PrimaryTenant)
                                    .ThenInclude(u => u.User));
             
            string PrimaryTenantID = string.Empty;
            if (lease?.PrimaryTenant != null)
            {
                PrimaryTenantID = lease.PrimaryTenant.User.Id;
                ViewBag.PrimaryTenantID = PrimaryTenantID;
                ViewBag.Tenant = lease.PrimaryTenant.User;
            }             
            messages = _unitofWork.Message.GetAll(x => (x.Type == Message.MessageType.WithUser
            && x.FromUserID == currentUserId && x.ToUserID == PrimaryTenantID) ||
           (x.Type == Message.MessageType.WithUser && x.ToUserID == currentUserId
           && x.FromUserID == PrimaryTenantID),
               includeProperties: "FromUser,ToUser").ToList();
            try
            {
                messages.ForEach(msg =>
                {
                    if (msg.ToUserID == currentUserId && msg.Read == false)
                        msg.Read = true;
                });
                _unitofWork.Message.UpdateRange(messages);
                _unitofWork.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return messages;
        }
    }
}
