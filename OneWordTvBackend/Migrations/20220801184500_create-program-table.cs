using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneWordTvBackend.Migrations
{
    public partial class createprogramtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OneWordTvPrograms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Hour = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Day = table.Column<string>(type: "text", nullable: false),
                    Created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneWordTvPrograms", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OneWordTvPrograms_Day",
                table: "OneWordTvPrograms",
                column: "Day");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OneWordTvPrograms");
        }
    }
}
