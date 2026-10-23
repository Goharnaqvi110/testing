using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Gharshare.Models
{
    public class BillDocument
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        public Int64 TenantBillID { get; set; }
        [JsonIgnore]
        public TenantBill? TenantBill { get; set; }
        public Int64 PropertyID { get; set; }
        [JsonIgnore]
        public Property? Property { get; set; }
        public Int64 LeaseAgreementID { get; set; }
        [JsonIgnore]
        public LeaseAgreement? LeaseAgreement { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(500)")]
        public string? FilePath { get; set; }
        [ValidateNever]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public ApplicationUser? CreatedbyUser { get; set; }
        public string? CreatedbyUserId { get; set; }        
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedbyUserId { get; set; }
        public ApplicationUser? UpdatedbyUser { get; set; }

    }
}
