using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Data.Migrations
{
    public partial class ccc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LotCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    FileId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LotCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LotCategories_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 1024, nullable: true),
                    CategoryId = table.Column<int>(nullable: false, defaultValue: 1),
                    OwnerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lots_LotCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "LotCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Auctions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LotId = table.Column<int>(nullable: false),
                    OperationDate = table.Column<DateTime>(nullable: false),
                    BetValue = table.Column<decimal>(type: "money", nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    Deadline = table.Column<DateTime>(nullable: true),
                    InitialPrice = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auctions_Lots_LotId",
                        column: x => x.LotId,
                        principalTable: "Lots",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LotImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LotId = table.Column<int>(nullable: false),
                    FileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LotImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LotImages_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LotImages_Lots_LotId",
                        column: x => x.LotId,
                        principalTable: "Lots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "lotcategory1.png" },
                    { 2, "lotcategory2.png" },
                    { 3, "lotcategory3.png" },
                    { 11, "lot1.jpg" },
                    { 12, "lot2.jpg" },
                    { 13, "lot3.jpg" }
                });

            migrationBuilder.InsertData(
                table: "LotCategories",
                columns: new[] { "Id", "FileId", "Name" },
                values: new object[] { 1, 1, "Miscellaneous" });

            migrationBuilder.InsertData(
                table: "LotCategories",
                columns: new[] { "Id", "FileId", "Name" },
                values: new object[] { 2, 2, "Category 2" });

            migrationBuilder.InsertData(
                table: "LotCategories",
                columns: new[] { "Id", "FileId", "Name" },
                values: new object[] { 3, 3, "Category 3" });

            migrationBuilder.InsertData(
                table: "Lots",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "OwnerId" },
                values: new object[] { 1, 1, "Description", "lot 1", 1 });

            migrationBuilder.InsertData(
                table: "Lots",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "OwnerId" },
                values: new object[] { 2, 1, "Description", "lot 2", 1 });

            migrationBuilder.InsertData(
                table: "Lots",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "OwnerId" },
                values: new object[] { 3, 2, "Description", "lot 3", 2 });

            migrationBuilder.InsertData(
                table: "Auctions",
                columns: new[] { "Id", "BetValue", "CustomerId", "Deadline", "InitialPrice", "LotId", "OperationDate" },
                values: new object[] { 1, 11m, 1, new DateTime(2022, 10, 6, 13, 10, 47, 0, DateTimeKind.Local).AddTicks(9140), 11m, 1, new DateTime(2022, 6, 28, 13, 10, 47, 6, DateTimeKind.Local).AddTicks(139) });

            migrationBuilder.InsertData(
                table: "LotImages",
                columns: new[] { "Id", "FileId", "LotId" },
                values: new object[,]
                {
                    { 1, 11, 1 },
                    { 2, 12, 1 },
                    { 3, 13, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_LotId",
                table: "Auctions",
                column: "LotId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_Name",
                table: "Files",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_LotCategories_FileId",
                table: "LotCategories",
                column: "FileId",
                unique: true,
                filter: "[FileId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LotImages_FileId",
                table: "LotImages",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_LotImages_LotId_FileId",
                table: "LotImages",
                columns: new[] { "LotId", "FileId" });

            migrationBuilder.CreateIndex(
                name: "IX_Lots_CategoryId",
                table: "Lots",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auctions");

            migrationBuilder.DropTable(
                name: "LotImages");

            migrationBuilder.DropTable(
                name: "Lots");

            migrationBuilder.DropTable(
                name: "LotCategories");

            migrationBuilder.DropTable(
                name: "Files");
        }
    }
}
