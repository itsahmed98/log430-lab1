using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace client.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LignesVente_Retours_RetourId",
                table: "LignesVente");

            migrationBuilder.DropIndex(
                name: "IX_LignesVente_RetourId",
                table: "LignesVente");

            migrationBuilder.DropColumn(
                name: "MontantTotal",
                table: "LignesVente");

            migrationBuilder.DropColumn(
                name: "RetourId",
                table: "LignesVente");

            migrationBuilder.RenameColumn(
                name: "MontantTotal",
                table: "Ventes",
                newName: "Total");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Total",
                table: "Ventes",
                newName: "MontantTotal");

            migrationBuilder.AddColumn<decimal>(
                name: "MontantTotal",
                table: "LignesVente",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "RetourId",
                table: "LignesVente",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LignesVente_RetourId",
                table: "LignesVente",
                column: "RetourId");

            migrationBuilder.AddForeignKey(
                name: "FK_LignesVente_Retours_RetourId",
                table: "LignesVente",
                column: "RetourId",
                principalTable: "Retours",
                principalColumn: "Id");
        }
    }
}
