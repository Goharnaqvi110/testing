using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gharshare.Models
{
    public class DashboardVM
    {
        public Int64 properties { get; set; } = 0;         
        public Int64 tenants { get; set; } = 0;
        public Int64 landlords { get; set; } = 0;
        public Int64 totalAds { get; set; } = 0;
        public Int64 totalCustomers { get; set; } = 0;
        public decimal totalEarnings { get; set; } = 0;
        public decimal tenantPercent { get; set; }
        public decimal landlordPercent { get; set; }
        public List<ApplicationUser>? recentCustomers { get; set; }
    }
}
