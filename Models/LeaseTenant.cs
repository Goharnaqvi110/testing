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
    public class LeaseTenant
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        public Int64 LeaseID { get; set; }
        public LeaseAgreement? Lease { get; set; }
        public Int64? TenantID { get; set; }
        public Applicant? Tenant { get; set; }        
        public string? UserId { get; set; }
        [ValidateNever]
        public ApplicationUser? User { get; set; }
        public bool? isPrimaryTenant { get; set; } = false;
        public DateTime? CreatedOn { get; set; } = DateTime.Now;
        [ValidateNever]
        public string? CreatedbyUserId { get; set; }
        [ValidateNever]
        public ApplicationUser? CreatedbyUser { get; set; }
        [ValidateNever]
        public DateTime UpdatedOn { get; set; }
        [ValidateNever]
        public string? UpdatedbyUserId { get; set; }
        [ValidateNever]
        public ApplicationUser? UpdatedbyUser { get; set; }

    }
}
