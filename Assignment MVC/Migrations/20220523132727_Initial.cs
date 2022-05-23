using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment_MVC.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "id", "City", "Name", "PhoneNumber" },
                values: new object[] { 1, "Stad 1", "Kalle", "01234562" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "id", "City", "Name", "PhoneNumber" },
                values: new object[] { 2, "Stad 2", "Sten", "01698941" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "id", "City", "Name", "PhoneNumber" },
                values: new object[] { 3, "Stad 3", "Börje", "016161814" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
