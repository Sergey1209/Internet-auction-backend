using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class aaa : Migration
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
                    InitialPrice = table.Column<decimal>(type: "money", nullable: true),
                    CategoryId = table.Column<int>(nullable: false, defaultValue: 1),
                    Deadline = table.Column<DateTime>(nullable: true),
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

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LotId = table.Column<int>(nullable: false),
                    OperationDate = table.Column<DateTime>(nullable: false),
                    Cost = table.Column<decimal>(type: "money", nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receipts_Lots_LotId",
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
                columns: new[] { "Id", "CategoryId", "Deadline", "Description", "InitialPrice", "Name", "OwnerId" },
                values: new object[] { 1, 1, new DateTime(2022, 10, 3, 18, 25, 48, 271, DateTimeKind.Local).AddTicks(3177), "Description", 12m, "lot 1", 1 });

            migrationBuilder.InsertData(
                table: "Lots",
                columns: new[] { "Id", "CategoryId", "Deadline", "Description", "InitialPrice", "Name", "OwnerId" },
                values: new object[] { 2, 1, new DateTime(2022, 10, 3, 18, 25, 48, 276, DateTimeKind.Local).AddTicks(4932), "Description", null, "lot 2", 1 });

            migrationBuilder.InsertData(
                table: "Lots",
                columns: new[] { "Id", "CategoryId", "Deadline", "Description", "InitialPrice", "Name", "OwnerId" },
                values: new object[] { 3, 2, new DateTime(2022, 10, 3, 18, 25, 48, 276, DateTimeKind.Local).AddTicks(5065), "Description", 11111m, "lot 3", 2 });

            migrationBuilder.InsertData(
                table: "LotImages",
                columns: new[] { "Id", "FileId", "LotId" },
                values: new object[] { 1, 11, 1 });

            migrationBuilder.InsertData(
                table: "LotImages",
                columns: new[] { "Id", "FileId", "LotId" },
                values: new object[] { 2, 12, 1 });

            migrationBuilder.InsertData(
                table: "LotImages",
                columns: new[] { "Id", "FileId", "LotId" },
                values: new object[] { 3, 13, 2 });

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

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_LotId",
                table: "Receipts",
                column: "LotId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LotImages");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "Lots");

            migrationBuilder.DropTable(
                name: "LotCategories");

            migrationBuilder.DropTable(
                name: "Files");
        }
    }
}
