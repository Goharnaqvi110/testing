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
    public class PropertyArea
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(70)")]         
        public string Name { get; set; }
        public bool isSelected { get; set; }
        public Int32 TotalNo { get; set; } = 0;
        [NotMapped]
        public List<IFormFile>? Photos { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        [Display(Name = "Additional Comments")]
        public string?  Comments { get; set; }
        public bool DefaultSelection { get; set; } = false;
        public List<PropertyAreaItem>? PropertyAreaItems { get; set; }
}
}
