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
    public class PropertyIncomeReceipt
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }         
        public Int64 RentalPaymentID { get; set; }
        [NotMapped]
        public RentalPayment RentalPayment { get; set; }         
        [Required]         
        public string? FilePath { get; set; }
        [ValidateNever]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string? CreatedbyUserId { get; set; }
        public ApplicationUser CreatedbyUser { get; set; }
        [ValidateNever]
        public DateTime UpdatedOn { get; set; }
        public string? UpdatedbyUserId { get; set; }
        public ApplicationUser UpdatedbyUser { get; set; }
    }
}
