using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gharshare.Models
{
    public class Room
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }         
        public Int64 PropertyID { get; set; }
        [NotMapped]
        public Property? Property { get; set; }
        public string? RoomName { get; set; }
        public string? RoomType { get; set; } //Private,Shared
        public string? RoomFurnishings { get; set; }//Flexible,Furnished,Unfurnished
        public string? BathroomType { get; set; } //Shared,Own,Ensuite
        public string? BedSize { get; set; } //Single,Double,Queen,King,None
        public string? RoomFeatures { get; set; } //Bed side table,Wardrobe,Drawers, Air conditioner,
                                                  //Heater, Desk,Lamp,Chair,Couch,TV,Balcony, Door lock, Kitchenette
        public bool IsActive { get; set; }=true;

        [ValidateNever]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public ApplicationUser CreatedbyUser { get; set; }
        [ValidateNever]
        public DateTime UpdatedOn { get; set; }
        public ApplicationUser UpdatedbyUser { get; set; }
    }
}
