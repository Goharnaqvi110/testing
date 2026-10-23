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
    public class Receipt
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        [ForeignKey("Property")]
        public Int64 PropertyID { get; set; }
        [NotMapped]
        public Property Property { get; set; }
        public Int64 Receiptnumber { get; set; }
        [ForeignKey("LeaseAgreement")]
        public Int64 LeaseAgreementID { get; set; }
        [NotMapped]
        public LeaseAgreement LeaseAgreement { get; set; }
        public ApplicationUser FromUser { get; set; }        
        public ApplicationUser ToUser { get; set; }
        
        [Column(TypeName = "nvarchar(500)")]
        public string Description { get; set; } // Rent,etc
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Decimal TotalPaidAmount { get; set; }
        [ValidateNever]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public ApplicationUser CreatedbyUser { get; set; }
        [ValidateNever]
        public DateTime UpdatedOn { get; set; }
        public ApplicationUser UpdatedbyUser { get; set; }

    }
}
