using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MediChain.Migrations
{
    /// <inheritdoc />
    public partial class addProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Price", "ProductName" },
                values: new object[,]
                {
                    { 1, "500MG,Painkiller", 10.0, "Paracetamol" },
                    { 2, "3 Ply, Pack of 50", 50.0, "Surgical Mask" },
                    { 3, "500ML, 70% Alcohol", 100.0, "Hand Sanitizer" },
                    { 4, "Infrared, Non-Contact", 200.0, "Digital Thermometer" },
                    { 5, "Pack of 10", 150.0, "Face Shield" },
                    { 6, "Fingertip, Blood Oxygen Monitor", 500.0, "Pulse Oximeter" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
