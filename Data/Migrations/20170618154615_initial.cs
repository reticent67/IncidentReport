using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IncidentReport.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crimes",
                columns: table => new
                {
                    CrimeID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    BailAmount = table.Column<int>(nullable: false),
                    CrimeTitle = table.Column<string>(nullable: true),
                    Level = table.Column<string>(nullable: true),
                    Section = table.Column<int>(nullable: false),
                    Subsection = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crimes", x => x.CrimeID);
                });

            migrationBuilder.CreateTable(
                name: "LocTypes",
                columns: table => new
                {
                    LocTypeID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    LocTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocTypes", x => x.LocTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Officers",
                columns: table => new
                {
                    OfficerID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    Assignment = table.Column<string>(nullable: true),
                    Division = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Serial = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Officers", x => x.OfficerID);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    DriversLicense = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    EthnicityID = table.Column<int>(nullable: false),
                    EyeColorID = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    GenderID = table.Column<int>(nullable: false),
                    HairID = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    Middle = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "InvestigativeReports",
                columns: table => new
                {
                    ReportID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    CrimeID = table.Column<int>(nullable: true),
                    IncidentNum = table.Column<int>(nullable: false),
                    MoBox = table.Column<string>(nullable: true),
                    Narrative = table.Column<string>(nullable: true),
                    OccurranceDate = table.Column<DateTime>(nullable: false),
                    OccurranceTime = table.Column<TimeSpan>(nullable: false),
                    ReportDate = table.Column<DateTime>(nullable: false),
                    ReportNum = table.Column<int>(nullable: false),
                    ReportTime = table.Column<TimeSpan>(nullable: false),
                    ReportingDistrict = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestigativeReports", x => x.ReportID);
                    table.ForeignKey(
                        name: "FK_InvestigativeReports_Crimes_CrimeID",
                        column: x => x.CrimeID,
                        principalTable: "Crimes",
                        principalColumn: "CrimeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    AddressNum = table.Column<int>(nullable: false),
                    Lattitude = table.Column<double>(nullable: false),
                    LocTypeID = table.Column<int>(nullable: true),
                    Longitude = table.Column<double>(nullable: false),
                    Prefix = table.Column<string>(nullable: true),
                    StreetName = table.Column<string>(nullable: true),
                    StreetType = table.Column<string>(nullable: true),
                    Suffix = table.Column<string>(nullable: true),
                    UnitNum = table.Column<string>(nullable: true),
                    ZipCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationID);
                    table.ForeignKey(
                        name: "FK_Locations_LocTypes_LocTypeID",
                        column: x => x.LocTypeID,
                        principalTable: "LocTypes",
                        principalColumn: "LocTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReportOfficers",
                columns: table => new
                {
                    ReportOfficerID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    OfficerID = table.Column<int>(nullable: false),
                    ReportID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportOfficers", x => x.ReportOfficerID);
                    table.ForeignKey(
                        name: "FK_ReportOfficers_Officers_OfficerID",
                        column: x => x.OfficerID,
                        principalTable: "Officers",
                        principalColumn: "OfficerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportOfficers_InvestigativeReports_ReportID",
                        column: x => x.ReportID,
                        principalTable: "InvestigativeReports",
                        principalColumn: "ReportID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportPersons",
                columns: table => new
                {
                    ReportPersonID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    PersonID = table.Column<int>(nullable: false),
                    ReportID = table.Column<int>(nullable: false),
                    RoleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportPersons", x => x.ReportPersonID);
                    table.ForeignKey(
                        name: "FK_ReportPersons_Persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportPersons_InvestigativeReports_ReportID",
                        column: x => x.ReportID,
                        principalTable: "InvestigativeReports",
                        principalColumn: "ReportID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportPersons_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonLocations",
                columns: table => new
                {
                    PersonLocationID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    LocTypeID = table.Column<int>(nullable: false),
                    LocationID = table.Column<int>(nullable: false),
                    PersonID = table.Column<int>(nullable: false),
                    RoleID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonLocations", x => x.PersonLocationID);
                    table.ForeignKey(
                        name: "FK_PersonLocations_Locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonLocations_Persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonLocations_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReportLocations",
                columns: table => new
                {
                    ReportLocationID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    InvestigativeReportReportID = table.Column<int>(nullable: true),
                    LocTypeID = table.Column<int>(nullable: false),
                    LocationID = table.Column<int>(nullable: false),
                    PersonID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportLocations", x => x.ReportLocationID);
                    table.ForeignKey(
                        name: "FK_ReportLocations_InvestigativeReports_InvestigativeReportReportID",
                        column: x => x.InvestigativeReportReportID,
                        principalTable: "InvestigativeReports",
                        principalColumn: "ReportID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReportLocations_LocTypes_LocTypeID",
                        column: x => x.LocTypeID,
                        principalTable: "LocTypes",
                        principalColumn: "LocTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportLocations_Locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportLocations_Persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvestigativeReports_CrimeID",
                table: "InvestigativeReports",
                column: "CrimeID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_LocTypeID",
                table: "Locations",
                column: "LocTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonLocations_LocationID",
                table: "PersonLocations",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonLocations_PersonID",
                table: "PersonLocations",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonLocations_RoleID",
                table: "PersonLocations",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_ReportLocations_InvestigativeReportReportID",
                table: "ReportLocations",
                column: "InvestigativeReportReportID");

            migrationBuilder.CreateIndex(
                name: "IX_ReportLocations_LocTypeID",
                table: "ReportLocations",
                column: "LocTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ReportLocations_LocationID",
                table: "ReportLocations",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_ReportLocations_PersonID",
                table: "ReportLocations",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_ReportOfficers_OfficerID",
                table: "ReportOfficers",
                column: "OfficerID");

            migrationBuilder.CreateIndex(
                name: "IX_ReportOfficers_ReportID",
                table: "ReportOfficers",
                column: "ReportID");

            migrationBuilder.CreateIndex(
                name: "IX_ReportPersons_PersonID",
                table: "ReportPersons",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_ReportPersons_ReportID",
                table: "ReportPersons",
                column: "ReportID");

            migrationBuilder.CreateIndex(
                name: "IX_ReportPersons_RoleID",
                table: "ReportPersons",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonLocations");

            migrationBuilder.DropTable(
                name: "ReportLocations");

            migrationBuilder.DropTable(
                name: "ReportOfficers");

            migrationBuilder.DropTable(
                name: "ReportPersons");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Officers");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "InvestigativeReports");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "LocTypes");

            migrationBuilder.DropTable(
                name: "Crimes");
        }
    }
}
