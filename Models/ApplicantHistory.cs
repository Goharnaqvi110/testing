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
    public class ApplicantHistory //Rental History
    {
        [Required]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        public Int64 ApplicantID { get; set; }
        public Applicant? Applicant { get; private set; }

        [Column(TypeName = "nvarchar(300)")]
        public string? Address { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string? UnitNo { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string? StreetNo { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string StreetName { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Suburb { get; set; }         
        public int PostCode { get; set; }
        //public string State { get; set; }
        //public string Country { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string LandlordType { get; set; } //Real estate agent, Directly through a landlord
                                                 //I own this home,Living with family/friends
        public string Email { get; set; }         
        [Column(TypeName = "nvarchar(50)")]
        [ValidateNever]
        public string? Phone { get; set; }
        public DateTime? DateStartedLiving { get; set; } //Additional Information
        public DateTime? DateEndedLiving { get; set; }  

        [Column(TypeName = "nvarchar(500)")]
        public string? AdditionalInformation { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string? Reasonforleaving { get; set; }
        [ValidateNever]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public ApplicationUser? CreatedbyUser { get; set; }
        public string? CreatedbyUserId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedbyUserId { get; set; }
        public ApplicationUser? UpdatedbyUser { get; set; }
    }
}
