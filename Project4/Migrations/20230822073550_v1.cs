using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project4.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblCoupons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Percent = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCoupons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblLocals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLocals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Avatar = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblRestaurants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Quality = table.Column<float>(nullable: false),
                    LocalID = table.Column<int>(nullable: false),
                    LocalsId = table.Column<int>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRestaurants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblRestaurants_tblLocals_LocalsId",
                        column: x => x.LocalsId,
                        principalTable: "tblLocals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblLogined",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    UsersId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLogined", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblLogined_tblUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    SalePrice = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Sold = table.Column<int>(nullable: false),
                    RestaurantID = table.Column<int>(nullable: false),
                    RestaurantsId = table.Column<int>(nullable: true),
                    CategoryID = table.Column<int>(nullable: false),
                    CategoriesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblProducts_tblCategories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "tblCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblProducts_tblRestaurants_RestaurantsId",
                        column: x => x.RestaurantsId,
                        principalTable: "tblRestaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblSizes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ProductID = table.Column<int>(nullable: false),
                    ProductsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblSizes_tblProducts_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "tblProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblToppings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ProductID = table.Column<int>(nullable: false),
                    ProductsId = table.Column<int>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblToppings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblToppings_tblProducts_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "tblProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblCarts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductID = table.Column<int>(nullable: false),
                    ProductsId = table.Column<int>(nullable: true),
                    QuantityProduct = table.Column<int>(nullable: false),
                    ToppingID = table.Column<int>(nullable: false),
                    ToppingsId = table.Column<int>(nullable: true),
                    QuantityTopping = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UsersId = table.Column<int>(nullable: true),
                    SizeID = table.Column<int>(nullable: false),
                    SizesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblCarts_tblProducts_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "tblProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblCarts_tblSizes_SizesId",
                        column: x => x.SizesId,
                        principalTable: "tblSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblCarts_tblToppings_ToppingsId",
                        column: x => x.ToppingsId,
                        principalTable: "tblToppings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblCarts_tblUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblHistorys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    UsersId = table.Column<int>(nullable: true),
                    CartID = table.Column<int>(nullable: false),
                    CartsId = table.Column<int>(nullable: true),
                    Payment = table.Column<int>(nullable: false),
                    CouponID = table.Column<int>(nullable: false),
                    CouponsId = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblHistorys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblHistorys_tblCarts_CartsId",
                        column: x => x.CartsId,
                        principalTable: "tblCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblHistorys_tblCoupons_CouponsId",
                        column: x => x.CouponsId,
                        principalTable: "tblCoupons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblHistorys_tblUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCarts_ProductsId",
                table: "tblCarts",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCarts_SizesId",
                table: "tblCarts",
                column: "SizesId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCarts_ToppingsId",
                table: "tblCarts",
                column: "ToppingsId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCarts_UsersId",
                table: "tblCarts",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_tblHistorys_CartsId",
                table: "tblHistorys",
                column: "CartsId");

            migrationBuilder.CreateIndex(
                name: "IX_tblHistorys_CouponsId",
                table: "tblHistorys",
                column: "CouponsId");

            migrationBuilder.CreateIndex(
                name: "IX_tblHistorys_UsersId",
                table: "tblHistorys",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_tblLogined_UsersId",
                table: "tblLogined",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProducts_CategoriesId",
                table: "tblProducts",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProducts_RestaurantsId",
                table: "tblProducts",
                column: "RestaurantsId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRestaurants_LocalsId",
                table: "tblRestaurants",
                column: "LocalsId");

            migrationBuilder.CreateIndex(
                name: "IX_tblSizes_ProductsId",
                table: "tblSizes",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_tblToppings_ProductsId",
                table: "tblToppings",
                column: "ProductsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblHistorys");

            migrationBuilder.DropTable(
                name: "tblLogined");

            migrationBuilder.DropTable(
                name: "tblCarts");

            migrationBuilder.DropTable(
                name: "tblCoupons");

            migrationBuilder.DropTable(
                name: "tblSizes");

            migrationBuilder.DropTable(
                name: "tblToppings");

            migrationBuilder.DropTable(
                name: "tblUsers");

            migrationBuilder.DropTable(
                name: "tblProducts");

            migrationBuilder.DropTable(
                name: "tblCategories");

            migrationBuilder.DropTable(
                name: "tblRestaurants");

            migrationBuilder.DropTable(
                name: "tblLocals");
        }
    }
}
