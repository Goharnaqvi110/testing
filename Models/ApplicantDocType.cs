using Microsoft.AspNetCore.Http;
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
    public class ApplicantDocType
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        [ValidateNever]
        public int type { get; set; } = 1; //1-Primary, 2-Secondary, 3-Income Proof 4-Application
        [Required]
        [Column(TypeName = "nvarchar(70)")]
        [ValidateNever]
        public string Name { get; set; }
        public int? Points { get; set; }
        public bool isSelected { get; set; } = false;
        [ValidateNever]
        public string? DocumentPath { get; set; }
        [NotMapped]
        public IFormFile? Document { get; set; }

        [ValidateNever]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public ApplicationUser? CreatedbyUser { get; set; }
        [ValidateNever]
        public DateTime? UpdatedOn { get; set; }
        public ApplicationUser? UpdatedbyUser { get; set; }


    }
}
