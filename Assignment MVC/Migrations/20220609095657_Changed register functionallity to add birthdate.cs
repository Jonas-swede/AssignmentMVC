using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment_MVC.Migrations
{
    public partial class Changedregisterfunctionallitytoaddbirthdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5a7980c3-1c76-402e-bf3e-a3441cc3a68b", "6fb1e070-3e2f-47e0-b9e4-2e2441beaf29", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9946dcc5-bafe-4016-9717-535e062fc987", "d8d12c41-9953-44f5-9188-4439a2f49f9a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "22ee4f37-610e-4466-b736-775440e1ea79", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "e27558f4-a09f-4927-a523-3b202b9ca8b9", "admin@gmail.com", false, null, null, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEObTQmN3KtqSXCJnAsGpa4afacwfSS9VONKiJ0gtZyS8gke81VDNFja9wzuhchkK5Q==", "1234567890", false, "0189e1d1-8be0-4bda-b316-378c12dc20d7", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "22ee4f37-610e-4466-b736-775440e1ea79", "5a7980c3-1c76-402e-bf3e-a3441cc3a68b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9946dcc5-bafe-4016-9717-535e062fc987");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "22ee4f37-610e-4466-b736-775440e1ea79", "5a7980c3-1c76-402e-bf3e-a3441cc3a68b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a7980c3-1c76-402e-bf3e-a3441cc3a68b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ee4f37-610e-4466-b736-775440e1ea79");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "AspNetUsers");

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
    }
}
