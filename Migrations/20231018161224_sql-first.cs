using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avaliacoes.Migrations
{
    /// <inheritdoc />
    public partial class sqlfirst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Divisao",
                columns: table => new
                {
                    DivisaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisao", x => x.DivisaoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DivisaoId = table.Column<int>(type: "int", nullable: false),
                    Admin = table.Column<int>(type: "int", nullable: false)
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
                    AvaliacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataPP = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataMeio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFull = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Acoes = table.Column<int>(type: "int", nullable: false),
                    Pubs = table.Column<int>(type: "int", nullable: false),
                    Bondes = table.Column<int>(type: "int", nullable: false),
                    Contencao = table.Column<int>(type: "int", nullable: false),
                    Estudos = table.Column<int>(type: "int", nullable: false),
                    Financeiro = table.Column<int>(type: "int", nullable: false),
                    Operacional = table.Column<int>(type: "int", nullable: false),
                    Dedicacao = table.Column<int>(type: "int", nullable: false),
                    Frequencia = table.Column<int>(type: "int", nullable: false),
                    Nota = table.Column<int>(type: "int", nullable: false),
                    Avaliador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Exibir = table.Column<bool>(type: "bit", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DivisaoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.AvaliacaoId);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_UsuarioId",
                table: "Avaliacao",
                column: "UsuarioId");

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
