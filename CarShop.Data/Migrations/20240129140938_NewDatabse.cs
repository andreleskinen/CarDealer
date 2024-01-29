using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewDatabse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarFilter_Cars_CarId",
                table: "CarFilter");

            migrationBuilder.DropForeignKey(
                name: "FK_CarFilter_Filter_FilterId",
                table: "CarFilter");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Mileages_MileageId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Prices_PriceId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Years_YearId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "Mileages");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Years");

            migrationBuilder.DropIndex(
                name: "IX_Cars_MileageId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_PriceId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_YearId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Filter",
                table: "Filter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarFilter",
                table: "CarFilter");

            migrationBuilder.RenameTable(
                name: "Filter",
                newName: "Filters");

            migrationBuilder.RenameTable(
                name: "CarFilter",
                newName: "CarFilters");

            migrationBuilder.RenameColumn(
                name: "YearId",
                table: "Cars",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "PriceId",
                table: "Cars",
                newName: "Mileage");

            migrationBuilder.RenameColumn(
                name: "MileageId",
                table: "Cars",
                newName: "CarType");

            migrationBuilder.RenameIndex(
                name: "IX_CarFilter_FilterId",
                table: "CarFilters",
                newName: "IX_CarFilters_FilterId");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Cars",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "CarType",
                table: "Filters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filters",
                table: "Filters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarFilters",
                table: "CarFilters",
                columns: new[] { "CarId", "FilterId" });

            migrationBuilder.CreateTable(
                name: "CarCategories",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCategories", x => new { x.CarId, x.CategoryId });
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CarFilters_Cars_CarId",
                table: "CarFilters",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarFilters_Filters_FilterId",
                table: "CarFilters",
                column: "FilterId",
                principalTable: "Filters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarFilters_Cars_CarId",
                table: "CarFilters");

            migrationBuilder.DropForeignKey(
                name: "FK_CarFilters_Filters_FilterId",
                table: "CarFilters");

            migrationBuilder.DropTable(
                name: "CarCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Filters",
                table: "Filters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarFilters",
                table: "CarFilters");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarType",
                table: "Filters");

            migrationBuilder.RenameTable(
                name: "Filters",
                newName: "Filter");

            migrationBuilder.RenameTable(
                name: "CarFilters",
                newName: "CarFilter");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Cars",
                newName: "YearId");

            migrationBuilder.RenameColumn(
                name: "Mileage",
                table: "Cars",
                newName: "PriceId");

            migrationBuilder.RenameColumn(
                name: "CarType",
                table: "Cars",
                newName: "MileageId");

            migrationBuilder.RenameIndex(
                name: "IX_CarFilters_FilterId",
                table: "CarFilter",
                newName: "IX_CarFilter_FilterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filter",
                table: "Filter",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarFilter",
                table: "CarFilter",
                columns: new[] { "CarId", "FilterId" });

            migrationBuilder.CreateTable(
                name: "Mileages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mileages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Years",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Years", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_MileageId",
                table: "Cars",
                column: "MileageId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_PriceId",
                table: "Cars",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_YearId",
                table: "Cars",
                column: "YearId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarFilter_Cars_CarId",
                table: "CarFilter",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarFilter_Filter_FilterId",
                table: "CarFilter",
                column: "FilterId",
                principalTable: "Filter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Mileages_MileageId",
                table: "Cars",
                column: "MileageId",
                principalTable: "Mileages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Prices_PriceId",
                table: "Cars",
                column: "PriceId",
                principalTable: "Prices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Years_YearId",
                table: "Cars",
                column: "YearId",
                principalTable: "Years",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
