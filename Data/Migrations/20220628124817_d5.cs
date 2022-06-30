using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Data.Migrations
{
    public partial class d5 : Migration
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

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.InsertData(
                table: "Auctions",
                columns: new[] { "Id", "BetValue", "CustomerId", "Deadline", "InitialPrice", "LotId", "OperationDate" },
                values: new object[,]
                {
                    { 101, 22m, 1, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 22m, 1, new DateTime(2021, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 102, 32m, 1, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 32m, 2, new DateTime(2021, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 103, 42m, 1, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 42m, 3, new DateTime(2021, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 104, 52m, 1, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 52m, 4, new DateTime(2021, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 105, 62m, 1, new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 62m, 5, new DateTime(2021, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 106, 72m, 1, new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 72m, 6, new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 107, 82m, 2, new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 82m, 7, new DateTime(2021, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 108, 92m, 2, new DateTime(2023, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 92m, 8, new DateTime(2021, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 109, 102m, 2, new DateTime(2023, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 102m, 9, new DateTime(2021, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 110, 112m, 2, new DateTime(2023, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 112m, 10, new DateTime(2021, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 111, 122m, 2, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 122m, 11, new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 112, 10m, 2, new DateTime(2020, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10m, 12, new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.InsertData(
                table: "Auctions",
                columns: new[] { "Id", "BetValue", "CustomerId", "Deadline", "InitialPrice", "LotId", "OperationDate" },
                values: new object[,]
                {
                    { 1, 22m, 1, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 22m, 1, new DateTime(2021, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 32m, 1, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 32m, 2, new DateTime(2021, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 42m, 1, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 42m, 3, new DateTime(2021, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 52m, 1, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 52m, 4, new DateTime(2021, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 62m, 1, new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 62m, 5, new DateTime(2021, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 72m, 1, new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 72m, 6, new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 82m, 2, new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 82m, 7, new DateTime(2021, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 92m, 2, new DateTime(2023, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 92m, 8, new DateTime(2021, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 102m, 2, new DateTime(2023, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 102m, 9, new DateTime(2021, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 112m, 2, new DateTime(2023, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 112m, 10, new DateTime(2021, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 122m, 2, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 122m, 11, new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 10m, 2, new DateTime(2020, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10m, 12, new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
