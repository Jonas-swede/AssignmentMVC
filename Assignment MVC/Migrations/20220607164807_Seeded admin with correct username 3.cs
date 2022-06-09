using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment_MVC.Migrations
{
    public partial class Seededadminwithcorrectusername3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb4876bd-dda4-4b8a-b2ab-8d7aab65418d", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEMF34lxs8a7nq4Hl/G+gl4eIOqW5gFqjGMoaX/6MrMg7smG/FbsoLUJGVHg/q5pUZw==", "3e987e6c-4731-46fe-8aa7-5b8f3f435f50" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53b7e8e4-60f2-434d-adab-6d14f05f22f5", null, null, "AQAAAAEAACcQAAAAEIFN/bybi/eMmVYDOtO1fGxMkitdfMnCgu2h5B2byYy809bykPaYeNtYH8LKtXvBew==", "84a0389e-1f5a-4f1f-bf18-ea86ea41da0a" });
        }
    }
}
