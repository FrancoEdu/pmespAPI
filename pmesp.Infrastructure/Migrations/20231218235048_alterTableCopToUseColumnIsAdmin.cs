using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pmesp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class alterTableCopToUseColumnIsAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Cops",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Cops");
        }
    }
}
