using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esercizio_U5_S1_L1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generi",
                columns: table => new
                {
                    IdGenere = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoGenere = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generi", x => x.IdGenere);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    IdBook = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Autore = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdGenere = table.Column<int>(type: "int", nullable: false),
                    Disponibilità = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.IdBook);
                    table.ForeignKey(
                        name: "FK_Books_Generi_IdGenere",
                        column: x => x.IdGenere,
                        principalTable: "Generi",
                        principalColumn: "IdGenere",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_IdGenere",
                table: "Books",
                column: "IdGenere");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Generi");
        }
    }
}
