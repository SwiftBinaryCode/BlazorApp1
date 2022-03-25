using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp1.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuperCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuperCourses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Classroom" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "On-Demand" });

            migrationBuilder.InsertData(
                table: "SuperCourses",
                columns: new[] { "Id", "CategoryId", "Name" },
                values: new object[] { 1, 1, "Math" });

            migrationBuilder.InsertData(
                table: "SuperCourses",
                columns: new[] { "Id", "CategoryId", "Name" },
                values: new object[] { 2, 1, "English" });

            migrationBuilder.CreateIndex(
                name: "IX_SuperCourses_CategoryId",
                table: "SuperCourses",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SuperCourses");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
