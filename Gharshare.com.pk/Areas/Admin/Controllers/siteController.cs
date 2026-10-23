using Gharshare.CommonHelper;
using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;

namespace Gharshare.com.pk.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = WebSiteRoles.Role_Admin + "," + WebSiteRoles.Role_SuperAdmin)]
    public class siteController : Controller
    {
        private IUnitofWork _unitofWork;
        public siteController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        [HttpPost]
        public IActionResult addtemplatetype(EmailTemplateType emailTemplateType)
        {
            var scenario = "";
            try
            {
                if (ModelState.IsValid)
                {
                    var emailTemplateTypeinDb = _unitofWork.EmailTemplateType.Get(
                        c => c.Title == emailTemplateType.Title.Trim());
                    if (emailTemplateTypeinDb != null)
                        _unitofWork.EmailTemplateType.Detach(emailTemplateTypeinDb);

                    if (emailTemplateTypeinDb != null && emailTemplateType.ID == 0) // add scenario
                    {
                        Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        return Json(new { error = "Email template type name already exists" });
                    }
                    else
                    {
                        if (emailTemplateType.ID > 0)
                        {
                            emailTemplateType.UpdatedbyUserId = HttpContext.Session.
                                GetString("_UserId");
                            emailTemplateType.UpdatedOn = DateTime.UtcNow;
                            _unitofWork.EmailTemplateType.update(emailTemplateType);
                            scenario = "edit";
                        }
                        else
                        {
                            emailTemplateType.CreatedbyUserId = HttpContext.Session.
                                GetString("_UserId");
                            emailTemplateType.UId = Guid.NewGuid().ToString();
                            _unitofWork.EmailTemplateType.Add(emailTemplateType);
                            scenario = "add";
                        }
                        _unitofWork.Save();
                    }
                }
            }
            catch (Exception exp)
            {
                TempData["ErrorMessage"] = exp.InnerException?.Message;
                TempData["StackTrace"] = exp.StackTrace;
                TempData["Source"] = exp.Source;
                return RedirectToAction("Error", "Error");
            }
            return (new JsonResult(scenario));
        }
        [HttpGet]
        public IActionResult addtemplatetype(Int64? typeId)
        {
            EmailTemplateType emailTemplateType = null;
            if (typeId != null)
            {
                emailTemplateType = _unitofWork.EmailTemplateType.Get(t => t.ID == typeId);
            }
            else
            {
                emailTemplateType = new EmailTemplateType();
            }
            return View(emailTemplateType);
        }
        [HttpGet]
        public IActionResult templatetypes(int pg = 1)
        {
            List<EmailTemplateType> emailTemplates = null;
            try
            {
                var emailTemplateTypes = _unitofWork.EmailTemplateType.GetAll(includeProperties:
                    "CreatedbyUser").OrderBy(c => c.Title).ToList();
                #region Pagination
                int pageSize = Pager.GetPageSize();
                if (pg < 1)
                {
                    pg = 1;
                }
                int recsCount = emailTemplateTypes.Count();
                int recSkip = (pg - 1) * pageSize;
                emailTemplates = emailTemplateTypes.Skip(recSkip).Take(pageSize).ToList();
                var pager = new Pager(recsCount, pg, "site", "templatetypes", pageSize, "", "",
                   emailTemplates.Count());
                this.ViewBag.Pager = pager;
                #endregion end pagination   
            }
            catch (Exception exp)
            {
                TempData["ErrorMessage"] = exp.InnerException?.Message;
                TempData["StackTrace"] = exp.StackTrace;
                TempData["Source"] = exp.Source;
                return RedirectToAction("Error", "Error");
            }
            return View(emailTemplates);
        }
        [HttpPost]
        public IActionResult deleteemailtemplate(EmailTemplate emailTemplate)
        {
            if (emailTemplate != null)
            {
                _unitofWork.EmailTemplate.Delete(emailTemplate);
                _unitofWork.Save();
                TempData["success"] = "Email template successfully deleted!";
            }
            return RedirectToAction("emailtemplates", "site", new { area = "admin" });
        }
        [HttpGet]
        public IActionResult deleteemailtemplate(string? templateId)
        {
            EmailTemplate emailTemplate = null;
            try
            {
                if (templateId != null)
                {
                    emailTemplate = _unitofWork.EmailTemplate.Get(et => et.UId == templateId);
                }
            }
            catch (Exception exp)
            {
                TempData["ErrorMessage"] = exp.InnerException?.Message;
                TempData["StackTrace"] = exp.StackTrace;
                TempData["Source"] = exp.Source;
                return RedirectToAction("Error", "Error");
            }
            return View(emailTemplate);
        }
        [HttpPost]
        public IActionResult createemailtemplate(EmailTemplate emailTemplate)
        {
            try
            {
                if (emailTemplate != null)
                {
                    if (emailTemplate.ID > 0)
                    {
                        emailTemplate.UpdatedbyUserId = HttpContext.Session.GetString("_UserId");
                        emailTemplate.UpdatedOn = DateTime.UtcNow;                        
                        _unitofWork.EmailTemplate.update(emailTemplate);
                        TempData["success"] = "Email template successfully updated!";
                    }
                    else
                    {
                        emailTemplate.UId = Guid.NewGuid().ToString();
                        emailTemplate.CreatedbyUserId = HttpContext.Session.GetString("_UserId");
                        _unitofWork.EmailTemplate.Add(emailTemplate);
                        TempData["success"] = "Email template successfully saved!";
                    }
                    _unitofWork.Save();
                }
            }
            catch (Exception exp)
            {
                TempData["ErrorMessage"] = exp.InnerException?.Message;
                TempData["StackTrace"] = exp.StackTrace;
                TempData["Source"] = exp.Source;
                return RedirectToAction("Error", "Error");
            }
            return Redirect("emailtemplates");
        }
        [HttpGet]
        public IActionResult createemailtemplate(string? templateId)
        {
            EmailTemplateVM emailTemplateVM = null;
            EmailTemplate emailTemplate = null;
            try
            {
                //var emailTemplateTypes = _unitofWork.EmailTemplateType.GetAll(t => t.IsActive == true).
                //    OrderBy(t => t.Title).ToList().Select(x => new SelectListItem()
                //    {
                //        Text = x.Title,
                //        Value = x.ID.ToString()
                //    });


                if (templateId != null)
                {
                    emailTemplate = _unitofWork.EmailTemplate.Get(et => et.UId == templateId);
                    ViewBag.Case = "edit";
                }
                else
                {
                    emailTemplate = new EmailTemplate();
                    ViewBag.Case = "add";
                }                 
            }
            catch (Exception exp)
            {
                TempData["ErrorMessage"] = exp.InnerException?.Message;
                TempData["StackTrace"] = exp.StackTrace;
                TempData["Source"] = exp.Source;
                return RedirectToAction("Error", "Error");
            }
            return View(emailTemplate);
        }
        [HttpGet]
        public IActionResult emailtemplates(int pg = 1)
        {
            List<EmailTemplate> data = null;
            try
            {
                var emailTemplates = _unitofWork.EmailTemplate.GetAll(includeProperties:
                    "CreatedbyUser").OrderBy(c => c.Title).ToList();
                #region Pagination
                int pageSize = Pager.GetPageSize();
                if (pg < 1)
                {
                    pg = 1;
                }
                int recsCount = emailTemplates.Count();
                int recSkip = (pg - 1) * pageSize;
                data = emailTemplates.Skip(recSkip).Take(pageSize).ToList();
                var pager = new Pager(recsCount, pg, "site", "emailtemplates", pageSize, "", "",
                    data.Count());
                this.ViewBag.Pager = pager;
                #endregion end pagination   
            }
            catch (Exception exp)
            {
                TempData["ErrorMessage"] = exp.InnerException?.Message;
                TempData["StackTrace"] = exp.StackTrace;
                TempData["Source"] = exp.Source;
                return RedirectToAction("Error", "Error");
            }
            return View(data);
        }

        [HttpPost]
        public IActionResult deletecontentytype(ContentType contentType)
        {
            try
            {
                _unitofWork.ContentType.Delete(contentType);
                _unitofWork.Save();
            }
            catch (Exception exp)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { error = "error deleting record" });
            }
            return Redirect("index");
        }
        [HttpGet]
        public IActionResult deletecontentytype(string contentTypeId)
        {
            var contentType = _unitofWork.ContentType.Get(c => c.uid == contentTypeId);
            return View(contentType);
        }
        [HttpPost]
        public IActionResult addcontentType(ContentType contentType)
        {
            var scenario = "";
            try
            {
                if (ModelState.IsValid)
                {
                    var contentTypeinDb = _unitofWork.ContentType.Get(c => c.Name == contentType.Name.Trim());
                    if (contentTypeinDb != null)
                        _unitofWork.ContentType.Detach(contentTypeinDb);

                    if (contentTypeinDb != null && contentTypeinDb.ID == 0) // add scenario
                    {
                        Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        return Json(new { error = "Content type already exists" });
                    }
                    else
                    {
                        if (contentType.ID > 0)
                        {
                            _unitofWork.ContentType.update(contentType);
                            scenario = "edit";
                        }
                        else
                        {
                            contentType.CreatedOn = DateTime.UtcNow;
                            contentType.uid = Guid.NewGuid().ToString();
                            _unitofWork.ContentType.Add(contentType);
                            scenario = "add";
                        }
                        _unitofWork.Save();
                    }
                }
            }
            catch (Exception exp)
            {
                TempData["ErrorMessage"] = exp.InnerException?.Message;
                TempData["StackTrace"] = exp.StackTrace;
                TempData["Source"] = exp.Source;
                return RedirectToAction("Error", "Error");
            }
            return (new JsonResult(scenario));
        }
        [HttpGet]
        public IActionResult addcontentType(Int64? contentTypeId)
        {
            ContentType contentType = null;
            try
            {
                if (contentTypeId != null)
                {
                    contentType = _unitofWork.ContentType.Get(c => c.ID == contentTypeId);
                }
                else
                {
                    contentType = new ContentType();
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
            return View(contentType);
        }
        [HttpGet]
        public IActionResult contenttypes(int pg = 1)
        {
            List<ContentType> data = null;
            try
            {
                var cities = _unitofWork.ContentType.GetAll().OrderBy(c => c.Name).ToList();
                #region Pagination
                int pageSize = Pager.GetPageSize();
                if (pg < 1)
                {
                    pg = 1;
                }
                int recsCount = cities.Count();
                int recSkip = (pg - 1) * pageSize;
                data = cities.Skip(recSkip).Take(pageSize).ToList();
                var pager = new Pager(recsCount, pg, "site", "contenttypes", pageSize, "", "",
                    data.Count());
                this.ViewBag.Pager = pager;
                #endregion end pagination   
            }
            catch (Exception exp)
            {
                TempData["ErrorMessage"] = exp.InnerException?.Message;
                TempData["StackTrace"] = exp.StackTrace;
                TempData["Source"] = exp.Source;
                return RedirectToAction("Error", "Error");
            }
            return View(data);
        }
        [HttpGet]
        public IActionResult transactions(int pg = 1)
        {
            //var userId = HttpContext.Session.GetString("_UserId");
            var payments = _unitofWork.UserPayment.GetAll(includeProperties: "User,Plan").ToList();
            #region Pagination
            int pageSize = Pager.GetPageSize();
            if (pg < 1)
            {
                pg = 1;
            }
            int recsCount = payments.Count();
            int recSkip = (pg - 1) * pageSize;
            var data = payments.Skip(recSkip).Take(pageSize).ToList();
            var pager = new Pager(recsCount, pg, "site", "transactions", pageSize, "", "",
                data.Count());
            ViewBag.Pager = pager;
            #endregion end pagination
            return View(data);
        }
        [HttpPost]
        public IActionResult deletefeature(Feature feature)
        {
            try
            {
                _unitofWork.Feature.Delete(feature);
                _unitofWork.Save();
            }
            catch (Exception exp)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { error = "error deleting feature" });
            }
            return Redirect("index");
        }
        [HttpGet]
        public IActionResult deletefeature(Int64 featureId)
        {
            var feature = _unitofWork.Feature.Get(a => a.ID == featureId);
            return View(feature);
        }
        public IActionResult featurelist()
        {
            List<Feature> features = null;
            try
            {
                features = _unitofWork.Feature.GetAll().ToList();
            }
            catch (Exception exp)
            {
                TempData["ErrorMessage"] = exp.InnerException?.Message;
                TempData["StackTrace"] = exp.StackTrace;
                TempData["Source"] = exp.Source;
                return RedirectToAction("Error", "Error");
            }
            return View(features);
        }
        [HttpGet]
        public IActionResult addfeature(Int64? Id)
        {
            Feature feature = null;
            if (Id != null)
            {
                feature = _unitofWork.Feature.Get(a => a.ID == Id);
            }
            else
            {
                feature = new Feature();
            }
            return View(feature);
        }
        [HttpPost]
        public IActionResult addfeature(Feature feature)
        {
            var scenario = "";
            try
            {
                if (ModelState.IsValid)
                {
                    var featureinDb = _unitofWork.Feature.Get(
                        c => c.ID == feature.ID);
                    if (featureinDb != null)
                        _unitofWork.Feature.Detach(featureinDb);

                    if (featureinDb != null && feature.ID == 0) // add scenario
                    {
                        Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        return Json(new { error = "Feature already exists" });
                    }
                    else
                    {
                        if (feature.ID > 0)
                        {
                            _unitofWork.Feature.update(feature);
                            scenario = "edit";
                        }
                        else
                        {
                            feature.CreatedOn = DateTime.UtcNow;
                            feature.uid = Guid.NewGuid().ToString();
                            _unitofWork.Feature.Add(feature);
                            scenario = "add";
                        }
                        _unitofWork.Save();
                    }
                }
            }
            catch (Exception exp)
            {
                TempData["ErrorMessage"] = exp.InnerException?.Message;
                TempData["StackTrace"] = exp.StackTrace;
                TempData["Source"] = exp.Source;
                return RedirectToAction("Error", "Error");
            }
            return (new JsonResult(scenario));
        }
        [HttpPost]
        public IActionResult deleteaccepting(Accepting accepting)
        {
            try
            {
                _unitofWork.Accepting.Delete(accepting);
                _unitofWork.Save();
            }
            catch (Exception exp)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { error = "error deleting accepting item" });
            }
            return Redirect("index");
        }
        [HttpGet]
        public IActionResult deleteaccepting(Int64 acceptingId)
        {
            var accepting = _unitofWork.Accepting.Get(a => a.ID == acceptingId);
            return View(accepting);
        }
        public IActionResult acceptinglist()
        {
            List<Accepting> acceptings = null;
            try
            {
                acceptings = _unitofWork.Accepting.GetAll().ToList();
            }
            catch (Exception exp)
            {
                TempData["ErrorMessage"] = exp.InnerException?.Message;
                TempData["StackTrace"] = exp.StackTrace;
                TempData["Source"] = exp.Source;
                return RedirectToAction("Error", "Error");
            }
            return View(acceptings);
        }
        [HttpGet]
        public IActionResult addaccepting(Int64? Id)
        {
            Accepting accepting = null;
            if (Id != null)
            {
                accepting = _unitofWork.Accepting.Get(a => a.ID == Id);
            }
            else
            {
                accepting = new Accepting();
            }
            return View(accepting);
        }
        [HttpPost]
        public IActionResult addaccepting(Accepting accepting)
        {
            var scenario = "";
            try
            {
                if (ModelState.IsValid)
                {
                    var acceptinginDb = _unitofWork.Accepting.Get(
                        c => c.ID == accepting.ID);
                    if (acceptinginDb != null)
                        _unitofWork.Accepting.Detach(acceptinginDb);

                    if (acceptinginDb != null && accepting.ID == 0) // add scenario
                    {
                        Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        return Json(new { error = "Accepting items already exists" });
                    }
                    else
                    {
                        if (accepting.ID > 0)
                        {
                            _unitofWork.Accepting.update(accepting);
                            scenario = "edit";
                        }
                        else
                        {
                            accepting.CreatedOn = DateTime.UtcNow;
                            accepting.uid = Guid.NewGuid().ToString();
                            _unitofWork.Accepting.Add(accepting);
                            scenario = "add";
                        }
                        _unitofWork.Save();
                    }
                }
            }
            catch (Exception exp)
            {
                TempData["ErrorMessage"] = exp.InnerException?.Message;
                TempData["StackTrace"] = exp.StackTrace;
                TempData["Source"] = exp.Source;
                return RedirectToAction("Error", "Error");
            }
            return (new JsonResult(scenario));
        }
        public IActionResult Index()
        {
            DashboardVM dashboardvm = null;
            try
            {
                var properties = _unitofWork.Property.GetAll(p => p.IsActive == true
                && p.IsActive == true).ToList().Count();

                var landlords = _unitofWork.User.GetAll(u => u.UserType == ApplicationUser.usertype.landlord)
                .ToList().Count();

                var tenants = _unitofWork.User.GetAll(u => u.UserType == ApplicationUser.usertype.tenant)
                .ToList().Count();

                var Customers = _unitofWork.User.GetAll(u => u.UserType == ApplicationUser.usertype.tenant
                   || u.UserType == ApplicationUser.usertype.landlord
                   || u.UserType == ApplicationUser.usertype.tenant).ToList();

                var totalCustomers = Customers.Count();

                var totalEarnings = _unitofWork.UserPayment.GetAll().Sum(up => up.Amount);
                var totalAds = _unitofWork.Property.GetAll(p => p.IsActive == true
                && p.IsAdlive == true).ToList().Count();

                var tenantPercent = 0;
                var landlordPercent = 0;

                if (totalCustomers > 0)
                {
                    landlordPercent = landlords * 100 / totalCustomers;
                    tenantPercent = tenants * 100 / totalCustomers;
                }
                dashboardvm = new DashboardVM
                {
                    properties = properties,
                    totalAds = totalAds,
                    totalCustomers = totalCustomers,
                    totalEarnings = totalEarnings,
                    tenantPercent = tenantPercent,
                    landlordPercent = landlordPercent,
                    landlords=landlords,
                    tenants=tenants,
                    recentCustomers = Customers.OrderByDescending(c => c.DateCreated).Take(5).ToList(),
                };
            }
            catch (Exception exp)
            {
                TempData["ErrorMessage"] = exp.InnerException?.Message;
                TempData["StackTrace"] = exp.StackTrace;
                TempData["Source"] = exp.Source;
                return RedirectToAction("Error", "Error");
            }
            return View(dashboardvm);
        }
        [HttpPost]
        public IActionResult deletecity(City city)
        {
            try
            {
                _unitofWork.City.Delete(city);
                _unitofWork.Save();
            }
            catch (Exception exp)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { error = "error deleting city" });
            }
            return Redirect("index");
        }
        [HttpGet]
        public IActionResult deletecity(Int64 cityId)
        {
            var city = _unitofWork.City.Get(c => c.ID == cityId, includeProperties: "State");
            return View(city);
        }
        [HttpPost]
        public IActionResult addcity(City city)
        {
            var scenario = "";
            try
            {
                if (ModelState.IsValid)
                {
                    var cityinDb = _unitofWork.City.Get(c => c.Name == city.Name.Trim());
                    if (cityinDb != null)
                        _unitofWork.City.Detach(cityinDb);

                    if (cityinDb != null && city.ID == 0) // add city scenario
                    {
                        Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        return Json(new { error = "City name already exists" });
                    }
                    else
                    {
                        if (city.ID > 0)
                        {
                            _unitofWork.City.update(city);
                            scenario = "edit";
                        }
                        else
                        {
                            city.DateCreated = DateTime.UtcNow;
                            city.uid = Guid.NewGuid().ToString();
                            _unitofWork.City.Add(city);
                            scenario = "add";
                        }
                        _unitofWork.Save();
                    }
                }
            }
            catch (Exception exp)
            {
                TempData["ErrorMessage"] = exp.InnerException?.Message;
                TempData["StackTrace"] = exp.StackTrace;
                TempData["Source"] = exp.Source;
                return RedirectToAction("Error", "Error");
            }
            return (new JsonResult(scenario));
        }
        [HttpGet]
        public IActionResult addcity(Int64? cityId)
        {
            City city = null;
            try
            {
                if (cityId != null)
                {
                    city = _unitofWork.City.Get(c => c.ID == cityId, includeProperties: "State");
                }
                else
                {
                    city = new City();
                }
                var Provinces = _unitofWork.State.GetAll()
                    .OrderBy(p => p.Name).ToList().Select(
                        x => new SelectListItem()
                        {
                            Text = x.Name,
                            Value = Convert.ToString(x.ID)
                        }
                        );
                ViewBag.Provinces = Provinces;
                ViewData["Provinces"] = Provinces;
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
            return View("addcity", city);
        }
        [HttpGet]
        public IActionResult cities(int pg = 1)
        {
            List<City> data = null;
            try
            {
                var cities = _unitofWork.City.GetAll().OrderBy(c => c.Name).ToList();
                #region Pagination
                int pageSize = Pager.GetPageSize();
                if (pg < 1)
                {
                    pg = 1;
                }
                int recsCount = cities.Count();
                int recSkip = (pg - 1) * pageSize;
                data = cities.Skip(recSkip).Take(pageSize).ToList();
                var pager = new Pager(recsCount, pg, "site", "cities", pageSize, "", "",
                    data.Count());
                this.ViewBag.Pager = pager;
                #endregion end pagination   
            }
            catch (Exception exp)
            {
                TempData["ErrorMessage"] = exp.InnerException?.Message;
                TempData["StackTrace"] = exp.StackTrace;
                TempData["Source"] = exp.Source;
                return RedirectToAction("Error", "Error");
            }
            return View(data);
        }
        [HttpPost]
        public IActionResult settings(Sitesetting sitesetting)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (sitesetting.ID > 0)
                    {
                        sitesetting.UpdatedOn = DateTime.UtcNow;
                        sitesetting.UpdatedbyUserId = HttpContext.Session.GetString("_UserId");
                        _unitofWork.Sitesetting.update(sitesetting);
                    }
                    else
                    {
                        sitesetting.CreatedOn = DateTime.UtcNow;
                        sitesetting.CreatedbyUserId = HttpContext.Session.GetString("_UserId");
                        sitesetting.UId = Guid.NewGuid().ToString();
                        _unitofWork.Sitesetting.Add(sitesetting);
                    }
                    _unitofWork.Save();
                    TempData["success"] = "Site settings successfully saved!";
                }
            }
            catch (Exception exp)
            {
                TempData["ErrorMessage"] = exp.InnerException?.Message;
                TempData["StackTrace"] = exp.StackTrace;
                TempData["Source"] = exp.Source;
                return RedirectToAction("Error", "Error");
            }
            return RedirectToAction("index", "site");
        }
        [HttpGet]
        public IActionResult settings()
        {
            Sitesetting sitesetting = new Sitesetting();
            Sitesetting sitesettingdb = null;
            try
            {
                sitesettingdb = _unitofWork.Sitesetting.Get(s => s.ID > 0);
            }
            catch (Exception exp)
            {
                TempData["ErrorMessage"] = exp.InnerException?.Message;
                TempData["StackTrace"] = exp.StackTrace;
                TempData["Source"] = exp.Source;
                return RedirectToAction("Error", "Error");
            }
            if (sitesettingdb != null)
                return View(sitesettingdb);
            else
                return View(sitesetting);
        }
    }
}
