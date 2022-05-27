using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment_MVC.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryName);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    LanguageName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.LanguageName);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(nullable: true),
                    CountryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityID);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryName",
                        column: x => x.CountryName,
                        principalTable: "Countries",
                        principalColumn: "CountryName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CityID = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.id);
                    table.ForeignKey(
                        name: "FK_People_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonLanguage",
                columns: table => new
                {
                    LanguageName = table.Column<string>(nullable: false),
                    Personid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonLanguage", x => new { x.Personid, x.LanguageName });
                    table.ForeignKey(
                        name: "FK_PersonLanguage_Language_LanguageName",
                        column: x => x.LanguageName,
                        principalTable: "Language",
                        principalColumn: "LanguageName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonLanguage_People_Personid",
                        column: x => x.Personid,
                        principalTable: "People",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                column: "CountryName",
                values: new object[]
                {
                    "Sverige",
                    "Norge",
                    "Finland"
                });

            migrationBuilder.InsertData(
                table: "Language",
                column: "LanguageName",
                values: new object[]
                {
                    "English",
                    "Svenska",
                    "Norsk"
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityID", "CityName", "CountryName" },
                values: new object[] { 1, "Stockholm", "Sverige" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityID", "CityName", "CountryName" },
                values: new object[] { 2, "Göteborg", "Sverige" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityID", "CityName", "CountryName" },
                values: new object[] { 3, "Oslo", "Norge" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "id", "CityID", "Name", "PhoneNumber" },
                values: new object[] { 1, 1, "Kalle", "01234562" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "id", "CityID", "Name", "PhoneNumber" },
                values: new object[] { 2, 2, "Sten", "01698941" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "id", "CityID", "Name", "PhoneNumber" },
                values: new object[] { 3, 2, "Börje", "016161814" });

            migrationBuilder.InsertData(
                table: "PersonLanguage",
                columns: new[] { "Personid", "LanguageName" },
                values: new object[,]
                {
                    { 1, "Svenska" },
                    { 2, "Svenska" },
                    { 2, "English" },
                    { 3, "Norsk" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryName",
                table: "Cities",
                column: "CountryName");

            migrationBuilder.CreateIndex(
                name: "IX_People_CityID",
                table: "People",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonLanguage_LanguageName",
                table: "PersonLanguage",
                column: "LanguageName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonLanguage");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
