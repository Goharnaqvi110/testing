using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gharshare.Models
{
    public class LeaseViewVM
    {
        public Property? Property { get; set; }
        public LeaseAgreement leaseAgreement { get; set; }
        public List<LeaseTenant>? AdditionalTenants { get; set; }
        public Applicant? PrimaryTenant { get; set; }
        public List<SelectListItem>? AllTenants { get; set; }
        public Document? LeasePdfDoc { get; set; }
        public IEnumerable<SelectListItem>? Leases { get; set; }
        public List<RentalPayment>? RentalPayments { get; set; }
    }
}
