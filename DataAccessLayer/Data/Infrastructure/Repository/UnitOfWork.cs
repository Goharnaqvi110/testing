using Gharshare.DataAccessLayer;
using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gharshare.DataAccessLayer.Data.Infrastructure.Repository
{
    public class UnitOfWork : IUnitofWork
    {
        public IPropertyRepository Property { get; private set; }
        public IPropertyTypeRepository PropertyType { get; private set; }
        public IPropertyAreaRepository PropertyArea { get; private set; }
        public IPropertyAreaItemRepository PropertyAreaItem { get; private set; }
        public IPropertyImagesRepository PropertyImages { get; private set; }
        public IPlanRepository Plan { get; private set; }
        public IPlanServiceRepository PlanService {get; private set;}
        public IServiceRepository Service { get; private set; }        
        public ITestimonialRepository Testimonial { get; private set; }
        public IMessageRepository Message { get; private set; }
        public IUserRepository User { get; private set; }
        public IUserPlanRepository UserPlan { get; private set; }
        public IUserPaymentRepository UserPayment { get; private set; }
        public IMeetingRepository Meeting { get; private set; }
        public IStateRepository State { get; private set; }
        public ICityRepository  City { get; private set; }
        public ISuburbRepository Suburb { get; private set; }
        public IRoomRepository Room { get; private set; }
        public IStaticContentRepository StaticContent { get; private set; }
        public IContentTypeRepository ContentType { get; private set; }
        public IToolkitRepository Toolkit { get; private set; }
        public IPropertyInspectionRepository PropertyInspection { get; private set; }
        public ILeaseAgreementRepository LeaseAgreement { get; private set; }
        public IConditionReportRepository ConditionReport { get; private set; }
        public ICRItemRepository CRItem { get; private set; }
        public ICRItemDetailRepository CRItemDetail { get; private set; }
        public ICRItemImageRepository CRItemImage { get; private set; }
        public ICRItemLookupRepository CRItemLookup { get; private set; }
        public IPropertyEnquiryRepository PropertyEnquiry { get; private set; }
        public IRentalPaymentRepository RentalPayment { get; private set; }
        public ICategoryRepository Category { get; private set; }
        public IExpenseRepository Expense { get; private set; }
        public ITenantBillRepository TenantBill { get; private set; }
        public IMaintenanceRepository Maintenance { get; private set; }
        public IExpenseDocumentRepository ExpenseDocument { get; private set; }
        public IBillDocumentRepository BillDocument { get; private set; }
        public IMaintenanceDocumentRepository MaintenanceDocument { get; private set; }
        public IReceiptRepository Receipt { get; private set; }
        public IApplicantRepository Applicant { get; private set; }
        public IApplicantAddIncomeRepository ApplicantAddIncome { get; private set; }
        public IApplicantDependentRepository ApplicantDependent { get; private set; }
        public IApplicantDocTypeRepository ApplicantDocType { get; private set; }
        public IApplicantDocumentRepository ApplicantDocument { get; private set; }
        public IApplicantEmployerRepository ApplicantEmployer { get; private set; }
        public IApplicantHistoryRepository ApplicantHistory { get; private set; }
        public IApplicantPetRepository ApplicantPet { get; private set; }
        public IApplicantReferenceRepository ApplicantReference { get; private set; }
        public IApplicantVehicleRepository ApplicantVehicle { get; private set; }
        public IDocumentTypeRepository DocumentType { get; private set; }
        public IDocumentRepository Document { get; private set; }
        public IUserBankAccountRepository UserBankAccount { get; private set; }
        public IFeatureRepository Feature { get; private set; }
        public IPropertyFeatureRepository PropertyFeature { get; private set; }
        public IAcceptingRepository Accepting { get; private set; }
        public IPropertyAcceptingRepository PropertyAccepting { get; private set; }
        public IPropertiesViewedRepository PropertiesViewed { get; private set; }
        public IApplicationRepository Application { get; private set; }
        public ILeaseTenantRepository LeaseTenant { get; private set; }
        public IBondAttachmentRepository BondAttachment { get; private set; }
        public IErrorLogRepository ErrorLog { get; }
        public IDemoRequestRepository DemoRequest { get; }
        public ISitesettingRepository Sitesetting { get; }
        public IEmailTemplateTypeRepository EmailTemplateType { get; }
        public IEmailTemplateRepository EmailTemplate { get; }
        public IEnquiryRepository Enquiry { get; }
        public IReferralRepository Referral { get; }


        private readonly ApplicationDBContext _dbContext;

        public UnitOfWork(ApplicationDBContext context)
        {
            _dbContext = context;            
            Property = new PropertyRepository(context);
            PropertyType = new PropertyTypeRepository(context);
            PropertyArea = new PropertyAreaRepository(context);
            PropertyAreaItem = new PropertyAreaItemRepository(context);
            PropertyImages = new PropertyImagesRepository(context);
            Plan = new PlanRepository(context);
            Service = new ServiceRepository(context);
            PlanService = new PlanServiceRepository(context);
            Testimonial = new TestimonialRepository(context);
            Message = new MessageRepository(context);
            User=new UserRepository(context);
            Meeting = new MeetingRepository(context);
            State= new StateRepository(context);
            City=new CityRepository(context);
            Suburb=new SuburbRepository(context);
            Room=new RoomRepository(context);
            StaticContent=new StaticContentRepository(context);
            ContentType = new ContentTypeRepository(context);
            Toolkit = new ToolkitRepository(context);
            PropertyInspection=new PropertyInspectionRepository(context);
            LeaseAgreement=new LeaseAgreementRepository(context);
            ConditionReport=new ConditionReportRepository(context);
            CRItem=new CRItemRepository(context);
            CRItemDetail=new CRItemDetailRepository(context);
            CRItemImage =new CRItemImageRepository(context);
            CRItemLookup=new CRItemLookupRepository(context);
            PropertyEnquiry = new PropertyEnquiryRepository(context);
            RentalPayment=new RentalPaymentRepository(context);
            Category = new CategoryRepository(context);
            Expense =new ExpenseRepository(context);
            TenantBill=new TenantBillRepository(context);
            Maintenance = new MaintenanceRepository(context);
            ExpenseDocument=new ExpenseDocumentRepository(context);
            BillDocument=new BillDocumentRepository(context);
            MaintenanceDocument=new MaintenanceDocumentRepository(context);
            Receipt=new ReceiptRepository(context);
            Applicant=new ApplicantRepository(context);
            ApplicantAddIncome=new ApplicantAddIncomeRepository(context);
            ApplicantDependent=new ApplicantDependentRepository(context);
            ApplicantDocType=new ApplicantDocTypeRepository(context);
            ApplicantDocument=new ApplicantDocumentRepository(context);
            ApplicantEmployer=new ApplicantEmployerRepository(context);
            ApplicantHistory=new ApplicantHistoryRepository(context);
            ApplicantPet=new ApplicantPetRepository(context);
            ApplicantReference=new ApplicantReferenceRepository(context);
            ApplicantVehicle=new ApplicantVehicleRepository(context);
            DocumentType=new DocumentTypeRepository(context);
            Document=new DocumentRepository(context);
            UserBankAccount=new UserBankAccountRepository(context);
            Feature = new FeatureRepository(context);
            PropertyFeature = new PropertyFeatureRepository(context);
            Accepting = new AcceptingRepository(context);
            PropertyAccepting = new PropertyAcceptingRepository(context);
            PropertiesViewed = new PropertiesViewedRepository(context);
            Application = new ApplicationRepository(context);
            LeaseTenant = new LeaseTenantRepository(context);
            BondAttachment = new BondAttachmentRepository(context);
            ErrorLog = new ErrorLogRepository(context);
            DemoRequest = new DemoRequestRepository(context);
            UserPlan = new UserPlanRepository(context);
            UserPayment = new UserPaymentRepository(context);
            Sitesetting = new SitesettingRepository(context);
            EmailTemplateType = new EmailTemplateTypeRepository(context);
            EmailTemplate = new EmailTemplateRepository(context);
            Enquiry = new EnquiryRepository(context);
            Referral=new ReferralRepository(context);
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
