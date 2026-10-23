using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class CreateGharshareDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "ApplicantDocTypes",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantDocTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Applicants",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    IsSmoker = table.Column<bool>(type: "bit", nullable: false),
                    OwnPets = table.Column<bool>(type: "bit", nullable: false),
                    NeedParking = table.Column<bool>(type: "bit", nullable: false),
                    LandlordType = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CurrentAddress = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    DateStartedLiving = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JobStatus = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    Reasonforleaving = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    IsRejected = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CRItemLookups",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    LandlordComments = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    TenantComments = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRItemLookups", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LeaseAgreements",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimaryTenantID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyID = table.Column<long>(type: "bigint", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AgreementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WeeklyRent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MonthlyRent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsPeriodicAgreement = table.Column<bool>(type: "bit", nullable: false),
                    AgreementType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeriodicRent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BondAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsBondPaid = table.Column<bool>(type: "bit", nullable: false),
                    IsBondPaidOutside = table.Column<bool>(type: "bit", nullable: false),
                    BondPaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentFrequency = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    RentPaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstRentPaymentDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodicAgreementStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsOutsidePaymentReceived = table.Column<bool>(type: "bit", nullable: false),
                    OutsidePaymentMonths = table.Column<int>(type: "int", nullable: true),
                    EmergencyContactName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    EmergencyPhoneNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    EmergencyEmail = table.Column<string>(type: "nvarchar(70)", nullable: true),
                    PaythroughGharshare = table.Column<bool>(type: "bit", nullable: false),
                    Directdebit = table.Column<bool>(type: "bit", nullable: false),
                    Bankdeposit = table.Column<bool>(type: "bit", nullable: false),
                    Cash = table.Column<bool>(type: "bit", nullable: false),
                    ChequeorMoneyorder = table.Column<bool>(type: "bit", nullable: false),
                    IsLandlordAgreedtoServeENotices = table.Column<bool>(type: "bit", nullable: false),
                    LandlordEmailForENotices = table.Column<string>(type: "nvarchar(70)", nullable: true),
                    IsRenterAgreedtoGetENotices = table.Column<bool>(type: "bit", nullable: false),
                    RenterEmailForENotices = table.Column<string>(type: "nvarchar(70)", nullable: true),
                    IsOwnerCorporationRulesAppy = table.Column<bool>(type: "bit", nullable: false),
                    IsConditionReportProvided = table.Column<bool>(type: "bit", nullable: false),
                    AddtionalTerms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgreetoTermsAndConditions = table.Column<bool>(type: "bit", nullable: false),
                    LeaseStatus = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    LandlordSign = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    TenantlordSign = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaseAgreements", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Meetings",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    MeetingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Medium = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    MediumID = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromUserID = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ToUserID = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Messageb = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    SentOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSent = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpFrontPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MonthlyCharges = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BoxHeading = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tagline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PropertyEnquiries",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyID = table.Column<long>(type: "bigint", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    AudioMessageFilePath = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    DateReceived = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyEnquiries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PropertyImages",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyID = table.Column<long>(type: "bigint", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyImages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PropertyIncomeReceipts",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyIncomeID = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyIncomeReceipts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PropertyInspections",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyID = table.Column<long>(type: "bigint", nullable: false),
                    InspectionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyInspections", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyID = table.Column<long>(type: "bigint", nullable: false),
                    Receiptnumber = table.Column<long>(type: "bigint", nullable: false),
                    LeaseAgreementID = table.Column<long>(type: "bigint", nullable: false),
                    FromUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RentalPayments",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaseAgreementID = table.Column<long>(type: "bigint", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountDue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Outstanding = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaymentStaus = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalPayments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyID = table.Column<long>(type: "bigint", nullable: false),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomFurnishings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BathroomType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BedSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomFeatures = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanIDs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "States",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StaticContent",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Page = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Section = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Heading = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    SubHeading = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    SubHeading2 = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaticContent", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Testimonials",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiniImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsShown = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Toolkit",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    PropertyAddress = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IPAddress = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    IsReplied = table.Column<bool>(type: "bit", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toolkit", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserBankAccounts",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountType = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    AccountTitle = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    AccountNo = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    BranchCode = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CardHolderName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    CardNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CardType = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    IsSelectedForPayment = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBankAccounts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateID = table.Column<long>(type: "bigint", nullable: true),
                    CityID = table.Column<long>(type: "bigint", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserType = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantAddIncomes",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantID = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AnnualTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentTerm = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantAddIncomes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ApplicantAddIncomes_Applicants_ApplicantID",
                        column: x => x.ApplicantID,
                        principalSchema: "dbo",
                        principalTable: "Applicants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantDependents",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantID = table.Column<long>(type: "bigint", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Relationship = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    IsLivingWithYou = table.Column<bool>(type: "bit", nullable: false),
                    IsReceivingChildSupport = table.Column<bool>(type: "bit", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantDependents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ApplicantDependents_Applicants_ApplicantID",
                        column: x => x.ApplicantID,
                        principalSchema: "dbo",
                        principalTable: "Applicants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantDocuments",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantID = table.Column<long>(type: "bigint", nullable: false),
                    DocumentTypeID = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantDocuments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ApplicantDocuments_Applicants_ApplicantID",
                        column: x => x.ApplicantID,
                        principalSchema: "dbo",
                        principalTable: "Applicants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantEmployers",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantID = table.Column<long>(type: "bigint", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    EmployerName = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnnualIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    IsCurrentEmployer = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantEmployers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ApplicantEmployers_Applicants_ApplicantID",
                        column: x => x.ApplicantID,
                        principalSchema: "dbo",
                        principalTable: "Applicants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantHistory",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantID = table.Column<long>(type: "bigint", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    UnitNo = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    StreetNo = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    StreetName = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Suburb = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    PostCode = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandlordType = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    DateStartedLiving = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    Reasonforleaving = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantHistory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ApplicantHistory_Applicants_ApplicantID",
                        column: x => x.ApplicantID,
                        principalSchema: "dbo",
                        principalTable: "Applicants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantPets",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantID = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(70)", nullable: true),
                    age = table.Column<int>(type: "int", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    PicturePath = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantPets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ApplicantPets_Applicants_ApplicantID",
                        column: x => x.ApplicantID,
                        principalSchema: "dbo",
                        principalTable: "Applicants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantReferences",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantID = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Relationship = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantReferences", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ApplicantReferences_Applicants_ApplicantID",
                        column: x => x.ApplicantID,
                        principalSchema: "dbo",
                        principalTable: "Applicants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantVehicles",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantID = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Registration = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    IsPrimaryVehicle = table.Column<bool>(type: "bit", nullable: false),
                    NeedParking = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantVehicles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ApplicantVehicles_Applicants_ApplicantID",
                        column: x => x.ApplicantID,
                        principalSchema: "dbo",
                        principalTable: "Applicants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanServices",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanID = table.Column<long>(type: "bigint", nullable: false),
                    ServiceID = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanServices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PlanServices_Plans_PlanID",
                        column: x => x.PlanID,
                        principalSchema: "dbo",
                        principalTable: "Plans",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateID = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateID",
                        column: x => x.StateID,
                        principalSchema: "dbo",
                        principalTable: "States",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyIncomes",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyID = table.Column<long>(type: "bigint", nullable: false),
                    LeaseAgreementID = table.Column<long>(type: "bigint", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsGSTIncluded = table.Column<bool>(type: "bit", nullable: false),
                    PaidById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyIncomes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PropertyIncomes_Users_PaidById",
                        column: x => x.PaidById,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "dbo",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateID = table.Column<long>(type: "bigint", nullable: false),
                    CityID = table.Column<long>(type: "bigint", nullable: false),
                    Suburb = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    AccommodationType = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TotalArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bed = table.Column<int>(type: "int", nullable: true),
                    Bathrooms = table.Column<int>(type: "int", nullable: true),
                    BondValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Monthlyrent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ParkingType = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Internet = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    BillStatus = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    MinimumStay = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    MaximumStay = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Features = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Totalflatmates = table.Column<int>(type: "int", nullable: true),
                    FlatmatePreference = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    AboutFlatmates = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Accepting = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    CoverImage = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    GoogleMapEmbedAPIURL = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    HideAddress = table.Column<bool>(type: "bit", nullable: false),
                    AvailableFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRented = table.Column<bool>(type: "bit", nullable: false),
                    IsRentedWhole = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RoomAvailable = table.Column<bool>(type: "bit", nullable: false),
                    WomenOnlyProperty = table.Column<bool>(type: "bit", nullable: false),
                    IsOnwnerOrAuthorized = table.Column<bool>(type: "bit", nullable: false),
                    ShowPhoneNo = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Properties_Cities_CityID",
                        column: x => x.CityID,
                        principalSchema: "dbo",
                        principalTable: "Cities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Properties_States_StateID",
                        column: x => x.StateID,
                        principalSchema: "dbo",
                        principalTable: "States",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Suburbs",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CityID1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suburbs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Suburbs_Cities_CityID1",
                        column: x => x.CityID1,
                        principalSchema: "dbo",
                        principalTable: "Cities",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ConditionReport",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProperyID = table.Column<long>(type: "bigint", nullable: false),
                    InspectionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LandlordSign = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    TenantSign = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConditionReport", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ConditionReport_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalSchema: "dbo",
                        principalTable: "Properties",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentTypeID = table.Column<long>(type: "bigint", nullable: false),
                    PropertyID = table.Column<long>(type: "bigint", nullable: false),
                    LeaseAgreementID = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Documents_LeaseAgreements_LeaseAgreementID",
                        column: x => x.LeaseAgreementID,
                        principalSchema: "dbo",
                        principalTable: "LeaseAgreements",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalSchema: "dbo",
                        principalTable: "Properties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<long>(type: "bigint", nullable: false),
                    PropertyID = table.Column<long>(type: "bigint", nullable: false),
                    LeaseAgreementID = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExpenseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsGSTIncluded = table.Column<bool>(type: "bit", nullable: false),
                    IsAlreadyPaid = table.Column<bool>(type: "bit", nullable: false),
                    CollectViaGharshare = table.Column<bool>(type: "bit", nullable: false),
                    PaidByUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Expenses_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalSchema: "dbo",
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenses_LeaseAgreements_LeaseAgreementID",
                        column: x => x.LeaseAgreementID,
                        principalSchema: "dbo",
                        principalTable: "LeaseAgreements",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenses_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalSchema: "dbo",
                        principalTable: "Properties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Maintenance",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<long>(type: "bigint", nullable: false),
                    PropertyID = table.Column<long>(type: "bigint", nullable: false),
                    LeaseAgreementID = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsGSTIncluded = table.Column<bool>(type: "bit", nullable: false),
                    Requestedby = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenance", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Maintenance_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalSchema: "dbo",
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Maintenance_LeaseAgreements_LeaseAgreementID",
                        column: x => x.LeaseAgreementID,
                        principalSchema: "dbo",
                        principalTable: "LeaseAgreements",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Maintenance_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalSchema: "dbo",
                        principalTable: "Properties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenantBills",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<long>(type: "bigint", nullable: false),
                    PropertyID = table.Column<long>(type: "bigint", nullable: false),
                    LeaseAgreementID = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsGSTIncluded = table.Column<bool>(type: "bit", nullable: false),
                    IsPaidByTenant = table.Column<bool>(type: "bit", nullable: false),
                    BillTenantNow = table.Column<bool>(type: "bit", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    CollectViaGharshare = table.Column<bool>(type: "bit", nullable: false),
                    PaidByUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantBills", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TenantBills_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalSchema: "dbo",
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenantBills_LeaseAgreements_LeaseAgreementID",
                        column: x => x.LeaseAgreementID,
                        principalSchema: "dbo",
                        principalTable: "LeaseAgreements",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenantBills_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalSchema: "dbo",
                        principalTable: "Properties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CRItems",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConditionReportID = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    LandlordComments = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    TenantComments = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CRItems_ConditionReport_ConditionReportID",
                        column: x => x.ConditionReportID,
                        principalSchema: "dbo",
                        principalTable: "ConditionReport",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseDocuments",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseID = table.Column<long>(type: "bigint", nullable: false),
                    PropertyID = table.Column<long>(type: "bigint", nullable: false),
                    LeaseAgreementID = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseDocuments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ExpenseDocuments_Expenses_ExpenseID",
                        column: x => x.ExpenseID,
                        principalSchema: "dbo",
                        principalTable: "Expenses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpenseDocuments_LeaseAgreements_LeaseAgreementID",
                        column: x => x.LeaseAgreementID,
                        principalSchema: "dbo",
                        principalTable: "LeaseAgreements",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ExpenseDocuments_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalSchema: "dbo",
                        principalTable: "Properties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceDocuments",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaintenanceID = table.Column<long>(type: "bigint", nullable: false),
                    PropertyID = table.Column<long>(type: "bigint", nullable: false),
                    LeaseAgreementID = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    IsPhoto = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceDocuments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MaintenanceDocuments_LeaseAgreements_LeaseAgreementID",
                        column: x => x.LeaseAgreementID,
                        principalSchema: "dbo",
                        principalTable: "LeaseAgreements",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaintenanceDocuments_Maintenance_MaintenanceID",
                        column: x => x.MaintenanceID,
                        principalSchema: "dbo",
                        principalTable: "Maintenance",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MaintenanceDocuments_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalSchema: "dbo",
                        principalTable: "Properties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillDocuments",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantBillID = table.Column<long>(type: "bigint", nullable: false),
                    PropertyID = table.Column<long>(type: "bigint", nullable: false),
                    LeaseAgreementID = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillDocuments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BillDocuments_LeaseAgreements_LeaseAgreementID",
                        column: x => x.LeaseAgreementID,
                        principalSchema: "dbo",
                        principalTable: "LeaseAgreements",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillDocuments_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalSchema: "dbo",
                        principalTable: "Properties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillDocuments_TenantBills_TenantBillID",
                        column: x => x.TenantBillID,
                        principalSchema: "dbo",
                        principalTable: "TenantBills",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CRItemDetails",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CRItemID = table.Column<long>(type: "bigint", nullable: false),
                    IsClean = table.Column<bool>(type: "bit", nullable: true),
                    IsUndamaged = table.Column<bool>(type: "bit", nullable: true),
                    IsWorking = table.Column<bool>(type: "bit", nullable: true),
                    IsTrue = table.Column<bool>(type: "bit", nullable: true),
                    LandlordComments = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    IsTenantAgreed = table.Column<bool>(type: "bit", nullable: false),
                    TenantComments = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CRItemLookupID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRItemDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CRItemDetails_CRItemLookups_CRItemLookupID",
                        column: x => x.CRItemLookupID,
                        principalSchema: "dbo",
                        principalTable: "CRItemLookups",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CRItemDetails_CRItems_CRItemID",
                        column: x => x.CRItemID,
                        principalSchema: "dbo",
                        principalTable: "CRItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CRItemImages",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CRItemID = table.Column<long>(type: "bigint", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRItemImages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CRItemImages_CRItems_CRItemID",
                        column: x => x.CRItemID,
                        principalSchema: "dbo",
                        principalTable: "CRItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantAddIncomes_ApplicantID",
                schema: "dbo",
                table: "ApplicantAddIncomes",
                column: "ApplicantID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantDependents_ApplicantID",
                schema: "dbo",
                table: "ApplicantDependents",
                column: "ApplicantID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantDocuments_ApplicantID",
                schema: "dbo",
                table: "ApplicantDocuments",
                column: "ApplicantID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantEmployers_ApplicantID",
                schema: "dbo",
                table: "ApplicantEmployers",
                column: "ApplicantID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantHistory_ApplicantID",
                schema: "dbo",
                table: "ApplicantHistory",
                column: "ApplicantID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantPets_ApplicantID",
                schema: "dbo",
                table: "ApplicantPets",
                column: "ApplicantID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantReferences_ApplicantID",
                schema: "dbo",
                table: "ApplicantReferences",
                column: "ApplicantID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantVehicles_ApplicantID",
                schema: "dbo",
                table: "ApplicantVehicles",
                column: "ApplicantID");

            migrationBuilder.CreateIndex(
                name: "IX_BillDocuments_LeaseAgreementID",
                schema: "dbo",
                table: "BillDocuments",
                column: "LeaseAgreementID");

            migrationBuilder.CreateIndex(
                name: "IX_BillDocuments_PropertyID",
                schema: "dbo",
                table: "BillDocuments",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_BillDocuments_TenantBillID",
                schema: "dbo",
                table: "BillDocuments",
                column: "TenantBillID");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateID",
                schema: "dbo",
                table: "Cities",
                column: "StateID");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionReport_PropertyID",
                schema: "dbo",
                table: "ConditionReport",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_CRItemDetails_CRItemID",
                schema: "dbo",
                table: "CRItemDetails",
                column: "CRItemID");

            migrationBuilder.CreateIndex(
                name: "IX_CRItemDetails_CRItemLookupID",
                schema: "dbo",
                table: "CRItemDetails",
                column: "CRItemLookupID");

            migrationBuilder.CreateIndex(
                name: "IX_CRItemImages_CRItemID",
                schema: "dbo",
                table: "CRItemImages",
                column: "CRItemID");

            migrationBuilder.CreateIndex(
                name: "IX_CRItems_ConditionReportID",
                schema: "dbo",
                table: "CRItems",
                column: "ConditionReportID");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_LeaseAgreementID",
                schema: "dbo",
                table: "Documents",
                column: "LeaseAgreementID");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_PropertyID",
                schema: "dbo",
                table: "Documents",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseDocuments_ExpenseID",
                schema: "dbo",
                table: "ExpenseDocuments",
                column: "ExpenseID");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseDocuments_LeaseAgreementID",
                schema: "dbo",
                table: "ExpenseDocuments",
                column: "LeaseAgreementID");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseDocuments_PropertyID",
                schema: "dbo",
                table: "ExpenseDocuments",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CategoryID",
                schema: "dbo",
                table: "Expenses",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_LeaseAgreementID",
                schema: "dbo",
                table: "Expenses",
                column: "LeaseAgreementID");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_PropertyID",
                schema: "dbo",
                table: "Expenses",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_CategoryID",
                schema: "dbo",
                table: "Maintenance",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_LeaseAgreementID",
                schema: "dbo",
                table: "Maintenance",
                column: "LeaseAgreementID");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_PropertyID",
                schema: "dbo",
                table: "Maintenance",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceDocuments_LeaseAgreementID",
                schema: "dbo",
                table: "MaintenanceDocuments",
                column: "LeaseAgreementID");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceDocuments_MaintenanceID",
                schema: "dbo",
                table: "MaintenanceDocuments",
                column: "MaintenanceID");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceDocuments_PropertyID",
                schema: "dbo",
                table: "MaintenanceDocuments",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_PlanServices_PlanID",
                schema: "dbo",
                table: "PlanServices",
                column: "PlanID");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_CityID",
                schema: "dbo",
                table: "Properties",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_StateID",
                schema: "dbo",
                table: "Properties",
                column: "StateID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyIncomes_PaidById",
                schema: "dbo",
                table: "PropertyIncomes",
                column: "PaidById");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "dbo",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "dbo",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Suburbs_CityID1",
                schema: "dbo",
                table: "Suburbs",
                column: "CityID1");

            migrationBuilder.CreateIndex(
                name: "IX_TenantBills_CategoryID",
                schema: "dbo",
                table: "TenantBills",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_TenantBills_LeaseAgreementID",
                schema: "dbo",
                table: "TenantBills",
                column: "LeaseAgreementID");

            migrationBuilder.CreateIndex(
                name: "IX_TenantBills_PropertyID",
                schema: "dbo",
                table: "TenantBills",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "dbo",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "dbo",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "dbo",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "dbo",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "dbo",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantAddIncomes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ApplicantDependents",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ApplicantDocTypes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ApplicantDocuments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ApplicantEmployers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ApplicantHistory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ApplicantPets",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ApplicantReferences",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ApplicantVehicles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BillDocuments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CRItemDetails",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CRItemImages",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Documents",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DocumentTypes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ExpenseDocuments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MaintenanceDocuments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Meetings",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Messages",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PlanServices",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PropertyEnquiries",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PropertyImages",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PropertyIncomeReceipts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PropertyIncomes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PropertyInspections",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Receipts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RentalPayments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Rooms",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Services",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "StaticContent",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Suburbs",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Testimonials",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Toolkit",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserBankAccounts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Applicants",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TenantBills",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CRItemLookups",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CRItems",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Expenses",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Maintenance",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Plans",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ConditionReport",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LeaseAgreements",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Properties",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "States",
                schema: "dbo");
        }
    }
}
