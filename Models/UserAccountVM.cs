using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gharshare.Models
{
    public class UserAccountVM
    {
        //public Property? Property { get; set; }
        public LeaseAgreement? Lease { get; set; }
        public UserBankAccount? userBankAccount { get; set; }
    }
}
