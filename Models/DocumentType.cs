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
    public class DocumentType
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(200)")]         
        public string Title { get; set; } //Application,Lease Agreement,condition report, maintenance receipts,
                                          //Expense,Bond lodgement receipt,building report,photo, other        
        public IEnumerable<Document>? Documents { get; set; }


    }
}
