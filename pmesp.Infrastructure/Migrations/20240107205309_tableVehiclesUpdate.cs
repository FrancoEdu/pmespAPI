using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pmesp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class tableVehiclesUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BanditId",
                table: "Vehicles",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_BanditId",
                table: "Vehicles",
                column: "BanditId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Bandits_BanditId",
                table: "Vehicles",
                column: "BanditId",
                principalTable: "Bandits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Bandits_BanditId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_BanditId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "BanditId",
                table: "Vehicles");
        }
    }
}
