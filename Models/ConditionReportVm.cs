using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gharshare.Models
{
    public class ConditionReportVm
    {
        public ConditionReport? CondtionReport { get; set; }
        [ValidateNever]
        public List<ConditionReport> ReportList { get; set; }         
        public Property? Property { get; set; }
        public IEnumerable<SelectListItem>? PropertyTypes { get; set; }
        public List<PropertyArea>? PropertyArea { get; set; }
        public List<PropertyAreaItem>? PropertyAreaItem { get; set; }
        public List<CRItem>? ReportItems { get; set; }
        public List<CRItemDetail>? ReportItemDetail { get; set; }
        public List<CRItemImage>? PhotosByLandlord { get; set; }
        public List<CRItemImage>? PhotosByTenant { get; set; }
    }
}
