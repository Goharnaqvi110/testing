using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Gharshare.Models
{
    public class ApplicantAddIncome
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        public Int64 ApplicantID { get; set; }
        public Applicant? Applicant { get; private set; }
        [Required]
        [Column(TypeName = "nvarchar(70)")]
        [ValidateNever]
        public string Title { get; set; }         
        [ValidateNever]
        public decimal? Amount { get; set; }
        [ValidateNever]
        public decimal? AnnualTotal { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(70)")]
        [ValidateNever]
        public string PaymentTerm { get; set; } //W-Weekly,F-Fortnightly,M-Monthly,A-Annulay
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public ApplicationUser? CreatedbyUser { get; set; }
        public string? CreatedbyUserId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedbyUserId { get; set; }
        public ApplicationUser? UpdatedbyUser { get; set; }


    }
}
