using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using IncidentReport.Data;

namespace IncidentReport.Migrations
{
    [DbContext(typeof(IRcontext))]
    [Migration("20170626010800_UpdateLocations2")]
    partial class UpdateLocations2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("IncidentReport.Models.Crime", b =>
                {
                    b.Property<int>("CrimeID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BailAmount");

                    b.Property<string>("CrimeTitle");

                    b.Property<string>("Level");

                    b.Property<int>("Section");

                    b.Property<string>("Subsection");

                    b.Property<string>("Type");

                    b.HasKey("CrimeID");

                    b.ToTable("Crimes");
                });

            modelBuilder.Entity("IncidentReport.Models.InvestigativeReport", b =>
                {
                    b.Property<int>("ReportID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CrimeID");

                    b.Property<int>("IncidentNum");

                    b.Property<string>("MoBox");

                    b.Property<string>("Narrative");

                    b.Property<DateTime>("OccurranceDate");

                    b.Property<TimeSpan>("OccurranceTime");

                    b.Property<DateTime>("ReportDate");

                    b.Property<int>("ReportNum");

                    b.Property<TimeSpan>("ReportTime");

                    b.Property<int>("ReportingDistrict");

                    b.Property<string>("Title");

                    b.HasKey("ReportID");

                    b.HasIndex("CrimeID");

                    b.ToTable("InvestigativeReports");
                });

            modelBuilder.Entity("IncidentReport.Models.Location", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddressNum");

                    b.Property<string>("City");

                    b.Property<double>("Lattitude");

                    b.Property<int?>("LocTypeID");

                    b.Property<double>("Longitude");

                    b.Property<string>("State");

                    b.Property<string>("StreetName");

                    b.Property<string>("UnitNum");

                    b.Property<int>("ZipCode");

                    b.HasKey("LocationID");

                    b.HasIndex("LocTypeID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("IncidentReport.Models.LocType", b =>
                {
                    b.Property<int>("LocTypeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LocTypeName");

                    b.HasKey("LocTypeID");

                    b.ToTable("LocTypes");
                });

            modelBuilder.Entity("IncidentReport.Models.Officer", b =>
                {
                    b.Property<int>("OfficerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Assignment");

                    b.Property<string>("Division");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Serial");

                    b.HasKey("OfficerID");

                    b.ToTable("Officers");
                });

            modelBuilder.Entity("IncidentReport.Models.Person", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("DriversLicense");

                    b.Property<string>("EmailAddress");

                    b.Property<int>("EthnicityID");

                    b.Property<int>("EyeColorID");

                    b.Property<string>("FirstName");

                    b.Property<int>("GenderID");

                    b.Property<int>("HairID");

                    b.Property<int>("Height");

                    b.Property<string>("LastName");

                    b.Property<string>("Middle");

                    b.Property<int>("PhoneNumber");

                    b.Property<int>("Weight");

                    b.HasKey("PersonID");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("IncidentReport.Models.PersonLocation", b =>
                {
                    b.Property<int>("PersonLocationID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("LocTypeID");

                    b.Property<int>("LocationID");

                    b.Property<int>("PersonID");

                    b.Property<int?>("RoleID");

                    b.HasKey("PersonLocationID");

                    b.HasIndex("LocationID");

                    b.HasIndex("PersonID");

                    b.HasIndex("RoleID");

                    b.ToTable("PersonLocations");
                });

            modelBuilder.Entity("IncidentReport.Models.ReportLocation", b =>
                {
                    b.Property<int>("ReportLocationID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("InvestigativeReportReportID");

                    b.Property<int>("LocTypeID");

                    b.Property<int>("LocationID");

                    b.Property<int>("PersonID");

                    b.HasKey("ReportLocationID");

                    b.HasIndex("InvestigativeReportReportID");

                    b.HasIndex("LocTypeID");

                    b.HasIndex("LocationID");

                    b.HasIndex("PersonID");

                    b.ToTable("ReportLocations");
                });

            modelBuilder.Entity("IncidentReport.Models.ReportOfficer", b =>
                {
                    b.Property<int>("ReportOfficerID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("OfficerID");

                    b.Property<int>("ReportID");

                    b.HasKey("ReportOfficerID");

                    b.HasIndex("OfficerID");

                    b.HasIndex("ReportID");

                    b.ToTable("ReportOfficers");
                });

            modelBuilder.Entity("IncidentReport.Models.ReportPerson", b =>
                {
                    b.Property<int>("ReportPersonID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PersonID");

                    b.Property<int>("ReportID");

                    b.Property<int>("RoleID");

                    b.HasKey("ReportPersonID");

                    b.HasIndex("PersonID");

                    b.HasIndex("ReportID");

                    b.HasIndex("RoleID");

                    b.ToTable("ReportPersons");
                });

            modelBuilder.Entity("IncidentReport.Models.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RoleName");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("IncidentReport.Models.InvestigativeReport", b =>
                {
                    b.HasOne("IncidentReport.Models.Crime", "Crime")
                        .WithMany("Reports")
                        .HasForeignKey("CrimeID");
                });

            modelBuilder.Entity("IncidentReport.Models.Location", b =>
                {
                    b.HasOne("IncidentReport.Models.LocType")
                        .WithMany("Locations")
                        .HasForeignKey("LocTypeID");
                });

            modelBuilder.Entity("IncidentReport.Models.PersonLocation", b =>
                {
                    b.HasOne("IncidentReport.Models.Location", "Location")
                        .WithMany("PersonLocations")
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IncidentReport.Models.Person", "Person")
                        .WithMany("Locations")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IncidentReport.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID");
                });

            modelBuilder.Entity("IncidentReport.Models.ReportLocation", b =>
                {
                    b.HasOne("IncidentReport.Models.InvestigativeReport")
                        .WithMany("OccurranceLocation")
                        .HasForeignKey("InvestigativeReportReportID");

                    b.HasOne("IncidentReport.Models.LocType", "LocType")
                        .WithMany()
                        .HasForeignKey("LocTypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IncidentReport.Models.Location", "Location")
                        .WithMany("ReportLocations")
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IncidentReport.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IncidentReport.Models.ReportOfficer", b =>
                {
                    b.HasOne("IncidentReport.Models.Officer", "Officer")
                        .WithMany("ReportOfficer")
                        .HasForeignKey("OfficerID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IncidentReport.Models.InvestigativeReport", "Report")
                        .WithMany("ReportingEmployee")
                        .HasForeignKey("ReportID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IncidentReport.Models.ReportPerson", b =>
                {
                    b.HasOne("IncidentReport.Models.Person", "Person")
                        .WithMany("ReportPersons")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IncidentReport.Models.InvestigativeReport", "Report")
                        .WithMany("InvolvedPersons")
                        .HasForeignKey("ReportID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IncidentReport.Models.Role", "Role")
                        .WithMany("ReportPersons")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
