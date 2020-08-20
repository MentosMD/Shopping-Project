using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingOnline.Migrations
{
    public partial class AddedSeedProducts2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ID", "CodeProduct", "Discount", "Name", "Price" },
                values: new object[,]
                {
                    { 1, -44900, 100.0, "Xiaomi Redmi 8A", 2099.0 },
                    { 2, -36726, 2000.0, "Apple iPhone XS", 14499.0 },
                    { 3, -45833, 200.0, "Samsung Galaxy A71 A715", 8299.0 },
                    { 4, -44894, 0.0, "Samsung Galaxy M30s M307", 4999.0 },
                    { 5, -44505, 3500.0, "Asus Zenfone 6 ZE630KL", 9999.0 },
                    { 6, -44330, 1500.0, "Sony Xperia 1 J9110", 15499.0 },
                    { 7, -36479, 100.0, "Nokia 5.1", 1999.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 7);
        }
    }
}
