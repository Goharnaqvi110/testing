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
    public class PropertyIncome
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        public Int64 PropertyID { get; set; }
        public Property? Property { get; set; }
        public Int64 LeaseAgreementID { get; set; }
        public LeaseAgreement? LeaseAgreement { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string Category { get; set; } //BondPayment,RentalIncome, Other
                                             
        [Column(TypeName = "nvarchar(500)")]
        public string? Description { get; set; }
        [Required]
        public decimal Amount { get; set; } = 0;
        [Required]
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public bool IsGSTIncluded { get; set; } = false;
        public string? PaidById { get; set; }
        public ApplicationUser? PaidBy { get; set; }
        [ValidateNever]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
         
        [ValidateNever]
        public DateTime? UpdatedOn { get; set; }
        [NotMapped]
        public ApplicationUser? UpdatedbyUser { get; set; }
        public string? UpdatedbyUserId { get; set; }
        public bool UserAgreetoPay { get; set; } = false;
        public IEnumerable<PropertyIncomeReceipt>? IncomeReceipts { get; set; }
    }
}
