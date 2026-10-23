using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class Applicant
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        [ValidateNever]
        public string? UserID { get; set; }
        [ValidateNever]
        public ApplicationUser? User { get; set; }
        [Column(TypeName = "nvarchar(10)")] //Mr,Mrs,Ms,Miss,Dr,Other        
        public string? Title { get; set; }
        [Column(TypeName = "nvarchar(10)")] //Male,Female,Unspecified
        public string? Gender { get; set; }

        [Display(Name = "Date of birth")]
        public DateTime? DOB { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [Column(TypeName = "nvarchar(70)")]
        public string? Email { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? Mobile { get; set; }
        public bool IsSmoker { get; set; } = false;
        public bool OwnPets { get; set; } = false;
        public bool NeedParking { get; set; } = false;

        [Column(TypeName = "nvarchar(50)")]
        public string? LandlordType { get; set; } //Real estate agent, Directly through a landlord
                                                  //I own this home,Living with family/friends
        [Column(TypeName = "nvarchar(300)")]
        public string? CurrentAddress { get; set; }
        public DateTime? DateStartedLiving { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string? JobStatus { get; set; } //Employed,Self-employed,Student,Retired,Unemployed

        [Column(TypeName = "nvarchar(500)")]
        public string? AdditionalInformation { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string? Reasonforleaving { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [ValidateNever]
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedbyUserID { get; set; }
        public bool isTenant { get; set; } = false;
        public bool? isaddedbyLandlord { get; set; } = false;
        public string? PostCode { get; set; }
        [ValidateNever]
        public Application? Application { get; set; }
        public ApplicationUser? UpdatedbyUser { get; set; }
        [ValidateNever]
        public List<ApplicantAddIncome>? AdditionalIncome { get; set; }
        public List<ApplicantDependent>? Dependents { get; set; }
        public List<ApplicantDocument>? Documents { get; set; }
        public List<ApplicantEmployer>? Employers { get; set; }
        public List<ApplicantHistory>? History { get; set; }
        public List<ApplicantPet>? Pets { get; set; }
        public List<ApplicantReference>? References { get; set; }
        public List<ApplicantVehicle>? Vehicles { get; set; }

    }

}
