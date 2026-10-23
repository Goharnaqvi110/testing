using Gharshare.CommonHelper;
using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gharshare.com.pk.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = WebSiteRoles.Role_Admin)]
    public class cmsController : Controller
    {
        private IUnitofWork _unitofWork;
        private Utility _utility;
        public cmsController(IUnitofWork unitofWork, Utility utility)
        {
            _unitofWork = unitofWork;
            _utility = utility;
        }
        public IActionResult getcontentlist(Int64 typeId, int pg = 1)
        {
            List<StaticContent> content = null;
            try
            {
                if (typeId != 0)
                {
                    content = _unitofWork.StaticContent.GetAll(sc => sc.ContentTypeID == typeId,
                        includeProperties: "CreatedbyUser").ToList();
                }
                else
                    content = _unitofWork.StaticContent.GetAll(sc => sc.Id > 0,
                            includeProperties: "CreatedbyUser").ToList();

                #region pagination
                if (content.Any())
                {
                    int pageSize = Pager.GetPageSize();
                    if (pg < 1)
                    {
                        pg = 1;
                    }
                    this.ViewBag.pg = pg;
                    int recsCount = content.Count();
                    int recSkip = (pg - 1) * pageSize;
                    content = content.Skip(recSkip).Take(pageSize).ToList();
                    var pager = new Pager(recsCount, pg, "cms", "index", pageSize, "", "",
                        content.Count());
                    this.ViewBag.Pager = pager;
                }
                #endregion
            }
            catch (Exception exp)
            {
                TempData["ErrorMessage"] = exp.Message;
                TempData["StackTrace"] = exp.StackTrace;
                TempData["Source"] = exp.Source;
                return RedirectToAction("Error", "Error");
            }

            return Json(content);
        }
        public IActionResult Index(int pg = 1)
        {
            List<StaticContent> content = null;
            try
            {
                content = _unitofWork.StaticContent.GetAll(sc => sc.Id > 0,
                    includeProperties: "ContentType,CreatedbyUser").ToList();
                var contentTypes = _unitofWork.ContentType.GetAll().OrderBy(c => c.Name).ToList()
                    .Select(c => new SelectListItem
                    {
                        Text = c.Name,
                        Value = c.ID.ToString(),
                    });
                ViewBag.ContentTypes = contentTypes;
                #region pagination
                if (content.Any())
                {
                    int pageSize = Pager.GetPageSize();
                    if (pg < 1)
                    {
                        pg = 1;
                    }
                    this.ViewBag.pg = pg;
                    int recsCount = content.Count();
                    int recSkip = (pg - 1) * pageSize;
                    content = content.Skip(recSkip).Take(pageSize).ToList();
                    var pager = new Pager(recsCount, pg, "cms", "index", pageSize, "", "",
                        content.Count());
                    this.ViewBag.Pager = pager;
                }
                #endregion
            }
            catch (Exception exp)
            {
                TempData["ErrorMessage"] = exp.Message;
                TempData["StackTrace"] = exp.StackTrace;
                TempData["Source"] = exp.Source;
                return RedirectToAction("Error", "Error");
            }

            return View(content);
        }

        [HttpGet]
        public IActionResult create()
        {
            StaticContent sc = new StaticContent();
            var contentTypes = _unitofWork.ContentType.GetAll().ToList().OrderBy(c => c.Name)
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.ID.ToString(),
                });
            ViewBag.ContentTypes = contentTypes;
            return View(sc);
        }
        [HttpPost]
        public IActionResult Create(StaticContent sc, IFormFile? file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (file != null)
                        //sc.Imagepath = _utility.SaveFile(file, @"assets/cms", 102400);
                        sc.Imagepath = _utility.SaveFile(file, @"assets/cms");
                    sc.CreatedbyUserId = HttpContext.Session.GetString("_UserId");
                    sc.UId = Guid.NewGuid().ToString();
                    _unitofWork.StaticContent.Add(sc);
                    _unitofWork.Save();
                    TempData["success"] = "Content saved successfully!";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
            return Redirect("index");
        }
        [HttpGet]
        public IActionResult Edit(string uid)
        {
            StaticContent sc;
            try
            {
                if (uid == null || uid == "")
                {
                    return NotFound();
                }
                else
                {
                    sc = _unitofWork.StaticContent.Get(sc => sc.UId == uid);
                    var contentTypes = _unitofWork.ContentType.GetAll().ToList().OrderBy(c => c.Name)
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.ID.ToString(),
                });
                    ViewBag.ContentTypes = contentTypes;
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
            return View(sc);
        }
        [HttpPost]
        public IActionResult Edit(StaticContent sc, IFormFile? file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (file != null)
                    {
                        _utility.DeletFile(sc.Imagepath);
                        sc.Imagepath = _utility.SaveFile(file, @"assets/cms");
                    }
                    sc.UpdatedbyUserId = HttpContext.Session.GetString("_UserId");
                    sc.UpdatedOn = DateTime.UtcNow;
                    _unitofWork.StaticContent.update(sc);
                    _unitofWork.Save();
                    TempData["success"] = "Content updated successfully!";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(string Id)
        {
            StaticContent sc;
            if (Id == null || Id == "")
            {
                return NotFound();
            }
            else
            {
                sc = _unitofWork.StaticContent.Get(sc => sc.UId == Id,
                    includeProperties: "CreatedbyUser");
            }
            return View(sc);
        }

        [HttpPost]
        public IActionResult delete(StaticContent  content)
        {
            try
            {
                var sc = _unitofWork.StaticContent.Get(sc => sc.UId == content.UId);
                _unitofWork.StaticContent.Delete(sc);
                _unitofWork.Save();
                TempData["success"] = "Content deleted successfully!";
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
    }
}
