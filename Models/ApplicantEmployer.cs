using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gharshare.Models
{
    public class ApplicantEmployer
    {
        [Required]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        public Int64 ApplicantID { get; set; }
        public Applicant? Applicant { get; private set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Occupation { get; set; }
        [Column(TypeName = "nvarchar(70)")]
        public string EmployerName { get; set; }
        [Column(TypeName = "nvarchar(70)")]
        [ValidateNever]
        public string? Website { get; set; }

        [Column(TypeName = "nvarchar(50)")]  
        public string ContactName { get; set; }
         
        [Column(TypeName = "nvarchar(50)")]
        [ValidateNever]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Mobile { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [ValidateNever]
        public string? Phone { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string? Address { get; set; }
        public DateTime? StartDate { get; set; }         
        [ValidateNever]
        public DateTime? EndDate { get; set; }         
        [ValidateNever]
        public Decimal? AnnualIncome { get; set; }
        [Column(TypeName = "nvarchar(100)")] //Casual,Part-Time,Full-Time,Contract
        public string JobType { get; set; } 

        [Column(TypeName = "nvarchar(500)")]
        public string? AdditionalInformation { get; set; }
        public bool IsCurrentEmployer { get; set; } = false;
        [ValidateNever]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public ApplicationUser? CreatedbyUser { get; set; }
        public string? CreatedbyUserId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedbyUserId { get; set; }
        public ApplicationUser? UpdatedbyUser { get; set; }
    }

}
