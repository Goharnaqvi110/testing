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
    public class propertyController : Controller
    {
        private IUnitofWork _unitofWork;
        private Utility _utility;
        public propertyController(IUnitofWork unitofWork, Utility Utility)
        {
            _unitofWork = unitofWork;
            _utility = Utility;
        }
        public JsonResult getpropertyadlist(int pg = 1, string SearchText = "",
            string sortOrder = "", string landlordId = "")
        {
            List<Property> adList = null;
            try
            {
                adList = _unitofWork.Property.GetAll(includeProperties: "Owner")
                    .OrderBy(p => p.Address).ToList();

                #region Filter Data based on selected filters
                if (landlordId != string.Empty && landlordId !=null)
                    adList = adList.Where(p => p.Owner.Id == landlordId).ToList();

                if (SearchText != string.Empty && SearchText != null && SearchText != "")
                    adList = adList.Where(p => p.Address.IndexOf(SearchText,
                        StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                #endregion

                #region Apply Pagination & Sorting                 
                ViewBag.LandlordSortParam = string.IsNullOrEmpty(sortOrder) ? "landlord_desc" : "";
                ViewBag.AddressSortParam = sortOrder == "address" ? "address_desc" : "address";

                int pageSize = Pager.GetPageSize();
                if (pg < 1)
                {
                    pg = 1;
                }
                ViewBag.pg = pg;
                int recsCount = adList.Count();
                var pager = new Pager(recsCount, pg, "property", "index", pageSize);
                pager.SortOrder = sortOrder;
                int recSkip = (pg - 1) * pageSize;
                switch (sortOrder)
                {
                    case "name":
                        adList = adList.Skip(recSkip).Take(pager.PageSize).OrderBy(p => p.Owner.Name).ToList();
                        ViewData["SortIcon"] = "fa fa-arrow-down";
                        break;
                    case "name_desc":
                        adList = adList.Skip(recSkip).Take(pager.PageSize).OrderByDescending(p => p.Owner.Name).
                            ToList();
                        ViewData["SortIcon"] = "fa fa-arrow-up";
                        break;
                    case "address":
                        adList = adList.Skip(recSkip).Take(pager.PageSize).OrderBy(u => u.Address).ToList();
                        ViewData["SortIconAddress"] = "fa fa-arrow-down";
                        break;
                    case "address_desc":
                        adList = adList.Skip(recSkip).Take(pager.PageSize).OrderByDescending(u => u.Address).ToList();
                        ViewData["SortIconAddress"] = "fa fa-arrow-up";
                        break;                     
                    default:
                        adList = adList.Skip(recSkip).Take(pager.PageSize).OrderBy(p => p.Owner.Name).ToList();
                        ViewData["SortIconType"] = "fa fa-arrow-down";
                        break;
                }
                this.ViewBag.Pager = pager;
                #endregion
            }
            catch (Exception exp)
            {
                LogErrorDetail(exp, "admin/property/getpropertyadlist");
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { error = "failed" });
            }
            return Json(adList);
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
                _unitofWork.ErrorLog.Add(errorLog);
                _unitofWork.Save();
            }
            catch (Exception exp)
            {

                throw;
            }
        }
        public IActionResult index(int pg = 1, string SearchText = "",
            string sortOrder = "", string landlordId = "")
        {
            List<Property> adList = null;
            try
            {
                adList = _unitofWork.Property.GetAll(p=>p.IsAdcreated==true,includeProperties: "Owner")
                    .OrderBy(p => p.Address).ToList();

                #region Filter Data based on selected filters
                if (landlordId != string.Empty && landlordId != null)
                    adList = adList.Where(p => p.Owner.Id == landlordId).ToList();

                if (SearchText != string.Empty && SearchText != null && SearchText != "")
                    adList = adList.Where(p => p.Address.IndexOf(SearchText,
                        StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                #endregion

                #region Apply Pagination & Sorting                 
                //ViewBag.LandlordnameSortParam = string.IsNullOrEmpty(sortOrder) ? "landlordname_desc" : "";
                ViewBag.LandlordnameSortParam = sortOrder == "landlordName" ? "landlordname_desc" : "landlordName";
                ViewBag.AddressSortParam = string.IsNullOrEmpty(sortOrder) ? "address_desc" : "";

                int pageSize = Pager.GetPageSize();
                if (pg < 1)
                {
                    pg = 1;
                }
                ViewBag.pg = pg;
                int recsCount = adList.Count();                
                int recSkip = (pg - 1) * pageSize;
                var data = adList.Skip(recSkip).Take(pageSize).ToList();
                var pager = new Pager(recsCount, pg, "property", "index", pageSize, "", "", data.Count());
                pager.SortOrder = sortOrder;
                switch (sortOrder)
                {
                    case "landlordName":
                        adList = adList.Skip(recSkip).Take(pager.PageSize).OrderBy(p => p.Owner.Name).ToList();
                        ViewData["SortIconLandlord"] = "fa fa-arrow-down";
                        break;
                    case "landlordName_desc":
                        adList = adList.Skip(recSkip).Take(pager.PageSize).OrderByDescending(p => p.Owner.Name).
                            ToList();
                        ViewData["SortIconLandlord"] = "fa fa-arrow-up";
                        break;
                    case "address":
                        adList = adList.Skip(recSkip).Take(pager.PageSize).OrderBy(p => p.Address).ToList();
                        ViewData["SortIconAddress"] = "fa fa-arrow-down";
                        break;
                    case "address_desc":
                        adList = adList.Skip(recSkip).Take(pager.PageSize).OrderByDescending(p => p.Address).ToList();
                        ViewData["SortIconAddress"] = "fa fa-arrow-up";
                        break;
                    default:
                        adList = adList.Skip(recSkip).Take(pager.PageSize).OrderBy(u => u.Address).ToList();
                        ViewData["SortIconAddress"] = "fa fa-arrow-down";
                        break;
                }
                this.ViewBag.Pager = pager;
                #endregion

                var landlords = _unitofWork.User.GetAll(u => u.UserType == ApplicationUser.usertype.landlord)
                    .OrderBy(u => u.Name).ToList().Select(c => new SelectListItem
                    {
                        Text=c.Name,
                        Value=c.Id
                    });
                ViewBag.Landlords = landlords;
            }
            catch (Exception exp)
            {
                TempData["ErrorMessage"] = exp.InnerException?.Message;
                TempData["StackTrace"] = exp.StackTrace;
                TempData["Source"] = exp.Source;
                return RedirectToAction("Error", "Error");
            }
            return View(adList);
        }
    }
}
