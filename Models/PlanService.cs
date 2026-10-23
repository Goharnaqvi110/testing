using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Reflection;

namespace Gharshare.Models
{
    public class PlanService
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        public Int64 PlanID { get; set; }
        public Plan Plan { get; set; }
        public Int64 ServiceID { get; set; }
        public Service Service { get; set; }
        public bool? isActive { get; set; } = true;
        public bool isSelected { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string? CreatedbyUserID { get; set; }
        public ApplicationUser? CreatedbyUser { get; set; }
        [ValidateNever]
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedbyUserID { get; set; }
        public ApplicationUser? UpdatedbyUser { get; set; }         
    }
}