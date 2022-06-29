using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class d2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Description 1");

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Description 2");

            migrationBuilder.InsertData(
                table: "Lots",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "OwnerId" },
                values: new object[,]
                {
                    { 3, 1, "Description 3", "lot 3", 1 },
                    { 4, 1, "Description 4", "lot 4", 1 },
                    { 5, 1, "Description 5", "lot 5", 1 },
                    { 6, 1, "Description 6", "lot 6", 1 },
                    { 7, 1, "Description 7", "lot 7", 1 },
                    { 8, 1, "Description 8", "lot 8", 1 },
                    { 9, 1, "Description 9", "lot 9", 1 },
                    { 10, 1, "Description 10", "lot 10", 1 },
                    { 11, 1, "Description 11", "lot 11", 1 },
                    { 12, 1, "Description 13", "lot 13", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.InsertData(
                table: "Auctions",
                columns: new[] { "Id", "BetValue", "CustomerId", "Deadline", "InitialPrice", "LotId", "OperationDate" },
                values: new object[,]
                {
                    { 1, 10m, 1, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10m, 1, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 10m, 1, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10m, 2, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Description");

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Description");
        }
    }
}
