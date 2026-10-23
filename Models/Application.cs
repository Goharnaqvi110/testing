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
    public class Application
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        public Int64 ApplicantID { get; set; }
        public Applicant? Applicant { get; private set; }
        public Int64 PropertyID { get; set; }
        public Property? Property { get; private set; }
        [Required]
        public decimal? Rent { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Display(Name ="Lease")]
        public string? LeasePeriod { get; set; }
        [Display(Name = "Date Submitted")]
        public DateTime DateSubmitted { get; set; } = DateTime.Now;
        public int Status { get; set; } = 1; // 1-submitted,2-approved 3-rejected
        public string? UserID { get; set; }
        [ValidateNever]
        public ApplicationUser User { get; set; }
        [ValidateNever]
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedbyUserID { get; set; }
        public bool? isaddedbyLandlord { get; set; } = false;
        [ValidateNever]
        public ApplicationUser UpdatedbyUser { get; set; }

    }

}
