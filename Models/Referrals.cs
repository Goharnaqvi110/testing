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
    public class Referral
    {
        [Key]
        public Int64 ID { get; set; }
        [MaxLength(36)]
        public string? UId { get; set; }
        public string? RecipientName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? referrallink { get; set; }
        public enum status
        {
            [Display(Name = "Sent")]
            sent = 1,
            [Display(Name = "Used")]
            used = 2
        }
        public DateTime DateCreated { get; set; }=DateTime.Now;
        [ValidateNever]
        public ApplicationUser? ReferredbyUser { get; set; }
        public string? ReferredbyUserID { get; set; }
        [ValidateNever]
        public DateTime? UpdatedOn { get; set; }
        [ValidateNever]
        public ApplicationUser UpdatedbyUser { get; set; }
        public string? UpdatedbyUserID { get; set; }         
    }
}
