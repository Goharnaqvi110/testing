using Gharshare.Models;
using Gharshare.CommonHelper;
namespace smartpropertymanager.pk.classes
{
    public class SearchbyAddressVM
    {
        public List<Property> Properties { get; set; }
        public Pager Pager { get; set; }
    }
}
