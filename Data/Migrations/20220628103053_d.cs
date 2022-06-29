using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class d : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BetValue", "Deadline", "InitialPrice", "OperationDate" },
                values: new object[] { 10m, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10m, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Auctions",
                columns: new[] { "Id", "BetValue", "CustomerId", "Deadline", "InitialPrice", "LotId", "OperationDate" },
                values: new object[] { 2, 10m, 1, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10m, 2, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BetValue", "Deadline", "InitialPrice", "OperationDate" },
                values: new object[] { 11m, new DateTime(2022, 10, 6, 13, 10, 47, 0, DateTimeKind.Local).AddTicks(9140), 11m, new DateTime(2022, 6, 28, 13, 10, 47, 6, DateTimeKind.Local).AddTicks(139) });

            migrationBuilder.InsertData(
                table: "Lots",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "OwnerId" },
                values: new object[] { 3, 2, "Description", "lot 3", 2 });
        }
    }
}
