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
    public class PropertyType
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(70)")]         
        public string Name { get; set; }
        [ValidateNever]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [ValidateNever]
        public ApplicationUser? CreatedbyUser { get; set; }
        public string? CreatedbyUserID { get; set; }
        [ValidateNever]
        public DateTime? UpdatedOn { get; set; }
        [ValidateNever]
        public ApplicationUser UpdatedbyUser { get; set; }
        public string? UpdatedbyUserID { get; set; }

        public static explicit operator int(PropertyType v)
        {
            throw new NotImplementedException();
        }
    }
}
