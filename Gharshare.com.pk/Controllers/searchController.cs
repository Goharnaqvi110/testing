using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using Gharshare.CommonHelper;
using Microsoft.EntityFrameworkCore;
using smartpropertymanager.pk.classes;
using iText.Commons.Utils;
using ServiceStack;
using Gharshare.Views.Shared.Components.SearchBar;
using System.Net;


namespace Gharshare.com.pk.Controllers
{
    public class searchController : Controller
    {
        private IUnitofWork _unitofWork;
        private Utility _utility;
        public searchController(IUnitofWork iUnitofWork, Utility utility)
        {
            _unitofWork = iUnitofWork;
            _utility = utility;
        }

        [HttpPost]
        public async Task<IActionResult> search(string? Searchphrase = null, int? pg = 1)
        {
            SearchVM searchvm = null;
            try
            {
               // List<Property> properties = null;
               var properties = _unitofWork.Property.GetAll
                          (p => p.IsActive == true && p.IsAdlive == true
                         /* && p.Address.Contains(Searchphrase)*/
                          ,includeProperties: "State,City")
                          .OrderByDescending(x => x.CreatedOn).ToList();
                if (Searchphrase != null)
                    properties = properties.Where(p => p.Address.Contains(Searchphrase)).ToList();
                
                searchvm = new SearchVM
                {
                    Properties = properties,
                    Searchphrase = string.Empty,
                    Features = _unitofWork.Feature.GetAll(f => f.IsActive == true).
                    OrderBy(f => f.Title).ToList()
                };
                #region Pagination
                int pageSize = Pager.GetPageSize();
                if (pg < 1)
                {
                    pg = 1;
                }
                int recsCount = searchvm.Properties.Count();
                int recSkip = (int)((pg - 1) * pageSize);
                var data = searchvm.Properties.Skip(recSkip).Take(pageSize).ToList();
                var pager = new Pager(recsCount, (int)pg, "property", "PropertyList",pageSize,
                    null, "", properties.Count(), "getProperties");
                searchvm.Properties = data;
                this.ViewBag.Pager = pager;
                #endregion end pagination
                return View("index", searchvm);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> index(string cid, string type, int pg = 1)
        {
            SearchVM searchvm = null;
            try
            {
                List<Property> properties = null;
                properties = _unitofWork.Property.GetAll
                         (p => p.IsActive == true && p.IsAdlive == true,
                         includeProperties: "State,City")
                         .OrderByDescending(x => x.CreatedOn).ToList();
                if (cid != null)
                    properties = properties.Where(p => p.CityID == Convert.ToInt64(cid)).ToList();
                if (type != null)
                    properties = properties.Where(p => p.CatogryID == (Property.Category)Convert.ToInt64(type))
                        .ToList();
                #region apply paging
                if (pg < 1)
                    pg = 1;
                int pageSize = Pager.GetPageSize();
                int recCount = properties.Count();
                int recSkip = (pg - 1) * pageSize;
                properties = properties.Skip(recSkip).Take(pageSize).ToList();
                Pager pager = new Pager(recCount, pg, "", "", pageSize, "", "", properties.Count(),
                    "searchPropertiesByAddress", 1);
                ViewBag.Pager = pager;
                #endregion

                searchvm = new SearchVM
                {
                    Properties = properties,
                    Searchphrase = null,
                    Features = _unitofWork.Feature.GetAll(f => f.IsActive == true).
                    OrderBy(f => f.Title).ToList()
                };
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
            return View(searchvm);
        }
        public JsonResult SearchPropertiesByAddress(int currentPage, string searchPhrase,
            int? sortOrderNo = 1)
        {
            var searchVm = new SearchbyAddressVM();
            try
            {
                var properties = _unitofWork.Property.GetAll(p => p.IsActive == true && p.IsAdlive == true
                && p.blockedbyAdmin == false && p.CityID != null, includeProperties: "State,City").ToList();
                if (searchPhrase != null && searchPhrase != "")
                    properties = properties.Where(p => p.Address.Contains(searchPhrase))
                        .OrderByDescending(x => x.CreatedOn).ToList();

                properties = SortProperties(properties, sortOrderNo);

                #region apply paging on properties
                int pageSize = Pager.GetPageSize();
                if (currentPage < 1)
                    currentPage = 1;
                int recsCount = properties.Count();
                int recSkip = (currentPage - 1) * pageSize;
                properties = properties.Skip(recSkip).Take(pageSize).ToList();
                var pager = new Pager(recsCount, currentPage, "", "", pageSize, searchPhrase, "", properties.Count(),
                    "searchPropertiesByAddress",(int)sortOrderNo);
                ViewBag.Pager = pager;
                #endregion
                searchVm.Pager = pager;
                searchVm.Properties = properties;
            }
            catch (Exception ex)
            {
                LogErrorDetail(ex, "search/SearchPropertiesByAddress");
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { error = "failed" });
            }
            return new JsonResult(searchVm);
        }
        public JsonResult sort(int sortid, string searchPhrase)
        {
            List<Property> properties = null;
            SearchbyAddressVM searchVm = null;
            try
            {
                properties = _unitofWork.Property.GetAll
                         (p => p.IsActive == true && p.IsAdlive == true)
                         .OrderByDescending(x => x.CreatedOn).ToList();
                properties = SortProperties(properties, sortid);
                
                if (searchPhrase != null)
                {
                    properties = properties.Where(p => p.Address.Contains(searchPhrase)).
                          OrderByDescending(p => p.Rent).ToList();
                }
                #region apply paging on properties
                int pageSize = Pager.GetPageSize();

                int currentPage = 1;
                int recsCount = properties.Count();
                int recSkip = (currentPage - 1) * pageSize;
                properties = properties.Skip(recSkip).Take(pageSize).ToList();
                var pager = new Pager(recsCount, currentPage, "", "", pageSize, searchPhrase, "", properties.Count(),
                    "searchPropertiesByAddress", sortid);
                ViewBag.Pager = pager;
                #endregion
                searchVm = new SearchbyAddressVM
                {
                    Pager = pager,
                    Properties = properties,
                };
            }
            catch (Exception ex)
            {
                LogErrorDetail(ex, "search/sort");
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { error = "failed" });

            }
            return new JsonResult(searchVm);

        }
        private List<Property> SortProperties(List<Property> properties,int? sortid=1)
        {
            switch (sortid)
            {
                case 1:
                    properties = properties.OrderBy(p => p.Address).ToList();
                    break;
                case 2:
                    properties = properties
                      .OrderByDescending(p => p.Rating)
                      .ThenByDescending(p => p.UserClicks).ToList();
                    break;
                case 3:
                    properties = properties
                      .OrderByDescending(p => p.CreatedOn).ToList();
                    break;
                case 4:
                    properties = properties
                     .OrderBy(p => p.Rent).ToList();
                    break;
                case 5:
                    properties = properties
                      .OrderByDescending(p => p.Rent).ToList();
                    break;
            }
            return properties;
        }
        public JsonResult searchonInput(string Searchphrase, int? sortOrderNo = 1)
        {
            List<Property> properties = null;
            SearchbyAddressVM searchVm = null;
            try
            {
                properties = _unitofWork.Property.GetAll
                          (p => p.IsActive == true && p.IsAdlive == true)
                          .OrderByDescending(x => x.CreatedOn).ToList();

                if (Searchphrase != null)
                    properties = properties.Where(p => p.IsActive == true && p.IsAdlive == true &&
                          p.Address.Contains(Searchphrase)).ToList();
                properties = SortProperties(properties, sortOrderNo);

                #region apply paging on properties
                int pageSize = Pager.GetPageSize();

                int currentPage = 1;
                int recsCount = properties.Count();
                int recSkip = (currentPage - 1) * pageSize;
                properties = properties.Skip(recSkip).Take(pageSize).ToList();
                var pager = new Pager(recsCount, currentPage, "", "", pageSize, Searchphrase, "", properties.Count(),
                    "searchPropertiesByAddress",(int)sortOrderNo);
                ViewBag.Pager = pager;
                #endregion

                searchVm = new SearchbyAddressVM
                {
                    Pager = pager,
                    Properties = properties,
                };
            }
            catch (Exception ex)
            {
                LogErrorDetail(ex, "search/SearchonInput");
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { error = "failed" });
            }
            return new JsonResult(searchVm);
        }
        [HttpPost]
        public IActionResult Filter([FromBody] PropertyFilter selection)
        {
            List<Property> filteredPropertyList = new List<Property>();
            SearchbyAddressVM searchVm = null;
            try
            {
                if (selection.selection != null)
                {
                    List<Int64> feature = selection.selection.Feature.Select(s => Int64.Parse(s)).ToList();
                    List<int> type = selection.selection.Type.Select(s => int.Parse(s)).ToList();
                    List<int> bed = selection.selection.Bed.Select(s => int.Parse(s)).ToList();
                    int? maxBed = bed.FirstOrDefault(b => b >= 5);

                    List<string> rent = selection.selection.Rent;

                    List<RentRange> rentRanges = new List<RentRange>();
                    foreach (string r in rent)
                    {
                        string[] rentValues = r.Split('-');
                        int minValue = int.Parse(rentValues[0]);
                        int maxValue = rentValues.Length > 1 ? int.Parse(rentValues[1]) : int.MaxValue;
                        rentRanges.Add(new RentRange(minValue, maxValue));
                    }
                    var query = _unitofWork.Property.GetAll(P => P.IsActive == true
                        && P.IsAdlive == true
                        && (type.Count == 0 || type.Contains((int)P.CatogryID))
                        && (maxBed == null || P.Bed >= maxBed)
                        && (!bed.Any() || bed.Contains((int)P.Bed))
                        && (!feature.Any() || P.Features.Any(pf =>
                        feature.Contains((long)pf.FeatureID)
                        && pf.isSelected == true)), includeProperties: "Features").ToList();

                    if (rentRanges.Count > 0)
                    {
                        query = query.Where(p => rentRanges.Any(rr => p.Rent >= rr.MinValue
                        && p.Rent <= rr.MaxValue)).ToList();
                    }
                    filteredPropertyList = query;
                    #region sorting
                    var sortOrderNo = selection.selection.sortorder;
                    filteredPropertyList=SortProperties(filteredPropertyList, sortOrderNo);
                    #endregion
                    #region apply paging on properties
                    int pageSize = Pager.GetPageSize();

                    int currentPage = 1;
                    int recsCount = filteredPropertyList.Count();
                    int recSkip = (currentPage - 1) * pageSize;
                    filteredPropertyList = filteredPropertyList.Skip(recSkip).Take(pageSize).ToList();
                    var pager = new Pager(recsCount, currentPage, "", "", pageSize, "", "", filteredPropertyList.Count(),
                        "searchPropertiesByAddress",(int)sortOrderNo);
                    ViewBag.Pager = pager;
                    #endregion

                    searchVm = new SearchbyAddressVM
                    {
                        Pager = pager,
                        Properties = filteredPropertyList,
                    };
                }
            }
            catch (Exception ex)
            {
                LogErrorDetail(ex, "/Property/Filter");
                return new JsonResult(new { error = true, message = ex.Message });
            }
            return new JsonResult(searchVm);
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
    }
}
