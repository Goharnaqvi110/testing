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
    public class Document
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        public Int64 DocumentTypeID { get; set; }
        public DocumentType? DocumentType { get; set; }
        public Int64 PropertyID { get; set; }
        public Property? Property { get; set; }
        public Int64 LeaseAgreementID { get; set; }
        public LeaseAgreement? LeaseAgreement { get; set; }
        public Int64? ApplicationID { get; set; }
        public Application? Application { get; set; }
        public Int64? MaintenanceID { get; set; }
        public Maintenance? Maintenance { get; set; }
        public Int64? ExpenseID { get; set; }
        public Expense? Expense { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(100)")]
        public string Name { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; } //1-PDF , 2-Word

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
