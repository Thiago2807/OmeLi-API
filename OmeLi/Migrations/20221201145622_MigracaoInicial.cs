using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmeLi.Migrations
{
    public partial class MigracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Editoras",
                columns: table => new
                {
                    EditoraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEditora = table.Column<string>(type: "varchar(60)", nullable: true),
                    DescEditora = table.Column<string>(type: "varchar(150)", nullable: true),
                    CnpjEditora = table.Column<string>(type: "char(14)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editoras", x => x.EditoraId);
                });

            migrationBuilder.CreateTable(
                name: "EnderecosFornecedores",
                columns: table => new
                {
                    EnderecoFornecedorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnderecoForn = table.Column<string>(type: "varchar(100)", nullable: false),
                    NumeroEndereco = table.Column<string>(type: "varchar(10)", nullable: true),
                    ComplementoEndereco = table.Column<string>(type: "varchar(20)", nullable: true),
                    BairroEndereco = table.Column<string>(type: "varchar(40)", nullable: true),
                    CidadeEndereco = table.Column<string>(type: "varchar(50)", nullable: true),
                    CepEndereo = table.Column<string>(type: "varchar(13)", nullable: true),
                    UfEndereco = table.Column<string>(type: "char(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecosFornecedores", x => x.EnderecoFornecedorId);
                });

            migrationBuilder.CreateTable(
                name: "Estoques",
                columns: table => new
                {
                    EstoqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoques", x => x.EstoqueId);
                });

            migrationBuilder.CreateTable(
                name: "StatusLivros",
                columns: table => new
                {
                    StatusLivroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescStatusLivroId = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusLivros", x => x.StatusLivroId);
                });

            migrationBuilder.CreateTable(
                name: "TiposPessoas",
                columns: table => new
                {
                    TipoPessoaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescTipoPessoa = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPessoas", x => x.TipoPessoaId);
                });

            migrationBuilder.CreateTable(
                name: "TiposTelefones",
                columns: table => new
                {
                    TipoTelefoneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescTipoTelefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposTelefones", x => x.TipoTelefoneId);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    FornecedorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFornecedor = table.Column<string>(type: "varchar(60)", nullable: true),
                    CnpjFornecedor = table.Column<string>(type: "char(14)", nullable: true),
                    EnderecoFornecedorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.FornecedorId);
                    table.ForeignKey(
                        name: "FK_Fornecedores_EnderecosFornecedores_EnderecoFornecedorId",
                        column: x => x.EnderecoFornecedorId,
                        principalTable: "EnderecosFornecedores",
                        principalColumn: "EnderecoFornecedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    LivroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeLivro = table.Column<string>(type: "varchar(60)", nullable: false),
                    DescLivro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    StatusLivroId = table.Column<int>(type: "int", nullable: false),
                    EditoraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.LivroId);
                    table.ForeignKey(
                        name: "FK_Livros_Editoras_EditoraId",
                        column: x => x.EditoraId,
                        principalTable: "Editoras",
                        principalColumn: "EditoraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Livros_StatusLivros_StatusLivroId",
                        column: x => x.StatusLivroId,
                        principalTable: "StatusLivros",
                        principalColumn: "StatusLivroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    PessoaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePessoa = table.Column<string>(type: "varchar(60)", nullable: true),
                    SobrenomePessoa = table.Column<string>(type: "varchar(60)", nullable: true),
                    CpfPessoa = table.Column<string>(type: "char(11)", nullable: true),
                    DtNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoPessoaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.PessoaId);
                    table.ForeignKey(
                        name: "FK_Pessoas_TiposPessoas_TipoPessoaId",
                        column: x => x.TipoPessoaId,
                        principalTable: "TiposPessoas",
                        principalColumn: "TipoPessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContatosFornecedores",
                columns: table => new
                {
                    ContatoFornecedorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroTelefone = table.Column<string>(type: "varchar(20)", nullable: false),
                    EnderecoEmail = table.Column<string>(type: "varchar(150)", nullable: true),
                    DddTelefone = table.Column<int>(type: "int", nullable: false),
                    TipoTelefoneId = table.Column<int>(type: "int", nullable: false),
                    FornecedorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContatosFornecedores", x => x.ContatoFornecedorId);
                    table.ForeignKey(
                        name: "FK_ContatosFornecedores_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "FornecedorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContatosFornecedores_TiposTelefones_TipoTelefoneId",
                        column: x => x.TipoTelefoneId,
                        principalTable: "TiposTelefones",
                        principalColumn: "TipoTelefoneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EditorasFornecedores",
                columns: table => new
                {
                    EditoraFornecedorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FornecedorId = table.Column<int>(type: "int", nullable: false),
                    EditoraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditorasFornecedores", x => x.EditoraFornecedorId);
                    table.ForeignKey(
                        name: "FK_EditorasFornecedores_Editoras_EditoraId",
                        column: x => x.EditoraId,
                        principalTable: "Editoras",
                        principalColumn: "EditoraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EditorasFornecedores_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "FornecedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivrosEstoque",
                columns: table => new
                {
                    LivroEstoqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QtdLivro = table.Column<float>(type: "real", nullable: false),
                    QtdLimiteLivro = table.Column<float>(type: "real", nullable: false),
                    LivroId = table.Column<int>(type: "int", nullable: false),
                    EstoqueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivrosEstoque", x => x.LivroEstoqueId);
                    table.ForeignKey(
                        name: "FK_LivrosEstoque_Estoques_EstoqueId",
                        column: x => x.EstoqueId,
                        principalTable: "Estoques",
                        principalColumn: "EstoqueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivrosEstoque_Livros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livros",
                        principalColumn: "LivroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivrosPessoas",
                columns: table => new
                {
                    LivroPessoaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LivroId = table.Column<int>(type: "int", nullable: false),
                    PessoaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivrosPessoas", x => x.LivroPessoaId);
                    table.ForeignKey(
                        name: "FK_LivrosPessoas_Livros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livros",
                        principalColumn: "LivroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivrosPessoas_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContatosFornecedores_FornecedorId",
                table: "ContatosFornecedores",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_ContatosFornecedores_TipoTelefoneId",
                table: "ContatosFornecedores",
                column: "TipoTelefoneId");

            migrationBuilder.CreateIndex(
                name: "IX_EditorasFornecedores_EditoraId",
                table: "EditorasFornecedores",
                column: "EditoraId");

            migrationBuilder.CreateIndex(
                name: "IX_EditorasFornecedores_FornecedorId",
                table: "EditorasFornecedores",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_EnderecoFornecedorId",
                table: "Fornecedores",
                column: "EnderecoFornecedorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Livros_EditoraId",
                table: "Livros",
                column: "EditoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_StatusLivroId",
                table: "Livros",
                column: "StatusLivroId");

            migrationBuilder.CreateIndex(
                name: "IX_LivrosEstoque_EstoqueId",
                table: "LivrosEstoque",
                column: "EstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_LivrosEstoque_LivroId",
                table: "LivrosEstoque",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_LivrosPessoas_LivroId",
                table: "LivrosPessoas",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_LivrosPessoas_PessoaId",
                table: "LivrosPessoas",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_TipoPessoaId",
                table: "Pessoas",
                column: "TipoPessoaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContatosFornecedores");

            migrationBuilder.DropTable(
                name: "EditorasFornecedores");

            migrationBuilder.DropTable(
                name: "LivrosEstoque");

            migrationBuilder.DropTable(
                name: "LivrosPessoas");

            migrationBuilder.DropTable(
                name: "TiposTelefones");

            migrationBuilder.DropTable(
                name: "Fornecedores");

            migrationBuilder.DropTable(
                name: "Estoques");

            migrationBuilder.DropTable(
                name: "Livros");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "EnderecosFornecedores");

            migrationBuilder.DropTable(
                name: "Editoras");

            migrationBuilder.DropTable(
                name: "StatusLivros");

            migrationBuilder.DropTable(
                name: "TiposPessoas");
        }
    }
}
