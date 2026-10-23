using Gharshare.Models;
using Microsoft.AspNetCore.Mvc;

namespace smartpropertymanager.pk.Controllers
{
    public class transactionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult transcompleted()
        {
            var transactionStatus = Request.Query["TS"].ToString();
           // var transactionMessage = transactionStatus == "F" ? "Transaction Failed" : "Transaction Successful";
            var orderId = Request.Query["O"].ToString();
            var transResult = new Transactionresult
            {
                OrderId = orderId,
                TransactionStatus = transactionStatus,
            };
            return View(transResult);
        }
    }
}
