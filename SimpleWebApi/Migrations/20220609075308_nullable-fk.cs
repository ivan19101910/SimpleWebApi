using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleWebApi.Migrations
{
    public partial class nullablefk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Incidents_IncidentId",
                table: "Accounts");

            migrationBuilder.AlterColumn<string>(
                name: "IncidentId",
                table: "Accounts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Incidents_IncidentId",
                table: "Accounts",
                column: "IncidentId",
                principalTable: "Incidents",
                principalColumn: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Incidents_IncidentId",
                table: "Accounts");

            migrationBuilder.AlterColumn<string>(
                name: "IncidentId",
                table: "Accounts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Incidents_IncidentId",
                table: "Accounts",
                column: "IncidentId",
                principalTable: "Incidents",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
