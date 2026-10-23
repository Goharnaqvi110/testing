using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Gharshare.Models
{
    public class Maintenance
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        public Int64 CategoryID { get; set; }
        public Category? Category { get; set; }
        public Int64 PropertyID { get; set; }
        [JsonIgnore]
        public Property? Property { get; set; }
        [JsonIgnore]
        public Int64? LeaseAgreementID { get; set; }
        public LeaseAgreement? LeaseAgreement { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(200)")]         
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string? Description { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Display(Name ="GST included?")]
        public bool IsGSTIncluded { get; set; } = false;
        public int Addedby { get; set; } // 1-Landlord 2-Tenant       
        public int Status { get; set; } // 1-Submitted, 2-Pending 3-Complete        
        [ValidateNever]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string? CreatedbyUserID { get; set; }
        public ApplicationUser? CreatedbyUser { get; set; }
        [ValidateNever]
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedbyUserID { get; set; }
        public ApplicationUser? UpdatedbyUser { get; set; }
        [JsonIgnore]
        public List<MaintenanceDocument>? MaintenanceDocuments { get; set; }
    }
}
