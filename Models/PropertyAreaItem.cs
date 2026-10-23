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
    public class PropertyAreaItem
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        public Int64 PropertyAreaID { get; set; }
        public PropertyArea? PropertyArea { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [NotMapped]
        public string? AreaName { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string Name { get; set; }
        public bool Clean { get; set; } = false;
        public bool Undamaged { get; set; } = false;
        public bool Working { get; set; } = false;
        [Column(TypeName ="nvarchar(500)")]
        public string? LandlordComments { get; set; }
        public bool TenantAgreed { get; set; } = false;
        [Column(TypeName="nvarchar(500)")]
        public string? TenantComments { get; set; }        
        public DateTime? CreatedOn { get; set; }
        public ApplicationUser? CreatedbyUser { get; set; }
        public string? CreatedbyUserId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public ApplicationUser? UpdatedbyUser { get; set; }
        public string? UpdatedbyUserId { get; set; }
        [NotMapped]
        public List<IFormFile>?Photos { get; set; }
        [NotMapped]
        public List<IFormFile>? LandlordPhotos { get; set; }
        public bool PhotoField { get; set; } = false;
        [Column(TypeName = "nvarchar(500)")]
        public string? AdditionalComments { get; set; }
        public bool AddComments { get; set; } = false;
        public bool isTrue { get; set; } = true;
        public Int64? Reading { get; set; }
        [ValidateNever]
        public DateTime? LastWorkedDate { get; set; }
        public DateTime? DeadlineDate { get; set; }
        public bool YesNoField { get; set; } = false;
        public bool MeterReadingField { get; set; } = false;
        public bool TobedoneByField { get; set; } = false;
        public bool LastWorkedOnField { get; set; } = false;
        public bool NormalField { get; set; } = true;
        public bool DeadlineDateField { get; set; } = false;
        [NotMapped]
        public string? LandlordPromise { get; set; }
    }
}
