using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pegasus.API.Migrations
{
    public partial class CascadeToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CallLogs_Contacts_ContactId",
                table: "CallLogs");

            migrationBuilder.AddForeignKey(
                name: "FK_CallLogs_Contacts_ContactId",
                table: "CallLogs",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CallLogs_Contacts_ContactId",
                table: "CallLogs");

            migrationBuilder.AddForeignKey(
                name: "FK_CallLogs_Contacts_ContactId",
                table: "CallLogs",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id");
        }
    }
}
