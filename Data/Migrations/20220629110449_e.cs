using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class e : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auctions_Lots_LotId",
                table: "Auctions");

            migrationBuilder.AddForeignKey(
                name: "FK_Auctions_Lots_LotId",
                table: "Auctions",
                column: "LotId",
                principalTable: "Lots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auctions_Lots_LotId",
                table: "Auctions");

            migrationBuilder.AddForeignKey(
                name: "FK_Auctions_Lots_LotId",
                table: "Auctions",
                column: "LotId",
                principalTable: "Lots",
                principalColumn: "Id");
        }
    }
}
