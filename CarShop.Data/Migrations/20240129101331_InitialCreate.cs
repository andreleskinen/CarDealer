using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarFilters_Cars_CarId",
                table: "CarFilters");

            migrationBuilder.DropForeignKey(
                name: "FK_CarFilters_Filters_FilterId",
                table: "CarFilters");

            migrationBuilder.DropTable(
                name: "CarBrands");

            migrationBuilder.DropTable(
                name: "CarManufacturers");

            migrationBuilder.DropTable(
                name: "CarMileage");

            migrationBuilder.DropTable(
                name: "CarModels");

            migrationBuilder.DropTable(
                name: "CarPrice");

            migrationBuilder.DropTable(
                name: "CarProductionYears");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "ProductionYears");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PriceOfCars",
                table: "PriceOfCars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MileageOfCars",
                table: "MileageOfCars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Filters",
                table: "Filters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarFilters",
                table: "CarFilters");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "PriceOfCars");

            migrationBuilder.DropColumn(
                name: "PriceOfCar",
                table: "PriceOfCars");

            migrationBuilder.DropColumn(
                name: "MileageId",
                table: "MileageOfCars");

            migrationBuilder.DropColumn(
                name: "MileageOfCar",
                table: "MileageOfCars");

            migrationBuilder.RenameTable(
                name: "PriceOfCars",
                newName: "Prices");

            migrationBuilder.RenameTable(
                name: "MileageOfCars",
                newName: "Mileages");

            migrationBuilder.RenameTable(
                name: "Filters",
                newName: "Filter");

            migrationBuilder.RenameTable(
                name: "CarFilters",
                newName: "CarFilter");

            migrationBuilder.RenameColumn(
                name: "ModelName",
                table: "Models",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ColorName",
                table: "Colors",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "Cars",
                newName: "YearId");

            migrationBuilder.RenameIndex(
                name: "IX_CarFilters_FilterId",
                table: "CarFilter",
                newName: "IX_CarFilter_FilterId");

            migrationBuilder.AddColumn<int>(
                name: "MakeId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MileageId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OptionTypes",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PriceId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Prices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Mileages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prices",
                table: "Prices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mileages",
                table: "Mileages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filter",
                table: "Filter",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarFilter",
                table: "CarFilter",
                columns: new[] { "CarId", "FilterId" });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Makes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makes", x => x.Id);
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
                name: "IX_Cars_MakeId",
                table: "Cars",
                column: "MakeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_MileageId",
                table: "Cars",
                column: "MileageId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ModelId",
                table: "Cars",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_PriceId",
                table: "Cars",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_YearId",
                table: "Cars",
                column: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_CarCategory_CategoriesId",
                table: "CarCategory",
                column: "CategoriesId");

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
                name: "FK_Cars_Makes_MakeId",
                table: "Cars",
                column: "MakeId",
                principalTable: "Makes",
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
                name: "FK_Cars_Models_ModelId",
                table: "Cars",
                column: "ModelId",
                principalTable: "Models",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarFilter_Cars_CarId",
                table: "CarFilter");

            migrationBuilder.DropForeignKey(
                name: "FK_CarFilter_Filter_FilterId",
                table: "CarFilter");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Makes_MakeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Mileages_MileageId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Models_ModelId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Prices_PriceId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Years_YearId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "CarCategory");

            migrationBuilder.DropTable(
                name: "Makes");

            migrationBuilder.DropTable(
                name: "Years");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Cars_MakeId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_MileageId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_ModelId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_PriceId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_YearId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prices",
                table: "Prices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mileages",
                table: "Mileages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Filter",
                table: "Filter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarFilter",
                table: "CarFilter");

            migrationBuilder.DropColumn(
                name: "MakeId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "MileageId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "OptionTypes",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Prices");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Mileages");

            migrationBuilder.RenameTable(
                name: "Prices",
                newName: "PriceOfCars");

            migrationBuilder.RenameTable(
                name: "Mileages",
                newName: "MileageOfCars");

            migrationBuilder.RenameTable(
                name: "Filter",
                newName: "Filters");

            migrationBuilder.RenameTable(
                name: "CarFilter",
                newName: "CarFilters");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Models",
                newName: "ModelName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Colors",
                newName: "ColorName");

            migrationBuilder.RenameColumn(
                name: "YearId",
                table: "Cars",
                newName: "CarId");

            migrationBuilder.RenameIndex(
                name: "IX_CarFilter_FilterId",
                table: "CarFilters",
                newName: "IX_CarFilters_FilterId");

            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "Models",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Colors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PriceId",
                table: "PriceOfCars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PriceOfCar",
                table: "PriceOfCars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MileageId",
                table: "MileageOfCars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MileageOfCar",
                table: "MileageOfCars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PriceOfCars",
                table: "PriceOfCars",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MileageOfCars",
                table: "MileageOfCars",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filters",
                table: "Filters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarFilters",
                table: "CarFilters",
                columns: new[] { "CarId", "FilterId" });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarMileage",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false),
                    MileageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarMileage", x => new { x.CarId, x.MileageId });
                    table.ForeignKey(
                        name: "FK_CarMileage_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarMileage_MileageOfCars_MileageId",
                        column: x => x.MileageId,
                        principalTable: "MileageOfCars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarModels",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModels", x => new { x.CarId, x.ModelId });
                    table.ForeignKey(
                        name: "FK_CarModels_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarModels_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarPrice",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false),
                    PriceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarPrice", x => new { x.CarId, x.PriceId });
                });

            migrationBuilder.CreateTable(
                name: "CarProductionYears",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false),
                    ProductionYearId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarProductionYears", x => new { x.CarId, x.ProductionYearId });
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false),
                    ManufacturerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionYears",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionYearId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionYears", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarBrands",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBrands", x => new { x.CarId, x.BrandId });
                    table.ForeignKey(
                        name: "FK_CarBrands_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarBrands_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarManufacturers",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false),
                    PricesId = table.Column<int>(type: "int", nullable: false),
                    ProductionYearsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarManufacturers", x => new { x.CarId, x.ManufacturerId });
                    table.ForeignKey(
                        name: "FK_CarManufacturers_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarManufacturers_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarManufacturers_PriceOfCars_PricesId",
                        column: x => x.PricesId,
                        principalTable: "PriceOfCars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarManufacturers_ProductionYears_ProductionYearsId",
                        column: x => x.ProductionYearsId,
                        principalTable: "ProductionYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarBrands_BrandId",
                table: "CarBrands",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CarManufacturers_ManufacturerId",
                table: "CarManufacturers",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_CarManufacturers_PricesId",
                table: "CarManufacturers",
                column: "PricesId");

            migrationBuilder.CreateIndex(
                name: "IX_CarManufacturers_ProductionYearsId",
                table: "CarManufacturers",
                column: "ProductionYearsId");

            migrationBuilder.CreateIndex(
                name: "IX_CarMileage_MileageId",
                table: "CarMileage",
                column: "MileageId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_ModelId",
                table: "CarModels",
                column: "ModelId");

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
    }
}
