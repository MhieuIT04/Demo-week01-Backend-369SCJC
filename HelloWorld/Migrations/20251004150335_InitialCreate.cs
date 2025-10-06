using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HelloWorld.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Thời sự" },
                    { 2, "Thể thao" },
                    { 3, "Giải trí" }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Content", "CreatedDate", "MenuId", "Title" },
                values: new object[,]
                {
                    { 1, "Nội dung chi tiết về cơn bão số 5...", new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bão số 5 sắp vào biển Đông" },
                    { 2, "CLB A thắng CLB B với tỷ số 2-1...", new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Kết quả vòng 10 V-League" },
                    { 3, "MV mới của ca sĩ X đạt triệu view...", new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Ca sĩ X ra mắt MV mới" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_News_MenuId",
                table: "News",
                column: "MenuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
