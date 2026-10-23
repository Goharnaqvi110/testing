using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gharshare.Models
{
    public class Suburb
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }
        [ForeignKey("City")]
        public int CityID { get; set; }
        [NotMapped]
        public City City { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;       
        
        //public IEnumerable<Property>? Properties { get; set; }
    }
}
