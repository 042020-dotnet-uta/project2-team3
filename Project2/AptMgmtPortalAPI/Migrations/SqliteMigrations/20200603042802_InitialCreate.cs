﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AptMgmtPortalAPI.Migrations.SqliteMigrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agreements",
                columns: table => new
                {
                    AgreementId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agreements", x => x.AgreementId);
                });

            migrationBuilder.CreateTable(
                name: "BillingPeriods",
                columns: table => new
                {
                    BillingPeriodId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PeriodStart = table.Column<DateTime>(type: "NVARCHAR(48)", nullable: false),
                    PeriodEnd = table.Column<DateTime>(type: "NVARCHAR(48)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingPeriods", x => x.BillingPeriodId);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceRequests",
                columns: table => new
                {
                    MaintenanceRequestId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TimeOpened = table.Column<DateTime>(type: "NVARCHAR(48)", nullable: false),
                    TimeClosed = table.Column<DateTime>(type: "NVARCHAR(48)", nullable: true),
                    OpeningUserId = table.Column<int>(nullable: false),
                    ClosingUserId = table.Column<int>(nullable: true),
                    MaintenanceRequestType = table.Column<string>(nullable: true),
                    CloseReason = table.Column<string>(nullable: true),
                    OpenNotes = table.Column<string>(nullable: true),
                    ResolutionNotes = table.Column<string>(nullable: true),
                    InternalNotes = table.Column<string>(nullable: true),
                    UnitNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceRequests", x => x.MaintenanceRequestId);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Amount = table.Column<double>(nullable: false),
                    ResourceType = table.Column<int>(nullable: false),
                    TimePaid = table.Column<DateTime>(type: "NVARCHAR(48)", nullable: false),
                    BillingPeriodId = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "ResourceUsageRates",
                columns: table => new
                {
                    ResourceUsageRateId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ResourceType = table.Column<int>(nullable: false),
                    Rate = table.Column<double>(nullable: false),
                    PeriodStart = table.Column<DateTime>(type: "NVARCHAR(48)", nullable: false),
                    PeriodEnd = table.Column<DateTime>(type: "NVARCHAR(48)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceUsageRates", x => x.ResourceUsageRateId);
                });

            migrationBuilder.CreateTable(
                name: "SignedAgreements",
                columns: table => new
                {
                    SignedAgreementId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TenantId = table.Column<int>(nullable: false),
                    AgreementId = table.Column<int>(nullable: false),
                    SignedDate = table.Column<DateTime>(type: "NVARCHAR(48)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "NVARCHAR(48)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "NVARCHAR(48)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignedAgreements", x => x.SignedAgreementId);
                });

            migrationBuilder.CreateTable(
                name: "TenantResourceUsages",
                columns: table => new
                {
                    TenantResourceUsageId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SampleTime = table.Column<DateTime>(type: "NVARCHAR(48)", nullable: false),
                    UsageAmount = table.Column<double>(nullable: false),
                    ResourceType = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantResourceUsages", x => x.TenantResourceUsageId);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    TenantId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.TenantId);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    UnitId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UnitNumber = table.Column<string>(nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserAccountType = table.Column<string>(nullable: false),
                    LoginName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    ApiKey = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "Text", "Title" },
                values: new object[] { 1, "This is a really long lease agreement text", "Lease Agreement" });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "Text", "Title" },
                values: new object[] { 2, "This is a really long utility agreement text", "Utility Agreement" });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "Text", "Title" },
                values: new object[] { 3, "This is a really long internet connection agreement text", "Internet Connection Agreement" });

            migrationBuilder.InsertData(
                table: "BillingPeriods",
                columns: new[] { "BillingPeriodId", "PeriodEnd", "PeriodStart" },
                values: new object[] { 1, new DateTime(2020, 6, 3, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(9635), new DateTime(2020, 5, 3, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118) });

            migrationBuilder.InsertData(
                table: "BillingPeriods",
                columns: new[] { "BillingPeriodId", "PeriodEnd", "PeriodStart" },
                values: new object[] { 2, new DateTime(2020, 6, 3, 21, 28, 2, 219, DateTimeKind.Local).AddTicks(73), new DateTime(2020, 3, 4, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118) });

            migrationBuilder.InsertData(
                table: "BillingPeriods",
                columns: new[] { "BillingPeriodId", "PeriodEnd", "PeriodStart" },
                values: new object[] { 3, new DateTime(2020, 6, 3, 21, 28, 2, 219, DateTimeKind.Local).AddTicks(94), new DateTime(2019, 12, 5, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118) });

            migrationBuilder.InsertData(
                table: "BillingPeriods",
                columns: new[] { "BillingPeriodId", "PeriodEnd", "PeriodStart" },
                values: new object[] { 4, new DateTime(2020, 6, 3, 21, 28, 2, 219, DateTimeKind.Local).AddTicks(97), new DateTime(2019, 6, 8, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118) });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 10, null, null, "Call Plumber", null, "No water", 8, null, null, new DateTime(2020, 3, 4, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), "108" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 9, null, null, "Call Plumber", null, "No water", 7, null, null, new DateTime(2020, 3, 4, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), "107" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 8, null, null, "Call Plumber", null, "No water", 6, null, null, new DateTime(2020, 3, 4, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), "106" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 6, null, null, "Call Plumber", null, "No water", 4, null, null, new DateTime(2020, 3, 4, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), "104" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 7, null, null, "Call Plumber", null, "No water", 5, null, null, new DateTime(2020, 3, 4, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), "105" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 4, "CanceledByTenant", 1, "Call Plumber", null, "No water", 2, "Fixed", new DateTime(2020, 5, 3, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), new DateTime(2020, 3, 4, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), "102" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 3, "CanceledByManagement", 1, "Call Plumber", null, "No water", 1, "Fixed", new DateTime(2020, 5, 3, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), new DateTime(2019, 12, 5, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), "101" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 2, "Completed", 1, "Call Comcast", null, "No Interet", 1, "Fixed", new DateTime(2020, 5, 3, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), new DateTime(2020, 3, 4, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), "101" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 1, "Completed", 1, "Call Plumber", "Plumbing", "No water", 1, "Fully restored.", new DateTime(2020, 6, 2, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(6749), new DateTime(2020, 3, 4, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), "101" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 5, "CanceledByManagement", 2, "Call Plumber", null, "No water", 3, "Fixed", new DateTime(2020, 5, 3, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), new DateTime(2020, 3, 4, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), "103" });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 37, 100.11, 1, 0, 8, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2203) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 28, 100.11, 1, 4, 6, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2182) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 29, 100.11, 1, 3, 6, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2185) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 30, 100.11, 1, 1, 6, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2187) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 31, 100.11, 1, 2, 7, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2189) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 32, 100.11, 1, 0, 7, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2191) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 33, 100.11, 1, 4, 7, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2194) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 34, 100.11, 1, 3, 7, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2196) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 35, 100.11, 1, 1, 7, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2198) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 36, 100.11, 1, 2, 8, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2200) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 38, 100.11, 1, 4, 8, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2205) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 46, 100.11, 1, 2, 10, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2224) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 40, 100.11, 1, 1, 8, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2209) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 41, 100.11, 1, 2, 9, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2212) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 42, 100.11, 1, 0, 9, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2214) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 43, 100.11, 1, 4, 9, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2217) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 44, 100.11, 1, 3, 9, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2220) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 45, 100.11, 1, 1, 9, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2222) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 27, 100.11, 1, 0, 6, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2180) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 47, 100.11, 1, 0, 10, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2226) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 48, 100.11, 1, 4, 10, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2229) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 50, 100.11, 1, 1, 10, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2233) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 39, 100.11, 1, 3, 8, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2207) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 26, 100.11, 1, 2, 6, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2178) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 49, 100.11, 1, 3, 10, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2231) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 24, 100.11, 1, 3, 5, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2172) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 1, 100.11, 1, 2, 1, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(1637) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 25, 100.11, 1, 1, 5, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2174) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 2, 100.11, 1, 0, 1, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2099) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 3, 100.11, 1, 4, 1, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2120) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 4, 100.11, 1, 3, 1, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2124) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 5, 100.11, 1, 1, 1, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2126) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 6, 100.11, 1, 2, 2, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2129) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 8, 100.11, 1, 4, 2, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2135) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 9, 100.11, 1, 3, 2, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2137) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 10, 100.11, 1, 1, 2, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2140) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 11, 100.11, 1, 2, 3, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2142) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 7, 100.11, 1, 0, 2, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2131) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 13, 100.11, 1, 4, 3, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2147) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 23, 100.11, 1, 4, 5, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2170) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 12, 100.11, 1, 0, 3, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2144) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 21, 100.11, 1, 2, 5, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2165) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 20, 100.11, 1, 1, 4, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2163) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 19, 100.11, 1, 3, 4, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2160) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 22, 100.11, 1, 0, 5, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2167) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 17, 100.11, 1, 0, 4, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2156) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 16, 100.11, 1, 2, 4, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2153) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 15, 100.11, 1, 1, 3, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2151) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 14, 100.11, 1, 3, 3, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2149) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 18, 100.11, 1, 4, 4, new DateTime(2020, 6, 1, 21, 28, 2, 218, DateTimeKind.Local).AddTicks(2158) });

            migrationBuilder.InsertData(
                table: "ResourceUsageRates",
                columns: new[] { "ResourceUsageRateId", "PeriodEnd", "PeriodStart", "Rate", "ResourceType" },
                values: new object[] { 1, new DateTime(2020, 11, 29, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(7888), new DateTime(2019, 12, 5, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), 40.450000000000003, 2 });

            migrationBuilder.InsertData(
                table: "ResourceUsageRates",
                columns: new[] { "ResourceUsageRateId", "PeriodEnd", "PeriodStart", "Rate", "ResourceType" },
                values: new object[] { 2, new DateTime(2020, 11, 29, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(8705), new DateTime(2019, 12, 5, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), 3.4500000000000002, 0 });

            migrationBuilder.InsertData(
                table: "ResourceUsageRates",
                columns: new[] { "ResourceUsageRateId", "PeriodEnd", "PeriodStart", "Rate", "ResourceType" },
                values: new object[] { 3, new DateTime(2020, 11, 29, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(8730), new DateTime(2019, 12, 5, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), 1100.0, 4 });

            migrationBuilder.InsertData(
                table: "ResourceUsageRates",
                columns: new[] { "ResourceUsageRateId", "PeriodEnd", "PeriodStart", "Rate", "ResourceType" },
                values: new object[] { 4, new DateTime(2020, 11, 29, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(8734), new DateTime(2019, 12, 5, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), 20.550000000000001, 3 });

            migrationBuilder.InsertData(
                table: "ResourceUsageRates",
                columns: new[] { "ResourceUsageRateId", "PeriodEnd", "PeriodStart", "Rate", "ResourceType" },
                values: new object[] { 5, new DateTime(2020, 11, 29, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(8737), new DateTime(2019, 12, 5, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), 1.75, 1 });

            migrationBuilder.InsertData(
                table: "SignedAgreements",
                columns: new[] { "SignedAgreementId", "AgreementId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 7, 1, new DateTime(2020, 6, 2, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(5650), new DateTime(2020, 3, 4, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), new DateTime(2020, 3, 4, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), 7 });

            migrationBuilder.InsertData(
                table: "SignedAgreements",
                columns: new[] { "SignedAgreementId", "AgreementId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 10, 1, new DateTime(2020, 6, 2, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(5658), new DateTime(2020, 3, 4, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), new DateTime(2020, 3, 4, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), 10 });

            migrationBuilder.InsertData(
                table: "SignedAgreements",
                columns: new[] { "SignedAgreementId", "AgreementId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 9, 3, new DateTime(2020, 6, 2, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(5655), new DateTime(2019, 6, 8, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), new DateTime(2019, 6, 8, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), 9 });

            migrationBuilder.InsertData(
                table: "SignedAgreements",
                columns: new[] { "SignedAgreementId", "AgreementId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 8, 2, new DateTime(2020, 6, 2, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(5653), new DateTime(2019, 12, 5, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), new DateTime(2019, 12, 5, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), 8 });

            migrationBuilder.InsertData(
                table: "SignedAgreements",
                columns: new[] { "SignedAgreementId", "AgreementId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 6, 3, new DateTime(2020, 6, 2, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(5648), new DateTime(2019, 6, 8, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), new DateTime(2019, 6, 8, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), 6 });

            migrationBuilder.InsertData(
                table: "SignedAgreements",
                columns: new[] { "SignedAgreementId", "AgreementId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 2, 2, new DateTime(2020, 6, 2, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(5612), new DateTime(2019, 12, 5, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), new DateTime(2019, 12, 5, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), 2 });

            migrationBuilder.InsertData(
                table: "SignedAgreements",
                columns: new[] { "SignedAgreementId", "AgreementId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 4, 1, new DateTime(2020, 6, 2, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(5642), new DateTime(2020, 3, 4, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), new DateTime(2020, 3, 4, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), 4 });

            migrationBuilder.InsertData(
                table: "SignedAgreements",
                columns: new[] { "SignedAgreementId", "AgreementId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 3, 3, new DateTime(2020, 6, 2, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(5639), new DateTime(2019, 6, 8, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), new DateTime(2019, 6, 8, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), 3 });

            migrationBuilder.InsertData(
                table: "SignedAgreements",
                columns: new[] { "SignedAgreementId", "AgreementId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 1, 1, new DateTime(2020, 6, 2, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(4803), new DateTime(2020, 3, 4, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), new DateTime(2020, 3, 4, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), 1 });

            migrationBuilder.InsertData(
                table: "SignedAgreements",
                columns: new[] { "SignedAgreementId", "AgreementId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 5, 2, new DateTime(2020, 6, 2, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(5645), new DateTime(2019, 12, 5, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), new DateTime(2019, 12, 5, 21, 28, 2, 211, DateTimeKind.Local).AddTicks(1118), 5 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 17, 0, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1825), 4, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 18, 4, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1828), 4, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 19, 3, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1831), 4, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 20, 1, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1833), 4, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 21, 2, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1835), 5, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 22, 0, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1838), 5, 60.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 23, 4, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1840), 5, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 24, 3, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1842), 5, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 25, 1, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1844), 5, 40.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 26, 2, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1847), 6, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 27, 0, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1849), 6, 60.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 29, 3, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1853), 6, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 30, 1, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1856), 6, 31.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 31, 2, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1858), 7, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 32, 0, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1860), 7, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 33, 4, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1862), 7, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 38, 4, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1874), 8, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 34, 3, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1865), 7, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 35, 1, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1867), 7, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 36, 2, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1869), 8, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 37, 0, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1871), 8, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 16, 2, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1822), 4, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 28, 4, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1851), 6, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 15, 1, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1820), 3, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 46, 2, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1892), 10, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 13, 4, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1815), 3, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 39, 3, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1876), 8, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 50, 1, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1901), 10, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 49, 3, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1899), 10, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 48, 4, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1896), 10, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 47, 0, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1894), 10, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 45, 1, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1890), 9, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 44, 3, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1888), 9, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 43, 4, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1885), 9, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 42, 0, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1883), 9, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 41, 2, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1881), 9, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 14, 3, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1818), 3, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 1, 2, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1260), 1, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 3, 4, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1790), 1, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 4, 3, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1794), 1, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 5, 1, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1796), 1, 40.399999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 6, 2, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1799), 2, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 7, 0, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1801), 2, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 8, 4, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1804), 2, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 9, 3, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1806), 2, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 10, 1, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1808), 2, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 11, 2, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1811), 3, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 12, 0, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1813), 3, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 2, 0, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1769), 1, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 40, 1, new DateTime(2020, 6, 1, 21, 28, 2, 217, DateTimeKind.Local).AddTicks(1879), 8, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 1, "jayson@gmail.com", "Jayson", "Lennon", "555-164-317", 3 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 9, "linda@gmail.com", "Linda", "Lopez", "555-607-558", 11 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 8, "frances@gmail.com", "Frances ", "Hook", "555-871-503", 10 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 7, "ruth@gmail.com", "Ruth ", "Williams", "555-337-777", 9 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 6, "deon@gmail.com", "Deon ", "Smith", "555-514-298", 8 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 5, "melvin@gmail.com", "Melvin", "Johnson", "555-858-445", 7 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 4, "sulav@gmail.com", "Sulav", "Aryal", "555-787-595", 6 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 3, "michael@gmail.com", "Michael", "Walker", "555-115-412", 5 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 2, "david@gmail.com", "David", "Sawyer", "555-195-162", 4 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 10, "regina@gmail.com", "Regina", "McCoy", "555-504-625", 12 });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 10, 10, "110" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 9, 9, "109" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 8, 8, "108" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 6, 6, "106" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 7, 7, "107" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 4, 4, "104" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 3, 3, "103" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 2, 2, "102" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 1, 1, "101" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 5, 5, "105" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 11, "test-key11", "linda", "", "linda", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 10, "test-key10", "frances", "", "frances", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 9, "test-key9", "ruth", "", "ruth", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 8, "test-key8", "deon", "", "deon", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 7, "test-key7", "melvin", "", "melvin", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 4, "test-key4", "david", "", "david", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 5, "test-key5", "michael", "", "michael", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 3, "test-key3", "jayson", "", "jayson", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 2, "test-key2", "manager", "manager", "manager", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Manager" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 1, "test-key1", "admin", "admin", "admin", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 12, "test-key12", "regina", "", "regina", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 6, "test-key6", "sulav", "", "sulav", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 13, "test-key13", "sulav2", "", "sulav2", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.CreateIndex(
                name: "IX_Units_UnitNumber",
                table: "Units",
                column: "UnitNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agreements");

            migrationBuilder.DropTable(
                name: "BillingPeriods");

            migrationBuilder.DropTable(
                name: "MaintenanceRequests");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "ResourceUsageRates");

            migrationBuilder.DropTable(
                name: "SignedAgreements");

            migrationBuilder.DropTable(
                name: "TenantResourceUsages");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}