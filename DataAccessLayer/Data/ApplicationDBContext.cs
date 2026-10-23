using Gharshare.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection.Emit;

namespace Gharshare.DataAccessLayer
{
    public class ApplicationDBContext : IdentityDbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<PropertyArea> PropertyAreas { get; set; }
        public DbSet<PropertyAreaItem> PropertyAreaItems { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<PlanService> PlanServices { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<PropertyImage> PropertyImages { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ApplicationUser> Users { get; set; } 
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Suburb> Suburbs { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<StaticContent> StaticContent { get; set; }
        public DbSet<ContentType> ContentTypes { get; set; }
        public DbSet<Toolkit> Toolkit { get; set; }
        public DbSet<PropertyInspection> PropertyInspections { get; set; }
        public DbSet<LeaseAgreement> LeaseAgreements { get; set; }
        public DbSet<ConditionReport> ConditionReport { get; set; }
        public DbSet<CRItem> CRItems { get; set; }
        public DbSet<CRItemDetail> CRItemDetails { get; set; }
        public DbSet<CRItemImage> CRItemImages { get; set; }
        public DbSet<CRItemLookup> CRItemLookups { get; set; }
        public DbSet<PropertyEnquiry> PropertyEnquiries { get; set; }
        public DbSet<RentalPayment> RentalPayments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Maintenance> Maintenance { get; set; }
        public DbSet<TenantBill> TenantBills { get; set; }
        public DbSet<ExpenseDocument> ExpenseDocuments { get; set; }
        public DbSet<BillDocument> BillDocuments { get; set; }
        public DbSet<MaintenanceDocument> MaintenanceDocuments { get; set; }
        public DbSet<Receipt>Receipts { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<ApplicantHistory> ApplicantHistory { get; set; }
        public DbSet<ApplicantDependent> ApplicantDependents { get; set; }
        public DbSet<ApplicantPet> ApplicantPets { get; set; }
        public DbSet<ApplicantVehicle> ApplicantVehicles { get; set; }
        public DbSet<ApplicantReference> ApplicantReferences { get; set; }
        public DbSet<ApplicantDocType> ApplicantDocTypes { get; set; }
        public DbSet<ApplicantDocument> ApplicantDocuments { get; set; }
        public DbSet<ApplicantAddIncome> ApplicantAddIncomes { get; set; }
        public DbSet<ApplicantEmployer> ApplicantEmployers { get; set; }
        public DbSet<PropertyIncome> PropertyIncomes { get; set; }
        public DbSet<PropertyIncomeReceipt> PropertyIncomeReceipts { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<UserBankAccount> UserBankAccounts { get; set; }
        public DbSet<PropertyFeature> PropertyFeatures { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Accepting> Acceptings { get; set; }
        public DbSet<PropertyAccepting> PropertyAcceptings { get; set; }
        public DbSet<PropertiesViewed> PropertiesViewed { get; set; }
        public DbSet<Application>Applications { get; set; }
        public DbSet<LeaseTenant> LeaseTenants { get; set; }
        public DbSet<BondAttachment> BondAttachments { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<DemoRequest> DemoRequests { get; set; }
        public DbSet<UserPayment> UsersPayments { get; set; }
        public DbSet<UserPlan> UsersPlans { get; set; }
        public DbSet<Sitesetting> Sitesettings { get; set; }
        public DbSet<EmailTemplateType> EmailTemplateTypes { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<Enquiry> Enquiries { get; set; }
        public DbSet<Referral> Referrals { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("dbo");
            builder.Entity<IdentityUser>(entity =>
            {
                entity.ToTable(name: "Users");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
            builder.Entity<LeaseAgreement>()
            .HasMany(l => l.LeaseTenants)
            .WithOne(t => t.Lease)
            .HasForeignKey(t => t.LeaseID);

            builder.Entity<Property>()
            .HasMany(p => p.UserBankAccounts)
            .WithOne(ba => ba.Property)
            .HasForeignKey(t => t.PropertyId);
        }
    }
    public class DataContextFactory : IDesignTimeDbContextFactory<ApplicationDBContext>
    {
        public ApplicationDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
            var builder = WebApplication.CreateBuilder(args);
            optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            return new ApplicationDBContext(optionsBuilder.Options);
        }
    }

}
