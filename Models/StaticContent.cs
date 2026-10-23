using Gharshare.Models;
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
    public class StaticContent
    {
        [Required]
        public Int64 Id { get; set; }
        [MaxLength(36)]
        public string? UId { get; set; }
        [Required]
        public Int64 ContentTypeID { get; set; }
        [ValidateNever]
        public ContentType ContentType { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(300)")]
        public string? Heading { get; set; }
        [Required(ErrorMessage = "*required")]
        public string? Topsection { get; set; }
        public string? Imagepath { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? LowersectionHeading { get; set; }
        public string? LowerSection { get; set; }         

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Created on")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [ValidateNever]
        [Display(Name = "Created by")]
        public ApplicationUser CreatedbyUser { get; set; }
        public string? CreatedbyUserId { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Updated on")]
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        [ValidateNever]
        public ApplicationUser UpdatedbyUser { get; set; }
        public string? UpdatedbyUserId { get; set; }
        public status Status { get; set; } = status.draft;
        public bool isFeatured { get; set; }= false;
        //public enum Type
        //{
        //    [Display(Name = "Advertise a Property")]
        //    advertise = 1,
        //    [Display(Name = "Property Market")]
        //    propertymarket = 2,
        //    [Display(Name = "Tax Tips")]
        //    taxtips = 3,
        //    [Display(Name = "Real Estate Updates")]
        //    realestateupdates = 4,
        //    [Display(Name = "Property Investing")]
        //    propertyinvesting = 5,
        //    [Display(Name = "SPM Updates")]
        //    SPMUpdates = 6,
        //    [Display(Name = "Property Management")]
        //    propertymanagement = 7,
        //    [Display(Name = "Property Maintenance")]
        //    propertymaintenance = 8,
        //    [Display(Name = "Tenants")]
        //    tenants = 9,
        //    [Display(Name = "Customer Stories")]
        //    customerstories = 10,
        //}
        public enum status
        {
            [Display(Name = "Active")]
            active = 1,
            [Display(Name = "Draft")]
            draft = 2,
            [Display(Name = "Canceled")]
            Canceled = 3
        }
    }
}
