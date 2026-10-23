using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gharshare.Models
{
    public class Service
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        [Required]
        public string Name { get; set; } 
        public ServiceType Type { get; set; } //Match, Manage, Maintain // 1 for match,
                                         //2 for manage, 3 for maintain
        public string? Description { get; set; }
        public string? PlanIDs { get; set; } // comma-separated PlanID
        public bool IsActive { get; set; } = true;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string? CreatedbyUserID { get; set; }
        public ApplicationUser? CreatedbyUser { get; set; }
        [ValidateNever]
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedbyUserID { get; set; }
        public ApplicationUser? UpdatedbyUser { get; set; }
        public Status status { get; set; } = Status.active;
        public enum Status
        {
            [Display(Name = "Active")]
            active = 1,
            [Display(Name = "Pending")]
            pending = 2,
            [Display(Name = "Canceled")]
            canceled = 3
        }
        public bool InPlan1 { get; set; } = false;
        public bool InPlan2 { get; set; } = false;
        public bool InPlan3 { get; set; } = false;
        //public IEnumerable<PlanService>? Services { get; set; }
        public enum ServiceType { Match = 1, Manage = 2, Maintain = 3 }
        public List<PlanService>? planServices { get; set; }
        [NotMapped]
        public bool isSelected { get; set; } = true;
    }
}
