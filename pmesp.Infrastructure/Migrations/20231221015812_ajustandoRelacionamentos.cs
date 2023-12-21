using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pmesp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ajustandoRelacionamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BanditAddress");

            migrationBuilder.CreateTable(
                name: "AddressBandit",
                columns: table => new
                {
                    AddressesId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BanditsId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressBandit", x => new { x.AddressesId, x.BanditsId });
                    table.ForeignKey(
                        name: "FK_AddressBandit_Addresses_AddressesId",
                        column: x => x.AddressesId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddressBandit_Bandits_BanditsId",
                        column: x => x.BanditsId,
                        principalTable: "Bandits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AddressBandit_BanditsId",
                table: "AddressBandit",
                column: "BanditsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressBandit");

            migrationBuilder.CreateTable(
                name: "BanditAddress",
                columns: table => new
                {
                    BanditId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BanditAddress", x => new { x.BanditId, x.AddressId });
                    table.ForeignKey(
                        name: "FK_BanditAddress_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BanditAddress_Bandits_BanditId",
                        column: x => x.BanditId,
                        principalTable: "Bandits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BanditAddress_AddressId",
                table: "BanditAddress",
                column: "AddressId");
        }
    }
}
