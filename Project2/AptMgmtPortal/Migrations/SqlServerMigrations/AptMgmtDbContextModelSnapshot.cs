﻿// <auto-generated />
using System;
using AptMgmtPortal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AptMgmtPortal.Migrations.SqlServerMigrations
{
    [DbContext(typeof(AptMgmtDbContext))]
    partial class AptMgmtDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AptMgmtPortal.Entity.BillingPeriod", b =>
                {
                    b.Property<int>("BillingPeriodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PeriodEnd")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(48)");

                    b.Property<string>("PeriodStart")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(48)");

                    b.HasKey("BillingPeriodId");

                    b.ToTable("BillingPeriods");
                });

            modelBuilder.Entity("AptMgmtPortal.Entity.MaintenanceRequest", b =>
                {
                    b.Property<int>("MaintenanceRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CloseReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ClosingUserId")
                        .HasColumnType("int");

                    b.Property<string>("InternalNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaintenanceRequestType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpenNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OpeningUserId")
                        .HasColumnType("int");

                    b.Property<string>("ResolutionNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TimeClosed")
                        .HasColumnType("NVARCHAR(48)");

                    b.Property<string>("TimeOpened")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(48)");

                    b.Property<string>("UnitNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaintenanceRequestId");

                    b.ToTable("MaintenanceRequests");
                });

            modelBuilder.Entity("AptMgmtPortal.Entity.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("BillingPeriodId")
                        .HasColumnType("int");

                    b.Property<int>("ResourceType")
                        .HasColumnType("int");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.Property<string>("TimePaid")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(48)");

                    b.HasKey("PaymentId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("AptMgmtPortal.Entity.ResourceUsageRate", b =>
                {
                    b.Property<int>("ResourceUsageRateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PeriodEnd")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(48)");

                    b.Property<string>("PeriodStart")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(48)");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<int>("ResourceType")
                        .HasColumnType("int");

                    b.HasKey("ResourceUsageRateId");

                    b.ToTable("ResourceUsageRates");
                });

            modelBuilder.Entity("AptMgmtPortal.Entity.Tenant", b =>
                {
                    b.Property<int>("TenantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TenantId");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("AptMgmtPortal.Entity.TenantResourceUsage", b =>
                {
                    b.Property<int>("TenantResourceUsageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ResourceType")
                        .HasColumnType("int");

                    b.Property<string>("SampleTime")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(48)");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.Property<double>("UsageAmount")
                        .HasColumnType("float");

                    b.HasKey("TenantResourceUsageId");

                    b.ToTable("TenantResourceUsages");
                });

            modelBuilder.Entity("AptMgmtPortal.Entity.Unit", b =>
                {
                    b.Property<int>("UnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("TenantId")
                        .HasColumnType("int");

                    b.Property<string>("UnitNumber")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UnitId");

                    b.HasIndex("UnitNumber")
                        .IsUnique()
                        .HasFilter("[UnitNumber] IS NOT NULL");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("AptMgmtPortal.Entity.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApiKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LoginName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserAccountType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
