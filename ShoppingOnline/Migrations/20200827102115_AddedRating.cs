using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingOnline.Migrations
{
    public partial class AddedRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CodeProduct = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Discount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetail",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceType = table.Column<string>(nullable: true),
                    OperatingSystem = table.Column<string>(nullable: true),
                    DisplayDiagonal = table.Column<string>(nullable: true),
                    DisplayResolution = table.Column<string>(nullable: true),
                    ScreenMatrixType = table.Column<string>(nullable: true),
                    RearCamera = table.Column<string>(nullable: true),
                    SecondChamber = table.Column<string>(nullable: true),
                    AccumulatorBattery = table.Column<string>(nullable: true),
                    CPU = table.Column<string>(nullable: true),
                    IsWiFi = table.Column<bool>(nullable: false),
                    IsMemoryCardSupport = table.Column<bool>(nullable: false),
                    ProductID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductDetail_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPicture",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(nullable: true),
                    FileExtension = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPicture", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductPicture_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(nullable: true),
                    LName = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Avatar = table.Column<string>(nullable: true),
                    UserRef = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Profile_User_UserRef",
                        column: x => x.UserRef,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderStatus = table.Column<int>(nullable: false),
                    TotalSum = table.Column<double>(nullable: false),
                    ProfileRef = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Order_Profile_ProfileRef",
                        column: x => x.ProfileRef,
                        principalTable: "Profile",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<int>(nullable: false),
                    ProfileRef = table.Column<int>(nullable: false),
                    ProductRef = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rating_Product_ProductRef",
                        column: x => x.ProductRef,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rating_Profile_ProfileRef",
                        column: x => x.ProfileRef,
                        principalTable: "Profile",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdersItems",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderRef = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrdersItems_Order_OrderRef",
                        column: x => x.OrderRef,
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ID", "CodeProduct", "Discount", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "00-00044898-002", 100.0, "Xiaomi Redmi 8A", 2099.0 },
                    { 2, "00-00036714-012", 2000.0, "Apple iPhone XS", 14499.0 },
                    { 3, "00-00045830-003", 200.0, "Samsung Galaxy A71 A715", 8299.0 },
                    { 4, "00-00044893-001", 0.0, "Samsung Galaxy M30s M307", 4999.0 },
                    { 5, "00-00044504-001", 3500.0, "Asus Zenfone 6 ZE630KL", 9999.0 },
                    { 6, "00-00044328-002", 1500.0, "Sony Xperia 1 J9110", 15499.0 },
                    { 7, "00-00036476-003", 100.0, "Nokia 5.1", 1999.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProfileRef",
                table: "Order",
                column: "ProfileRef");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersItems_OrderRef",
                table: "OrdersItems",
                column: "OrderRef");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetail_ProductID",
                table: "ProductDetail",
                column: "ProductID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductPicture_ProductId",
                table: "ProductPicture",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_UserRef",
                table: "Profile",
                column: "UserRef",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rating_ProductRef",
                table: "Rating",
                column: "ProductRef");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_ProfileRef",
                table: "Rating",
                column: "ProfileRef",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "OrdersItems");

            migrationBuilder.DropTable(
                name: "ProductDetail");

            migrationBuilder.DropTable(
                name: "ProductPicture");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
