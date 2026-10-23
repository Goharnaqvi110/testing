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
    public class CRItemImage
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        public Int64 CRItemID { get; set; }
        public CRItem? CRItem { get; set; }         
        public string ImagePath { get; set; }
        public bool AddedByLandlord { get; set; } 
        public bool AddedByTenant { get; set; }
    }
}
