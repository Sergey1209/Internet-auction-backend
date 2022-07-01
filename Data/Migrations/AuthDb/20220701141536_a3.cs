using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations.AuthDb
{
    public partial class a3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PeopleAuths",
                keyColumn: "PersonId",
                keyValue: 1,
                column: "Role",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PeopleAuths",
                keyColumn: "PersonId",
                keyValue: 1,
                column: "Role",
                value: 2);
        }
    }
}
