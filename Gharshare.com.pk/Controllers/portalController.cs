using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using System.Security.Claims;
using Gharshare.Views.Shared.Components.SearchBar;
using Gharshare.CommonHelper;
using IronPdf;
using iText.Commons.Utils;
using System.Net;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using System.Web.Helpers;
using smartpropertymanager.pk.classes;
using System.Drawing;
using System.Linq;
 
namespace Gharshare.com.pk.Areas.portal.Controllers
{
    public class portalController : Controller
    {
        private IUnitofWork _unitofWork;
        private Utility _utility;
        private readonly UserManager<ApplicationUser> _userManager;
        private ControllerContext _controllerContext;
        public portalController(IUnitofWork iunitofWork, Utility utility,
            UserManager<ApplicationUser> userManager)
        {
            _unitofWork = iunitofWork;
            _utility = utility;
            _userManager = userManager;
        }
        
        public JsonResult updateUserPaymentOption(Int64 selectedOptionId)
        {
            var userId = HttpContext.Session.GetString("_UserId");
            try
            {
                var userAccounts = _unitofWork.UserBankAccount
                    .GetAll(a => a.UserId == userId).ToList();
                userAccounts.ForEach(account =>
                {
                    account.IsSelectedForPayment = false;
                });
                var selectedAccount = _unitofWork.UserBankAccount
                    .Get(a => a.ID == selectedOptionId);
                selectedAccount.IsSelectedForPayment = true;
                selectedAccount.UpdatedbyUserId = userId;
                selectedAccount.UpdatedOn = DateTime.UtcNow;
                _unitofWork.UserBankAccount.update(selectedAccount);
                _unitofWork.Save();
            }
            catch (Exception exp)
            {
                LogErrorDetail(exp, "portal/updateUserPaymentOption");
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { error = "failed" });
            }
            return Json("success");
        }
        public JsonResult saveUserBankAccount(UserBankAccount account)
        {
            try
            {
                if (account != null)
                {
                    var userBankAccount = account;
                    userBankAccount.uid = Guid.NewGuid().ToString();
                    userBankAccount.CreatedOn = DateTime.UtcNow;
                    userBankAccount.PropertyId = Convert.ToInt64(HttpContext.Session.GetString("propertyId"));
                    userBankAccount.AccountType = UserBankAccount.acctype.bankaccount;
                    userBankAccount.UserId = HttpContext.Session.GetString("_UserId");
                    userBankAccount.CreatedbyUserId = HttpContext.Session.GetString("_UserId");
                    _unitofWork.UserBankAccount.Add(userBankAccount);
                    _unitofWork.Save();
                }
            }
            catch (Exception exp)
            {
                LogErrorDetail(exp, "portal/savecard");
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { error = "failed" });
            }
            return Json("success");
        }
        public JsonResult savecard(UserBankAccount card)
        {
            try
            {
                if (card != null)
                {
                    var userCreditCard = card;
                    userCreditCard.uid = Guid.NewGuid().ToString();
                    userCreditCard.CreatedOn = DateTime.UtcNow;
                    userCreditCard.PropertyId = Convert.ToInt64(HttpContext.Session.GetString("propertyId"));
                    userCreditCard.AccountType = UserBankAccount.acctype.creditcard;
                    userCreditCard.UserId = HttpContext.Session.GetString("_UserId");
                    userCreditCard.CreatedbyUserId = HttpContext.Session.GetString("_UserId");
                    //userCreditCard.IsSelectedForPayment = true;
                    _unitofWork.UserBankAccount.Add(userCreditCard);
                    _unitofWork.Save();
                }
            }
            catch (Exception exp)
            {
                LogErrorDetail(exp, "portal/savecard");
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { error = "failed" });
            }
            return Json("success");
        }
        public IActionResult AddPaymentmethod(string paymentMethod)
        {
            if (paymentMethod == "card")
                ViewBag.Paymentmethod = "card";
            else
                ViewBag.Paymentmethod = "bank";
            return View();
        }
        public IActionResult selectpaymentoption()
        {
            return View();
        }
        public IActionResult paymentoptions(string pid)
        {
            PaymentoptionsVm paymentoptions = null;
            var property = _unitofWork.Property.Get(p => p.uid == pid);
            HttpContext.Session.SetString("propertyId", property.ID.ToString());
            try
            {
                var userId = HttpContext.Session.GetString("_UserId");
                paymentoptions = new PaymentoptionsVm
                {
                    UserBankAccounts = _unitofWork.UserBankAccount
                    .GetAll(ba => ba.UserId == userId
                    && ba.AccountType == UserBankAccount.acctype.bankaccount)
                    .ToList(),
                    UserCreditCard = _unitofWork.UserBankAccount
                    .GetAll(ba => ba.UserId == userId
                    && ba.AccountType == UserBankAccount.acctype.creditcard)
                    .ToList()
                };
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
            return View(paymentoptions);
        }
        public JsonResult getCreaditCard(Int64 propertyId)
        {
            UserBankAccount creditCard = null;
            try
            {
                creditCard = _unitofWork.UserBankAccount
                    .Get(cc => cc.PropertyId == propertyId
                    && cc.AccountType == UserBankAccount.acctype.creditcard);
            }
            catch (Exception exp)
            {
                LogErrorDetail(exp, "portal/getCreaditCard");
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { error = "failed" });
            }
            return Json(creditCard);
        }
        public JsonResult getBankAccount(Int64 leaseId)
        {
            LeaseAgreement leaseDb = null;
            try
            {
                leaseDb = _unitofWork.LeaseAgreement.Get(la => la.ID == leaseId);
            }
            catch (Exception exp)
            {
                LogErrorDetail(exp, "portal/getBankAccount");
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { error = "failed" });
            }
            return Json(leaseDb);
        }
        public JsonResult updateUserCreditcard(BillingVm billingVm)
        {
            try
            {
                if (billingVm.UserCreditCard != null)
                {
                    var userCreditCardDb = _unitofWork.UserBankAccount
                        .Get(uc => uc.ID == billingVm.UserCreditCard.ID);
                    if (userCreditCardDb != null)
                    {
                        userCreditCardDb.CardHolderName = billingVm.UserCreditCard.CardHolderName;
                        userCreditCardDb.CardNo = billingVm.UserCreditCard.CardNo;
                        userCreditCardDb.CardType = billingVm.UserCreditCard.CardType;
                        userCreditCardDb.Month = billingVm.UserCreditCard.Month;
                        userCreditCardDb.Year = billingVm.UserCreditCard.Year;
                        userCreditCardDb.IsSelectedForPayment = billingVm.UserCreditCard.IsSelectedForPayment;
                        userCreditCardDb.UpdatedbyUserId = HttpContext.Session.GetString("_UserId");
                        userCreditCardDb.UpdatedOn = DateTime.UtcNow;
                        _unitofWork.UserBankAccount.update(userCreditCardDb);
                    }
                    else
                    {
                        var userCreditCard = billingVm.UserCreditCard;
                        userCreditCard.uid = Guid.NewGuid().ToString();
                        userCreditCard.CreatedOn = DateTime.UtcNow;
                        userCreditCard.AccountType = UserBankAccount.acctype.creditcard;
                        userCreditCard.UserId = HttpContext.Session.GetString("_UserId");
                        userCreditCard.CreatedbyUserId = HttpContext.Session.GetString("_UserId");
                        _unitofWork.UserBankAccount.Add(userCreditCard);
                    }
                    _unitofWork.Save();
                }
            }
            catch (Exception exp)
            {
                LogErrorDetail(exp, "portal/updateUserBankAccount");
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { error = "failed" });
            }
            return Json("success");
        }
        public JsonResult updateUserBankAccount(BillingVm billingVm)
        {
            try
            {
                if (billingVm.selectedProperty.Lease != null)
                {
                    var leaseDb = _unitofWork.LeaseAgreement
                        .Get(la => la.ID == billingVm.selectedProperty.Lease.ID);
                    leaseDb.BankName = billingVm.selectedProperty.Lease.BankName;
                    leaseDb.Branch = billingVm.selectedProperty.Lease.Branch;
                    leaseDb.AccountTitle = billingVm.selectedProperty.Lease.AccountTitle;
                    leaseDb.AccountNo = billingVm.selectedProperty.Lease.AccountNo;
                    leaseDb.UpdatedbyUserId = HttpContext.Session.GetString("_UserId");
                    leaseDb.UpdatedOn = DateTime.UtcNow;
                    _unitofWork.LeaseAgreement.update(leaseDb);
                    _unitofWork.Save();
                }
            }
            catch (Exception exp)
            {
                LogErrorDetail(exp, "portal/updateUserBankAccount");
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { error = "failed" });
            }
            return Json("success");
        }
        public IActionResult billing()
        {
            var userId = HttpContext.Session.GetString("_UserId");
            BillingVm billing = null;
            try
            {
                var properties = _unitofWork.Property
                    .GetAll(p => p.Owner.Id == userId
                    //&& p.Lease.LeaseStatus == LeaseAgreement.status.Active
                    , includeProperties: "Lease")
                    .ToList()
                    .OrderBy(p => p.Address);

                billing = new BillingVm
                {
                    Payments = _unitofWork.UserPayment
                    .GetAll(p => p.UserId == userId,
                    includeProperties: "User,Plan")
                    .ToList(),

                    Leases = properties.Where(p=>p.Lease!=null)
                    .Select(p => new SelectListItem
                    {
                        Text = p.Address,
                        Value = p.Lease.ID.ToString()
                    }).ToList(),

                    Properties = properties
                    .Select(p => new SelectListItem
                    {
                        Text = p.Address,
                        Value = p.ID.ToString()
                    }).ToList(),
                    selectedProperty = properties.FirstOrDefault(),

                    UserCreditCard = _unitofWork.UserBankAccount
                    .Get(a => a.AccountType == UserBankAccount.acctype.creditcard
                    && a.IsSelectedForPayment == true
                    && a.PropertyId == properties.FirstOrDefault().ID)
                };
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
            return View(billing);
        }
        public IActionResult checkout(string uid)
        {
            try
            {
                var property = _unitofWork.Property.Get(p => p.uid == uid);
                var propertyId = property.ID;
                vmPricing vmPricing = new vmPricing();
                var plans = _unitofWork.Plan
                    .GetAll(p => p.PlanType == Plan.Plantype.forlandlord,
                    includeProperties: "Services.Service")
                    .ToList();
                var services = _unitofWork.Service.GetAll(s => s.IsActive == true)
                    .ToList();
                vmPricing.Match = _unitofWork.Service.GetAll(s => s.IsActive == true &&
                s.Type == Service.ServiceType.Match).ToList();
                vmPricing.Manage = _unitofWork.Service.GetAll(s => s.Type == Service.ServiceType.Manage
                && s.IsActive == true)
                    .ToList();
                vmPricing.Maintain = _unitofWork.Service.GetAll(s => s.IsActive == true &&
                s.Type == Service.ServiceType.Maintain).ToList();
                vmPricing.Testimonials = _unitofWork.Testimonial.GetAll(t => t.IsShown == true)
                    .ToList();
                vmPricing.Plans = plans;
                vmPricing.Services = services;
                vmPricing.DefaultPlan = _unitofWork.Plan.Get(p => p.DefaultPlan == true);
                ViewBag.PropertyAddress = _unitofWork.Property
                    .Get(p => p.ID == propertyId).Address;
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

[HttpGet]
        public async Task<IActionResult> viewleasedoc(string uid)
        {
            try
            {
                LeaseAgreement leaseAgreement = _unitofWork.LeaseAgreement.Get(x => x.uid == uid,
                    includeProperties: "Property.Owner,PrimaryTenant");
                LeaseViewVM leaseViewVM = new LeaseViewVM
                {
                    leaseAgreement = leaseAgreement,
                    LeasePdfDoc = _unitofWork.Document
                    .Get(x => x.LeaseAgreementID == leaseAgreement.ID && x.DocumentTypeID == 2)
                };
                return View(leaseViewVM);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }

        }
        public IActionResult rentalpayments(string lid, string pid)
        {
            var leaseViewVM = new LeaseViewVM();
            try
            {
                Property Property = _unitofWork.Property
                    .Get(x => x.uid == pid);
                var leaseAgreement = _unitofWork.LeaseAgreement
                    .Get(la => la.uid == lid, includeProperties: "Property.Owner,PrimaryTenant");
                leaseViewVM.leaseAgreement = leaseAgreement;

                leaseViewVM.Leases = _unitofWork.LeaseAgreement.
                    GetAll(la => la.PropertyID == Property.ID
                    , includeProperties: "Property.Owner,PrimaryTenant")
                    .Select(l => new SelectListItem
                    {
                        Text = l.ID + " " + l.PrimaryTenant.FirstName + " " +
                        Utility.ConvertToShortDateFormat(l.AgreementDate),
                        Value = Convert.ToString(l.ID)
                    });
                leaseViewVM.RentalPayments = _unitofWork.RentalPayment
                    .GetAll(rp => rp.LeaseAgreementID == leaseAgreement.ID
                    & rp.PaymentStaus == RentalPayment.status.paid ||
                    rp.PaymentStaus == RentalPayment.status.partiallypaid)
                    .ToList();

                var nextRentalPayment = _unitofWork.RentalPayment
                    .GetAll(rp => rp.LeaseAgreementID == leaseAgreement.ID
                    & rp.PaymentStaus == RentalPayment.status.due)
                    .OrderBy(rp => rp.PaymentDate)
                    .FirstOrDefault();

                if (nextRentalPayment != null)
                {
                    var nextPaymentDueAmount = Utility.Format(nextRentalPayment.AmountDue);
                    var nextPaymentDueDate = Utility
                        .ConvertToShortDateFormat(nextRentalPayment.DueDate);

                    ViewBag.nextPaymentDueAmount = nextPaymentDueAmount;
                    ViewBag.nextPaymentDueDate = nextPaymentDueDate;
                }
                else
                {
                    ViewBag.nextPaymentDueAmount = "N/A";
                    ViewBag.nextPaymentDueDate = "N/A";
                }
                var paymentsCompleted = _unitofWork.RentalPayment
                    .GetAll(rp => rp.LeaseAgreementID == leaseAgreement.ID
                    & rp.PaymentStaus == RentalPayment.status.paid).ToList()
                    .Count();
                ViewBag.PaymentsCompleted = paymentsCompleted;

                var paymentsRemaining = _unitofWork.RentalPayment
                    .GetAll(rp => rp.LeaseAgreementID == leaseAgreement.ID
                    & rp.PaymentStaus == RentalPayment.status.due).ToList()
                    .Count();
                ViewBag.PaymentsRemaining = Utility.Format(paymentsRemaining);

                var outstandingBalance = _unitofWork.RentalPayment
                    .GetAll(rp => rp.LeaseAgreementID == leaseAgreement.ID
                    & rp.PaymentStaus == RentalPayment.status.due).ToList()
                    .Sum(x => x.AmountDue);
                ViewBag.outstandingBalance = Utility.Format(outstandingBalance);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
            return View(leaseViewVM);
        }
        public IActionResult download(string uid)
        {
            byte[] bytes;
            try
            {
                Document LeasePdfDoc = _unitofWork.Document.Get(x => x.uid == uid);
                string filepath = _utility.GetRootPath() + LeasePdfDoc.FilePath;
                FileStream fs = new System.IO.FileStream(filepath, FileMode.Open, FileAccess.Read);
                bytes = _utility.ReadStream(fs);
                Response.Headers.Add("Content-Disposition", "attachment ;filename=document.pdf");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
            return File(bytes, "text /plain", "document.pdf");
        }
        [HttpGet]
        public IActionResult document(string uid, string? filepath)
        {
            try
            {
                Document doc = null;
                if (filepath != string.Empty && filepath != null)
                    doc = _unitofWork.Document.Get(x => x.FilePath == filepath,
                    includeProperties: "DocumentType");
                else
                    doc = _unitofWork.Document.Get(x => x.uid == uid, includeProperties: "DocumentType");
                return View(doc);
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> deletedocument(Document document)
        {
            try
            {
                if (document != null)
                {
                    _utility.DeletFile(document.FilePath);
                    var doc = _unitofWork.Document.Get(d => d.ID == document.ID);
                    _unitofWork.Document.Delete(doc);
                    _unitofWork.Save();
                    TempData["success"] = "Record successfully deleted !";
                }
                return RedirectToAction("documents", "portal");
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
        public async Task<IActionResult> deletedocument(Int64 ID)
        {
            try
            {
                var expense = _unitofWork.Document.Get(d => d.ID == ID,
                    includeProperties: "DocumentType,Property");
                return View(expense);
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
        public async Task<IActionResult> viewdoc(Int64 id)
        {
            try
            {
                var doc = _unitofWork.BondAttachment.Get(x => x.ID == id);
                return View(doc);
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
        public async Task<IActionResult> viewconditionreport(string ID)
        {
            try
            {
                var conditionreport = _unitofWork.ConditionReport.Get(x => x.uid == ID,
                    includeProperties: "Property");
                return View(conditionreport);
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
        public IActionResult downloadcreport(string ID)
        {
            try
            {
                var conditionReport = _unitofWork.ConditionReport.Get(x => x.uid == ID);
                string filepath = _utility.GetRootPath() + conditionReport.FilePath;
                FileStream fs = new System.IO.FileStream(filepath, FileMode.Open, FileAccess.Read);
                byte[] bytes = _utility.ReadStream(fs);
                Response.Headers.Add("Content-Disposition", "attachment ;filename=ConditionReport.pdf");
                return File(bytes, "text /plain", "ConditionReport.pdf");
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
        public async Task<IActionResult> expense(string pid)
        {
            try
            {
                var property = _unitofWork.Property.Get(p => p.uid == pid);
                var expense = GetExpenses(pid);
                var activeLease = _unitofWork.LeaseAgreement.Get(la => la.PropertyID == property.ID &&
            la.LeaseStatus == LeaseAgreement.status.Active ||
            la.LeaseStatus == LeaseAgreement.status.Created);
                ViewData["propertyaddress"] = property.Address;
                if (activeLease != null)
                    ViewBag.LeaseId = activeLease.ID;
                else
                    ViewBag.LeaseId = null;
                ViewBag.PropertyId = property.ID;
                #region apply paging on properties
                int pageSize = Pager.GetPageSize();

                int currentPage = 1;
                int recsCount = expense.Count();
                int recSkip = (currentPage - 1) * pageSize;
                expense = expense.Skip(recSkip).Take(pageSize).ToList();
                var pager = new Pager(recsCount, currentPage, "", "", pageSize, "", "", expense.Count(),
                    "getExpenses", 0, pid);
                ViewBag.Pager = pager;
                #endregion
                return View(expense);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        private List<Expense> GetExpenses(string pid)
        {
            var property = _unitofWork.Property.Get(p => p.uid == pid);
            List<Expense> expense = _unitofWork.Expense.GetAll(x => x.PropertyID == property.ID,
                includeProperties: "Category,ExpenseDocuments,Property").ToList();
            HttpContext.Session.SetString("PropertyId", property.ID.ToString());
            return (expense);
        }
        public JsonResult GetExpenseList(int currentPage, string searchPhrase, string pid, int? sortOrderNo = 1)
        {
            var property = _unitofWork.Property.Get(p => p.uid == pid);
            var expense = GetExpenses(pid);
            var activeLease = _unitofWork.LeaseAgreement.Get(la => la.PropertyID == property.ID &&
        la.LeaseStatus == LeaseAgreement.status.Active || la.LeaseStatus == LeaseAgreement.status.Created);
            #region apply paging on properties
            int pageSize = Pager.GetPageSize();
            if (currentPage < 1)
                currentPage = 1;
            int recsCount = expense.Count();
            int recSkip = (currentPage - 1) * pageSize;
            expense = expense.Skip(recSkip).Take(pageSize).ToList();
            var pager = new Pager(recsCount, currentPage, "", "", pageSize, searchPhrase, "", expense.Count(),
                "getExpenses", (int)sortOrderNo, pid);
            ViewBag.Pager = pager;
            #endregion
            // Create a new list to hold the transformed documents
            //List<object> transformedDocuments = new List<object>();

            //// Loop through each document and transform it
            //foreach (var document in documents)
            //{
            //    var transformedDocument = new
            //    {
            //        ID = document.ID,
            //        UID = document.uid,
            //        Title = document.DocumentType.Title,
            //        CreatedBy = document.CreatedbyUser?.Name,
            //        PropertyAddress = document.Property.Address,
            //        CreatedOn = document.CreatedOn,
            //    };
            //    transformedDocuments.Add(transformedDocument);
            //}

            // Create a JSON object to hold the transformed documents and any other required data
            var result = new
            {
                Expenses = expense, //transformedDocuments,
                Pager = pager,
                LeaseId = activeLease.ID
            };

            // Return the JSON result
            return new JsonResult(result);
        }
        //private async void GeneratePDF()
        //{
        //    string htmlforPdf = await _utility.RenderViewToStringAsync("expense", expense, ControllerContext);
        //    var Renderer = new ChromePdfRenderer();
        //    var PDF = Renderer.RenderHtmlAsPdf(htmlforPdf);
        //    ViewBag.PrintPdf = "Yes"; // to set Layout of the view to null 
        //    string filename = _utility.GenerateFileName("expense.pdf", @"assets/pdfdocs");
        //    var contentlength = PDF.BinaryData.Length;
        //    Response.Headers["Content-Length"] = contentlength.ToString();
        //    Response.Headers.Add("Content-Disposition", "inline;filename=" + filename);
        //    PDF.SaveAs(filename);
        //    //return File(PDF.BinaryData, "application/pdf;"); //to get file from a view and open in browser
        //}

        [HttpPost]
        public async Task<IActionResult> addexpense(Expense expense, List<IFormFile> receipts)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string propertyId = HttpContext.Session.GetString("PropertyId");
                    var property = _unitofWork.Property.Get(p => p.ID == Convert.ToInt64(propertyId));
                    expense.PropertyID = Convert.ToInt64(propertyId);
                    expense.uid = Guid.NewGuid().ToString();
                    expense.CreatedbyUserId = HttpContext.Session.GetString("_UserId");
                    _unitofWork.Expense.Add(expense);
                    _unitofWork.Save();

                    List<ExpenseDocument> expenseDocuments = new List<ExpenseDocument>();

                    foreach (var file in receipts)
                    {
                        IFormFile currentFile = file;
                        string _filePath = _utility.SaveFile(currentFile, @"assets/ExpenseReceipts");
                        if (_filePath != null)
                        {
                            ExpenseDocument expenseDocument = new ExpenseDocument
                            {
                                ExpenseID = expense.ID,
                                FilePath = _filePath,
                                CreatedbyUserId = HttpContext.Session.GetString("_UserId"),
                                uid = Guid.NewGuid().ToString()
                            };
                            expenseDocuments.Add(expenseDocument);
                        }
                    }
                    _unitofWork.ExpenseDocument.AddRange(expenseDocuments);
                    _unitofWork.Save();
                    TempData["success"] = "Record successfully saved !";
                    string pid = HttpContext.Session.GetString("PropertyId");
                    return RedirectToAction("expense", new { pid = property.uid });

                }
                return View(expense);
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
        public async Task<IActionResult> addexpense(Int64 pid)
        {
            try
            {
                Expense expense = new Expense();
                expense.PropertyID = pid;
                ViewBag.PropertyID = pid; // to provide pid as route value to cancel button
                ViewBag.Categories = LoadCategories();
                return View(expense);
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
        public async Task<IActionResult> editexpense(Int64 id)
        {
            try
            {
                Expense expense = _unitofWork.Expense.Get(x => x.ID == id, includeProperties: "ExpenseDocuments");
                List<SelectListItem> Categories = LoadCategories();
                ViewBag.Categories = Categories;
                return View(expense);
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
        public async Task<IActionResult> editexpense(Expense expense)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    expense.UpdatedbyUserId = HttpContext.Session.GetString("_UserId");
                    expense.UpdatedOn = DateTime.Now;
                    _unitofWork.Expense.update(expense);
                    _unitofWork.Save();
                    TempData["success"] = "Record successfully updated !";
                }
                string pid = HttpContext.Session.GetString("PropertyId");
                string lid = HttpContext.Session.GetString("LeaseId");
                return RedirectToAction("expense", new { pid });
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
        public async Task<IActionResult> editmaitenance(Int64 id)
        {
            try
            {
                Maintenance maintenance = _unitofWork.Maintenance.Get(x => x.ID == id, includeProperties: "MaintenanceDocuments");
                List<SelectListItem> Categories = LoadCategories();
                ViewBag.Categories = Categories;
                return View(maintenance);
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> deleteexpense(Expense expense)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    List<ExpenseDocument> expenseDocuments = _unitofWork.ExpenseDocument.GetAll(x => x.ExpenseID == expense.ID).ToList();

                    foreach (var file in expenseDocuments)
                    {
                        _utility.DeletFile(file.FilePath);
                    }
                    _unitofWork.ExpenseDocument.DeleteRange(expenseDocuments);
                    _unitofWork.Expense.Delete(expense);
                    _unitofWork.Save();
                    TempData["success"] = "Record successfully deleted !";
                }
                string pid = HttpContext.Session.GetString("PropertyId");
                ViewBag.PropertyId = pid;
                return RedirectToAction("expense", new { pid });
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
        public async Task<IActionResult> deleteexpense(Int64 ID)
        {
            try
            {
                Expense expense = _unitofWork.Expense.Get(x => x.ID == ID);
                List<SelectListItem> Categories = LoadCategories();
                ViewBag.Categories = Categories;
                ViewBag.PropertyId = HttpContext.Session.GetString("PropertyId");
                return View(expense);
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
        public async Task<IActionResult> deletemaitenance(Int64 ID)
        {
            try
            {
                Maintenance maintenance = _unitofWork.Maintenance.Get(x => x.ID == ID, includeProperties: "MaintenanceDocuments");
                List<SelectListItem> Categories = LoadCategories();
                ViewBag.Categories = Categories;
                ViewBag.PropertyId = HttpContext.Session.GetString("PropertyId");
                return View(maintenance);
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> deletemaitenance(Maintenance maintenance)
        {
            try
            {
                if (maintenance.ID > 0)
                {
                    List<MaintenanceDocument> maintenanceDocuments = _unitofWork.MaintenanceDocument
                        .GetAll(x => x.MaintenanceID == maintenance.ID).ToList();

                    foreach (var file in maintenanceDocuments)
                    {
                        _utility.DeletFile(file.FilePath);
                    }
                    _unitofWork.MaintenanceDocument.DeleteRange(maintenanceDocuments);
                    _unitofWork.Maintenance.Delete(maintenance);
                    _unitofWork.Save();
                    TempData["success"] = "Record successfully deleted !";
                }
                string pid = HttpContext.Session.GetString("PropertyId");
                string lid = HttpContext.Session.GetString("LeaseId");

                ViewBag.LeaseId = lid;
                ViewBag.PropertyId = pid;
                var property = _unitofWork.Property.Get(p => p.ID == Convert.ToInt64(pid));
                string pUid = null;
                if (property != null)
                    pUid = property.uid;
                var lease = _unitofWork.LeaseAgreement.Get(l => l.ID == Convert.ToInt64(lid));
                string lUid = null;
                if (lease != null)
                    lUid = lease.uid;
                return RedirectToAction("maintenance", new { lid=lUid, pid=pUid });
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
        public async Task<IActionResult> editmaitenance(Maintenance maintenance)
        {
            try
            {
                if (maintenance.ID > 0)
                {
                    maintenance.UpdatedbyUserID = HttpContext.Session.GetString("_UserId");
                    _unitofWork.Maintenance.update(maintenance);
                    _unitofWork.Save();
                    TempData["success"] = "Record successfully updated !";
                }
                string pid = HttpContext.Session.GetString("PropertyId");
                string lid = HttpContext.Session.GetString("LeaseId");

                var property = _unitofWork.Property.Get(p => p.ID == Convert.ToInt64(pid));
                string pUid = null;
                if (property != null)
                    pUid = property.uid;
                var lease = _unitofWork.LeaseAgreement.Get(l => l.ID == Convert.ToInt64(lid));
                string lUid = null;
                if (lease != null)
                    lUid = lease.uid;
                return RedirectToAction("maintenance", new { lid = lUid, pid = pUid });
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
        public async Task<IActionResult> addmaintenance(Maintenance maintenance, List<IFormFile> photos, List<IFormFile> receipts)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string userType = HttpContext.Session.GetString("_UserType");
                    string propertyId = HttpContext.Session.GetString("PropertyId");
                    string leaseId = HttpContext.Session.GetString("LeaseId");
                    if (propertyId != null)
                        maintenance.PropertyID = Convert.ToInt64(propertyId);
                    if (leaseId != null)
                        maintenance.LeaseAgreementID = Convert.ToInt64(leaseId);

                    maintenance.CreatedbyUserID = HttpContext.Session.GetString("_UserId");

                    if (userType == WebSiteRoles.Role_Tenant)
                        maintenance.Addedby = 2; //maintenance added by tenant   
                    else
                    {
                        maintenance.Addedby = 1; //maintenance added by landlord
                        maintenance.Status = 1;
                    }
                    maintenance.uid = Guid.NewGuid().ToString();
                    _unitofWork.Maintenance.Add(maintenance);
                    _unitofWork.Save();

                    List<MaintenanceDocument> maintenancePhotos = new List<MaintenanceDocument>();

                    foreach (var file in photos)
                    {
                        IFormFile currentFile = file;
                        string _filePath = _utility.SaveFile(currentFile, @"assets/MaintenanceDocs");
                        if (_filePath != null)
                        {
                            MaintenanceDocument maintenancePhoto = new MaintenanceDocument
                            {
                                MaintenanceID = maintenance.ID,
                                LeaseAgreementID = maintenance.LeaseAgreementID,
                                PropertyID = maintenance.PropertyID,
                                FilePath = _filePath,
                                IsPhoto = true,
                                CreatedbyUserID = HttpContext.Session.GetString("_UserId"),
                                uid = Guid.NewGuid().ToString()
                            };
                            maintenancePhotos.Add(maintenancePhoto);
                        }
                    }
                    _unitofWork.MaintenanceDocument.AddRange(maintenancePhotos);

                    List<MaintenanceDocument> maintenanceReceipts = new List<MaintenanceDocument>();

                    foreach (var file in receipts)
                    {
                        IFormFile currentFile = file;
                        string _filePath = _utility.SaveFile(currentFile, @"assets/MaintenanceDocs");
                        if (_filePath != null)
                        {
                            MaintenanceDocument maintenanceReceipt = new MaintenanceDocument
                            {
                                MaintenanceID = maintenance.ID,
                                LeaseAgreementID = maintenance.LeaseAgreementID,
                                PropertyID = maintenance.PropertyID,
                                FilePath = _filePath,
                                IsPhoto = false,
                                CreatedbyUserID = HttpContext.Session.GetString("_UserId"),
                                uid = Guid.NewGuid().ToString()
                            };
                            maintenanceReceipts.Add(maintenanceReceipt);
                        }
                    }
                    _unitofWork.MaintenanceDocument.AddRange(maintenanceReceipts);
                    _unitofWork.Save();

                }
                string pid = HttpContext.Session.GetString("PropertyId");
                string lid = HttpContext.Session.GetString("LeaseId");
                var maintenanceDb = _unitofWork.Maintenance.Get(m => m.ID == maintenance.ID,
                    includeProperties: "Property,LeaseAgreement");
                var propertyUid = maintenanceDb.Property.uid;

                if (maintenanceDb.LeaseAgreement != null)
                    lid = maintenanceDb.LeaseAgreement.uid;
                else
                    lid = null;

                return RedirectToAction("maintenance", new { lid= lid, pid=propertyUid });
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
        public async Task<IActionResult> addmaintenance()
        {
            try
            {
                ViewBag.Categories = LoadCategories();
                Maintenance maintenance = new Maintenance();
                return View(maintenance);
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
        public async Task<IActionResult> maintenance(string lid, string pid)
        {
            try
            {
                var maintenance = MaintenanceList(lid, pid);
                #region Paging
                int pageSize = Pager.GetPageSize();
                int currentPage = 1;
                int recsCount = maintenance.Count();
                int recSkip = (currentPage - 1) * pageSize;
                maintenance = maintenance.Skip(recSkip).Take(pageSize).ToList();
                var pager = new Pager(recsCount, currentPage, "", "", pageSize, "", "", maintenance.Count(),
                    "getMaintenance", 1, lid,pid);
                ViewBag.Pager = pager;
                #endregion
                return View(maintenance);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        private List<Maintenance> MaintenanceList(string lid, string pid)
        {
            var property = _unitofWork.Property.Get(x => x.uid == pid);
            var lease = _unitofWork.LeaseAgreement.Get(la => la.uid == lid);

            var maintenance = _unitofWork.Maintenance
                    .GetAll(includeProperties: "Category,Property").ToList();
            if (pid != null)
                maintenance = maintenance.Where(x => x.PropertyID == property.ID).ToList();
            if (lid != null)
                maintenance = maintenance.Where(x => x.LeaseAgreementID == lease.ID).ToList();

            if (HttpContext.Session.GetString("_UserType") == WebSiteRoles.Role_Tenant)
                maintenance = maintenance
                    .Where(x => x.Addedby == 2).ToList();// show only added by tenant                 
            if (property != null)
            {
                ViewBag.PropertyAddress = property.Address;
                HttpContext.Session.SetString("PropertyId", property.ID.ToString());
            }
            else
            {
                ViewBag.PropertyAddress = null;
            }
            if (lease != null)
                HttpContext.Session.SetString("LeaseId", lease.ID.ToString()); 
            return maintenance;
        }
        public JsonResult GetMaintenanceList(int currentPage, string leaseId, string propertyid,
             string searchText, int? sortOrderNo = 1)
        {
            var maintenance = MaintenanceList(leaseId, propertyid);
            #region apply paging on properties
            int pageSize = Pager.GetPageSize();
            if (currentPage < 1)
                currentPage = 1;
            int recsCount = maintenance.Count();
            int recSkip = (currentPage - 1) * pageSize;
            maintenance = maintenance.Skip(recSkip).Take(pageSize).ToList();
            var pager = new Pager(recsCount, currentPage, "", "", pageSize, searchText, "", maintenance.Count(),
                "getMaintenance", (int)sortOrderNo,leaseId,propertyid);
            ViewBag.Pager = pager;
            #endregion
            // Create a new list to hold the transformed documents
            List<object> transformedMaintenanceList = new List<object>();

            //// Loop through each document and transform it
            foreach (var maint in maintenance)
            {
                var transformedMaintenance = new
                {
                    ID = maint.ID,
                    UID = maint.uid,
                    Addedby=maint.Addedby,
                    CategoryTitle = maint.Category.Title,
                    Title = maint.Title,
                    Description=maint.Description,
                    Amount=maint.Description,
                    PropertyAddress =maint.Property.Address,
                    Status=maint.Status,                     
                    CreatedOn = maint.CreatedOn,
                };
                transformedMaintenanceList.Add(transformedMaintenance);
            }             
            // Create a JSON object to hold the transformed documents and any other required data
            var result = new
            {
                Maintenance = transformedMaintenanceList,
                Pager = pager,
            };

            // Return the JSON result
            return new JsonResult(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> paybill(Int64 billId)
        {
            try
            {
                string UserId = HttpContext.Session.GetString("_UserId");
                string UserAccountNo = HttpContext.Session.GetString("_UserAccount");
                string PaymentMethod = HttpContext.Session.GetString("_PaymentMethod");
                TenantBill tenantBill = _unitofWork.TenantBill.Get(x => x.ID == billId);

                string result = Pay(UserAccountNo, PaymentMethod);
                if (result == "success")
                {
                    tenantBill.IsPaidByTenant = true;
                    tenantBill.PaymentDate = DateTime.Now;
                    tenantBill.PaidByUserID = UserId;
                    tenantBill.UpdatedbyUserID = UserId;
                    tenantBill.UpdatedOn = DateTime.Now;
                    _unitofWork.TenantBill.update(tenantBill);
                    _unitofWork.Save();
                    TempData["success"] = "Bill successfully paid !";
                }
                return RedirectToAction("bills", tenantBill.LeaseAgreementID);
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
        public async Task<IActionResult> bill(Int64 ID)
        {
            try
            {
                TenantBill tenantBill = _unitofWork.TenantBill.Get(x => x.ID == ID);
                InitialiseUserPaymentSetting(tenantBill.PropertyID);
                return View(tenantBill);
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
        public IActionResult documents(Int64? propertyid = 0, Int64? leaseid = 0)
        {
            try
            {
                var documents = GetDocuments(propertyid, leaseid);
                #region apply paging on properties
                int pageSize = Pager.GetPageSize();

                int currentPage = 1;
                int recsCount = documents.Count();
                int recSkip = (currentPage - 1) * pageSize;
                documents = documents.Skip(recSkip).Take(pageSize).ToList();
                var pager = new Pager(recsCount, currentPage, "", "", pageSize, "", "", documents.Count(),
                    "getDocuments");
                ViewBag.Pager = pager;
                #endregion
                return View(documents);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }

        private List<Document> GetDocuments(Int64? propertyid = 0, Int64? leaseid = 0)
        {

            List<Document> documents = _unitofWork.Document.GetAll(includeProperties:
                "Property,DocumentType,CreatedbyUser,LeaseAgreement.PrimaryTenant").ToList();
            if (propertyid != 0)
                documents = documents.Where(d => d.PropertyID == propertyid).ToList();
            if (leaseid != 0)
                documents = documents.Where(d => d.LeaseAgreementID == leaseid).ToList();
            var userType = HttpContext.Session.GetString("_UserType");
            var userId = HttpContext.Session.GetString("_UserId");
            if (string.Equals(userType, WebSiteRoles.Role_Landlord, StringComparison.OrdinalIgnoreCase))
            {
                documents = documents.Where(d => d.Property.OwnerId == userId).ToList();
            }
            else if (string.Equals(userType, WebSiteRoles.Role_Tenant, StringComparison.OrdinalIgnoreCase))
            {
                documents = documents.Where(d => d.LeaseAgreement.PrimaryTenant.UserID == userId).ToList();
            }
            return documents;
        }
        public JsonResult GetDocumentList(int currentPage, string searchPhrase, Int64? propertyid = 0,
            Int64? leaseid = 0, int? sortOrderNo = 1)
        {
            var documents = GetDocuments(propertyid, leaseid);

            #region apply paging on properties
            int pageSize = Pager.GetPageSize();
            if (currentPage < 1)
                currentPage = 1;
            int recsCount = documents.Count();
            int recSkip = (currentPage - 1) * pageSize;
            documents = documents.Skip(recSkip).Take(pageSize).ToList();
            var pager = new Pager(recsCount, currentPage, "", "", pageSize, searchPhrase, "", documents.Count(),
                "getDocuments", (int)sortOrderNo);
            ViewBag.Pager = pager;
            #endregion
            // Create a new list to hold the transformed documents
            List<object> transformedDocuments = new List<object>();

            // Loop through each document and transform it
            foreach (var document in documents)
            {
                var transformedDocument = new
                {
                    ID = document.ID,
                    UID = document.uid,
                    Title = document.DocumentType.Title,
                    CreatedBy = document.CreatedbyUser?.Name,
                    PropertyAddress = document.Property.Address,
                    CreatedOn = document.CreatedOn,
                };
                transformedDocuments.Add(transformedDocument);
            }

            // Create a JSON object to hold the transformed documents and any other required data
            var result = new
            {
                Documents = transformedDocuments,
                Pager = pager
            };

            // Return the JSON result
            return new JsonResult(result);
        }
        [HttpGet]
        public async Task<IActionResult> bills(string ID)
        {
            try
            {
                var lease = _unitofWork.LeaseAgreement.Get(la => la.uid == ID);
                ViewBag.LeaseID = lease.ID;
                List<TenantBill> tenantBills = _unitofWork.TenantBill.GetAll(x => x.LeaseAgreementID == lease.ID,
                    includeProperties: "Property,Category,BillDocuments,LeaseAgreement").ToList();
                var userType = HttpContext.Session.GetString("_UserType");
                if (string.Equals(userType, WebSiteRoles.Role_Tenant, StringComparison.OrdinalIgnoreCase))
                    tenantBills = tenantBills.Where(b => b.BillTenantNow == true).ToList();
                var property = _unitofWork.Property.Get(p => p.Lease.ID == lease.ID, includeProperties: "Lease");
                if (property != null)
                    ViewData["propertyAddress"] = property.Address;
                else
                    ViewData["propertyAddress"] = "";
                #region
                int pageSize = Pager.GetPageSize();
                int currentPage = 1;
                int recsCount = tenantBills.Count();
                int recSkip = (currentPage - 1) * pageSize;
                tenantBills = tenantBills.Skip(recSkip).Take(pageSize).ToList();
                var pager = new Pager(recsCount, currentPage, "", "", pageSize, "", "", tenantBills.Count(),
                    "getBills", 1, ID);
                ViewBag.Pager = pager;
                #endregion
                return View(tenantBills);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        public JsonResult GetBillList(int currentPage, string billId, string searchPhrase, int? sortOrderNo = 1)
        {
            var lease = _unitofWork.LeaseAgreement.Get(la => la.uid == billId);

            List<TenantBill> tenantBills = _unitofWork.TenantBill.GetAll(x => x.LeaseAgreementID == lease.ID,
                includeProperties: "Category,BillDocuments").ToList();
            var userType = HttpContext.Session.GetString("_UserType");
            if (string.Equals(userType, WebSiteRoles.Role_Tenant, StringComparison.OrdinalIgnoreCase))
                tenantBills = tenantBills.Where(b => b.BillTenantNow == true).ToList();
            #region apply paging on properties
            int pageSize = Pager.GetPageSize();

            if (currentPage < 1)
                currentPage = 1;
            int recsCount = tenantBills.Count();
            int recSkip = (currentPage - 1) * pageSize;
            tenantBills = tenantBills.Skip(recSkip).Take(pageSize).ToList();
            var pager = new Pager(recsCount, currentPage, "", "", pageSize, searchPhrase, "", tenantBills.Count(),
                "getBills", (int)sortOrderNo, billId);
            ViewBag.Pager = pager;
            #endregion             
            var result = new
            {
                Bills = tenantBills,
                Pager = pager,
                UserType = userType
            };
            // Return the JSON result
            return new JsonResult(result);
        }
        [HttpGet]
        public async Task<IActionResult> editbill(Int64 id)
        {
            TenantBill bill;
            try
            {
                ViewBag.Categories = LoadCategories();
                bill = _unitofWork.TenantBill.Get(b => b.ID == id);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
            return View(bill);
        }
        //[ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> editbill(TenantBill tenatbill, List<IFormFile> attachment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tenatbill.UpdatedbyUserID = HttpContext.Session.GetString("_UserId");
                    tenatbill.UpdatedOn = DateTime.UtcNow;
                    _unitofWork.TenantBill.update(tenatbill);
                    _unitofWork.Save();
                }
                if (attachment.Count() > 0)
                {
                    List<BillDocument> billlist = new List<BillDocument>();
                    foreach (var file in attachment)
                    {
                        IFormFile currentFile = file;
                        string _filePath = _utility.SaveFile(currentFile, @"assets/Bills");
                        if (_filePath != null)
                        {
                            BillDocument billDocument = new BillDocument
                            {
                                TenantBillID = tenatbill.ID,
                                LeaseAgreementID = tenatbill.LeaseAgreementID,
                                PropertyID = tenatbill.PropertyID,
                                FilePath = _filePath,
                                CreatedbyUserId = HttpContext.Session.GetString("_UserId"),
                                uid = Guid.NewGuid().ToString()
                            };
                            billlist.Add(billDocument);
                        }
                    }
                    _unitofWork.BillDocument.AddRange(billlist);
                    _unitofWork.Save();
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
            var tenantBillDb = _unitofWork.TenantBill.Get(tb => tb.ID == tenatbill.ID,
                        includeProperties: "LeaseAgreement");
            return RedirectToAction("bills", "portal", new { ID = tenantBillDb.LeaseAgreement.uid });
        }
        [HttpPost]
        public IActionResult billtenant(Int64 expenseid, Int64 leaseid)
        {
            try
            {
                ViewBag.Categories = LoadCategories();
                var expense = _unitofWork.Expense.Get(e => e.ID == expenseid);
                Int64 propertyId = expense.PropertyID;
                ViewBag.Amount = expense.Amount;
                ViewBag.createbill = false;
                TenantBill tenantBill = new TenantBill
                {
                    LeaseAgreementID = leaseid,
                    PropertyID = propertyId,
                    Amount = expense.Amount,
                    CategoryID = expense.CategoryID,
                    Title = expense.Title,
                    Description = expense.Description,
                    BillTenantNow = true,
                    CreatedOn = DateTime.UtcNow,
                };
                return View("createbill", tenantBill);
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
        public IActionResult createbill(Int64 leaseID)
        {
            try
            {
                ViewBag.Categories = LoadCategories();
                LeaseAgreement leaseAgreement = _unitofWork.LeaseAgreement.Get(x => x.ID == leaseID);
                Int64 PID = leaseAgreement.PropertyID;
                ViewBag.createbill = true;
                TenantBill tenantBill = new TenantBill
                {
                    LeaseAgreementID = leaseID,
                    PropertyID = PID
                };
                return View(tenantBill);
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
        public async Task<IActionResult> deletebill(Int64 id)
        {
            TenantBill bill;
            try
            {
                ViewBag.Categories = LoadCategories();
                bill = _unitofWork.TenantBill.Get(b => b.ID == id);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
            return View(bill);
        }
        [HttpPost]
        public async Task<IActionResult> deletebill(TenantBill bill)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    List<BillDocument> docs = _unitofWork.BillDocument.
                        GetAll(x => x.TenantBillID == bill.ID).ToList();
                    foreach (var file in docs)
                    {
                        _utility.DeletFile(file.FilePath);
                    }
                    _unitofWork.BillDocument.DeleteRange(docs);
                    _unitofWork.TenantBill.Delete(bill);
                    _unitofWork.Save();
                    TempData["success"] = "Record successfully deleted !";
                }
                var leaseid = bill.LeaseAgreementID;
                return RedirectToAction("bills", "portal", new { ID = leaseid });

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }
        private List<SelectListItem> LoadCategories()
        {
            IEnumerable<SelectListItem> categories = _unitofWork.Category.GetAll().ToList().Select(
                    x => new SelectListItem()
                    {
                        Text = x.Title,
                        Value = Convert.ToString(x.ID)
                    }
                    );
            return categories.ToList();
        }
        [HttpPost]
        public IActionResult createbill(TenantBill tenantBill, List<IFormFile> bill)
        {
            try
            {
                TenantBill tenantBillDb = null;
                if (ModelState.IsValid)
                {
                    tenantBill.CreatedbyUserID = HttpContext.Session.GetString("_UserId");
                    tenantBill.CreatedOn = DateTime.UtcNow;
                    tenantBill.uid = Guid.NewGuid().ToString();
                    _unitofWork.TenantBill.Add(tenantBill);
                    _unitofWork.Save();
                    TempData["success"] = "Bill has been successfully saved!";
                    tenantBillDb = _unitofWork.TenantBill.Get(tb => tb.ID == tenantBill.ID,
                        includeProperties: "LeaseAgreement");
                }
                List<BillDocument> billlist = new List<BillDocument>();

                foreach (var file in bill)
                {
                    IFormFile currentFile = file;
                    string _filePath = _utility.SaveFile(currentFile, @"assets/Bills");
                    if (_filePath != null)
                    {
                        BillDocument billDocument = new BillDocument
                        {
                            TenantBillID = tenantBill.ID,
                            LeaseAgreementID = tenantBill.LeaseAgreementID,
                            PropertyID = tenantBill.PropertyID,
                            FilePath = _filePath,
                            CreatedbyUserId = HttpContext.Session.GetString("_UserId"),
                            uid = Guid.NewGuid().ToString()
                        };
                        billlist.Add(billDocument);
                    }
                }
                _unitofWork.BillDocument.AddRange(billlist);
                _unitofWork.Save();
                return RedirectToAction("bills", "portal", new { ID = tenantBillDb.LeaseAgreement.uid });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }

        public JsonResult DeleteAttachment(Int64 ID)
        {
            try
            {
                BondAttachment bondAttachment = _unitofWork.BondAttachment.Get(x => x.ID == ID);
                _utility.DeletFile(bondAttachment.FilePath);
                _unitofWork.BondAttachment.Delete(bondAttachment);
                _unitofWork.Save();
                TempData["success"] = "Attachment successfully deleted!";
            }
            catch (Exception ex)
            {
                LogErrorDetail(ex, "Portal/DeleteAttachment");
            }
            return Json(true);
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
        [HttpPost]
        public async Task<IActionResult> bondattachement(Int64 ID, List<IFormFile> attachment, bool isAttachment = true)
        {
            try
            {
                if (attachment != null && attachment.Count() != 0)
                {
                    Int64 leaseId = ID;
                    var fileType = BondAttachment.documenttype.landlordattachment;
                    if (isAttachment)
                    {
                        if (string.Equals(HttpContext.Session.GetString("_UserType"),
                            WebSiteRoles.Role_Tenant, StringComparison.OrdinalIgnoreCase))
                            fileType = BondAttachment.documenttype.tenantattachment;
                    }
                    else
                    {
                        if (string.Equals(HttpContext.Session.GetString("_UserType"),
                            WebSiteRoles.Role_Tenant, StringComparison.OrdinalIgnoreCase))
                            fileType = BondAttachment.documenttype.tenantfile;
                        else
                            fileType = BondAttachment.documenttype.landlordfile;
                    }

                    List<BondAttachment> bondAttachmentList = new List<BondAttachment>();

                    foreach (var file in attachment)
                    {
                        IFormFile currentFile = file;
                        string _filePath = _utility.SaveFile(currentFile, @"assets/bondattachment");
                        if (_filePath != null)
                        {
                            BondAttachment bondAttachment = new BondAttachment
                            {
                                LeaseID = ID,
                                type = fileType,
                                FilePath = _filePath,
                                UploadedByUserId = HttpContext.Session.GetString("_UserId"),
                                uid = Guid.NewGuid().ToString()
                            };
                            bondAttachmentList.Add(bondAttachment);
                        }
                    }
                    _unitofWork.BondAttachment.AddRange(bondAttachmentList);
                    _unitofWork.Save();
                    TempData["success"] = "File(s) successfully attached !";
                }
                if (HttpContext.Session.GetString("_UserType") == WebSiteRoles.Role_Landlord)
                    return RedirectToAction("list", "Property");
                else /*if (HttpContext.Session.GetString("_UserType") == WebSiteRoles.Role_Tenant)*/
                    return RedirectToAction("index", "tenant");
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
        [ValidateAntiForgeryToken]
        public IActionResult bond(LeaseAgreement leaseAgreement)
        {
            try
            {
                string UserId = HttpContext.Session.GetString("_UserId");
                string UserAccountNo = HttpContext.Session.GetString("_UserAccount");
                string PaymentMethod = HttpContext.Session.GetString("_PaymentMethod");
                string result = Pay(UserAccountNo, PaymentMethod);
                if (result == "success")
                {
                    RentalPayment rentalPayment = new RentalPayment
                    {
                        PropertyID = leaseAgreement.PropertyID,
                        LeaseAgreementID = leaseAgreement.ID,
                        AmountDue = leaseAgreement.BondAmount,
                        AmountPaid = leaseAgreement.BondAmount,
                        From = leaseAgreement.From,
                        To = leaseAgreement.To,
                        paymentType = RentalPayment.type.bondPayment,
                        Description = "Bond amount paid",
                        PaidById = UserId,
                        UserAgreetoPay = true,
                        PaymentDate = DateTime.Now,
                        uid = Guid.NewGuid().ToString()
                    };
                    _unitofWork.RentalPayment.Add(rentalPayment);
                    LeaseAgreement lease = _unitofWork.LeaseAgreement
                        .Get(x => x.ID == leaseAgreement.ID);
                    lease.IsBondPaid = true;
                    lease.UpdatedbyUserId = UserId;
                    lease.UpdatedOn = DateTime.Now;
                    _unitofWork.LeaseAgreement.update(lease);
                    _unitofWork.Save();
                    TempData["success"] = "Bond payment has been successfully done !";
                }
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }
        }

        private string Pay(string? userAccountNo, string? paymentMethod)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }
            // payment gateway integration to be done later.
            return "success";
        }

        [HttpGet]
        public IActionResult bond(string ID)
        {
            try
            {
                LeaseAgreement leaseAgreement = _unitofWork.LeaseAgreement.Get(x => x.uid == ID,
                    includeProperties: "Property,PrimaryTenant");
                List<BondAttachment> TenantAttachments = _unitofWork.BondAttachment
                    .GetAll(x => x.LeaseID == leaseAgreement.ID
                && x.type == BondAttachment.documenttype.tenantattachment).ToList();
                List<BondAttachment> LandlordAttachments = _unitofWork.BondAttachment
                    .GetAll(x => x.LeaseID == leaseAgreement.ID
                && x.type == BondAttachment.documenttype.landlordattachment).ToList();
                var TenantFiles = _unitofWork.BondAttachment.GetAll(x => x.LeaseID == leaseAgreement.ID
                && x.type == BondAttachment.documenttype.tenantfile).ToList();
                var LandlordFiles = _unitofWork.BondAttachment.GetAll(x => x.LeaseID == leaseAgreement.ID
                && x.type == BondAttachment.documenttype.landlordfile).ToList();
                InitialiseUserPaymentSetting(leaseAgreement.PropertyID);

                BondVM bondVM = new BondVM
                {
                    leaseAgreement = leaseAgreement,
                    TenantAttachments = TenantAttachments,
                    LandlordAttachments = LandlordAttachments,
                    TenantFiles = TenantFiles,
                    LandlordFiles = LandlordFiles
                };
                return View(bondVM);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                TempData["StackTrace"] = ex.StackTrace;
                TempData["Source"] = ex.Source;
                return RedirectToAction("Error", "Error");
            }

        }

        private void InitialiseUserPaymentSetting(Int64 propertyId)
        {
            try
            {
                string userId = HttpContext.Session.GetString("_UserId");
                UserBankAccount userAccount = _unitofWork
                    .UserBankAccount
                    .Get(x => x.UserId == userId && x.PropertyId == propertyId
                    && x.IsSelectedForPayment == true);

                if (userAccount != null)
                {
                    if (userAccount.CardNo != null)
                    {
                        ViewBag.PaymentMethod = "card";
                        ViewBag.UserAccount = userAccount.CardNo;
                        HttpContext.Session.SetString("_UserAccount", userAccount.CardNo);
                        HttpContext.Session.SetString("_CardType", userAccount.CardType.ToString());
                        HttpContext.Session.SetString("_PaymentMethod", "card");
                    }
                    else
                    {
                        ViewBag.PaymentMethod = "bank";
                        ViewBag.UserAccount = userAccount.AccountNo;
                        HttpContext.Session.SetString("_UserAccount", userAccount.AccountNo);
                        HttpContext.Session.SetString("_PaymentMethod", "bank");
                        //HttpContext.Session.SetString("_UserBank", userAccount.Bank);
                    }
                }
                else
                {
                    ViewBag.PaymentMethod = null;
                    ViewBag.UserAccount = null;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public IActionResult Index()
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
