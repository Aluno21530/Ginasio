using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ginasio.Migrations
{
    /// <inheritdoc />
    public partial class TireioUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Praticantes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Praticantes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
