using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StanbicAPI.Migrations
{
    public partial class Stanbic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankNotifications");

            migrationBuilder.CreateTable(
                name: "StanbicBankNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BusinessAccountNo = table.Column<string>(nullable: true),
                    InvoiceNumber = table.Column<string>(nullable: true),
                    AvailableAccountBalance = table.Column<string>(nullable: true),
                    ValidateEndPoint = table.Column<string>(nullable: true),
                    BusinessShortCode = table.Column<string>(nullable: true),
                    PaymentDetails = table.Column<string>(nullable: true),
                    TransId = table.Column<string>(nullable: true),
                    ThirdPartyTransId = table.Column<string>(nullable: true),
                    CallbackUrl = table.Column<string>(nullable: true),
                    TransactionType = table.Column<string>(nullable: true),
                    Msisdn = table.Column<string>(nullable: true),
                    OrgAccountBalance = table.Column<string>(nullable: true),
                    TransAmount = table.Column<string>(nullable: true),
                    TransTime = table.Column<string>(nullable: true),
                    ApiKey = table.Column<string>(nullable: true),
                    BillRefNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StanbicBankNotifications", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StanbicBankNotifications");

            migrationBuilder.CreateTable(
                name: "BankNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApiKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailableAccountBalance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillRefNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessAccountNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessShortCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CallbackUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Msisdn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrgAccountBalance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThirdPartyTransId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransAmount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidateEndPoint = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankNotifications", x => x.Id);
                });
        }
    }
}
