using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gharshare.Models
{
    public class MaintenanceDocument
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        public Int64 MaintenanceID { get; set; }
        public Maintenance? Maintenance { get; set; }        
        public Int64 PropertyID { get; set; }
        public Property? Property { get; set; }
        public Int64? LeaseAgreementID { get; set; }
        public LeaseAgreement? LeaseAgreement { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(500)")]
        public string? FilePath { get; set; }
        public bool IsPhoto { get; set; } = true; //false=receipt, true=photo
        [ValidateNever]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string? CreatedbyUserID { get; set; }
        public ApplicationUser? CreatedbyUser { get; set; }
        [ValidateNever]
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedbyUserID { get; set; }
        public ApplicationUser? UpdatedbyUser { get; set; }
    }
}
