using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment_MVC.Migrations
{
    public partial class Changedregisterfunctionallitytoaddfirstandlastname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a35598c3-561f-4457-a33d-6c89bec7b9ef");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "f4eefa29-a81f-4542-9f94-c68ac21108a6", "75855652-6318-4cdb-9641-0e18f119b7ba" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75855652-6318-4cdb-9641-0e18f119b7ba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f4eefa29-a81f-4542-9f94-c68ac21108a6");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "837c6fec-9035-44a0-b627-aac5989a9ada", "51f122ba-9f95-4f6a-85a4-3e75fd7b11f1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f2186b0f-7c41-4bf6-8339-eba5de46ed5d", "51057638-8bfc-4fed-bae4-c95311e53d1e", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e4b0d032-2272-4850-9ef1-9e6d8381570e", 0, "cf7d24b7-49d2-4b5f-a8fe-e13655c53d6b", "admin@gmail.com", false, null, null, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEHhx2aHpobng6h/l6pjUQARY/18zjOqzSc8iy4pgRl4k8rIWpMXONlyYVmuMzRDyQQ==", "1234567890", false, "59cf203a-c5d0-4386-866d-b631c3624337", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "e4b0d032-2272-4850-9ef1-9e6d8381570e", "837c6fec-9035-44a0-b627-aac5989a9ada" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2186b0f-7c41-4bf6-8339-eba5de46ed5d");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "e4b0d032-2272-4850-9ef1-9e6d8381570e", "837c6fec-9035-44a0-b627-aac5989a9ada" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "837c6fec-9035-44a0-b627-aac5989a9ada");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4b0d032-2272-4850-9ef1-9e6d8381570e");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "75855652-6318-4cdb-9641-0e18f119b7ba", "00cca931-4b14-48d4-a3fa-b85d6cb1d81c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a35598c3-561f-4457-a33d-6c89bec7b9ef", "6f043f4d-cd01-4fd8-af7d-ff2f51d86196", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f4eefa29-a81f-4542-9f94-c68ac21108a6", 0, "dde076b8-0f54-40f6-b8a6-0bffcca43eb7", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEKpRrVJbAKPvqhBtic9zQvqztTarsVSZuo2aOgg886tZLqtO2+qyV2gAjL3If/ftYQ==", "1234567890", false, "dfc6d3d5-b01d-4a57-acaa-f07226166b3a", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "f4eefa29-a81f-4542-9f94-c68ac21108a6", "75855652-6318-4cdb-9641-0e18f119b7ba" });
        }
    }
}
