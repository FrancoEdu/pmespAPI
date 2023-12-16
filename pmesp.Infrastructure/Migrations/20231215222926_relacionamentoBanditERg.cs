using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pmesp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class relacionamentoBanditERg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BanditId",
                table: "RGs",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_RGs_BanditId",
                table: "RGs",
                column: "BanditId");

            migrationBuilder.AddForeignKey(
                name: "FK_RGs_Bandits_BanditId",
                table: "RGs",
                column: "BanditId",
                principalTable: "Bandits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RGs_Bandits_BanditId",
                table: "RGs");

            migrationBuilder.DropIndex(
                name: "IX_RGs_BanditId",
                table: "RGs");

            migrationBuilder.DropColumn(
                name: "BanditId",
                table: "RGs");
        }
    }
}
