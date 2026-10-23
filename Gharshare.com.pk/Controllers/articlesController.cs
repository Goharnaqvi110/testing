using Gharshare.CommonHelper;
using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using Microsoft.AspNetCore.Mvc;

namespace smartpropertymanager.pk.Controllers
{
    public class articlesController : Controller
    {
        private IUnitofWork _unitofWork;
        private Utility _utility;
        public articlesController(IUnitofWork iUnitofWork, Utility utility)
        {
            _unitofWork = iUnitofWork;
            _utility = utility;
        }
        public IActionResult detail(string id)
        {
            StaticContent blog = null;
            try
            {
                if (id != null)
                    blog = _unitofWork.StaticContent.Get(blog => blog.UId == id);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
            return View(blog);
        }
        public IActionResult index(string type, int pg = 1)
        {
            vmBlog vmBlog = null;
             
            try
            {                 
               var articles = _unitofWork.StaticContent.GetAll(sc => sc.Id > 0 && sc.isFeatured==false
               && ! sc.ContentType.Name.Contains("FAQs"),
                    includeProperties: "CreatedbyUser")
                    .OrderByDescending(sc => sc.CreatedOn).ToList();
                var featuredArticle = _unitofWork.StaticContent.Get(sc => sc.isFeatured == false
                    && !sc.ContentType.Name.Contains("FAQs"),
                    includeProperties: "CreatedbyUser");

                #region pagination 
                int pageSize = Pager.GetPageSize();
                if (pg < 1)
                {
                    pg = 1;
                }
                this.ViewBag.pg = pg;
                int recsCount = articles.Count();
                int recSkip = (pg - 1) * pageSize;
                articles = articles.Skip(recSkip).Take(pageSize).ToList();
                var pager = new Pager(recsCount, pg, "info", "content", pageSize, "", type,
                    articles.Count());
                this.ViewBag.Pager = pager;
                #endregion                

                vmBlog = new vmBlog
                {
                    Articles=articles,
                    FeaturedArticle= featuredArticle,
                };
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
            return View(vmBlog);
        }
    }
}
