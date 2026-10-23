using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using System.Security.Claims;
using Gharshare.Views.Shared.Components.SearchBar;
using Gharshare.CommonHelper;
using System.Text;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.SignalR;
using Gharshare.com.pk.Hubs;
using System.Net;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Http;

namespace ShareHouseManagement.Areas.Admin.Controllers
{
    //[Area("Admin")]
    // [Authorize(Roles=WebSiteRoles.Role_Admin+","+WebSiteRoles.Role_Manager + "," +WebSiteRoles.Role_Landlord)]
    public class propertyController : Controller
    {
        private IUnitofWork _unitofWork;
        private IWebHostEnvironment _hostingEnvironment;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private Utility _utility;
        private readonly IEmailSender _emailSender;
        private readonly IHubContext<ChatHub> _chat;
        public propertyController(
            IUnitofWork iunitofWork,
            Utility utility,
            IWebHostEnvironment hostingEnvironment,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            IEmailSender emailSender,
            EmailSender emailSender1, IHubContext<ChatHub> chat
            )
        {
            _unitofWork = iunitofWork;
            _utility = utility;
            _hostingEnvironment = hostingEnvironment;
            _signInManager = signInManager;
            _userManager = userManager;
            //_emailStore = GetEmailStore();
            _emailSender = emailSender;
            //_emailSender1 = emailSender1;
            _chat = chat;
        }
        [HttpPost]
        public IActionResult editproperty(Property property)
        {

            try
            {
                var propertyDb = _unitofWork.Property.Get(p => p.ID == property.ID);
                if (propertyDb == null)
                {
                    TempData["error"] = "Property record could not be updated.Please try later.";
                    return RedirectToAction("list", "property");
                }
                else
                {
                    propertyDb.Address = property.Address;
                    propertyDb.Bed = property.Bed;
                    propertyDb.Bathroom = property.Bathroom;
                    propertyDb.TotalParkings = property.TotalParkings;
                    propertyDb.Rent = property.Rent;
                    propertyDb.UpdatedOn = DateTime.UtcNow;
                    propertyDb.UpdatedbyUserId = HttpContext.Session.GetString("_UserId");
                    _unitofWork.Property.update(propertyDb);
                    _unitofWork.Save();
                    TempData["success"] = "Property record successfully updated !";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
            return RedirectToAction("list", "property");
        }
        public IActionResult editproperty(string propertyUid)
        {
            Property property;
            try
            {
                property = _unitofWork.Property.Get(p => p.uid == propertyUid);

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
            return View("editproperty", property);
        }
        public JsonResult changePropertyFavouritestatus(Int64 pid, Int64 status)
        {
            try
            {
                var loggedInUserId = HttpContext.Session.GetString("_UserId");
                var propertyViewed = _unitofWork.PropertiesViewed.Get(p => p.PropertyID == pid
                && p.UserID == loggedInUserId);

                if (status == 1)// add to favourite list
                {
                    propertyViewed.IsFavourite = true;
                }
                else // remove from favourite list
                {
                    propertyViewed.IsFavourite = false;
                }
                _unitofWork.PropertiesViewed.update(propertyViewed);
                _unitofWork.Save();
            }
            catch (Exception exp)
            {
                LogErrorDetail(exp, "property/changePropertyFavouritestatus");
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { error = "failed" });
            }
            return new JsonResult("success");
        }
        public JsonResult changeAdstatus(Int64 pid, Int64 status, bool blockedByAdminVal,
            bool isAdmin = false)
        {
            try
            {
                var property = _unitofWork.Property.Get(p => p.ID == pid);
                if (isAdmin)
                    property.blockedbyAdmin = blockedByAdminVal;
                else if (status == 1)// go live
                {
                    property.IsAdlive = true;
                    property.IsActive = true;
                }
                else // remove ad
                {
                    property.IsAdlive = false;
                }
                _unitofWork.Property.update(property);
                _unitofWork.Save();
            }
            catch (Exception exp)
            {
                LogErrorDetail(exp, "property/changeAdstatus");
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { error = "failed" });
            }
            return new JsonResult("success");
        }
        private List<SelectListItem> LoadCities()
        {
            IEnumerable<SelectListItem> Cities = _unitofWork.City.GetAll()
                .OrderBy(c => c.Name).ToList().Select(
                    x => new SelectListItem()
                    {
                        Text = x.Name,
                        Value = Convert.ToString(x.ID)
                    }
                    );
            return Cities.ToList();
        }
        public async Task<IActionResult> PropertyList(string? Searchphrase = null, int? pg = 1)
        {
            SearchVM searchvm = null;
            //try
            //{
            List<Property> properties = null;

            if (Searchphrase != null)
            {
                properties = _unitofWork.Property.GetAll
                      (p => p.IsActive == true && p.IsAdlive == true &&
                      p.Address.Contains(Searchphrase),
                      includeProperties: "State,City").ToList();
            }
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
            var pager = new Pager(recsCount, (int)pg, "property", "PropertyList",
                pageSize);//, Searchphrase);
                          //pager.HasSearchPhrase = true;
            int recSkip = (int)((pg - 1) * pageSize);
            var data = searchvm.Properties.Skip(recSkip).Take(pager.PageSize).ToList();
            searchvm.Properties = data;
            this.ViewBag.Pager = pager;
            #endregion end pagination
            return View(searchvm);
            //}
            //catch (Exception ex)
            //{
            //    TempData["ErrorMessage"] = ex.Message;
            //    TempData["StackTrace"] = ex.StackTrace;
            //    TempData["Source"] = ex.Source;
            //    return RedirectToAction("Error", "Error");
            //}
        }

        #region contains list filtering etc. commented this as below solution wasn't workable. Applied alternative.
        //[HttpPost]
        //public IActionResult createconditionreport(ConditionReportVm conditionReportVm)
        //{
        //    var selectedAreaIds = conditionReportVm.PropertyArea.
        //        Where(x=>x.isSelected==true && x.TotalNo >0).Select(x => x.ID).ToList(); 
        //    //Get records along with include prop from db based on values selected by user 
        //    List<PropertyArea> propertyAreafromDB = _unitofWork.PropertyArea.GetAll
        //        (includeProperties: "PropertyAreaItems").Where(x => selectedAreaIds.Contains(x.ID)).ToList();
        //    //Filter selected list to replace value of 'TotalNo' of list 'propertyAreafromDB' with list
        //    //'selectedPropertyareas'.
        //    var selectedPropertyareas = conditionReportVm.PropertyArea.Where(x => x.isSelected == true 
        //    && x.TotalNo > 0).ToList();

        //    //updating value of 'TotalNo' of list 'propertyAreafromDB' with list 'selectedPropertyareas'.
        //    foreach (var ps in selectedPropertyareas)
        //    {
        //        foreach(var pd in propertyAreafromDB)
        //        {
        //            if(ps.ID==pd.ID)
        //            {
        //                pd.TotalNo = ps.TotalNo;
        //                pd.isSelected = true;
        //            }

        //        }
        //    }
        //    conditionReportVm.PropertyArea = propertyAreafromDB;
        //    var property = _unitofWork.Property.Get(x => x.ID == conditionReportVm.Property.ID,
        //        includeProperties: "Owner");
        //    conditionReportVm.Property = property;
        //    return View(conditionReportVm);
        //}
        #endregion

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

        [HttpGet]
        public IActionResult List()
        {
            try
            {
                var UserId = HttpContext.Session.GetString("_UserId");
                ViewData["userID"] = UserId;
                ViewData["userType"] = HttpContext.Session.GetString("_UserType");

                List<Property> Properties = null;
                if (UserId != null)
                {
                    Properties = _unitofWork.Property.GetAll(x => x.OwnerId == UserId, includeProperties: "Enquiries,Lease,Plan").ToList();
                    return View(Properties);
                }
                else
                    return Redirect("/login");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        [Authorize(Roles = WebSiteRoles.Role_Admin + "," + WebSiteRoles.Role_Landlord)]
        public IActionResult Index(int pg = 1, string SearchText = "", string sortOrder = "")
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ApplicationUser user = _userManager.Users.Where(_u => _u.Id == userId).FirstOrDefault();
                List<Property> Properties;

                #region Get Data on Search criterion
                Search search = new Search() { Action = "index", Controller = "Property", SearchText = SearchText };
                ViewBag.Search = search;


                if (user.UserType == ApplicationUser.usertype.admin)
                {
                    if (SearchText == string.Empty || SearchText == null)
                        Properties = _unitofWork.Property.GetAll(includeProperties: "Images,Owner,State,City").ToList();

                    else
                        Properties = _unitofWork.Property.GetAll(p => p.Address.Contains(SearchText.Trim()) || p.City.Name.Contains(SearchText.Trim()), includeProperties: "Images,Owner,State,City").ToList();
                }
                else
                {
                    if (SearchText == string.Empty || SearchText == null)
                        Properties = _unitofWork.Property.GetAll(x => x.OwnerId == userId, includeProperties: "Images,Owner,State,City").ToList();
                    //Properties = _unitofWork.Property.GetAll(x => x.OwnerId == userId).ToList();
                    else
                        Properties = _unitofWork.Property.GetAll(x => x.OwnerId == userId && x.Address.Contains(SearchText.Trim()) || x.City.Name.Contains(SearchText.Trim()), includeProperties: "Images,Owner,State,City").ToList();

                }

                #endregion

                #region Apply pagination & sorting
                ViewBag.LocationSortParam = string.IsNullOrEmpty(sortOrder) ? "location_desc" : "";
                ViewBag.CitySortParam = sortOrder == "City" ? "city_desc" : "City";

                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.Json", optional: false);
                IConfiguration configuration = builder.Build();
                int pageSize = Convert.ToInt32(configuration.GetValue<string>("PageSize:Size"));

                if (pg < 1)
                {
                    pg = 1;
                }
                ViewBag.pg = pg;
                int recsCount = Properties.Count();
                var pager = new Pager(recsCount, pg, "Property", "index", pageSize);
                pager.SortOrder = sortOrder;
                int recSkip = (pg - 1) * pageSize;

                List<Property> data;
                switch (sortOrder)
                {
                    case "location_desc":
                        data = Properties.Skip(recSkip).Take(pager.PageSize).OrderByDescending(p => p.Address).ToList();
                        ViewData["SortIcon"] = "fa fa-arrow-up";
                        break;
                    case "City":
                        data = Properties.Skip(recSkip).Take(pager.PageSize).OrderBy(p => p.City.Name).ToList();
                        ViewData["SortIconCity"] = "fa fa-arrow-down";
                        break;
                    case "city_desc":
                        data = Properties.Skip(recSkip).Take(pager.PageSize).OrderByDescending(p => p.City.Name).ToList();
                        ViewData["SortIconCity"] = "fa fa-arrow-up";
                        break;

                    default:
                        data = Properties.Skip(recSkip).Take(pager.PageSize).OrderBy(p => p.Address).ToList();
                        ViewData["SortIcon"] = "fa fa-arrow-down";
                        break;
                }

                this.ViewBag.Pager = pager;
                #endregion

                return View(data);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        [Authorize(Roles = WebSiteRoles.Role_Admin + "," + WebSiteRoles.Role_Landlord)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PropertyVM propertyVm, List<IFormFile> files, IFormFile filecoverImage)
        {
            try
            {
                string _userId = propertyVm.Landlord.Id;
                string _coverImagePath = string.Empty;
                if (ModelState.IsValid)
                {
                    if (filecoverImage != null)
                    {
                        _coverImagePath = _utility.SaveFile(filecoverImage, @"assets/PropertyImages");
                    }
                    propertyVm.Property.CoverImage = _coverImagePath;
                    propertyVm.Property.OwnerId = _userId;
                    propertyVm.Property.uid = Guid.NewGuid().ToString();
                    _unitofWork.Property.Add(propertyVm.Property);
                    _unitofWork.Save();
                    Int64 _propertyId = propertyVm.Property.ID;
                    foreach (var file in files)
                    {
                        IFormFile currentFile = file;
                        PropertyImage _propertyImage = new PropertyImage();
                        string _imagePath = _utility.SaveFile(currentFile, @"assets/PropertyImages");
                        _propertyImage.ImagePath = _imagePath;
                        _propertyImage.PropertyID = _propertyId;
                        _propertyImage.uid = Guid.NewGuid().ToString();
                        _propertyImage.Description = "Image of property with Id:" + Convert.ToString(_propertyId);
                        _unitofWork.PropertyImages.Add(_propertyImage);
                        _unitofWork.Save();
                    }
                    TempData["success"] = "Property created successfully!";
                }
                else
                    TempData["error"] = "Error creating property. Please contact administrator.";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        [Authorize(Roles = WebSiteRoles.Role_Admin + "," + WebSiteRoles.Role_Landlord)]
        [HttpGet]
        public IActionResult createad(string id)
        {
            try
            {
                Property Property = _unitofWork.Property
                    .Get(x => x.uid == id, includeProperties: "Images,Owner,State,City");

                string _userId = Property.OwnerId;

                PropertyVM propertyVM = new PropertyVM()
                {
                    Property = Property,
                    Properties = _unitofWork.Property.GetAll().ToList(),
                    Landlords = _userManager.Users
                    .Where(x => x.UserType == ApplicationUser.usertype.landlord)
                    .Select(
                        x => new SelectListItem()
                        {
                            Text = x.Name,
                            Value = x.Id
                        }),
                    Landlord = _unitofWork.User.Get(x => x.Id == _userId, includeProperties: "City,State"),
                    PropertyImages = _unitofWork.PropertyImages.GetAll(x => x.PropertyID == Property.ID).ToList(),
                    States = _unitofWork.State.GetAll().OrderBy(s => s.Name).ToList().Select(
                            s => new SelectListItem()
                            {
                                Text = s.Name,
                                Value = s.ID.ToString()
                            }),
                    State = _unitofWork.State.Get(s => s.ID == Property.StateID),
                    //Cities = _unitofWork.City.GetAll(x => x.StateID == Property.StateID).OrderBy(c => c.Name).ToList().Select(
                    Cities = _unitofWork.City.GetAll().OrderBy(c => c.Name).ToList().Select(
                    c => new SelectListItem()
                    {
                        Text = c.Name,
                        Value = c.ID.ToString()
                    }),
                    City = _unitofWork.City.Get(c => c.ID == Property.CityID),
                    Suburbs = _unitofWork.Suburb.GetAll(s => s.CityID == Property.CityID).
                    OrderBy(s => s.Name).ToList().Select(
                            s => new SelectListItem()
                            {
                                Text = s.Name,
                                Value = s.ID.ToString()

                            }),
                    PropertyFeatures = _unitofWork.PropertyFeature
                    .GetAll(x => x.PropertyID == Property.ID, includeProperties: "Feature").ToList(),
                    PropertyAcceptings = _unitofWork.PropertyAccepting
                    .GetAll(x => x.PropertyID == Property.ID, includeProperties: "Accepting").ToList(),
                    Inspections = _unitofWork.PropertyInspection.GetAll(x => x.PropertyID == Property.ID).ToList(),

                };
                return View(propertyVM);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        [HttpPost]
        [Produces("application/json")]
        public JsonResult updatePropertyCoverImage(Int64 propertyID, IFormFile file)
        {
            string newPropertyCoverPhoto = null;
            try
            {
                Int64 PID = propertyID;
                Property property = _unitofWork.Property.Get(x => x.ID == PID);
                if (PID != null && PID != 0 && file != null)
                {                    
                    PropertyImage _coverImage = null;
                    Int64 _propertyId = property.ID;

                    //Delete old cover photo from file system
                    if (property.CoverImage!=null && property.CoverImage==string.Empty)
                    _utility.DeletFile(property.CoverImage);

                    //Delete old cover image record from 'PropertyImages' table
                    var oldCoverImgRec = _unitofWork.PropertyImages.Get(i => i.PropertyID == propertyID 
                    && i.isCover == true);
                    if(oldCoverImgRec!=null)
                    _unitofWork.PropertyImages.Delete(oldCoverImgRec);

                    //Save new cover image and add the propertyImage record
                    IFormFile newCoverImage = file;
                    _coverImage = new PropertyImage();
                    string _newCoverimagePath = _utility.SaveFile(newCoverImage, @"assets/PropertyImages");

                    _coverImage.isCover = true;
                    _coverImage.ImagePath = _newCoverimagePath;
                    _coverImage.PropertyID = _propertyId;
                    _coverImage.uid = Guid.NewGuid().ToString();
                    _coverImage.Description = "Image of property with Id:" + Convert.ToString(_propertyId);
                    _unitofWork.PropertyImages.Add(_coverImage);

                    //Update cover image path in properties table
                    property.CoverImage = _newCoverimagePath;
                    _unitofWork.Property.update(property);
                    _unitofWork.Save();
                    //file path of new cover image
                    newPropertyCoverPhoto = _newCoverimagePath;
                }
            }
            catch (Exception ex)
            {
                LogErrorDetail(ex, "Property/updatePropertyCoverImage");
            }
            //return file path of new cover image
            return new JsonResult(newPropertyCoverPhoto);
        }
        [HttpPost]
        [Produces("application/json")]
        public JsonResult savePropertyImages(Int64 propertyID, List<IFormFile> files)
        {
            List<PropertyImage> PropertyImages = null;
            try
            {
                Int64 PID = propertyID;
                Property property = _unitofWork.Property.Get(x => x.ID == PID);
                if (PID != null && PID != 0 && files != null)
                {
                    PropertyImage _propertyImage = null;
                    Int64 _propertyId = property.ID;
                    for (int i = 0; i < files.Count(); i++)
                    {
                        if (i == 0)
                        {
                            _utility.DeletFile(property.CoverImage);
                            property.CoverImage = _utility.SaveFile(files[i],
                                @"assets/PropertyImages");
                            _unitofWork.Property.update(property);
                        }

                        IFormFile currentFile = files[i];
                        _propertyImage = new PropertyImage();
                        string _imagePath = _utility.SaveFile(currentFile, @"assets/PropertyImages");
                        if (i == 0)
                            _propertyImage.isCover = true;
                        _propertyImage.ImagePath = _imagePath;
                        _propertyImage.PropertyID = _propertyId;
                        _propertyImage.uid = Guid.NewGuid().ToString();
                        _propertyImage.Description = "Image of property with Id:" + Convert.ToString(_propertyId);
                        _unitofWork.PropertyImages.Add(_propertyImage);
                    }
                    _unitofWork.Save();
                    PropertyImages = _unitofWork.PropertyImages.GetAll(x => x.PropertyID == PID)
                       .OrderByDescending(x => x.isCover == true).ToList();
                }
            }
            catch (Exception ex)
            {
                LogErrorDetail(ex, "Property/savePropertyImages");
            }
            //return new JsonResult(JsonConvert.SerializeObject(PropertyImages));
            //string json = JsonConvert.SerializeObject(PropertyImages);
            return new JsonResult(PropertyImages);
        }
        [Authorize(Roles = WebSiteRoles.Role_Admin + "," + WebSiteRoles.Role_Landlord)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult createad(PropertyVM propertyVM)
        {
            var property = _unitofWork.Property.Get(p => p.ID == propertyVM.Property.ID);
            try
            {
                if (ModelState.IsValid)
                {
                    property.UnitNo = propertyVM.Property.UnitNo;
                    property.Street = propertyVM.Property.Street;
                    property.Suburb = propertyVM.Property.Suburb;
                    property.CityID = propertyVM.Property.CityID;
                    property.PostalCode = propertyVM.Property.PostalCode;
                    property.Bed = propertyVM.Property.Bed;
                    property.Bathroom = propertyVM.Property.Bathroom;
                    property.InternetStatus = propertyVM.Property.InternetStatus;
                    property.BedSize = propertyVM.Property.BedSize;
                    property.TotalParkings = propertyVM.Property.TotalParkings;
                    property.Parkingtype = propertyVM.Property.Parkingtype;
                    property.AvailableFrom = propertyVM.Property.AvailableFrom;
                    property.Rent = propertyVM.Property.Rent;
                    property.BondValue = propertyVM.Property.BondValue;
                    property.HidePrice = propertyVM.Property.HidePrice;
                    property.HideAddress = propertyVM.Property.HideAddress;
                    property.SharePhone = propertyVM.Property.ShowPhoneNo;
                    property.CatogryID = propertyVM.Property.CatogryID;
                    property.TotalArea = propertyVM.Property.TotalArea;
                    property.AdTitle = propertyVM.Property.AdTitle;
                    property.Description = propertyVM.Property.Description;
                    property.showInspectionTime = propertyVM.Property.showInspectionTime;
                    property.IsAdlive = propertyVM.Property.IsAdlive;
                    property.IsOnwnerOrAuthorized = propertyVM.Property.IsOnwnerOrAuthorized;
                    property.UpdatedbyUserId = HttpContext.Session.GetString("_UserId");
                    property.UpdatedOn = DateTime.UtcNow;
                    property.IsAdcreated = true;
                    _unitofWork.Property.update(property);
                    _unitofWork.Save();
                    _unitofWork.PropertyFeature.UpdateRange(propertyVM.PropertyFeatures);
                    _unitofWork.PropertyAccepting.UpdateRange(propertyVM.PropertyAcceptings);
                    _unitofWork.PropertyInspection.UpdateRange(propertyVM.Inspections);
                    _unitofWork.Save();
                    //TempData["success"] = "Ad successfully created!";
                }
                else
                {
                    TempData["error"] = "Error creating property ad!";
                }
                // return RedirectToAction("List");
                return Json(property.uid);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        [Authorize(Roles = WebSiteRoles.Role_Admin + "," + WebSiteRoles.Role_Landlord)]
        [HttpGet]
        public IActionResult Add()
        {
            try
            {
                Property property = new Property
                {
                    Owneremail = HttpContext.Session.GetString("ownerEmail"),
                    Ownermobile = HttpContext.Session.GetString("ownerPhone"),
                    OwnerId = HttpContext.Session.GetString("_UserId")

                };
                var States = _unitofWork.State.GetAll().OrderBy(s => s.Name).ToList().Select(
                            s => new SelectListItem()
                            {
                                Text = s.Name,
                                Value = s.ID.ToString()
                            });
                ViewBag.States = States;
                var cities = LoadCities();
                ViewBag.Cities = cities;
                return View(property);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        private string GenerateUniquePropertyCode(string uid)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(uid));
                // Convert the hashed bytes to a hexadecimal string and take the first 4 characters
                string hashString = BitConverter.ToString(bytes).Replace("-", "").Substring(0, 4);
                return hashString;
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Property property)
        {
            try
            {
                ApplicationUser Owner = _userManager.Users.Where(_u =>
                _u.Id == HttpContext.Session.GetString("_UserId")).FirstOrDefault();
                property.OwnerId = Owner.Id;
                property.OwnerName = Owner.Name;
                property.uid = Guid.NewGuid().ToString();
                property.PropertyCode = GenerateUniquePropertyCode(property.uid);
                property.IsActive = true;
                property.CreatedbyUserId = HttpContext.Session.GetString("_UserId");
                _unitofWork.Property.Add(property);
                _unitofWork.Save();
                List<PropertyFeature> propertyFeatureList = new List<PropertyFeature>();
                var features = _unitofWork.Feature.GetAll(x => x.IsActive == true).ToList();

                for (int i = 0; i < features.Count(); i++)
                {
                    PropertyFeature propertyFeature = new PropertyFeature
                    {
                        PropertyID = property.ID,
                        CreatedOn = DateTime.Now,
                        FeatureID = features[i].ID,
                        isSelected = false,
                        uid = Guid.NewGuid().ToString()
                    };
                    propertyFeatureList.Add(propertyFeature);
                }
                _unitofWork.PropertyFeature.AddRange(propertyFeatureList);

                List<PropertyAccepting> propertyAcceptingList = new List<PropertyAccepting>();
                var acceptings = _unitofWork.Accepting.GetAll(x => x.IsActive == true).ToList();

                for (int i = 0; i < acceptings.Count(); i++)
                {
                    PropertyAccepting propertyAccepting = new PropertyAccepting
                    {
                        PropertyID = property.ID,
                        AcceptingID = acceptings[i].ID,
                        isSelected = false,
                        CreatedOn = DateTime.Now,
                        uid = Guid.NewGuid().ToString()
                    };
                    propertyAcceptingList.Add(propertyAccepting);
                }
                _unitofWork.PropertyAccepting.AddRange(propertyAcceptingList);

                List<PropertyInspection> Inspections = new List<PropertyInspection>();
                for (int i = 0; i < 3; i++)
                {
                    PropertyInspection inspection = new PropertyInspection
                    {
                        PropertyID = property.ID,
                        InspectionDate = DateTime.Now,
                        From = null,
                        To = null,
                        isActive = true,
                        CreatedOn = DateTime.Now,
                        CreatedbyUser = null,
                        UpdatedOn = DateTime.Now,
                        UpdatedbyUser = null,
                        uid = Guid.NewGuid().ToString()
                    };
                    Inspections.Add(inspection);
                }
                _unitofWork.PropertyInspection.AddRange(Inspections);
                _unitofWork.Save();
                TempData["success"] = "Property successfully added";
                return RedirectToAction("list");
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
        public IActionResult Create()
        {
            try
            {
                var UserId = HttpContext.Session.GetString("_UserId");
                var userType = HttpContext.Session.GetString("_UserType");

                PropertyVM propertyVM = null;

                if (userType == "Admin" || userType == "Manager")
                {
                    propertyVM = new PropertyVM()
                    {
                        Property = new Property(),
                        Properties = _unitofWork.Property.GetAll().ToList(),
                        Landlords = _userManager.Users.Where(x => x.UserType == ApplicationUser.usertype.landlord).Select(
                            x => new SelectListItem()
                            {
                                Text = x.Name,
                                Value = x.Id
                            }
                            ),
                        Landlord = new ApplicationUser(),
                        PropertyImages = null,
                        States = _unitofWork.State.GetAll().OrderBy(s => s.Name).ToList().Select(
                            s => new SelectListItem()
                            {
                                Text = s.Name,
                                Value = s.ID.ToString()

                            }),
                        State = new State()
                    };
                }
                else if (userType == "Landlord")
                {
                    propertyVM = new PropertyVM()
                    {
                        Property = new Property(),
                        Properties = _unitofWork.Property.GetAll().ToList(),
                        Landlords = _userManager.Users.Where(x => x.UserType == ApplicationUser.usertype.landlord && x.Id == UserId).Select(
                             x => new SelectListItem()
                             {
                                 Text = x.Name,
                                 Value = x.Id
                             }),
                        Landlord = new ApplicationUser(),
                        PropertyImages = null,
                        States = _unitofWork.State.GetAll().OrderBy(s => s.Name).ToList().Select(
                            s => new SelectListItem()
                            {
                                Text = s.Name,
                                Value = s.ID.ToString()

                            }),
                        State = new State()
                    };
                }
                return View(propertyVM);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }

        public JsonResult GetSuburbs(int cityid)
        {
            List<Suburb> suburbs = null;
            try
            {
                suburbs = _unitofWork.Suburb.GetAll(s => s.CityID == cityid).OrderBy(s => s.Name).ToList();

            }
            catch (Exception ex)
            {
                LogErrorDetail(ex, "Property/GetSuburbs");
            }
            return new JsonResult(suburbs);
        }
        public JsonResult GetCities(int stateid)
        {
            List<City> cities = null;
            try
            {
                cities = _unitofWork.City.GetAll(c => c.StateID == stateid).OrderBy(c => c.Name).ToList();
            }
            catch (Exception ex)
            {
                LogErrorDetail(ex, "Property/GetCities");
            }
            return new JsonResult(cities);
        }

        [Authorize(Roles = WebSiteRoles.Role_Admin + "," + WebSiteRoles.Role_Landlord)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditAd(PropertyVM propertyVM, IFormFile? filecoverImage, List<IFormFile> files)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Property property = propertyVM.Property;
                    property.OwnerId = propertyVM.Landlord.Id;
                    property.UpdatedOn = DateTime.Now;
                    _unitofWork.Property.update(property);
                    _unitofWork.PropertyFeature.UpdateRange(propertyVM.PropertyFeatures);
                    _unitofWork.PropertyAccepting.UpdateRange(propertyVM.PropertyAcceptings);
                    UpdatePropertyImages(propertyVM.Property, filecoverImage, files);
                    _unitofWork.PropertyInspection.UpdateRange(propertyVM.Inspections);
                    _unitofWork.Save();
                    TempData["success"] = "Ad successfully updated!";
                }
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }

        [Authorize(Roles = WebSiteRoles.Role_Admin + "," + WebSiteRoles.Role_Landlord)]
        [HttpGet]
        public IActionResult EditAd(Int64 ID)
        {
            try
            {
                Property Property = _unitofWork.Property.Get(x => x.ID == ID, includeProperties: "Images,Owner");
                string _userId = Property.OwnerId;

                PropertyVM propertyVM = new PropertyVM()
                {
                    Property = _unitofWork.Property.Get(x => x.ID == ID, includeProperties: "Images,Owner,State,City"),
                    Properties = _unitofWork.Property.GetAll().ToList(),
                    Landlords = _userManager.Users.Where(x => x.UserType == ApplicationUser.usertype.landlord).Select(
                        x => new SelectListItem()
                        {
                            Text = x.Name,
                            Value = x.Id
                        }
                        ),
                    Landlord = _unitofWork.User.Get(x => x.Id == _userId, includeProperties: "City,State"),
                    PropertyImages = _unitofWork.PropertyImages.GetAll(x => x.PropertyID == ID).ToList(),
                    States = _unitofWork.State.GetAll().OrderBy(s => s.Name).ToList().Select(
                            s => new SelectListItem()
                            {
                                Text = s.Name,
                                Value = s.ID.ToString()
                            }),
                    State = _unitofWork.State.Get(s => s.ID == Property.StateID),
                    Cities = _unitofWork.City.GetAll(x => x.StateID == Property.StateID).OrderBy(c => c.Name).ToList().Select(
                            c => new SelectListItem()
                            {
                                Text = c.Name,
                                Value = c.ID.ToString()
                            }),
                    City = _unitofWork.City.Get(c => c.ID == Property.CityID),
                    Suburbs = _unitofWork.Suburb.GetAll(s => s.CityID == Property.CityID).OrderBy(s => s.Name).ToList().Select(
                            s => new SelectListItem()
                            {
                                Text = s.Name,
                                Value = s.ID.ToString()
                            }),
                    PropertyFeatures = _unitofWork.PropertyFeature.GetAll(x => x.PropertyID == ID, includeProperties: "Feature").ToList(),
                    PropertyAcceptings = _unitofWork.PropertyAccepting.GetAll(x => x.PropertyID == ID, includeProperties: "Accepting").ToList(),
                    Inspections = _unitofWork.PropertyInspection.GetAll(x => x.PropertyID == ID).ToList()
                };
                return View(propertyVM);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        public IActionResult Detail(string uid)
        {
            try
            {
                Property Property = _unitofWork.Property.Get(x => x.uid == uid);
                string _userId = Property.OwnerId;
                HttpContext.Session.SetString("LandlordId", _userId);
                var userClicks = Property.UserClicks;
                if (userClicks == null)
                    userClicks = 0;
                userClicks += 1;
                Property.UserClicks = userClicks;
                _unitofWork.Property.update(Property);
                _unitofWork.Save();
                HttpContext.Session.SetString("PropertyID", Property.ID.ToString());

                List<PropertyImage> floorImages = _unitofWork.PropertyImages.
                    GetAll(x => x.PropertyID == Property.ID &&
                    x.ImageType == PropertyImage.type.floor).ToList();
                // Top 5 Property Categories
                var topCategories = _unitofWork.Property.GetAll(p => p.IsActive == true && p.IsAdlive == true)
                .GroupBy(p => (Property.Category)p.CatogryID)
                .OrderByDescending(g => g.Count())
                .Take(5).Select(g => new TopCategories
                {
                    CategoryName = g.Key.ToString(),
                    Total = g.Count()
                }).ToList();
                //----
                // Top Five best rating properties
                var topProperties = _unitofWork.Property
                .GetAll(p => p.IsActive == true && p.IsAdlive == true,
                includeProperties: "City")
                .OrderByDescending(p => p.Rating)
                .ThenByDescending(p => p.UserClicks)
                .Take(5).ToList();
                //--

                // Popular properties
                var popularProperties = _unitofWork.Property
                .GetAll(p => p.IsActive == true && p.IsAdlive == true &&
                p.Rating >= 4, includeProperties: "City")
                .OrderByDescending(p => p.Rating)
                .ThenByDescending(p => p.UserClicks).ToList();
                //--
                // Related properties
                var relatedProperties = _unitofWork.Property
                .GetAll(p => p.IsActive == true && p.IsAdlive == true && p.uid != uid &&
                p.CityID == Property.CityID, includeProperties: "City")
                .OrderByDescending(p => p.Rating)
                .ThenByDescending(p => p.UserClicks).ToList();
                //--
                //check if property included in user's favourite list
                var loggedinUserId = HttpContext.Session.GetString("_UserId");

                bool isFavouriteProperty = false;
                var favouriteProperty = _unitofWork.PropertiesViewed.Get(p => p.PropertyID == Property.ID
                && p.IsFavourite == true && p.UserID == loggedinUserId);

                if (favouriteProperty != null) //user has already added property to their fav list.
                    isFavouriteProperty = true;


                PropertyVM propertyVM = new PropertyVM()
                {
                    Enquiry = new Enquiry
                    {
                        Enquirystatus = Enquiry.EnquiryStatus.unread,
                        PropertyID = Property.ID
                    },
                    Property = _unitofWork.Property.Get(x => x.uid == uid, includeProperties: "State,City"),
                    Properties = _unitofWork.Property.GetAll().ToList(),
                    Landlords = _userManager.Users.Where(x => x.UserType == ApplicationUser.usertype.landlord).Select(
                        x => new SelectListItem()
                        {
                            Text = x.Name,
                            Value = x.Id
                        }
                        ),
                    Landlord = _userManager.Users.Single(x => x.Id == _userId),
                    PropertyImages = _unitofWork.PropertyImages.GetAll(x => x.PropertyID == Property.ID).ToList(),
                    PropertyFeatures = _unitofWork.PropertyFeature.GetAll(x => x.PropertyID == Property.ID &&
                    x.isSelected == true, includeProperties: "Feature").ToList(),
                    PropertyAcceptings = _unitofWork.PropertyAccepting.GetAll(x => x.PropertyID == Property.ID
                    && x.isSelected == true, includeProperties: "Accepting").ToList(),
                    Inspections = _unitofWork.PropertyInspection.
                    GetAll(x => x.PropertyID == Property.ID && x.From != null).ToList(),
                    FloorImages = floorImages,
                    TopCategories = topCategories,
                    TopProperties = topProperties,
                    PopularProperties = popularProperties,
                    RelatedProperties = relatedProperties,
                    Searchphrase = string.Empty,
                    IsPropertyUserFavourite = isFavouriteProperty
                };
                var usertype = HttpContext.Session.GetString("_UserType");
                var userid = HttpContext.Session.GetString("_UserId");
                if (string.Equals(usertype, WebSiteRoles.Role_Tenant, StringComparison.OrdinalIgnoreCase)
                    && userid != null)
                    RecordUserPropertyView(Property.ID, usertype, userid);
                return View(propertyVM);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        private void RecordUserPropertyView(long iD, string usertype, string userid)
        {
            try
            {
                PropertiesViewed propertiesViewed = _unitofWork.PropertiesViewed.Get(x => x.PropertyID == iD
                && x.UserID == userid);
                if (propertiesViewed != null)
                {
                    propertiesViewed.ViewDate = DateTime.Now;
                    _unitofWork.PropertiesViewed.update(propertiesViewed);
                    _unitofWork.Save();
                }
                else
                {
                    propertiesViewed = new PropertiesViewed();
                    propertiesViewed.PropertyID = iD;
                    //propertiesViewed.uid = Guid.NewGuid().ToString(); uid field to be added to the model
                    propertiesViewed.UserID = userid;
                    propertiesViewed.ViewDate = DateTime.Now;
                    _unitofWork.PropertiesViewed.Add(propertiesViewed);
                    _unitofWork.Save();
                }
            }
            catch (Exception ex)
            {
                // LogErrorDetail(ex, "Property/RecordUserPropertyView");
                throw;
            }
        }

        [Authorize(Roles = WebSiteRoles.Role_Admin)]
        [HttpGet]
        public IActionResult Delete(Int64 ID)
        {
            try
            {
                Property Property = _unitofWork.Property.Get(x => x.ID == ID, includeProperties: "Images,Owner,State,City");
                return View(Property);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }

        [Authorize(Roles = WebSiteRoles.Role_Admin)]
        [HttpPost]
        public IActionResult Delete(Property property)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IEnumerable<PropertyImage> propertyImage = _unitofWork.PropertyImages.GetAll(x => x.PropertyID == property.ID);
                    _unitofWork.PropertyImages.DeleteRange(propertyImage);
                    _unitofWork.Property.Delete(property);
                    _unitofWork.Save();
                    _utility.DeletFile(property.CoverImage);
                    foreach (var image in propertyImage)
                    {
                        _utility.DeletFile(image.ImagePath);
                    }
                }
                TempData["success"] = "Property deleted successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        [Authorize(Roles = WebSiteRoles.Role_Admin + "," + WebSiteRoles.Role_Landlord)]
        [HttpGet]
        public IActionResult PropertyPics(Int64 ID)
        {
            try
            {
                Property Property = _unitofWork.Property.Get(x => x.ID == ID);
                string _userId = Property.OwnerId;
                PropertyVM propertyVM = new PropertyVM()
                {
                    Property = _unitofWork.Property.Get(x => x.ID == ID),
                    Properties = _unitofWork.Property.GetAll().ToList(),
                    Landlords = _userManager.Users.Where(x => x.UserType == ApplicationUser.usertype.landlord).Select(
                        x => new SelectListItem()
                        {
                            Text = x.Name,
                            Value = x.Id
                        }
                        ),
                    Landlord = _userManager.Users.Single(x => x.Id == _userId),
                    PropertyImages = _unitofWork.PropertyImages.GetAll(x => x.PropertyID == ID).ToList()
                };
                return View(propertyVM);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }

        [Authorize(Roles = WebSiteRoles.Role_Admin + "," + WebSiteRoles.Role_Landlord)]
        public JsonResult DeleteCover(Int64 ID)
        {
            try
            {
                Property property = _unitofWork.Property.Get(x => x.ID == ID);
                Int64 propertyID = ID;
                ViewBag.PropertyID = propertyID;
                _utility.DeletFile(property.CoverImage);
                property.CoverImage = String.Empty;
                _unitofWork.Property.update(property);
                _unitofWork.Save();
                TempData["success"] = "Property cover image deleted successfully!";
            }
            catch (Exception ex)
            {
                LogErrorDetail(ex, "Property/DeleteCover");
            }
            return Json(true);
        }
        [Authorize(Roles = WebSiteRoles.Role_Admin + "," + WebSiteRoles.Role_Landlord)]
        public JsonResult DeletePropertyImage(Int64 ID)
        {
            List<PropertyImage> images = null;
            try
            {
                PropertyImage propertyImage = _unitofWork.PropertyImages.Get(x => x.ID == ID);
                Int64 propertyImageID = ID;
                Int64 propertyID = propertyImage.PropertyID;

                _utility.DeletFile(propertyImage.ImagePath);
                propertyImage.ImagePath = String.Empty;
                _unitofWork.PropertyImages.Delete(propertyImage);
                _unitofWork.Save();
                images = _unitofWork.PropertyImages.GetAll(x => x.PropertyID == propertyID).ToList();
                //TempData["success"] = "Property image deleted successfully!";
            }
            catch (Exception ex)
            {
                LogErrorDetail(ex, "Property/DeletePropertyImage");
            }
            return new JsonResult(images);
        }
        public void UpdatePropertyImages(Property property, IFormFile filecoverImage, List<IFormFile> imageFiles)
        {
            try
            {
                Int64 PID = property.ID;
                if (PID != null && PID != 0)
                {
                    if (filecoverImage != null || imageFiles != null)
                    {
                        //Property property = _unitofWork.Property.Get(x => x.ID == PID);
                        if (filecoverImage != null)
                        {
                            if (property.CoverImage != null)
                                _utility.DeletFile(property.CoverImage);
                            string _coverImagePath = _utility.SaveFile(filecoverImage, @"assets/PropertyImages");
                            property.CoverImage = _coverImagePath;
                            _unitofWork.Property.update(property);
                            _unitofWork.Save();
                        }
                        if (imageFiles != null)
                        {
                            Int64 _propertyId = property.ID;
                            foreach (var file in imageFiles)
                            {
                                IFormFile currentFile = file;
                                PropertyImage _propertyImage = new PropertyImage();
                                string _imagePath = _utility.SaveFile(currentFile, @"assets/PropertyImages");
                                _propertyImage.ImagePath = _imagePath;
                                _propertyImage.PropertyID = _propertyId;
                                _propertyImage.uid = Guid.NewGuid().ToString();
                                _propertyImage.Description = "Image of property with Id:" + Convert.ToString(_propertyId);
                                _unitofWork.PropertyImages.Add(_propertyImage);
                                // _unitofWork.Save();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //LogErrorDetail(ex, "Property/UpdatePropertyImages");
                throw;
            }
        }
        [Authorize(Roles = WebSiteRoles.Role_Admin + "," + WebSiteRoles.Role_Landlord)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PropertyPics(PropertyVM propertyVM, IFormFile filecoverImage, List<IFormFile> imageFiles)
        {
            try
            {
                Int64 PID = propertyVM.Property.ID;
                ModelState.Clear();
                if (PID != null && PID != 0)
                {
                    if (filecoverImage != null || imageFiles != null)
                    {
                        Property property = _unitofWork.Property.Get(x => x.ID == PID);
                        if (filecoverImage != null)
                        {
                            _utility.DeletFile(property.CoverImage);
                            string _coverImagePath = _utility.SaveFile(filecoverImage, @"assets/PropertyImages");
                            property.CoverImage = _coverImagePath;
                            _unitofWork.Property.update(property);
                            _unitofWork.Save();
                            TempData["success"] = "New cover image for property added successfully!";
                        }
                        if (imageFiles != null)
                        {
                            Int64 _propertyId = property.ID;
                            foreach (var file in imageFiles)
                            {
                                IFormFile currentFile = file;
                                PropertyImage _propertyImage = new PropertyImage();
                                string _imagePath = _utility.SaveFile(currentFile, @"assets/PropertyImages");
                                _propertyImage.ImagePath = _imagePath;
                                _propertyImage.PropertyID = _propertyId;
                                _propertyImage.uid = Guid.NewGuid().ToString();
                                _propertyImage.Description = "Image of property with Id:" + Convert.ToString(_propertyId);
                                _unitofWork.PropertyImages.Add(_propertyImage);
                                _unitofWork.Save();
                            }
                            if (TempData["success"] != null)
                            {
                                TempData["success"] = "New cover and images for property has been added successfully !";
                            }
                            else
                            {
                                TempData["success"] = "New images for property has been added successfully !";
                            }
                        }
                    }
                }

                return RedirectToAction("Index");
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
