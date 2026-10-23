using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gharshare.Models
{
    public class BondVM
    {
        public LeaseAgreement leaseAgreement { get; set; }
        public List<BondAttachment>? LandlordAttachments { get; set; }
        public List<BondAttachment>? TenantAttachments { get; set; }
        public List<BondAttachment>? LandlordFiles { get; set; }
        public List<BondAttachment>? TenantFiles { get; set; }
    }
}
