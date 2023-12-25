using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pmesp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateBanditTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExtensionPhoto",
                table: "Bandits",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PrincipalPhoto",
                table: "Bandits",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtensionPhoto",
                table: "Bandits");

            migrationBuilder.DropColumn(
                name: "PrincipalPhoto",
                table: "Bandits");
        }
    }
}
