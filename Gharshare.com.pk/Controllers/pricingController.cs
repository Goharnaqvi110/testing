using Microsoft.AspNetCore.Mvc;
using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;

namespace Gharshare.com.pk.Controllers
{
    public class pricingController : Controller
    {
        private IUnitofWork _unitofWork;
        public pricingController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public IActionResult index()
        {
            try
            {
                vmPricing vmPricing = new vmPricing();
                var plans = _unitofWork.Plan.GetAll().ToList(); ;
                var services = _unitofWork.Service.GetAll(s => s.IsActive == true)
                    .ToList();
                vmPricing.Match = _unitofWork.Service.GetAll(s => s.IsActive == true &&
                s.Type == Service.ServiceType.Match).ToList();
                vmPricing.Manage = _unitofWork.Service.GetAll(s =>s.Type==Service.ServiceType.Manage 
                && s.IsActive == true)
                    .ToList();
                vmPricing.Maintain = _unitofWork.Service.GetAll(s => s.IsActive == true &&
                s.Type == Service.ServiceType.Maintain).ToList();
                vmPricing.Testimonials = _unitofWork.Testimonial.GetAll(t => t.IsShown == true)
                    .ToList();
                vmPricing.Plans = plans;
                vmPricing.Services = services;
                return View(vmPricing);
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
