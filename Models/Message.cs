using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Gharshare.Models
{
    public class Message
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        public string FromUserID { get; set; }
        public ApplicationUser FromUser { get; set; }
        public string ToUserID { get; set; }
        public ApplicationUser ToUser { get; set; }
        [Required][Column(TypeName = "nvarchar(MAX)")]
        [Display(Name = "Message")]
        public string Text { get; set; }
        
        [Display(Name = "Date")]
        public DateTime SentOn { get; set; }=DateTime.Now;
        public bool Sent { get; set; }
        public bool Read { get; set; } 
        public enum MessageType
        {
            WithUser=1,
            WithAdmin=2
        }
        public MessageType? Type { get; set; }
    }
}
