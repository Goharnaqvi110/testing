using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Gharshare.Models
{
    public class Property
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        [Display(Name = "Property ID")]
        [Column(TypeName = "nvarchar(30)")]
        public string? PropertyCode { get; set; }
        public string OwnerId { get; set; }
        [ValidateNever]
        public ApplicationUser Owner { get; set; } //Owner: Owns or authorizes property
        public string? Address { get; set; }
        public Int64? StateID { get; set; }
        [ValidateNever]
        public State State { get; set; }
        //[RegularExpression(@"(/^[0-9]+$/)$", ErrorMessage = "City is required")]         
        public Int64? CityID { get; set; }

        [ValidateNever]
        public City City { get; set; }

        [ValidateNever]
        [Column(TypeName = "nvarchar(255)")]
        public string? Suburb { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        [ValidateNever]
        public string? Street { get; set; }
        [ValidateNever]
        [Display(Name = "Postal Code")]
        public string? PostalCode { get; set; }
        public Category CatogryID { get; set; }
        public string? TotalArea { get; set; }

        [RegularExpression(@"^(100|[1-9]?[0-9])$", ErrorMessage = "Only integer value between 1-100.")]
        public int? Bed { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [RegularExpression(@"^[0-9]+x[0-9]+$", ErrorMessage = "Enter size in lenght x width format e.g 10x10")]
        [Display(Name = "Bed Size")]
        public string? BedSize { get; set; }

        [RegularExpression(@"^(100|[1-9]?[0-9])$", ErrorMessage = "Only integer value between 1-100.")]
        public int? Bathroom { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [RegularExpression(@"^[0-9]+x[0-9]+$", ErrorMessage = "Enter size in lenght x width format e.g 10x10")]
        [Display(Name = "Bath Size")]
        public string? BathSize { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [RegularExpression(@"^[0-9]+x[0-9]+$", ErrorMessage = "Enter size in lenght x width format e.g 10x10")]
        [Display(Name = "Lounge")]
        public string? LoungeSize { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [RegularExpression(@"^[0-9]+x[0-9]+$", ErrorMessage = "Enter size in lenght x width format e.g 10x10")]
        [Display(Name = "Dining Area")]
        public string? DiningSize { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [RegularExpression(@"^[0-9]+x[0-9]+$", ErrorMessage = "Enter size in lenght x width format e.g 10x10")]
        [Display(Name = "Garden")]
        public string? GardenSize { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [RegularExpression(@"^[0-9]+x[0-9]+$", ErrorMessage = "Enter size in lenght x width format e.g 10x10")]
        [Display(Name = "Gym Area")]
        public string? Gym { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [RegularExpression(@"^[0-9]+x[0-9]+$", ErrorMessage = "Enter size in lenght x width format e.g 10x10")]
        [Display(Name = "Kitchen")]
        public string? KitchenSize { get; set; }
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Only integer values")]
        [Display(Name = "Year built")]
        public int? Yearbuilt { get; set; }
        public string? VideoURL { get; set; }
        [Display(Name = "Popular Tags")]
        public string? PopularTags { get; set; }

        [ValidateNever]
        [RegularExpression(@"^[1-9]+$", ErrorMessage = "Enter a valid number")]
        public Decimal? BondValue { get; set; }
        [Display(Name = "Rent")]         
        public Decimal? Rent { get; set; }
        
        [ValidateNever]
        public Int32? TotalParkings { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [RegularExpression(@"^[0-9]+x[0-9]+$", ErrorMessage = "Enter size in lenght x width format e.g 10x10")]
        public string? ParkingSize { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        [ValidateNever]
        public string? AdTitle { get; set; }
        public bool HidePrice { get; set; } = false;

        [Column(TypeName = "nvarchar(MAX)")]
        public string? Description { get; set; }
        public int? Totalflatmates { get; set; } // Once all rooms are rented

        [Column(TypeName = "nvarchar(MAX)")]
        public string? AboutFlatmates { get; set; }

        [ValidateNever]
        [Column(TypeName = "nvarchar(255)")]
        public string? CoverImage { get; set; }

        [ValidateNever]
        [Column(TypeName = "nvarchar(1000)")]
        public string? GoogleMapEmbedAPIURL { get; set; }
        public bool HideAddress { get; set; } = false;
        [Display(Name = "Owner Name")]
        public string? OwnerName { get; set; }
        [ValidateNever]
        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Owner Mobile")]
        public string? Ownermobile { get; set; }
        [ValidateNever]
        [Column(TypeName = "nvarchar(200)")]
        [Display(Name = "Owner email")]
        public string? Owneremail { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string? Propertyfor { get; set; } //Rent, Sale
        public bool NeedTenant { get; set; } = true;        
        public DateTime? AvailableFrom { get; set; }
        public bool IsRented { get; set; } = false;
        public bool IsRentedWhole { get; set; } = false;
        public bool RoomAvailable { get; set; } = true;
        public bool WomenOnlyProperty { get; set; } = false;
        public bool IsOnwnerOrAuthorized { get; set; } = false;
        public bool ShowPhoneNo { get; set; } = false;
        public bool IsActive { get; set; } = false;
        public bool IsAdlive { get; set; } = false;
        public bool blockedbyAdmin { get; set; } = false;
        public bool? IsAdcreated { get; set; } = false;
        [Display(Name = "Unit No")]
        [ValidateNever]         
        public Int32? UnitNo { get; set; }
        public bool? SharePhone { get; set; }
        [ValidateNever]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [ValidateNever]
        public ApplicationUser CreatedbyUser { get; set; }
        public string? CreatedbyUserId { get; set; }
        
        [ValidateNever]
        public DateTime? UpdatedOn { get; set; }
        [ValidateNever]
        public ApplicationUser UpdatedbyUser { get; set; }
        public string? UpdatedbyUserId { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? AdCreatedOn { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? ShortDescription { get; set; }
        public Int64? UserClicks { get; set; } = 0;
        public Decimal? Rating { get; set; } = 0;
        public PropertyType? Propertytype { get; set; }
        public Parking? Parkingtype { get; set; }
        public Preference? Flatmatepreference { get; set; }
        public MinimumStay? MinStay { get; set; }
        public MaximumStay? MaxStay { get; set; }
        public Internet? InternetStatus { get; set; } = Internet.Unknown;
        public Int64? PlanId { get; set; }
        public DateTime? PlanStart { get; set; }
        public DateTime? PlanEnd { get; set; }
        public bool PlanExpired { get; set; } = false;
        public bool showInspectionTime { get; set; } = false;
        [ValidateNever]
        public Plan? Plan { get; set; }
        public tenantstatus? TenantStatus { get; set; }
        public enum tenantstatus
        {
            [Display(Name = "I need tenant to find a tenant")]
            needtenant = 1,
            [Display(Name = "I already have a tenant")]
            havetenant = 2,
        }
            [ValidateNever]
        public IEnumerable<PropertyImage>? Images { get; set; }
        [ValidateNever]
        [JsonIgnore]
        public List<PropertyFeature> Features { get; set; }
        [ValidateNever]
        public List<UserBankAccount> UserBankAccounts { get; set; }
        [ValidateNever]
        public IEnumerable<TenantBill> TenantBills { get; set; }
        [ValidateNever]
        public IEnumerable<BillDocument> BillDocuments { get; set; }
        [ValidateNever]
        public IEnumerable<ConditionReport> ConditionReports { get; set; }
        [ValidateNever]
        public IEnumerable<Document> Documents { get; set; }
        [ValidateNever]
        public IEnumerable<Expense> Expenses { get; set; }
        [ValidateNever]
        public IEnumerable<ExpenseDocument> ExpenseDocuments { get; set; }
        [ValidateNever]
        [JsonIgnore]
        public IEnumerable<Maintenance> MaintenanceRecord { get; set; }
        [ValidateNever]
        [JsonIgnore]
        public IEnumerable<MaintenanceDocument> MaintenanceDocuments { get; set; }
        [ValidateNever]
        public List<PropertyEnquiry> Enquiries { get; set; }
        [ValidateNever]
        public IEnumerable<PropertyIncome> PropertyIncome { get; set; }
        [ValidateNever]
        public IEnumerable<PropertyInspection> PropertyInspections { get; set; }
        [ValidateNever]
        [JsonIgnore]
        public IEnumerable<Application>? Applications { get; set; }
        [ValidateNever]
        public LeaseAgreement? Lease { get; set; }

        public enum Preference
        {
            [Display(Name = "Men Only")]
            Menonly = 1,
            [Display(Name = "Women Only")]
            Womenonly = 2,
            [Display(Name = "No Couples")]
            Nocouples = 3,
            [Display(Name = "Anyone Inc. Couples")]
            AnyoneIncCouples = 4
        }

        public enum MinimumStay
        {
            [Display(Name = "One Month")]
            OneMonth = 1,
            [Display(Name = "Two Months")]
            TwoMonth = 2,
            [Display(Name = "Four Months")]
            FourMonth = 3,
            [Display(Name = "Six Month")]
            Sixmonth = 4,
            [Display(Name = "Twelve Month")]
            Twelvemonth = 5
        }

        public enum MaximumStay
        {
            [Display(Name = "One Months")]
            OneMonth = 1,
            [Display(Name = "Six Months")]
            SixMonths = 2,
            [Display(Name = "One Year")]
            OneYear = 3,
            [Display(Name = "Two Years")]
            TwoYears = 4,
            [Display(Name = "Three Years")]
            ThreeYears = 5,
            [Display(Name = "Five Years")]
            FiveYears = 6,
            [Display(Name = "No Limit")]
            FivePlus = 6
        }
        public enum Internet
        {
            [Display(Name = "No Internet")]
            Nointernet = 1,
            [Display(Name = "Available(not included in rent)")]
            AvailableNotincludedInRent = 2,
            [Display(Name = "Included in Rent")]
            IncludedInRent = 3,
            [Display(Name = "Unlimited(included in rent)")]
            UnlimitedIncludedInRent = 4,
            [Display(Name = "Unknown")]
            Unknown =5
        }
        public enum Parking
        {
            [Display(Name = "No Parking")]
            NoParking = 1,
            [Display(Name = "Off-stree")]
            Onstreet = 2,
            [Display(Name = "On-stree")]
            Offstree = 3
        }
        public enum Category
        {
            [Display(Name = "House")]
            House = 1,
            [Display(Name = "Room")]
            Room = 2,
            [Display(Name = "Apartment")]
            Apartment = 3,
            [Display(Name = "Hostel")]
            Hostel = 4,
            [Display(Name = "Hostel Room")]
            HostelRoom = 5,
            [Display(Name = "Shop")]
            Shop = 6,
            [Display(Name = "Office")]
            Office = 7,
            [Display(Name = "Luxury Villa")]
            LuxuryVilla = 8
        }
        public enum PropertyType
        {
            Residential = 1,
            Commercial = 2
        }
        public static string GetEnumDisplayName(Enum value)
        {
            return value
                .GetType()
                .GetMember(value.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()
                .Name;
        }

    }
}
