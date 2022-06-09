using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment_MVC.Migrations
{
    public partial class Seededadminwithcorrectusername2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53b7e8e4-60f2-434d-adab-6d14f05f22f5", "AQAAAAEAACcQAAAAEIFN/bybi/eMmVYDOtO1fGxMkitdfMnCgu2h5B2byYy809bykPaYeNtYH8LKtXvBew==", "84a0389e-1f5a-4f1f-bf18-ea86ea41da0a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e84ee0eb-6bc8-429a-8b5c-b5c65cd933e7", null, "127960c6-3200-42ac-9d3b-75e2fffdd9a6" });
        }
    }
}
