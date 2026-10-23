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
    public class ApplicantDependent
    {
        [Required]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        public Int64 ApplicantID { get; set; }
        public Applicant? Applicant { get; private set; }

        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? LastName { get; set; }
        public int? Age { get; set; }
        [Column(TypeName = "nvarchar(10)")] //Male,Female,Unspecified
        public string Gender { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Relationship { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string IsLivingWithYou { get; set; } //Yes, No
        [Column(TypeName = "nvarchar(10)")]
        public string IsReceivingChildSupport { get; set; }//Yes, No
        [Column(TypeName = "nvarchar(500)")]
        public string? AdditionalInformation { get; set; }
        [ValidateNever]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public ApplicationUser? CreatedbyUser { get; set; }
        public string? CreatedbyUserId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedbyUserId { get; set; }
        public ApplicationUser? UpdatedbyUser { get; set; }



    }

}
