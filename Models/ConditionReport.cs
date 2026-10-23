using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gharshare.Models
{
    public class ConditionReport
    {
        [Key]
        public Int64 ID { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string? uid { get; set; }
        public Int64 PropertyID { get; set; }
        public Property? Property { get; set; }
        public Int64? LeaseAgreementID { get; set; }
        public LeaseAgreement? LeaseAgreement { get; set; }
        public Int64? PrimaryTenantID { get; set; }
        public Applicant? PrimaryTenant { get; set; }
        public DateTime? InspectionDate { get; set; }        
        public Byte[]? LandlordSign { get; set; }
        public Byte[]? TenantSign { get; set; }
        public DateTime? CreatedOn { get; set; }
        public ApplicationUser? CreatedbyUser { get; set; }
        public string? CreatedbyUserId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public ApplicationUser? UpdatedbyUser { get; set; }
        public string? UpdatedbyUserId { get; set; }
        public List<CRItem>? ReportItems { get; set; }
        [NotMapped]
        public string? LandlorsigData { get; set; }
        [NotMapped]
        public string? TenantsigData { get; set; }        
        public enum Status
        {
            [Display(Name = "Created")]
            Created = 1,
            [Display(Name = "Signed by Landlord")]
            SignedByLandlord = 2,
            [Display(Name = "Signed by Tenant")]
            SignedByTenant = 3,
            [Display(Name = "Signed by both Landlord & Tenant")]
            SignedByLandlordAndTenant=4,
            [Display(Name = "Completed")]
            Completed =5
        }
        public Status? status { get; set; }
        public bool SignedByLandlord { get; set; }
        public DateTime? LandlordSignedOn { get; set; }
        public bool SignedByTenant { get; set; }
        public DateTime? TenantSignedOn { get; set; }
        public bool Sent2Tenant { get; set; }
        [ValidateNever]
        public string? FilePath { get; set; }
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
