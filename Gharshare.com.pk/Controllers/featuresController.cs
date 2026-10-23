using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gharshare.com.pk.Controllers
{
    public class featuresController : Controller
    {
        private IUnitofWork _unitofWork;
        public featuresController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public IActionResult index()
        {
            try
            {
                var testimonials = _unitofWork.Testimonial.
                    GetAll(t => t.IsShown == true).ToList();
                return View(testimonials);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        public IActionResult features()
        {
            return View();
        }
        public IActionResult advertise()
        {
            try
            {
                var content = _unitofWork.StaticContent.GetAll(sc => sc.ContentTypeID == 1);                
                return View(content);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        public IActionResult enquiries()
        {
            try
            {
                var content = _unitofWork.StaticContent.GetAll(sc => sc.ContentTypeID == 2);
                return View(content);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        public IActionResult applications()
        {
            try
            {
                var content = _unitofWork.StaticContent.GetAll(sc => sc.ContentTypeID == 3);                 
                return View(content);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        public IActionResult tenantchecks()
        {
            try
            {
                var content = _unitofWork.StaticContent.GetAll(sc => sc.ContentTypeID == 4);                
                return View(content);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        public IActionResult leaseagreement()
        {
            try
            {
                var content = _unitofWork.StaticContent.GetAll(sc => sc.ContentTypeID == 5);                
                return View(content);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        public IActionResult tenantsetup()
        {
            try
            {
                var content = _unitofWork.StaticContent.GetAll(sc => sc.ContentTypeID == 6);                
                return View(content);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        public IActionResult conditionreport()
        {
            try
            {
                var content = _unitofWork.StaticContent.GetAll(sc => sc.ContentTypeID == 7);                
                return View(content);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        public IActionResult collectbond()
        {
            try
            {
                var content = _unitofWork.StaticContent.GetAll(sc => sc.ContentTypeID == 8);                
                return View(content);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        public IActionResult rentalpayments()
        {
            try
            {
                var content = _unitofWork.StaticContent.GetAll(sc => sc.ContentTypeID == 9);                
                return View(content);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        public IActionResult expenses()
        {
            try
            {
                var content = _unitofWork.StaticContent.GetAll(sc => sc.ContentTypeID == 10);             
                return View(content);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        public IActionResult tenantbills()
        {
            try
            {
                var content = _unitofWork.StaticContent.GetAll(sc => sc.ContentTypeID == 11);                
                return View(content);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        public IActionResult reports()
        {
            try
            {
                var content = _unitofWork.StaticContent.GetAll(sc => sc.ContentTypeID == 12);                
                return View(content);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        public IActionResult maintenance()
        {
            try
            {
                var content = _unitofWork.StaticContent.GetAll(sc => sc.ContentTypeID == 13);                
                return View(content);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        public IActionResult inspections()
        {
            try
            {
                var content = _unitofWork.StaticContent.GetAll(sc => sc.ContentTypeID == 14);                
                return View(content);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        public IActionResult documents()
        {
            try
            {
                var content = _unitofWork.StaticContent.GetAll(sc => sc.ContentTypeID == 15);                
                return View(content);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
    }
}
