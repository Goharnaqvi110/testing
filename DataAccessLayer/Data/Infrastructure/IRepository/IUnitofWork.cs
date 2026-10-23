using Gharshare.DataAccessLayer.Data.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gharshare.DataAccessLayer.Data.Infrastructure.IRepository
{
    public interface IUnitofWork
    {
        IPropertyRepository Property { get; }
        IPropertyTypeRepository PropertyType { get; }
        IPropertyAreaRepository PropertyArea { get; }
        IPropertyAreaItemRepository PropertyAreaItem { get; }
        IPropertyImagesRepository PropertyImages { get; }
        IPlanRepository Plan { get; }
        IServiceRepository Service { get; }
        IPlanServiceRepository PlanService { get; }
        ITestimonialRepository Testimonial { get; }
        IMessageRepository Message { get; }
        IUserRepository User { get; }
        IUserPaymentRepository UserPayment { get; }
        IUserPlanRepository UserPlan { get; }
        IMeetingRepository Meeting { get; }
        IStateRepository State { get; }
        ICityRepository City { get; }
        ISuburbRepository Suburb { get; }
        IRoomRepository Room { get; }
        IStaticContentRepository StaticContent { get; }
        IContentTypeRepository ContentType { get; }
        IToolkitRepository Toolkit { get; }
        IPropertyInspectionRepository PropertyInspection { get; }
        ILeaseAgreementRepository LeaseAgreement { get; }
        IConditionReportRepository ConditionReport { get; }
        ICRItemRepository CRItem { get; }
        ICRItemDetailRepository CRItemDetail { get; }
        ICRItemImageRepository CRItemImage { get; }
        ICRItemLookupRepository CRItemLookup { get; }
        IPropertyEnquiryRepository PropertyEnquiry { get; }
        IRentalPaymentRepository RentalPayment { get; }
        ICategoryRepository Category { get; }
        IExpenseRepository Expense { get; }
        ITenantBillRepository TenantBill { get; }
        IMaintenanceRepository Maintenance { get; }
        IExpenseDocumentRepository ExpenseDocument { get; }
        IBillDocumentRepository BillDocument { get; }
        IMaintenanceDocumentRepository MaintenanceDocument { get; }
        IReceiptRepository Receipt { get; }
        IApplicantRepository Applicant { get; }
        IApplicantAddIncomeRepository ApplicantAddIncome { get; }
        IApplicantDependentRepository ApplicantDependent { get; }
        IApplicantDocTypeRepository ApplicantDocType { get; }
        IApplicantDocumentRepository ApplicantDocument { get; }
        IApplicantEmployerRepository ApplicantEmployer { get; }
        IApplicantHistoryRepository ApplicantHistory { get; }
        IApplicantPetRepository ApplicantPet { get; }
        IApplicantReferenceRepository ApplicantReference { get; }
        IApplicantVehicleRepository ApplicantVehicle { get; }
        IDocumentTypeRepository DocumentType { get; }
        IDocumentRepository Document { get; }
        IUserBankAccountRepository UserBankAccount { get; }
        IPropertyFeatureRepository PropertyFeature { get; }
        IFeatureRepository Feature { get; }
        IAcceptingRepository Accepting { get; }
        IPropertyAcceptingRepository PropertyAccepting { get; }
        IPropertiesViewedRepository PropertiesViewed { get; }
        IApplicationRepository Application { get; }
        ILeaseTenantRepository LeaseTenant { get; }
        IBondAttachmentRepository BondAttachment { get; }
        IErrorLogRepository ErrorLog { get; }
        IDemoRequestRepository DemoRequest { get; }
        ISitesettingRepository Sitesetting { get; }
        IEmailTemplateTypeRepository EmailTemplateType { get; }
        IEmailTemplateRepository EmailTemplate { get; }
        IEnquiryRepository Enquiry { get; }
        IReferralRepository Referral { get; }
        void Save();
    }
}
