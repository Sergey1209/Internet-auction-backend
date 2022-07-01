using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _1 : Migration
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
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
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
                    InitialPrice = table.Column<decimal>(type: "money", nullable: true),
                    InitialDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auctions_Lots_LotId",
                        column: x => x.LotId,
                        principalTable: "Lots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                values: new object[,]
                {
                    { 1, 2, "Description 1", "lot 1", 2 },
                    { 73, 2, "Description 73", "lot 73", 2 },
                    { 72, 2, "Description 72", "lot 72", 2 },
                    { 71, 2, "Description 71", "lot 71", 2 },
                    { 70, 2, "Description 70", "lot 70", 3 },
                    { 69, 2, "Description 69", "lot 69", 2 },
                    { 68, 2, "Description 68", "lot 68", 2 },
                    { 67, 2, "Description 67", "lot 67", 2 },
                    { 66, 2, "Description 66", "lot 66", 2 },
                    { 65, 2, "Description 65", "lot 65", 3 },
                    { 64, 2, "Description 64", "lot 64", 2 },
                    { 63, 2, "Description 63", "lot 63", 2 },
                    { 62, 2, "Description 62", "lot 62", 2 },
                    { 61, 2, "Description 61", "lot 61", 2 },
                    { 60, 2, "Description 60", "lot 60", 3 },
                    { 59, 2, "Description 59", "lot 59", 2 },
                    { 58, 2, "Description 58", "lot 58", 2 },
                    { 57, 2, "Description 57", "lot 57", 2 },
                    { 56, 2, "Description 56", "lot 56", 2 },
                    { 55, 2, "Description 55", "lot 55", 3 },
                    { 54, 2, "Description 54", "lot 54", 2 },
                    { 53, 2, "Description 53", "lot 53", 2 },
                    { 74, 2, "Description 74", "lot 74", 2 },
                    { 52, 2, "Description 52", "lot 52", 2 },
                    { 75, 2, "Description 75", "lot 75", 3 },
                    { 77, 2, "Description 77", "lot 77", 2 },
                    { 98, 2, "Description 98", "lot 98", 2 },
                    { 97, 2, "Description 97", "lot 97", 2 },
                    { 96, 2, "Description 96", "lot 96", 2 },
                    { 95, 2, "Description 95", "lot 95", 3 },
                    { 94, 2, "Description 94", "lot 94", 2 },
                    { 93, 2, "Description 93", "lot 93", 2 },
                    { 92, 2, "Description 92", "lot 92", 2 },
                    { 91, 2, "Description 91", "lot 91", 2 },
                    { 90, 2, "Description 90", "lot 90", 3 },
                    { 89, 2, "Description 89", "lot 89", 2 },
                    { 88, 2, "Description 88", "lot 88", 2 },
                    { 87, 2, "Description 87", "lot 87", 2 },
                    { 86, 2, "Description 86", "lot 86", 2 },
                    { 85, 2, "Description 85", "lot 85", 3 },
                    { 84, 2, "Description 84", "lot 84", 2 },
                    { 83, 2, "Description 83", "lot 83", 2 },
                    { 82, 2, "Description 82", "lot 82", 2 },
                    { 81, 2, "Description 81", "lot 81", 2 },
                    { 80, 2, "Description 80", "lot 80", 3 },
                    { 79, 2, "Description 79", "lot 79", 2 },
                    { 78, 2, "Description 78", "lot 78", 2 },
                    { 76, 2, "Description 76", "lot 76", 2 },
                    { 51, 2, "Description 51", "lot 51", 2 },
                    { 50, 2, "Description 50", "lot 50", 3 },
                    { 49, 2, "Description 49", "lot 49", 2 },
                    { 22, 2, "Description 22", "lot 22", 2 },
                    { 21, 2, "Description 21", "lot 21", 2 },
                    { 20, 2, "Description 20", "lot 20", 3 },
                    { 19, 2, "Description 19", "lot 19", 2 },
                    { 18, 2, "Description 18", "lot 18", 2 },
                    { 17, 2, "Description 17", "lot 17", 2 },
                    { 16, 2, "Description 16", "lot 16", 2 },
                    { 15, 2, "Description 15", "lot 15", 3 },
                    { 14, 2, "Description 14", "lot 14", 2 },
                    { 13, 2, "Description 13", "lot 13", 2 },
                    { 12, 2, "Description 12", "lot 12", 2 },
                    { 11, 2, "Description 11", "lot 11", 2 },
                    { 10, 2, "Description 10", "lot 10", 3 },
                    { 9, 2, "Description 9", "lot 9", 2 },
                    { 8, 2, "Description 8", "lot 8", 2 },
                    { 7, 2, "Description 7", "lot 7", 2 },
                    { 6, 2, "Description 6", "lot 6", 2 },
                    { 5, 2, "Description 5", "lot 5", 3 },
                    { 4, 2, "Description 4", "lot 4", 2 },
                    { 3, 2, "Description 3", "lot 3", 2 },
                    { 2, 2, "Description 2", "lot 2", 2 },
                    { 23, 2, "Description 23", "lot 23", 2 },
                    { 24, 2, "Description 24", "lot 24", 2 },
                    { 25, 2, "Description 25", "lot 25", 3 },
                    { 26, 2, "Description 26", "lot 26", 2 },
                    { 48, 2, "Description 48", "lot 48", 2 },
                    { 47, 2, "Description 47", "lot 47", 2 },
                    { 46, 2, "Description 46", "lot 46", 2 },
                    { 45, 2, "Description 45", "lot 45", 3 },
                    { 44, 2, "Description 44", "lot 44", 2 },
                    { 43, 2, "Description 43", "lot 43", 2 },
                    { 42, 2, "Description 42", "lot 42", 2 },
                    { 41, 2, "Description 41", "lot 41", 2 },
                    { 40, 2, "Description 40", "lot 40", 3 },
                    { 39, 2, "Description 39", "lot 39", 2 },
                    { 99, 2, "Description 99", "lot 99", 2 },
                    { 38, 2, "Description 38", "lot 38", 2 },
                    { 36, 2, "Description 36", "lot 36", 2 },
                    { 35, 2, "Description 35", "lot 35", 3 },
                    { 34, 2, "Description 34", "lot 34", 2 },
                    { 33, 2, "Description 33", "lot 33", 2 },
                    { 32, 2, "Description 32", "lot 32", 2 },
                    { 31, 2, "Description 31", "lot 31", 2 },
                    { 30, 2, "Description 30", "lot 30", 3 },
                    { 29, 2, "Description 29", "lot 29", 2 },
                    { 28, 2, "Description 28", "lot 28", 2 },
                    { 27, 2, "Description 27", "lot 27", 2 },
                    { 37, 2, "Description 37", "lot 37", 2 },
                    { 1000, 2, "Description 1000", "lot 1000", 1 }
                });

            migrationBuilder.InsertData(
                table: "Auctions",
                columns: new[] { "Id", "BetValue", "CustomerId", "Deadline", "InitialDate", "InitialPrice", "LotId", "OperationDate" },
                values: new object[,]
                {
                    { 201, 22m, 1, new DateTime(2022, 7, 2, 15, 22, 6, 359, DateTimeKind.Local).AddTicks(9926), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 22m, 1, new DateTime(2022, 7, 2, 15, 22, 6, 359, DateTimeKind.Local).AddTicks(9926) },
                    { 272, 732m, 2, new DateTime(2022, 9, 11, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7327), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 732m, 72, new DateTime(2022, 9, 11, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7327) },
                    { 271, 722m, 2, new DateTime(2022, 9, 10, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7323), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 722m, 71, new DateTime(2022, 9, 10, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7323) },
                    { 270, 712m, 2, new DateTime(2022, 9, 9, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7319), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 712m, 70, new DateTime(2022, 9, 9, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7319) },
                    { 269, 702m, 2, new DateTime(2022, 9, 8, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7314), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 702m, 69, new DateTime(2022, 9, 8, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7314) },
                    { 268, 692m, 2, new DateTime(2022, 9, 7, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7310), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 692m, 68, new DateTime(2022, 9, 7, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7310) },
                    { 267, 682m, 2, new DateTime(2022, 9, 6, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7306), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 682m, 67, new DateTime(2022, 9, 6, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7306) },
                    { 266, 672m, 2, new DateTime(2022, 9, 5, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7302), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 672m, 66, new DateTime(2022, 9, 5, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7302) },
                    { 265, 662m, 2, new DateTime(2022, 9, 4, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7295), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 662m, 65, new DateTime(2022, 9, 4, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7295) },
                    { 264, 652m, 2, new DateTime(2022, 9, 3, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7291), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 652m, 64, new DateTime(2022, 9, 3, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7291) },
                    { 263, 642m, 2, new DateTime(2022, 9, 2, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7287), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 642m, 63, new DateTime(2022, 9, 2, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7287) },
                    { 273, 742m, 2, new DateTime(2022, 9, 12, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7331), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 742m, 73, new DateTime(2022, 9, 12, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7331) },
                    { 262, 632m, 2, new DateTime(2022, 9, 1, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7282), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 632m, 62, new DateTime(2022, 9, 1, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7282) },
                    { 260, 612m, 2, new DateTime(2022, 8, 30, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7274), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 612m, 60, new DateTime(2022, 8, 30, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7274) },
                    { 259, 602m, 2, new DateTime(2022, 8, 29, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7270), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 602m, 59, new DateTime(2022, 8, 29, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7270) },
                    { 258, 592m, 2, new DateTime(2022, 8, 28, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7266), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 592m, 58, new DateTime(2022, 8, 28, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7266) },
                    { 257, 582m, 2, new DateTime(2022, 8, 27, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7262), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 582m, 57, new DateTime(2022, 8, 27, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7262) },
                    { 256, 572m, 2, new DateTime(2022, 8, 26, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7258), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 572m, 56, new DateTime(2022, 8, 26, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7258) },
                    { 255, 562m, 2, new DateTime(2022, 8, 25, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7254), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 562m, 55, new DateTime(2022, 8, 25, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7254) },
                    { 254, 552m, 2, new DateTime(2022, 8, 24, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7250), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 552m, 54, new DateTime(2022, 8, 24, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7250) },
                    { 253, 542m, 2, new DateTime(2022, 8, 23, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7246), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 542m, 53, new DateTime(2022, 8, 23, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7246) },
                    { 252, 532m, 2, new DateTime(2022, 8, 22, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7242), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 532m, 52, new DateTime(2022, 8, 22, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7242) },
                    { 251, 522m, 2, new DateTime(2022, 8, 21, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7238), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 522m, 51, new DateTime(2022, 8, 21, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7238) },
                    { 261, 622m, 2, new DateTime(2022, 8, 31, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7278), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 622m, 61, new DateTime(2022, 8, 31, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7278) },
                    { 250, 512m, 2, new DateTime(2022, 8, 20, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7234), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 512m, 50, new DateTime(2022, 8, 20, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7234) },
                    { 274, 752m, 2, new DateTime(2022, 9, 13, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7335), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 752m, 74, new DateTime(2022, 9, 13, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7335) },
                    { 276, 772m, 2, new DateTime(2022, 9, 15, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7344), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 772m, 76, new DateTime(2022, 9, 15, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7344) },
                    { 298, 992m, 2, new DateTime(2022, 10, 7, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7433), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 992m, 98, new DateTime(2022, 10, 7, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7433) },
                    { 297, 982m, 2, new DateTime(2022, 10, 6, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7429), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 982m, 97, new DateTime(2022, 10, 6, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7429) },
                    { 296, 972m, 2, new DateTime(2022, 10, 5, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7425), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 972m, 96, new DateTime(2022, 10, 5, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7425) },
                    { 295, 962m, 2, new DateTime(2022, 10, 4, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7421), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 962m, 95, new DateTime(2022, 10, 4, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7421) },
                    { 294, 952m, 2, new DateTime(2022, 10, 3, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7417), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 952m, 94, new DateTime(2022, 10, 3, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7417) },
                    { 293, 942m, 2, new DateTime(2022, 10, 2, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7413), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 942m, 93, new DateTime(2022, 10, 2, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7413) },
                    { 292, 932m, 2, new DateTime(2022, 10, 1, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7409), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 932m, 92, new DateTime(2022, 10, 1, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7409) },
                    { 291, 922m, 2, new DateTime(2022, 9, 30, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7405), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 922m, 91, new DateTime(2022, 9, 30, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7405) },
                    { 290, 912m, 2, new DateTime(2022, 9, 29, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7401), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 912m, 90, new DateTime(2022, 9, 29, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7401) },
                    { 289, 902m, 2, new DateTime(2022, 9, 28, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7397), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 902m, 89, new DateTime(2022, 9, 28, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7397) },
                    { 275, 762m, 2, new DateTime(2022, 9, 14, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7340), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 762m, 75, new DateTime(2022, 9, 14, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7340) },
                    { 288, 892m, 2, new DateTime(2022, 9, 27, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7393), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 892m, 88, new DateTime(2022, 9, 27, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7393) },
                    { 286, 872m, 2, new DateTime(2022, 9, 25, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7385), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 872m, 86, new DateTime(2022, 9, 25, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7385) },
                    { 285, 862m, 2, new DateTime(2022, 9, 24, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7380), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 862m, 85, new DateTime(2022, 9, 24, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7380) },
                    { 284, 852m, 2, new DateTime(2022, 9, 23, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7376), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 852m, 84, new DateTime(2022, 9, 23, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7376) },
                    { 283, 842m, 2, new DateTime(2022, 9, 22, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7372), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 842m, 83, new DateTime(2022, 9, 22, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7372) },
                    { 282, 832m, 2, new DateTime(2022, 9, 21, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7368), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 832m, 82, new DateTime(2022, 9, 21, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7368) },
                    { 281, 822m, 2, new DateTime(2022, 9, 20, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7364), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 822m, 81, new DateTime(2022, 9, 20, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7364) },
                    { 280, 812m, 2, new DateTime(2022, 9, 19, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7360), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 812m, 80, new DateTime(2022, 9, 19, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7360) },
                    { 279, 802m, 2, new DateTime(2022, 9, 18, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7356), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 802m, 79, new DateTime(2022, 9, 18, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7356) },
                    { 278, 792m, 2, new DateTime(2022, 9, 17, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7352), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 792m, 78, new DateTime(2022, 9, 17, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7352) },
                    { 277, 782m, 2, new DateTime(2022, 9, 16, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7348), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 782m, 77, new DateTime(2022, 9, 16, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7348) },
                    { 287, 882m, 2, new DateTime(2022, 9, 26, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7389), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 882m, 87, new DateTime(2022, 9, 26, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7389) },
                    { 299, 1002m, 2, new DateTime(2022, 10, 8, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7437), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1002m, 99, new DateTime(2022, 10, 8, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7437) },
                    { 249, 502m, 2, new DateTime(2022, 8, 19, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7230), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 502m, 49, new DateTime(2022, 8, 19, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7230) },
                    { 247, 482m, 2, new DateTime(2022, 8, 17, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7222), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 482m, 47, new DateTime(2022, 8, 17, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7222) },
                    { 221, 222m, 2, new DateTime(2022, 7, 22, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6986), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 222m, 21, new DateTime(2022, 7, 22, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6986) },
                    { 220, 212m, 2, new DateTime(2022, 7, 21, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6982), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 212m, 20, new DateTime(2022, 7, 21, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6982) },
                    { 219, 202m, 2, new DateTime(2022, 7, 20, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6978), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 202m, 19, new DateTime(2022, 7, 20, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6978) },
                    { 218, 192m, 2, new DateTime(2022, 7, 19, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6973), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 192m, 18, new DateTime(2022, 7, 19, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6973) },
                    { 217, 182m, 2, new DateTime(2022, 7, 18, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6967), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 182m, 17, new DateTime(2022, 7, 18, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6967) },
                    { 216, 172m, 2, new DateTime(2022, 7, 17, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6963), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 172m, 16, new DateTime(2022, 7, 17, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6963) },
                    { 215, 162m, 2, new DateTime(2022, 7, 16, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6959), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 162m, 15, new DateTime(2022, 7, 16, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6959) },
                    { 214, 152m, 2, new DateTime(2022, 7, 15, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6955), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 152m, 14, new DateTime(2022, 7, 15, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6955) },
                    { 213, 142m, 2, new DateTime(2022, 7, 14, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6951), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 142m, 13, new DateTime(2022, 7, 14, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6951) },
                    { 248, 492m, 2, new DateTime(2022, 8, 18, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7226), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 492m, 48, new DateTime(2022, 8, 18, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7226) },
                    { 212, 132m, 2, new DateTime(2022, 7, 13, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6946), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 132m, 12, new DateTime(2022, 7, 13, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6946) },
                    { 210, 112m, 2, new DateTime(2022, 7, 11, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6936), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 112m, 10, new DateTime(2022, 7, 11, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6936) },
                    { 209, 102m, 2, new DateTime(2022, 7, 10, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6930), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 102m, 9, new DateTime(2022, 7, 10, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6930) },
                    { 208, 92m, 2, new DateTime(2022, 7, 9, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6926), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 92m, 8, new DateTime(2022, 7, 9, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6926) },
                    { 207, 82m, 2, new DateTime(2022, 7, 8, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6921), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 82m, 7, new DateTime(2022, 7, 8, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6921) },
                    { 206, 72m, 1, new DateTime(2022, 7, 7, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6916), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 72m, 6, new DateTime(2022, 7, 7, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6916) },
                    { 205, 62m, 1, new DateTime(2022, 7, 6, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6904), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 62m, 5, new DateTime(2022, 7, 6, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6904) },
                    { 204, 52m, 1, new DateTime(2022, 7, 5, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6899), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 52m, 4, new DateTime(2022, 7, 5, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6899) },
                    { 203, 42m, 1, new DateTime(2022, 7, 4, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6888), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 42m, 3, new DateTime(2022, 7, 4, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6888) },
                    { 202, 32m, 1, new DateTime(2022, 7, 3, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6727), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 32m, 2, new DateTime(2022, 7, 3, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6727) },
                    { 211, 122m, 2, new DateTime(2022, 7, 12, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6942), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 122m, 11, new DateTime(2022, 7, 12, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6942) },
                    { 223, 242m, 2, new DateTime(2022, 7, 24, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6995), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 242m, 23, new DateTime(2022, 7, 24, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6995) },
                    { 222, 232m, 2, new DateTime(2022, 7, 23, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6991), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 232m, 22, new DateTime(2022, 7, 23, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6991) },
                    { 225, 262m, 2, new DateTime(2022, 7, 26, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7003), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 262m, 25, new DateTime(2022, 7, 26, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7003) },
                    { 246, 472m, 2, new DateTime(2022, 8, 16, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7218), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 472m, 46, new DateTime(2022, 8, 16, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7218) },
                    { 245, 462m, 2, new DateTime(2022, 8, 15, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7214), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 462m, 45, new DateTime(2022, 8, 15, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7214) },
                    { 244, 452m, 2, new DateTime(2022, 8, 14, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7210), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 452m, 44, new DateTime(2022, 8, 14, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7210) },
                    { 243, 442m, 2, new DateTime(2022, 8, 13, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7206), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 442m, 43, new DateTime(2022, 8, 13, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7206) },
                    { 242, 432m, 2, new DateTime(2022, 8, 12, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7202), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 432m, 42, new DateTime(2022, 8, 12, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7202) },
                    { 241, 422m, 2, new DateTime(2022, 8, 11, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7198), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 422m, 41, new DateTime(2022, 8, 11, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7198) },
                    { 240, 412m, 2, new DateTime(2022, 8, 10, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7194), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 412m, 40, new DateTime(2022, 8, 10, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7194) },
                    { 239, 402m, 2, new DateTime(2022, 8, 9, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7182), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 402m, 39, new DateTime(2022, 8, 9, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7182) },
                    { 224, 252m, 2, new DateTime(2022, 7, 25, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6999), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 252m, 24, new DateTime(2022, 7, 25, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(6999) },
                    { 237, 382m, 2, new DateTime(2022, 8, 7, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7055), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 382m, 37, new DateTime(2022, 8, 7, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7055) },
                    { 238, 392m, 2, new DateTime(2022, 8, 8, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7059), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 392m, 38, new DateTime(2022, 8, 8, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7059) },
                    { 235, 362m, 2, new DateTime(2022, 8, 5, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7046), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 362m, 35, new DateTime(2022, 8, 5, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7046) },
                    { 234, 352m, 2, new DateTime(2022, 8, 4, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7042), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 352m, 34, new DateTime(2022, 8, 4, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7042) },
                    { 233, 342m, 2, new DateTime(2022, 8, 3, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7036), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 342m, 33, new DateTime(2022, 8, 3, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7036) },
                    { 232, 332m, 2, new DateTime(2022, 8, 2, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7032), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 332m, 32, new DateTime(2022, 8, 2, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7032) },
                    { 231, 322m, 2, new DateTime(2022, 8, 1, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7028), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 322m, 31, new DateTime(2022, 8, 1, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7028) },
                    { 230, 312m, 2, new DateTime(2022, 7, 31, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7024), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 312m, 30, new DateTime(2022, 7, 31, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7024) },
                    { 229, 302m, 2, new DateTime(2022, 7, 30, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7020), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 302m, 29, new DateTime(2022, 7, 30, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7020) },
                    { 228, 292m, 2, new DateTime(2022, 7, 29, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7016), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 292m, 28, new DateTime(2022, 7, 29, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7016) },
                    { 227, 282m, 2, new DateTime(2022, 7, 28, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7011), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 282m, 27, new DateTime(2022, 7, 28, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7011) },
                    { 226, 272m, 2, new DateTime(2022, 7, 27, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7007), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 272m, 26, new DateTime(2022, 7, 27, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7007) },
                    { 236, 372m, 2, new DateTime(2022, 8, 6, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7050), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 372m, 36, new DateTime(2022, 8, 6, 15, 22, 6, 364, DateTimeKind.Local).AddTicks(7050) },
                    { 1100, 10m, 2, new DateTime(2020, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10m, 1000, new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "LotImages",
                columns: new[] { "Id", "FileId", "LotId" },
                values: new object[,]
                {
                    { 3, 13, 2 },
                    { 2, 12, 1 },
                    { 1, 11, 1 }
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
