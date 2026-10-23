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
    public class UserBankAccount
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        [ValidateNever]
        public string? UserId { get; set; }
        public Int64 PropertyId { get; set; }
        public Property Property { get; set; }
        [ValidateNever]
        public ApplicationUser User { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [ValidateNever]
        public acctype AccountType { get; set; }
        public enum acctype
        {
            [Display(Name = "Bank Account")]
            bankaccount = 1,
            [Display(Name = "Credit Card")]
            creditcard = 2,
        }
        [Column(TypeName = "nvarchar(100)")]
        public string? BankName { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string? AccountTitle { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? AccountNo { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? BranchCode { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? CardHolderName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? CardNo { get; set; }
        public Int32 Year { get; set; }
        public Int32 Month { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string? CVV { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public cardtype CardType { get; set; }
        public enum cardtype
        {
            [Display(Name = "Visa")]
            visa = 1,
            [Display(Name = "Express")]
            express = 2,
        }
        public bool IsSelectedForPayment { get; set; } = false;
        [ValidateNever]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [ValidateNever]
        public string? CreatedbyUserId { get; set; }
        [ValidateNever]
        public ApplicationUser? CreatedbyUser { get; set; }
        [ValidateNever]
        public DateTime? UpdatedOn { get; set; }
        [ValidateNever]
        public string? UpdatedbyUserId { get; set; }
        [ValidateNever]
        public ApplicationUser? UpdatedbyUser { get; set; }
    }
}
