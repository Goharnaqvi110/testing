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
    public class CRItemDetail
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        public Int64 CRItemID { get; set; }
        public CRItem? CRItem { get; set; }
        public Int64 AreaItemId { get; set; }
        public PropertyAreaItem? AreaItem { get;set;}
        public bool Clean { get; set; } = false;
        public bool Undamaged { get; set; } = false;
        public bool Working { get; set; } = false;
        public bool True { get; set; } = false;
        [Column(TypeName ="nvarchar(500)")]
        public string? LandlordComments { get; set; }
        public bool TenantAgreed { get; set; } = false;
        [Column(TypeName="nvarchar(500)")]
        public string? TenantComments { get; set; }
        public DateTime? LastWorkedDate { get; set; }
        public DateTime? DeadlineDate { get; set; }
        public Int64? Reading { get; set; }
        public bool NormalField { get; set; } = true;
        public bool PhotoField { get; set; } = false;
        public bool YesNoField { get; set; } = false;
        public bool MeterReadingField { get; set; } = false;
        public bool LastWorkedOnField { get; set; } = false;
        public bool TobedoneByField { get; set; } = false;
        public bool DeadlineDateField { get; set; } = false;
        [Column(TypeName = "nvarchar(500)")]
        public string? LandlordPromise { get; set; }
        public bool AddComments { get; set; } = false;
        [Column(TypeName = "nvarchar(500)")]
        public string? AdditionalComments { get; set; }
        [NotMapped]
        public List<IFormFile>?PhotosbyTenant { get; set; }
    }
}
