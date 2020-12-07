using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace power_classroom.Data.Migrations
{
    public partial class AddNewsResource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewsResourceList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ArticleType = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Source = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsResourceList", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsResourceList");
        }
    }
}
