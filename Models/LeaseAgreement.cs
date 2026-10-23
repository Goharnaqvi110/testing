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
    public class LeaseAgreement
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        [ValidateNever]
        public Int64? PrimaryTenantID { get; set; }
        [ValidateNever]
        public Applicant PrimaryTenant { get; set; }
        public Int64 PropertyID { get; set; }
        //[ValidateNever]
        public Property? Property { get; set; }
        public DateTime From { get; set; } 
        public DateTime? To { get; set; }
        public DateTime AgreementDate { get; set; } = DateTime.Now;        
        [ValidateNever]
        public decimal? WeeklyRent { get; set; }
        [Required]
        [ValidateNever]
        public decimal? MonthlyRent { get; set; } // (weeklyRent/7)*365/12
        [Required]
        [ValidateNever]
        public bool IsPeriodicAgreement { get; set; } = false;
        public Agreement AgreementType { get; set; }
        public enum Agreement { Fixed=1,Periodic=2}        
        [Display(Name = "Periodic Rent")]
        [ValidateNever]
        public decimal? PeriodicRent { get; set; } // Of weekly or fortnight
        [Required]
        [Display(Name = "Bond Amount")]
        public decimal BondAmount { get; set; }
        public bool IsBondPaid { get; set; } = false;
        public bool IsBondPaidOutside { get; set; } = false;
        [Required]
        [Display(Name = "Bond payment date")]
        //[DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BondPaymentDate { get; set; }
        [Required]
        public Frequency PaymentFrequency { get; set; } = Frequency.Monthly;
        public enum Frequency { Monthly=1,Fortnightly=2,Weekly=3 }
        [Required]
        [Display(Name = "Rent Payment Date")]
        public DateTime RentPaymentDate { get; set; }
        [Display(Name = "First rent payment due date")]
        public DateTime FirstRentPaymentDueDate { get; set; }
        [Display(Name = "Periodic agreement start date")]
        public DateTime? PeriodicAgreementStartDate { get; set; } // Periodic agreement starts
        [Display(Name = "Is payment made outside")]                                                          // as soon fixed terms expires
        public bool IsPaymentMadeOutside { get; set; } = false; // outside refers to outside
        [Display(Name = "Number of outside payments made")]                                                          // of Gharhsare.com.pk
        public int? OutsidePaymentNo { get; set; } // no of months payment received outside.
        [Display(Name = "Need early first payment")]
        public bool NeedEarlyFirstPayment { get; set; } = false;
        [Display(Name = "Early first payment due date")]
        public DateTime? EarlyFirstPaymentDueDate { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Emergency contact name")]
        public string? EmergencyContactName { get; set; } // For repair
        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Emergency phone no")]
        public string? EmergencyPhoneNo { get; set; }
        [Column(TypeName = "nvarchar(70)")]
        [Display(Name = "Emergency email")]
        public string? EmergencyEmail { get; set; }
        [Display(Name = "Pay bond via Gharshare")]
        public bool PaybondviaGharshare { get; set; } = true;
        [Display(Name = "Direct debit")]
        public bool Directdebit { get; set; } = true;        
        [Display(Name = "Bank deposit")] 
        public bool Bankdeposit { get; set; } = false;
        public bool Cash { get; set; } = false;
        [Display(Name = "Cheque or Moneyorder")]
        public bool ChequeorMoneyorder { get; set; } = false;
        public bool IsLandlordAgreedtoServeENotices { get; set; } = true;
        [Column(TypeName = "nvarchar(70)")]
        [Display(Name = "Landlord email for e-notices")]
        public string? LandlordEmailForENotices { get; set; }
        public bool IsRenterAgreedtoGetENotices { get; set; } = true;
        [Column(TypeName = "nvarchar(70)")]
        public string? RenterEmailForENotices { get; set; }
        public bool OwnerCorpRulesApply { get; set; } = true;
        public bool IsConditionReportProvided { get; set; } = true;
        public string? AddtionalTerms { get; set; }
        [Display(Name = "Agree to Terms and Conditions")]
        public bool AgreetoTermsAndConditions { get; set; } = true;
        public status? LeaseStatus { get; set; } = status.Created;
        public enum status
        {
            Created=1, Active=2, Expired=3, Terminated=4,Renewed=5
        }
        public Byte[]? LandlordSign { get; set; }
        public Byte[]? TenantlordSign { get; set; }
        public bool SignedByLandlord { get; set; } = false;         
        public DateTime? LandlordSignedOn { get; set; }
        public bool SignedByTenant { get; set; } = false;
        public bool landlordagree2sign { get; set; } = false;
        public bool tenantagree2sign { get; set; } = false;        
        public DateTime? TenantSignedOn { get; set; }
        public bool Sent2Tenant { get; set; } = false;
        [NotMapped]
        public string? LandlorsigData { get; set; }
        [NotMapped]
        public string? TenantsigData { get; set; }
        public bool SendEmailNotifications { get; set; } // Consent to Electronic Services via email
        [ValidateNever]
        public bool AdditionalTenants { get; set; } = false;
        public string? BankName { get; set; }
        [ValidateNever]
        public string? AccountTitle { get; set; }
        [ValidateNever]
        public string? Branch { get; set; }
        [ValidateNever]
        public string? AccountNo { get; set; }
        [ValidateNever]
        public Bond BondStatus { get; set; } = Bond.Unpaid;
        public enum Bond
        {
            Unpaid = 1, Pending = 2, paid = 3
        }

        [ValidateNever]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [ValidateNever]
        public DateTime? UpdatedOn { get; set; }         
        public string? UpdatedbyUserId { get; set; }
        [ValidateNever]
        public ApplicationUser UpdatedbyUser { get; set; }
        [NotMapped]
        public bool sendupdatedlease { get; set; } = false;
        [ValidateNever]
        public IEnumerable<TenantBill> TenantBills { get; set; }
        [ValidateNever]
        public IEnumerable<BillDocument> BillDocuments { get; set; }
        [ValidateNever]
        public IEnumerable<Document> Documents { get; set; }
        [ValidateNever]
        public IEnumerable<Expense> Expenses { get; set; }
        [ValidateNever]
        public IEnumerable<ExpenseDocument> ExpenseDocuments { get; set; }
        [ValidateNever]
        public IEnumerable<Maintenance> MaintenanceRecord { get; set; }
        [ValidateNever]
        public IEnumerable<MaintenanceDocument> MaintenanceDocuments { get; set; }
        [ValidateNever]
        public IEnumerable<PropertyIncome> PropertyIncome { get; set; }
        [ValidateNever]
        public List<LeaseTenant> LeaseTenants { get; }
    }
}
