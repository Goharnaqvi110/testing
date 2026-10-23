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
    public class Expense
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
        public Int64? LeaseAgreementID { get; set; }
        public LeaseAgreement? LeaseAgreement { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(200)")]         
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string? Description { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public decimal? AmountOwedbytenant { get; set; }        
        [Required]
        [Display(Name = "Expense Date")]
        public DateTime ExpenseDate { get; set; }
        [Display(Name = "Includes GST")]
        public bool GSTIncluded { get; set; } = false;
        public bool AlreadyPaid { get; set; } = false;
        public bool? PayViaUs { get; set; } = true;
        public ApplicationUser? PaidByUser { get; set; }
        public string? PaidByUserId { get; set; }
        [ValidateNever]
        public DateTime? CreatedOn { get; set; } = DateTime.Now;
        public ApplicationUser? CreatedbyUser { get; set; }
        public string? CreatedbyUserId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public ApplicationUser? UpdatedbyUser { get; set; }
        public string? UpdatedbyUserId { get; set; }
        public List<ExpenseDocument>? ExpenseDocuments { get; set; }

    }
}
