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
    public class ApplicantVehicle
    {
        [Required]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        public Int64 ApplicantID { get; set; }
        public Applicant? Applicant { get; private set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Type { get; set; } //Car,Truck,Carvan,Motorbike,Boat,Other
        [Column(TypeName = "nvarchar(70)")]
        public string Registration { get; set; } 
        
        [Column(TypeName = "nvarchar(150)")]
        public string Make { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string Model { get; set; }
        public bool IsPrimaryVehicle { get; set; }
        public bool NeedParking { get; set; }
        [ValidateNever]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public ApplicationUser? CreatedbyUser { get; set; }
        public string? CreatedbyUserId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedbyUserId { get; set; }
        public ApplicationUser? UpdatedbyUser { get; set; }

    }

}
