using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vucoAPI.Migrations
{
    /// <inheritdoc />
    public partial class CriaçãoProdutos3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataDeCriação",
                table: "Produtos",
                newName: "DataDeCriacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataDeCriacao",
                table: "Produtos",
                newName: "DataDeCriação");
        }
    }
}
