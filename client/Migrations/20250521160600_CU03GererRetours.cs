using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace client.Migrations
{
    /// <inheritdoc />
    public partial class CU03GererRetours : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Raison",
                table: "Retours");

            migrationBuilder.AddColumn<int>(
                name: "ProduitId",
                table: "Retours",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantite",
                table: "Retours",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Retours_ProduitId",
                table: "Retours",
                column: "ProduitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Retours_Produits_ProduitId",
                table: "Retours",
                column: "ProduitId",
                principalTable: "Produits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Retours_Produits_ProduitId",
                table: "Retours");

            migrationBuilder.DropIndex(
                name: "IX_Retours_ProduitId",
                table: "Retours");

            migrationBuilder.DropColumn(
                name: "ProduitId",
                table: "Retours");

            migrationBuilder.DropColumn(
                name: "Quantite",
                table: "Retours");

            migrationBuilder.AddColumn<string>(
                name: "Raison",
                table: "Retours",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
