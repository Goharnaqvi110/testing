using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gharshare.Models
{
    public class BillingVm
    {
        public List<SelectListItem> Properties{ get; set; }
        public List<SelectListItem> Leases { get; set; }
        public List<UserPayment>? Payments { get; set; }
        public UserBankAccount UserCreditCard { get; set; }
        public Property selectedProperty { get; set; }
    }
}
