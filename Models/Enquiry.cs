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
    public class Enquiry
    {
        [Key]
        public Int64 ID { get; set; }
        [MaxLength(36)]
        public string? UId { get; set; }
        public Int64? ParentEnquiryId { get; set; }
        public bool isReplied { get; set; } = false;
        public Int64? PropertyID { get; set; }
        [ValidateNever]
        public Property Property { get; set; }
        [Required]
        public EnquriyType? Enquirytype { get; set; }
        public string Message { get; set; }
        public string FromUserID { get; set; }
        public ApplicationUser FromUser { get; set; }
        public string ToUserID { get; set; }
        public ApplicationUser ToUser { get; set; }
        public DateTime DateReceived { get; set; } = DateTime.Now;
        public EnquiryStatus Enquirystatus { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [ValidateNever]
        public DateTime? UpdatedOn { get; set; }
        public ApplicationUser? UpdatedbyUser { get; set; }
        [NotMapped]
        public string sendto {get;set;}
        [NotMapped]
        public string landlordId { get; set; }
        [NotMapped]
        public string tenantId { get; set; }
        public enum EnquriyType
        {
            [Display(Name = "Inspection")]
            aboutinspection = 1,
            [Display(Name = "Rental application")]
            rentalapplication = 2,
            [Display(Name = "Availability")]
            availability = 3,
            [Display(Name = "Lease length")]
            leaselength = 4,
            aboutproperty=5,
        }
        public enum EnquiryStatus
        {
            [Display(Name ="Read")]
            read = 1,
            [Display(Name = "Unread")]
            unread = 2,
            [Display(Name = "Shortlist")]
            shortlist = 3,
            [Display(Name = "Not suitable")]
            notsuitable
        }
    }
}
