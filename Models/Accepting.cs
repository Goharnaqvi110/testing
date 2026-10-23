using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace Gharshare.Models
{
    public class Accepting
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        [Required]
        [ValidateNever]
        [Column(TypeName= "nvarchar(200)")]
        public string Title { get; set; }
        public bool isSelected { get; set; }
        public bool IsActive { get; set; }=true;
        [ValidateNever]
        public DateTime CreatedOn { get; set; } = DateTime.Now;         
    }
}
