using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avaliacoes.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Divisao",
                columns: table => new
                {
                    DivisaoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisao", x => x.DivisaoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    DivisaoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuario_Divisao_DivisaoId",
                        column: x => x.DivisaoId,
                        principalTable: "Divisao",
                        principalColumn: "DivisaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    AvaliacaoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Grau = table.Column<string>(type: "TEXT", nullable: true),
                    DattaPP = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DataMeio = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DataFull = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Acoes = table.Column<int>(type: "INTEGER", nullable: true),
                    Pubs = table.Column<int>(type: "INTEGER", nullable: true),
                    Bondes = table.Column<int>(type: "INTEGER", nullable: true),
                    Contencao = table.Column<int>(type: "INTEGER", nullable: true),
                    Estudos = table.Column<int>(type: "INTEGER", nullable: true),
                    Financeiro = table.Column<int>(type: "INTEGER", nullable: true),
                    Operacional = table.Column<int>(type: "INTEGER", nullable: true),
                    Dedicacao = table.Column<int>(type: "INTEGER", nullable: true),
                    Frequencia = table.Column<int>(type: "INTEGER", nullable: true),
                    Nota = table.Column<int>(type: "INTEGER", nullable: true),
                    Avaliador = table.Column<string>(type: "TEXT", nullable: true),
                    DivisaoId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.AvaliacaoId);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Usuario_AvaliacaoId",
                        column: x => x.AvaliacaoId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_DivisaoId",
                table: "Usuario",
                column: "DivisaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Divisao");
        }
    }
}
