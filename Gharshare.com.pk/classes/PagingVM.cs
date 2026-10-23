using Gharshare.Models;
using Gharshare.CommonHelper;
namespace smartpropertymanager.pk.classes
{
    public class PagingVM
    {
        public List<Document> Documents { get; set; }
        public Pager Pager { get; set; }
    }
}
