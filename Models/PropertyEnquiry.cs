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
    public class PropertyEnquiry
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        public Int64 PropertyID { get; set; }
        [ValidateNever]
        public Property Property { get; set; }
        [Required]
        public Enquriy? About { get; set; }
        public enum Enquriy 
        {
            [Display(Name = "Inspection")]
            Inspection = 1,
            [Display(Name = "Rental application")]
            Rentalapplication = 2,
            [Display(Name = "Available date")]
            AvailableDate = 3,
            [Display(Name = "Lease length")]
            LengthofLease = 4
        }
        public enum Type
        {
            TextMessage=1,
            Audio=2
        }            
        public Type EnquiryType { get; set; } 
        [Required]
        [Column(TypeName = "nvarchar(300)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(70)")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string Mobile { get; set; }
        [Column(TypeName ="nvarchar(500)")]
        public string Message { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string? AudioMessageFilePath { get; set; }
        public DateTime DateReceived { get; set; } = DateTime.Now;
        public enum EnquiryStatus 
        { 
            read=1,
            unread=2,
            shortlist=3,
            notsuitable
        }
        public EnquiryStatus Status { get; set; }  
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [ValidateNever]
        public DateTime? UpdatedOn { get; set; }
        public ApplicationUser? UpdatedbyUser { get; set; }
        public string? CreatedbyUserID { get; set; }
        public ApplicationUser? CreatedbyUser { get; set; }
    }
}
