using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations.AuthDb
{
    public partial class a2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PeopleAuths",
                keyColumn: "PersonId",
                keyValue: 1,
                column: "Password",
                value: "1");

            migrationBuilder.UpdateData(
                table: "PeopleAuths",
                keyColumn: "PersonId",
                keyValue: 2,
                column: "Password",
                value: "1");

            migrationBuilder.UpdateData(
                table: "PeopleAuths",
                keyColumn: "PersonId",
                keyValue: 3,
                column: "Password",
                value: "1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PeopleAuths",
                keyColumn: "PersonId",
                keyValue: 1,
                column: "Password",
                value: "pass1");

            migrationBuilder.UpdateData(
                table: "PeopleAuths",
                keyColumn: "PersonId",
                keyValue: 2,
                column: "Password",
                value: "pass2");

            migrationBuilder.UpdateData(
                table: "PeopleAuths",
                keyColumn: "PersonId",
                keyValue: 3,
                column: "Password",
                value: "pass3");
        }
    }
}
