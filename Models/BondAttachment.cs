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
    public class BondAttachment
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        public Int64 LeaseID { get; set; }
        public LeaseAgreement? Lease { get; set; }
        public documenttype type { get; set; }
        public enum documenttype
        {
            [Display(Name ="Landlord attachment")]
            landlordattachment = 1,
            [Display(Name = "Tenant attachment")]
            tenantattachment = 2,
            [Display(Name = "Landlord file")]
            landlordfile=3,
            [Display(Name = "Tenant file")]
            tenantfile =4
        }
        public string? FilePath { get; set; }
        public string? UploadedByUserId { get; set; }
        [ValidateNever]
        public ApplicationUser? UploadedByUser { get; set; }
        public DateTime? CreatedOn { get; set; } = DateTime.Now;

        [ValidateNever]
        public DateTime? UpdatedOn { get; set; }
        [ValidateNever]
        public string? UpdatedbyUserId { get; set; }
        [ValidateNever]
        public ApplicationUser? UpdatedbyUser { get; set; }

    }
}
