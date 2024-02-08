using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Livraria.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    LivroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Lancamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Capa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Editora = table.Column<int>(type: "int", nullable: false),
                    Categoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.LivroId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livros");
        }
    }
}
