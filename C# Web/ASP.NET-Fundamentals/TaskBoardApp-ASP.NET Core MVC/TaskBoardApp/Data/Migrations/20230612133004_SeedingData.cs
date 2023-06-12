using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "01e72c46-3ab1-4118-a0c3-5540e66f6650", 0, "58e1e52a-9c94-4b54-942a-4ae53f81a743", "test@softuni.bg", false, false, null, "TEST@SOFTUNI.BG", "NIKOLAI KOSTOV", "AQAAAAEAACcQAAAAEMOCGThM5Ux8TZt20m4rAY8WqtIARXF1Ia1WEV+vYIzkVxenfaZhWk4mISqoUiCzDQ==", null, false, "57e98499-929d-45c8-939a-bd2410604dd1", false, "Nikolai Kostov" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 11, 24, 16, 30, 3, 738, DateTimeKind.Local).AddTicks(1214), "Implement better styling for all public pages", "01e72c46-3ab1-4118-a0c3-5540e66f6650", "Improve CSS styles", null },
                    { 2, 1, new DateTime(2023, 1, 12, 16, 30, 3, 738, DateTimeKind.Local).AddTicks(1251), "Create android client app for the Taskboard RESTful API", "01e72c46-3ab1-4118-a0c3-5540e66f6650", "Android client app", null },
                    { 3, 2, new DateTime(2023, 5, 12, 16, 30, 3, 738, DateTimeKind.Local).AddTicks(1256), "Create windows forms desktop client app for the Taskboard RESTful API", "01e72c46-3ab1-4118-a0c3-5540e66f6650", "Desktop Client App", null },
                    { 4, 3, new DateTime(2022, 6, 12, 16, 30, 3, 738, DateTimeKind.Local).AddTicks(1259), "Implement [Create Task] page for adding new tasks", "01e72c46-3ab1-4118-a0c3-5540e66f6650", "Create Tasks", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "01e72c46-3ab1-4118-a0c3-5540e66f6650");

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
