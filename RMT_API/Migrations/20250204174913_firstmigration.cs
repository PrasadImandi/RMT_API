using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RMT_API.Migrations
{
    /// <inheritdoc />
    public partial class firstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessTypeMaster",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessTypeMaster", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ContactInformation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactTypeID = table.Column<int>(type: "int", nullable: false),
                    ContactNumber = table.Column<string>(type: "varchar(20)", nullable: false),
                    ContactEmail = table.Column<string>(type: "varchar(60)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInformation", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ContactTypeMaster",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactTypeMaster", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryMotionMaster",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryMotionMaster", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DomainLevelMaster",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainLevelMaster", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DomainMaster",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainMaster", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DomainRoleMaster",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainRoleMaster", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FormAccess",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessTypeID = table.Column<int>(type: "int", nullable: false),
                    FormID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormAccess", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FormMaster",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormMaster", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LaptopProviderMaster",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaptopProviderMaster", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Leaves",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceID = table.Column<int>(type: "int", nullable: false),
                    LeaveTypeID = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "varchar(15)", nullable: false),
                    ApproverID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaves", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LeaveTypeMaster",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveTypeMaster", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LocationMaster",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(20)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationMaster", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(60)", nullable: false),
                    ContactNumber = table.Column<string>(type: "varchar(20)", nullable: false),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerTypeID = table.Column<int>(type: "int", nullable: false),
                    ParentManagerId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Manager_Manager_ParentManagerId",
                        column: x => x.ParentManagerId,
                        principalTable: "Manager",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ManagerTypeMaster",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerTypeMaster", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PincodeMaster",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(20)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PincodeMaster", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PublicHolidaysMaster",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(200)", nullable: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: true),
                    PHDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PHYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicHolidaysMaster", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RegionMaster",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(20)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionMaster", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ResourceDeployments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceID = table.Column<int>(type: "int", nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AllocationPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceDeployments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ResourceInformation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceInformation", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ResourceLifecycles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceID = table.Column<int>(type: "int", nullable: false),
                    LifecycleType = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "varchar(200)", nullable: true),
                    HandledByID = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceLifecycles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ResourceOffboardings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceID = table.Column<int>(type: "int", nullable: false),
                    OffboardingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HandledByID = table.Column<int>(type: "int", nullable: false),
                    ExitDocumentName = table.Column<string>(type: "varchar(200)", nullable: true),
                    DocumentPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "varchar(20)", nullable: true),
                    FileSize = table.Column<int>(type: "int", nullable: false),
                    ExitReason = table.Column<string>(type: "varchar(500)", nullable: true),
                    Notes = table.Column<string>(type: "varchar(500)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceOffboardings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ResourceOnboardings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceID = table.Column<int>(type: "int", nullable: false),
                    OnboardingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HandledByID = table.Column<int>(type: "int", nullable: false),
                    DocumentName = table.Column<string>(type: "varchar(50)", nullable: true),
                    DocumentPath = table.Column<string>(type: "varchar(200)", nullable: true),
                    FileType = table.Column<string>(type: "varchar(20)", nullable: true),
                    FileSize = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "varchar(500)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceOnboardings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(100)", nullable: true),
                    MobileNumber = table.Column<string>(type: "varchar(60)", nullable: true),
                    EmailID = table.Column<string>(type: "varchar(60)", nullable: true),
                    ClientID = table.Column<int>(type: "int", nullable: true),
                    ProjectID = table.Column<int>(type: "int", nullable: true),
                    PMID = table.Column<int>(type: "int", nullable: true),
                    RMID = table.Column<int>(type: "int", nullable: true),
                    SupplierID = table.Column<int>(type: "int", nullable: true),
                    ResourceInformationID = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SegmentMaster",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SegmentMaster", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SPOC",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SPOCContactNumber = table.Column<string>(type: "varchar(20)", nullable: true),
                    SPOCEmailID = table.Column<string>(type: "varchar(60)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPOC", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StateMaster",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(100)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateMaster", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SupportTypeMaster",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportTypeMaster", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Timesheets",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceID = table.Column<int>(type: "int", nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoursWorked = table.Column<string>(type: "varchar(500)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timesheets", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(100)", nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", nullable: true),
                    UserName = table.Column<string>(type: "varchar(100)", nullable: false),
                    Password = table.Column<string>(type: "varchar(max)", nullable: false),
                    AccessTypeID = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_AccessTypeMaster_AccessTypeID",
                        column: x => x.AccessTypeID,
                        principalTable: "AccessTypeMaster",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Supplier_Code = table.Column<string>(type: "nvarchar(max)", nullable: false, computedColumnSql: "CONCAT('S', RIGHT('10000' + CAST(ID AS VARCHAR), 5))", stored: true),
                    SIDDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "varchar(200)", nullable: true),
                    StateID = table.Column<int>(type: "int", nullable: true),
                    GST = table.Column<string>(type: "varchar(60)", nullable: true),
                    PAN = table.Column<string>(type: "varchar(20)", nullable: true),
                    TAN = table.Column<string>(type: "varchar(20)", nullable: true),
                    ContactInformationID = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Supplier_ContactInformation_ContactInformationID",
                        column: x => x.ContactInformationID,
                        principalTable: "ContactInformation",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ReportingManager",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RMContactNumber = table.Column<string>(type: "varchar(20)", nullable: true),
                    RMEmailID = table.Column<string>(type: "varchar(60)", nullable: true),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    ProjectManagerID = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportingManager", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ReportingManager_Manager_ProjectManagerID",
                        column: x => x.ProjectManagerID,
                        principalTable: "Manager",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "AcademicDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResultPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Attachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResourceInformationID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AcademicDetails_ResourceInformation_ResourceInformationID",
                        column: x => x.ResourceInformationID,
                        principalTable: "ResourceInformation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CertificationDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Attachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResourceInformationID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificationDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CertificationDetails_ResourceInformation_ResourceInformationID",
                        column: x => x.ResourceInformationID,
                        principalTable: "ResourceInformation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceInformationID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Documents_ResourceInformation_ResourceInformationID",
                        column: x => x.ResourceInformationID,
                        principalTable: "ResourceInformation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    FathersName = table.Column<string>(type: "varchar(100)", nullable: true),
                    MothersName = table.Column<string>(type: "varchar(100)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlternateContactNumber = table.Column<string>(type: "varchar(20)", nullable: false),
                    EmergencyContactNumber = table.Column<string>(type: "varchar(20)", nullable: false),
                    HometownAddress = table.Column<string>(type: "varchar(20)", nullable: true),
                    OfficialMailingAddress = table.Column<string>(type: "varchar(60)", nullable: true),
                    PinCodeID = table.Column<int>(type: "int", nullable: true),
                    StateID = table.Column<int>(type: "int", nullable: true),
                    ResourceInformationID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PersonalDetails_ResourceInformation_ResourceInformationID",
                        column: x => x.ResourceInformationID,
                        principalTable: "ResourceInformation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionalDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetAssignedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssetModelNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    AssetSerialNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    AttendanceRequired = table.Column<bool>(type: "bit", nullable: false),
                    CWFID = table.Column<string>(type: "varchar(50)", nullable: true),
                    LastWorkingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OfficialEmailID = table.Column<string>(type: "varchar(60)", nullable: true),
                    OverallExperience = table.Column<int>(type: "int", nullable: false),
                    PODate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PONo = table.Column<string>(type: "varchar(50)", nullable: true),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JoiningLocationID = table.Column<int>(type: "int", nullable: true),
                    LaptopProviderID = table.Column<int>(type: "int", nullable: true),
                    DomainID = table.Column<int>(type: "int", nullable: true),
                    DomainRoleID = table.Column<int>(type: "int", nullable: true),
                    DomainLevelID = table.Column<int>(type: "int", nullable: true),
                    ResourceInformationID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProfessionalDetails_ResourceInformation_ResourceInformationID",
                        column: x => x.ResourceInformationID,
                        principalTable: "ResourceInformation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortName = table.Column<string>(type: "varchar(50)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "varchar(200)", nullable: true),
                    Notes = table.Column<string>(type: "varchar(500)", nullable: true),
                    RegionID = table.Column<int>(type: "int", nullable: false),
                    StateID = table.Column<int>(type: "int", nullable: false),
                    LocationID = table.Column<int>(type: "int", nullable: false),
                    PincodeID = table.Column<int>(type: "int", nullable: false),
                    SPOCID = table.Column<int>(type: "int", nullable: true),
                    ReportingManagerID = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Clients_ReportingManager_ReportingManagerID",
                        column: x => x.ReportingManagerID,
                        principalTable: "ReportingManager",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "BGVDocuments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(500)", nullable: true),
                    Attachments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentsID = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BGVDocuments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BGVDocuments_Documents_DocumentsID",
                        column: x => x.DocumentsID,
                        principalTable: "Documents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JoiningDocuments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AadharCard = table.Column<string>(type: "varchar(30)", nullable: false),
                    AppraisalLetter = table.Column<string>(type: "varchar(30)", nullable: false),
                    DrivingLicense = table.Column<string>(type: "varchar(30)", nullable: false),
                    JoiningLetter = table.Column<string>(type: "varchar(30)", nullable: false),
                    OfferLetter = table.Column<string>(type: "varchar(30)", nullable: false),
                    PanCard = table.Column<string>(type: "varchar(30)", nullable: false),
                    Passport = table.Column<string>(type: "varchar(30)", nullable: false),
                    DocumentsID = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JoiningDocuments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_JoiningDocuments_Documents_DocumentsID",
                        column: x => x.DocumentsID,
                        principalTable: "Documents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectCode = table.Column<string>(type: "varchar(20)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: true),
                    PMID = table.Column<int>(type: "int", nullable: true),
                    RMID = table.Column<int>(type: "int", nullable: true),
                    DeleiveryMotionID = table.Column<int>(type: "int", nullable: true),
                    SegmentID = table.Column<int>(type: "int", nullable: true),
                    SupportTypeID = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Projects_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Projects_DeliveryMotionMaster_DeleiveryMotionID",
                        column: x => x.DeleiveryMotionID,
                        principalTable: "DeliveryMotionMaster",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Projects_Manager_PMID",
                        column: x => x.PMID,
                        principalTable: "Manager",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Projects_ReportingManager_RMID",
                        column: x => x.RMID,
                        principalTable: "ReportingManager",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_SegmentMaster_SegmentID",
                        column: x => x.SegmentID,
                        principalTable: "SegmentMaster",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Projects_SupportTypeMaster_SupportTypeID",
                        column: x => x.SupportTypeID,
                        principalTable: "SupportTypeMaster",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicDetails_ResourceInformationID",
                table: "AcademicDetails",
                column: "ResourceInformationID");

            migrationBuilder.CreateIndex(
                name: "IX_BGVDocuments_DocumentsID",
                table: "BGVDocuments",
                column: "DocumentsID");

            migrationBuilder.CreateIndex(
                name: "IX_CertificationDetails_ResourceInformationID",
                table: "CertificationDetails",
                column: "ResourceInformationID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ReportingManagerID",
                table: "Clients",
                column: "ReportingManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ResourceInformationID",
                table: "Documents",
                column: "ResourceInformationID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JoiningDocuments_DocumentsID",
                table: "JoiningDocuments",
                column: "DocumentsID",
                unique: true,
                filter: "[DocumentsID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_ParentManagerId",
                table: "Manager",
                column: "ParentManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDetails_ResourceInformationID",
                table: "PersonalDetails",
                column: "ResourceInformationID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalDetails_ResourceInformationID",
                table: "ProfessionalDetails",
                column: "ResourceInformationID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientID",
                table: "Projects",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DeleiveryMotionID",
                table: "Projects",
                column: "DeleiveryMotionID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_PMID",
                table: "Projects",
                column: "PMID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_RMID",
                table: "Projects",
                column: "RMID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_SegmentID",
                table: "Projects",
                column: "SegmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_SupportTypeID",
                table: "Projects",
                column: "SupportTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ReportingManager_ProjectManagerID",
                table: "ReportingManager",
                column: "ProjectManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_ContactInformationID",
                table: "Supplier",
                column: "ContactInformationID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AccessTypeID",
                table: "Users",
                column: "AccessTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicDetails");

            migrationBuilder.DropTable(
                name: "BGVDocuments");

            migrationBuilder.DropTable(
                name: "CertificationDetails");

            migrationBuilder.DropTable(
                name: "ContactTypeMaster");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "DomainLevelMaster");

            migrationBuilder.DropTable(
                name: "DomainMaster");

            migrationBuilder.DropTable(
                name: "DomainRoleMaster");

            migrationBuilder.DropTable(
                name: "FormAccess");

            migrationBuilder.DropTable(
                name: "FormMaster");

            migrationBuilder.DropTable(
                name: "JoiningDocuments");

            migrationBuilder.DropTable(
                name: "LaptopProviderMaster");

            migrationBuilder.DropTable(
                name: "Leaves");

            migrationBuilder.DropTable(
                name: "LeaveTypeMaster");

            migrationBuilder.DropTable(
                name: "LocationMaster");

            migrationBuilder.DropTable(
                name: "ManagerTypeMaster");

            migrationBuilder.DropTable(
                name: "PersonalDetails");

            migrationBuilder.DropTable(
                name: "PincodeMaster");

            migrationBuilder.DropTable(
                name: "ProfessionalDetails");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "PublicHolidaysMaster");

            migrationBuilder.DropTable(
                name: "RegionMaster");

            migrationBuilder.DropTable(
                name: "ResourceDeployments");

            migrationBuilder.DropTable(
                name: "ResourceLifecycles");

            migrationBuilder.DropTable(
                name: "ResourceOffboardings");

            migrationBuilder.DropTable(
                name: "ResourceOnboardings");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "SPOC");

            migrationBuilder.DropTable(
                name: "StateMaster");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Timesheets");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "DeliveryMotionMaster");

            migrationBuilder.DropTable(
                name: "SegmentMaster");

            migrationBuilder.DropTable(
                name: "SupportTypeMaster");

            migrationBuilder.DropTable(
                name: "ContactInformation");

            migrationBuilder.DropTable(
                name: "AccessTypeMaster");

            migrationBuilder.DropTable(
                name: "ResourceInformation");

            migrationBuilder.DropTable(
                name: "ReportingManager");

            migrationBuilder.DropTable(
                name: "Manager");
        }
    }
}
