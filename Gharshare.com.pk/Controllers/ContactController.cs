using Microsoft.AspNetCore.Mvc;
using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;

namespace TenancyManagement.Controllers
{
    public class ContactController : Controller
    {
        private IUnitofWork _unitofWork;

        public ContactController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Message message)
        {
            if (ModelState.IsValid)
            {
                message.uid = Guid.NewGuid().ToString();
                _unitofWork.Message.Add(message);
                _unitofWork.Save();
                TempData["success"] = "Your message has been received. We will contact you soon";
            }
            ModelState.Clear();
            message = new Message();
            //message.SenderName = string.Empty;
            //message.Subject = string.Empty;
            //message.Email = string.Empty;
            //message.Messagebody=string.Empty;
            return View(message);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Message message)
        {

            if (ModelState.IsValid)
            {
                _unitofWork.Message.update(message);
                _unitofWork.Save();
                ViewData["Success"] = "Your message has been sent. We will contact you soon";
                return View();
            }
            return View();
        }
    }
}
