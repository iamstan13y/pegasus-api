using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pegasus.API.Migrations
{
    public partial class CallTypeToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direction",
                table: "CallLogs");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "CallLogs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "CallLogs");

            migrationBuilder.AddColumn<int>(
                name: "Direction",
                table: "CallLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
