using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pmesp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateDataTableBanditV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChainRegistration",
                table: "Bandits",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CrimeFunction",
                table: "Bandits",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CriminalRG",
                table: "Bandits",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CriminalSituation",
                table: "Bandits",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "MaritalStatus",
                table: "Bandits",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Bandits",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Naturalness",
                table: "Bandits",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ORCRIM",
                table: "Bandits",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "OperationPhone",
                table: "Bandits",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PixCPF",
                table: "Bandits",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PixEmail",
                table: "Bandits",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PixPhone",
                table: "Bandits",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Profession",
                table: "Bandits",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "WhatsApp",
                table: "Bandits",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChainRegistration",
                table: "Bandits");

            migrationBuilder.DropColumn(
                name: "CrimeFunction",
                table: "Bandits");

            migrationBuilder.DropColumn(
                name: "CriminalRG",
                table: "Bandits");

            migrationBuilder.DropColumn(
                name: "CriminalSituation",
                table: "Bandits");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "Bandits");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Bandits");

            migrationBuilder.DropColumn(
                name: "Naturalness",
                table: "Bandits");

            migrationBuilder.DropColumn(
                name: "ORCRIM",
                table: "Bandits");

            migrationBuilder.DropColumn(
                name: "OperationPhone",
                table: "Bandits");

            migrationBuilder.DropColumn(
                name: "PixCPF",
                table: "Bandits");

            migrationBuilder.DropColumn(
                name: "PixEmail",
                table: "Bandits");

            migrationBuilder.DropColumn(
                name: "PixPhone",
                table: "Bandits");

            migrationBuilder.DropColumn(
                name: "Profession",
                table: "Bandits");

            migrationBuilder.DropColumn(
                name: "WhatsApp",
                table: "Bandits");
        }
    }
}
