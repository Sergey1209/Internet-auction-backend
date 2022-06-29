using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class d4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 4,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "OwnerId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "OwnerId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "OwnerId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CategoryId", "OwnerId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CategoryId", "OwnerId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CategoryId", "OwnerId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CategoryId", "OwnerId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 12,
                column: "CategoryId",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 4,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "OwnerId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "OwnerId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "OwnerId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CategoryId", "OwnerId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CategoryId", "OwnerId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CategoryId", "OwnerId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CategoryId", "OwnerId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 12,
                column: "CategoryId",
                value: 1);
        }
    }
}
