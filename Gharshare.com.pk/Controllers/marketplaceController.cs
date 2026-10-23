using Microsoft.AspNetCore.Mvc;
using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;

namespace Gharshare.com.pk.Controllers
{
    public class marketplaceController : Controller
    {
        private IUnitofWork _unitofWork;
        public marketplaceController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
       public IActionResult index()
        {
            return View();
        }
        public IActionResult bookconditionreport()
        {
            try
            {
                var faqs = _unitofWork.StaticContent.GetAll(faqs => 
                faqs.ContentType.Name == "Book Condition Report FAQs",
                    includeProperties: "ContentType").ToList();
                return View(faqs);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }

        }
        public IActionResult emergencyassistance()
        {
            try
            {
                var faqs = _unitofWork.StaticContent.GetAll(faqs => 
                faqs.ContentType.Name == "Emergency Assistance FAQs",
                    includeProperties: "ContentType").ToList();
                return View(faqs);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        public IActionResult hiretradeperson()
        {
            try
            {
                var faqs = _unitofWork.StaticContent.GetAll(faqs => 
                faqs.ContentType.Name == "Hire Tradeperson FAQs",
                    includeProperties: "ContentType").ToList();
                return View(faqs);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        public IActionResult landlordinsurance()
        {
            try
            {
                var faqs = _unitofWork.StaticContent.GetAll(faqs =>
                faqs.ContentType.Name == "Landlord Insurance FAQs",
                    includeProperties: "ContentType").ToList();
                return View(faqs);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        public IActionResult bookinspection()
        {
            try
            {
                var faqs = _unitofWork.StaticContent.GetAll(faqs => 
                faqs.ContentType.Name == "Book Inspection FAQs",
                    includeProperties: "ContentType").ToList();
                return View(faqs);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }

        }
        public IActionResult photography()
        {
            try
            {
                var faqs = _unitofWork.StaticContent.GetAll(faqs => 
                faqs.ContentType.Name == "Photography FAQs",
                    includeProperties: "ContentType").ToList();
                return View(faqs);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }

        }
        public IActionResult taxdepreciation()
        {
            try
            {
                var faqs = _unitofWork.StaticContent.GetAll(faqs =>
                faqs.ContentType.Name == "Book Inspection FAQs",
                    includeProperties: "ContentType").ToList();
                return View(faqs);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }

        }
        public IActionResult utilities()
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
    }
}
