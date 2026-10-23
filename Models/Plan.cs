using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gharshare.Models
{
    public class Plan
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        [Required]
        public string Title { get; set; } // Match, Manage, Maintain
        [Required]
        public PropertyType Type { get; set; } // Residential, Commercial, For Sale
        public enum PropertyType
        {
            [Display(Name = "Residential Property")]
            Residential = 1,
            [Display(Name = "Commercial Property")]
            Commercial = 2,
            [Display(Name = "Property for Sale")]
            Sale = 3
        }
        [Required]
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        public Decimal UpFrontPrice { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        public Decimal? MonthlyCharges { get; set; }
        [Required]
        public string? BoxHeading { get; set; }
        [Required]
        public string? Tagline { get; set; }
        public string? Description { get; set; }
        public bool DefaultPlan { get; set; } = false;
        public string? ImagePath { get; set; }
        [Required]
        public Plantype PlanType { get; set; }
        public enum Plantype
        {
            [Display(Name = "For landlord")]
            forlandlord = 1,
            [Display(Name = "For tenant")]
            fortenant = 2,
            [Display(Name = "For both tenant & landlord")]
            forboth = 3,
        }
        public Status PlanStatus { get; set; }
        public enum Status
        {
            [Display(Name = "Active")]
            active = 1,
            [Display(Name = "Pending")]
            pending = 2,
            [Display(Name = "Canceled")]
            canceled = 3
        }
        public List<PlanService>? Services { get; set; }
        public DateTime? CreatedOn { get; set; } = DateTime.Now;
        public ApplicationUser? CreatedbyUser { get; set; }
        public string? CreatedbyUserId { get; set; }
        [ValidateNever]
        public DateTime? UpdatedOn { get; set; }
        public ApplicationUser? UpdatedbyUser { get; set; }
        public string? UpdatedbyUserId { get; set; }
        public List<UserPlan>? UsersonPlan { get; set; }
    }
}
