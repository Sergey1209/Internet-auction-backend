using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class aaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nickname = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeopleAuths",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 128, nullable: false),
                    Password = table.Column<string>(maxLength: 30, nullable: false),
                    Role = table.Column<int>(nullable: false, defaultValue: 2)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleAuths", x => x.PersonId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_PeopleAuths_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Nickname" },
                values: new object[] { 1, "Person1" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Nickname" },
                values: new object[] { 2, "Person2" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Nickname" },
                values: new object[] { 3, "Person3" });

            migrationBuilder.InsertData(
                table: "PeopleAuths",
                columns: new[] { "PersonId", "Email", "Password", "Role" },
                values: new object[] { 1, "mail10@gmail.com", "pass1", 2 });

            migrationBuilder.InsertData(
                table: "PeopleAuths",
                columns: new[] { "PersonId", "Email", "Password", "Role" },
                values: new object[] { 2, "mail12@gmail.com", "pass2", 2 });

            migrationBuilder.InsertData(
                table: "PeopleAuths",
                columns: new[] { "PersonId", "Email", "Password", "Role" },
                values: new object[] { 3, "mail13@gmail.com", "pass3", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_PeopleAuths_Email",
                table: "PeopleAuths",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PeopleAuths_PersonId",
                table: "PeopleAuths",
                column: "PersonId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeopleAuths");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
