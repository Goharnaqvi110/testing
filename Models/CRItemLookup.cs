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
    public class CRItemLookup
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(70)")]
        public string Type { get; set; } //Item,general,safety,Health,Communication,Water
        [Required]
        [Column(TypeName = "nvarchar(70)")]         
        public string Title { get; set; }
        
        [Column(TypeName ="nvarchar(500)")]
        public string? LandlordComments { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string? TenantComments { get; set; }
        [ValidateNever]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public ApplicationUser CreatedbyUser { get; set; }
        [ValidateNever]
        public DateTime UpdatedOn { get; set; }
        public ApplicationUser UpdatedbyUser { get; set; }
        public IEnumerable<CRItemDetail>? CRItemDetail { get; set; }

    }
}
