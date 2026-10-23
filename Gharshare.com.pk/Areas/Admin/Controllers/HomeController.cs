using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Gharshare.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private IUnitofWork _unitofWork;
        public HomeController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }      


    }
}
