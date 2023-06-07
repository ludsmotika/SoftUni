using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forum.App.Data.Migrations
{
    public partial class CreatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[] { new Guid("28e1c89b-c249-4837-ab49-68277ac699f3"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque vel pretium velit, eget imperdiet massa. In diam dolor, hendrerit. ", "My third post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[] { new Guid("2da9cf21-e0cb-419c-b504-ade3cab3a1c7"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed venenatis libero vel nibh ultricies mattis. Sed sagittis sem in leo.", "My first post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[] { new Guid("a0fe0191-40c0-4d87-aa7e-03434c79f28b"), "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...", "My second post" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
