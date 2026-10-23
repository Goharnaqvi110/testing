using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gharshare.Models
{
    public class PaymentoptionsVm
    {         
        public List<UserBankAccount> UserCreditCard { get; set; }
        public List<UserBankAccount> UserBankAccounts { get; set; }
    }
}
