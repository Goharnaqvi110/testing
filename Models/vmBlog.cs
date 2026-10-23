using Gharshare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gharshare.Models
{
    public class vmBlog
    {
        public List<StaticContent> Articles { get; set; }
        public StaticContent FeaturedArticle {get;set;} 
    }
}
