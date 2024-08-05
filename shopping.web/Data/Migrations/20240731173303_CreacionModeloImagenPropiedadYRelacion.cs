using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shopping.web.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreacionModeloImagenPropiedadYRelacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImagenArticulo",
                columns: table => new
                {
                    ImagenArticuloId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticuloId = table.Column<int>(type: "int", nullable: false),
                    UrlImagenArticulo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagenArticulo", x => x.ImagenArticuloId);
                    table.ForeignKey(
                        name: "FK_ImagenArticulo_Articulo_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "Articulo",
                        principalColumn: "ArticuloId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImagenArticulo_ArticuloId",
                table: "ImagenArticulo",
                column: "ArticuloId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagenArticulo");
        }
    }
}
