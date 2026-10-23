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
    public class ExpenseDocument
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        public Int64 ExpenseID { get; set; }        
        public Expense Expense { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(500)")]
        public string FilePath { get; set; }
        [ValidateNever]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public ApplicationUser? CreatedbyUser { get; set; }
        public string? CreatedbyUserId { get; set; }
        [ValidateNever]
        public DateTime? UpdatedOn { get; set; }
        public ApplicationUser? UpdatedbyUser { get; set; }
        public string? UpdatedbyUserId { get; set; }
    }
}
