using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CallMe.Data.Migrations
{
    public partial class alterando_produto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DesejoProdutos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DesejoProdutos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaID = table.Column<int>(type: "int", nullable: false),
                    ProdutoID = table.Column<int>(type: "int", nullable: false),
                    StatusDesejoProduto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesejoProdutos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DesejoProdutos_Pessoas_PessoaID",
                        column: x => x.PessoaID,
                        principalTable: "Pessoas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DesejoProdutos_Produtos_ProdutoID",
                        column: x => x.ProdutoID,
                        principalTable: "Produtos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DesejoProdutos_PessoaID",
                table: "DesejoProdutos",
                column: "PessoaID");

            migrationBuilder.CreateIndex(
                name: "IX_DesejoProdutos_ProdutoID",
                table: "DesejoProdutos",
                column: "ProdutoID");
        }
    }
}
