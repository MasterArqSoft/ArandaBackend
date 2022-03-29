using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirst.Infrastructure.Migrations
{
    public partial class CreateInital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Product");

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Product",
                columns: table => new
                {
                    ProductId = table.Column<long>(type: "BIGINT", nullable: false, comment: "Identificador del producto")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Nombre del producto"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Descripción del producto"),
                    Categoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Categoria del producto"),
                    Imagen = table.Column<byte[]>(type: "varbinary(8000)", maxLength: 8000, nullable: true, comment: "Imagen del producto")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                schema: "Product",
                table: "Product",
                columns: new[] { "ProductId", "Categoria", "Descripcion", "Imagen", "Nombre" },
                values: new object[,]
                {
                    { 1L, "Category No1", "Descripción No1", null, "Product No1" },
                    { 2L, "Category No2", "Descripción No2", null, "Product No2" },
                    { 3L, "Category No3", "Descripción No3", null, "Product No3" },
                    { 4L, "Category No4", "Descripción No4", null, "Product No4" },
                    { 5L, "Category No5", "Descripción No5", null, "Product No5" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product",
                schema: "Product");
        }
    }
}
