using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ginasio.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraTentativa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JWTTokens",
                columns: table => new
                {
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    refToken = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JWTTokens");
        }
    }
}
