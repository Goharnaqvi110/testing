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
    public class TenantBill   
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        public Int64 CategoryID { get; set; }
        [ValidateNever]        
        public Category Category { get; set; }
        public Int64 PropertyID { get; set; }
        [JsonIgnore]
        public Property? Property { get; set; }
        public Int64 LeaseAgreementID { get; set; }
        [ValidateNever]
        [JsonIgnore]
        public LeaseAgreement LeaseAgreement { get; set; }
        [Required]         
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string? Description { get; set; }
        [Required]
        public decimal? Amount { get; set; } = 0;
        [Required]
        [Display(Name = "Due date")]
        public DateTime DueDate { get; set; }
        [Display(Name = "Payment date")]
        public DateTime? PaymentDate { get; set; }
        [Display(Name = "GST Included?")]
        public bool IsGSTIncluded { get; set; } = false;        
        public bool IsPaidByTenant { get; set; } = false;
        [Display(Name = "Send bill to tenant now?")]
        public bool BillTenantNow { get; set; } = false;
        [Column(TypeName = "nvarchar(500)")]
        public string? Message { get; set; }
        public bool CollectViaGharshare { get; set; } = true;
        [ValidateNever]
        public ApplicationUser? PaidByUser { get; set; }
        public string? PaidByUserID { get; set; }
        [ValidateNever]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [ValidateNever]
        public ApplicationUser? CreatedbyUser { get; set; }
        public string? CreatedbyUserID { get; set; }
        [ValidateNever]
        public DateTime UpdatedOn { get; set; }
        public ApplicationUser? UpdatedbyUser { get; set; }
        public string? UpdatedbyUserID { get; set; }        
        public List<BillDocument>? BillDocuments { get; set; }
    }
}
