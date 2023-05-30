using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ginasio.Migrations
{
    /// <inheritdoc />
    public partial class AdicioneiAAutenticacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Praticantes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Praticantes");
        }
    }
}
