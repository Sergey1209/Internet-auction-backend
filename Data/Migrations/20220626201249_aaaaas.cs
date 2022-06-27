using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Data.Migrations
{
    public partial class aaaaas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Lots_LotId",
                table: "Receipts");

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 1,
                column: "Deadline",
                value: new DateTime(2022, 10, 4, 23, 12, 49, 172, DateTimeKind.Local).AddTicks(7262));

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 2,
                column: "Deadline",
                value: new DateTime(2022, 10, 4, 23, 12, 49, 177, DateTimeKind.Local).AddTicks(811));

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 3,
                column: "Deadline",
                value: new DateTime(2022, 10, 4, 23, 12, 49, 177, DateTimeKind.Local).AddTicks(906));

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Lots_LotId",
                table: "Receipts",
                column: "LotId",
                principalTable: "Lots",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Lots_LotId",
                table: "Receipts");

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 1,
                column: "Deadline",
                value: new DateTime(2022, 10, 3, 18, 25, 48, 271, DateTimeKind.Local).AddTicks(3177));

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 2,
                column: "Deadline",
                value: new DateTime(2022, 10, 3, 18, 25, 48, 276, DateTimeKind.Local).AddTicks(4932));

            migrationBuilder.UpdateData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: 3,
                column: "Deadline",
                value: new DateTime(2022, 10, 3, 18, 25, 48, 276, DateTimeKind.Local).AddTicks(5065));

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Lots_LotId",
                table: "Receipts",
                column: "LotId",
                principalTable: "Lots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
