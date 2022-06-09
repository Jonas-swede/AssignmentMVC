using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment_MVC.Migrations
{
    public partial class Seededadminwithcorrectusername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "UserName" },
                values: new object[] { "e84ee0eb-6bc8-429a-8b5c-b5c65cd933e7", "127960c6-3200-42ac-9d3b-75e2fffdd9a6", "admin@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "UserName" },
                values: new object[] { "55496ff6-48aa-452f-9155-8600f846938d", "41a74af8-cf7e-4e3c-b2e1-a159b34c20e1", "Admin" });
        }
    }
}
