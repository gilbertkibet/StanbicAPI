using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StanbicAPI.Migrations
{
    public partial class Kcb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KcbBillNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TransactionReference = table.Column<string>(nullable: true),
                    RequestId = table.Column<string>(nullable: true),
                    ChannelCode = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true),
                    TransactionAmount = table.Column<string>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    CustomerReference = table.Column<string>(nullable: true),
                    CustomerName = table.Column<string>(nullable: true),
                    CustomerMobileNumber = table.Column<string>(nullable: true),
                    Balance = table.Column<string>(nullable: true),
                    Narration = table.Column<string>(nullable: true),
                    CreditAccountIdentifier = table.Column<string>(nullable: true),
                    OrganizationShortCode = table.Column<string>(nullable: true),
                    TillNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KcbBillNotifications", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KcbBillNotifications");
        }
    }
}
