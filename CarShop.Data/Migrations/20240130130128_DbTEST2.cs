using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class DbTEST2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarFilters");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Filters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoryFilters",
                columns: table => new
                {
                    FilterId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryFilters", x => new { x.CategoryId, x.FilterId });
                    table.ForeignKey(
                        name: "FK_CategoryFilters_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryFilters_Filters_FilterId",
                        column: x => x.FilterId,
                        principalTable: "Filters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filters_CarId",
                table: "Filters",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryFilters_FilterId",
                table: "CategoryFilters",
                column: "FilterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Filters_Cars_CarId",
                table: "Filters",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filters_Cars_CarId",
                table: "Filters");

            migrationBuilder.DropTable(
                name: "CategoryFilters");

            migrationBuilder.DropIndex(
                name: "IX_Filters_CarId",
                table: "Filters");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Filters");

            migrationBuilder.CreateTable(
                name: "CarFilters",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false),
                    FilterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarFilters", x => new { x.CarId, x.FilterId });
                    table.ForeignKey(
                        name: "FK_CarFilters_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarFilters_Filters_FilterId",
                        column: x => x.FilterId,
                        principalTable: "Filters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarFilters_FilterId",
                table: "CarFilters",
                column: "FilterId");
        }
    }
}
