using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gharshare.Models
{
    public class CRItem
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        public Int64 ConditionReportID { get; set; }
        public ConditionReport? ConditionReport { get; set; }
        [Column(TypeName = "nvarchar(70)")]
        public string Name { get; set; }
        public Int64 PropertyAreaID { get; set; }
        public PropertyArea? PropertyArea  { get;set;}

        [Column(TypeName ="nvarchar(500)")]
        [Display(Name = "Additional Comments")]
        public string? Comments { get; set; }
        public DateTime? CreatedOn { get; set; }
        public ApplicationUser? CreatedbyUser { get; set; }
        public string? CreatedbyUserId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public ApplicationUser? UpdatedbyUser { get; set; }
        public string? UpdatedbyUserId { get; set; }
        public List<CRItemDetail>? CRItemDetail { get; set; }
        public List<CRItemImage>? CRItemImages { get; set; }

    }
}
