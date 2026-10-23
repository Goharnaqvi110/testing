using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gharshare.Models
{
    public class RentalPayment
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        public Int64 PropertyID { get; set; }
        public Property? Property{get; set;}
        public Int64 LeaseAgreementID { get; set; }
        public LeaseAgreement? LeaseAgreement { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? PaymentDate { get; set; }        
        [Required]
        public decimal AmountDue { get; set; }         
        public decimal? AmountPaid { get; set; }
        public decimal? Outstanding { get; set; } = 0;
        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public type paymentType { get; set; }
        public enum type
        {
            [Display(Name = "Rental Income")]
            rentalIncome = 1,
            [Display(Name = "Bond Payment")]
            bondPayment = 2,
            [Display(Name = "Other")]
            Other = 3
        }
        [Column(TypeName = "nvarchar(500)")]
        public string? Description { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public status? PaymentStaus { get; set; } 
        public enum status
        {
            [Display(Name ="Due")]
            due = 1,
            [Display(Name = "Paid")]
            paid = 2,
            [Display(Name = "Partially Paid")]
            partiallypaid =3
        }
        [ValidateNever]
        public bool IsGSTIncluded { get; set; } = false;
        public bool UserAgreetoPay { get; set; } = false;
        public string? PaidById { get; set; }
        public ApplicationUser? PaidBy { get; set; }
        [ValidateNever]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [ValidateNever]
        public DateTime? UpdatedOn { get; set; }
        [NotMapped]
        public ApplicationUser? UpdatedbyUser { get; set; }
        public string? UpdatedbyUserId { get; set; }        
        public PropertyIncomeReceipt Receipt { get; set; }
    }
}
