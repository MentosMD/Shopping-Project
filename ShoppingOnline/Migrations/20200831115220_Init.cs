using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingOnline.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "ID",
                keyValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ID", "Email", "Password", "Role", "Token" },
                values: new object[] { 1, "test@test.com", "qwer123", null, null });
        }
    }
}
