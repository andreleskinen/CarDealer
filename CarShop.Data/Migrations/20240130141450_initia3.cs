using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class initia3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarCategory");

            migrationBuilder.CreateIndex(
                name: "IX_CarCategories_CategoryId",
                table: "CarCategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarCategories_Cars_CarId",
                table: "CarCategories",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarCategories_Categories_CategoryId",
                table: "CarCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarCategories_Cars_CarId",
                table: "CarCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_CarCategories_Categories_CategoryId",
                table: "CarCategories");

            migrationBuilder.DropIndex(
                name: "IX_CarCategories_CategoryId",
                table: "CarCategories");

            migrationBuilder.CreateTable(
                name: "CarCategory",
                columns: table => new
                {
                    CarsId = table.Column<int>(type: "int", nullable: false),
                    CategoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCategory", x => new { x.CarsId, x.CategoriesId });
                    table.ForeignKey(
                        name: "FK_CarCategory_Cars_CarsId",
                        column: x => x.CarsId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarCategory_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarCategory_CategoriesId",
                table: "CarCategory",
                column: "CategoriesId");
        }
    }
}
