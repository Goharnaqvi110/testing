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
    public class ApplicationUser:IdentityUser
    {
        [Required]
        [ValidateNever]
        public string Name { get; set; }
        public string? SurName { get; set; }
        public bool FreetoMessage { get; set; } = true;
        public Int64? StateID { get; set; }
        [ValidateNever]
        public State State { get; set; }
        public Int64? CityID { get; set; }
        [ValidateNever]
        public City City { get; set; }
        public string? Address { get; set; }
        public string? PostalCode { get; set; }
        public usertype UserType { get; set; }
        public enum usertype
        {   
            [Display(Name = "Landlord")]
            landlord = 1,
            [Display(Name = "Tenant")]
            tenant = 2,
            [Display(Name = "Admin")]
            admin = 3,
            [Display(Name = "Super admin")]
            superadmin = 4,
            [Display(Name = "Free User")]
            freeuser = 5,
        }
        [ValidateNever]
        public string? ProfilePicture { get; set; }
        [ValidateNever]
        public string? BankName { get; set; }
        [ValidateNever]
        public string? AccountTitle { get; set; }
        [ValidateNever]
        public string? Branch { get; set; }
        [ValidateNever]
        public string? AccountNo { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        [Display(Name = "Active")]
        public bool IsActive { get; set; } = true;
        [ValidateNever]
        public string? Mobile { get; set; }
        public bool Mobileverified { get; set; } = false;
        public string? CNIC { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool AgreedtoTerms { get; set; } = false;
        public Int32? Age { get; set; }
        public gender? Gender { get; set; }
        public enum gender
        {
            [Display(Name = "Male")]
            male = 1,
            [Display(Name = "Female")]
            female = 2,
            [Display(Name = "Transgender")]
            transgender = 3            
        }
        public bool DefaultAdmin { get; set; } = false;
        public bool ShowNumber { get; set; } = false;        
        public decimal Responserate { get; set; }
        public DateTime Lastloggedin { get; set; }
        [ValidateNever]
        [NotMapped]
        public IEnumerable<Property>? Properties { get; set; }
        [ValidateNever]
        [NotMapped]
        public IEnumerable<LeaseAgreement>? LeaseAgreements { get; set; }
        [ValidateNever]
        [NotMapped]
        public IEnumerable<Message>? Messages { get; set; }
        [ValidateNever]
        [NotMapped]
        public IEnumerable<Testimonial>? Testimonials { get; set; }
        [ValidateNever]
        [NotMapped]
        public IEnumerable<UserBankAccount>? UserAccounts { get; set; }
        //public Applicant? Applicant { get; set; }
    }

}
