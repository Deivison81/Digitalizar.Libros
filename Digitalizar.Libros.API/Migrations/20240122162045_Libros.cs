using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digitalizar.Libros.API.Migrations
{
    /// <inheritdoc />
    public partial class Libros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriaID = table.Column<int>(type: "int", nullable: false),
                    EditorialID = table.Column<int>(type: "int", nullable: false),
                    AutorID = table.Column<int>(type: "int", nullable: false),
                    ruta = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    nombre_archivo = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Libros_Autores_AutorID",
                        column: x => x.AutorID,
                        principalTable: "Autores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Libros_Categorias_CategoriaID",
                        column: x => x.CategoriaID,
                        principalTable: "Categorias",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Libros_Editoriales_EditorialID",
                        column: x => x.EditorialID,
                        principalTable: "Editoriales",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libros_AutorID",
                table: "Libros",
                column: "AutorID");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_CategoriaID",
                table: "Libros",
                column: "CategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_EditorialID",
                table: "Libros",
                column: "EditorialID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libros");
        }
    }
}
