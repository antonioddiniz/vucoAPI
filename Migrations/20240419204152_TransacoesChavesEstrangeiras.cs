using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vucoAPI.Migrations
{
    /// <inheritdoc />
    public partial class TransacoesChavesEstrangeiras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TransacaoId",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransacaoId1",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Transacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario1 = table.Column<int>(type: "int", nullable: false),
                    Usuario1Id = table.Column<int>(type: "int", nullable: false),
                    IdUsuario2 = table.Column<int>(type: "int", nullable: false),
                    Usuario2Id = table.Column<int>(type: "int", nullable: false),
                    DataTransacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transacoes_Usuarios_Usuario1Id",
                        column: x => x.Usuario1Id,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transacoes_Usuarios_Usuario2Id",
                        column: x => x.Usuario2Id,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_TransacaoId",
                table: "Produtos",
                column: "TransacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_TransacaoId1",
                table: "Produtos",
                column: "TransacaoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_UsuarioId",
                table: "Produtos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_Usuario1Id",
                table: "Transacoes",
                column: "Usuario1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_Usuario2Id",
                table: "Transacoes",
                column: "Usuario2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Transacoes_TransacaoId",
                table: "Produtos",
                column: "TransacaoId",
                principalTable: "Transacoes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Transacoes_TransacaoId1",
                table: "Produtos",
                column: "TransacaoId1",
                principalTable: "Transacoes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Usuarios_UsuarioId",
                table: "Produtos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Transacoes_TransacaoId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Transacoes_TransacaoId1",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Usuarios_UsuarioId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "Transacoes");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_TransacaoId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_TransacaoId1",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_UsuarioId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "TransacaoId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "TransacaoId1",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Produtos");
        }
    }
}
