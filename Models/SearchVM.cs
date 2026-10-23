namespace Gharshare.Models
{
    public class SearchVM
    {
        public List<City>? Cities { get; set; }
        public List<Property>? Properties { get; set; }
        public List<Feature>? Features { get; set; }
        public string? Searchphrase {get;set;}
    }
}
