using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pegasus.API.Migrations
{
    public partial class ContactsToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactName",
                table: "CallLogs");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "CallLogs");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "CallLogs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "CallLogs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactPhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactPhoneNumbers_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CallLogs_ContactId",
                table: "CallLogs",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPhoneNumbers_ContactId",
                table: "ContactPhoneNumbers",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_CallLogs_Contacts_ContactId",
                table: "CallLogs",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CallLogs_Contacts_ContactId",
                table: "CallLogs");

            migrationBuilder.DropTable(
                name: "ContactPhoneNumbers");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_CallLogs_ContactId",
                table: "CallLogs");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "CallLogs");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "CallLogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ContactName",
                table: "CallLogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "CallLogs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
