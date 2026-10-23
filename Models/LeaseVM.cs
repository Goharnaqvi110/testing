using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gharshare.Models
{
    public class LeaseVM
    {
        public Property? Property { get; set; }
        public LeaseAgreement leaseAgreement { get; set; }
        public IEnumerable<SelectListItem>? States { get; set; }
        public IEnumerable<SelectListItem>? Cities { get; set; }
        public IEnumerable<SelectListItem>? Applicants { get; set; }
        public List<Applicant>? AddtionalTenants { get; set; }
        public Applicant? PrimaryTenant { get; set; }
    }
}
