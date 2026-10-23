using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gharshare.Models
{
    public class ApplicantPet
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        public Int64 ApplicantID { get; set; }
        public Applicant? Applicant { get; private set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "*")]
        public string? Name { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Type { get; set; } //Other,Bird,Cat, Dog
        [Column(TypeName = "nvarchar(70)")]
        public string? Breed { get; set; }
        public int? age { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string? Size { get; set; } //S-Small,M-Medium,L-Large

        [Column(TypeName = "nvarchar(200)")]
        public string? PicturePath { get; set; }
        
        [Column(TypeName = "nvarchar(500)")]
        public string? AdditionalInformation { get; set; }
        [ValidateNever]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public ApplicationUser? CreatedbyUser { get; set; }
        public string? CreatedbyUserId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedbyUserId { get; set; }
        public ApplicationUser? UpdatedbyUser { get; set; }
        [NotMapped]
        [ValidateNever]
        public IFormFile? Petpic { get; set; }

    }

}
