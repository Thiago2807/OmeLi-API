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
                name: "Estoque",
                columns: table => new
                {
                    EstoqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque", x => x.EstoqueId);
                });

            migrationBuilder.CreateTable(
                name: "StatusLivro",
                columns: table => new
                {
                    StatusLivroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescStatusLivroId = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusLivro", x => x.StatusLivroId);
                });

            migrationBuilder.CreateTable(
                name: "TipoPessoa",
                columns: table => new
                {
                    TipoPessoaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescTipoPessoa = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPessoa", x => x.TipoPessoaId);
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
                name: "Livro",
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
                    table.PrimaryKey("PK_Livro", x => x.LivroId);
                    table.ForeignKey(
                        name: "FK_Livro_Editoras_EditoraId",
                        column: x => x.EditoraId,
                        principalTable: "Editoras",
                        principalColumn: "EditoraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Livro_StatusLivro_StatusLivroId",
                        column: x => x.StatusLivroId,
                        principalTable: "StatusLivro",
                        principalColumn: "StatusLivroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
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
                    table.PrimaryKey("PK_Pessoa", x => x.PessoaId);
                    table.ForeignKey(
                        name: "FK_Pessoa_TipoPessoa_TipoPessoaId",
                        column: x => x.TipoPessoaId,
                        principalTable: "TipoPessoa",
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
                    TipoTelefoneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContatosFornecedores", x => x.ContatoFornecedorId);
                    table.ForeignKey(
                        name: "FK_ContatosFornecedores_TiposTelefones_TipoTelefoneId",
                        column: x => x.TipoTelefoneId,
                        principalTable: "TiposTelefones",
                        principalColumn: "TipoTelefoneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivroEstoque",
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
                    table.PrimaryKey("PK_LivroEstoque", x => x.LivroEstoqueId);
                    table.ForeignKey(
                        name: "FK_LivroEstoque_Estoque_EstoqueId",
                        column: x => x.EstoqueId,
                        principalTable: "Estoque",
                        principalColumn: "EstoqueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivroEstoque_Livro_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livro",
                        principalColumn: "LivroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivroPessoa",
                columns: table => new
                {
                    LivroPessoaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LivroId = table.Column<int>(type: "int", nullable: false),
                    PessoaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroPessoa", x => x.LivroPessoaId);
                    table.ForeignKey(
                        name: "FK_LivroPessoa_Livro_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livro",
                        principalColumn: "LivroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivroPessoa_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    FornecedorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFornecedor = table.Column<string>(type: "varchar(60)", nullable: true),
                    CnpjFornecedor = table.Column<string>(type: "char(14)", nullable: true),
                    ContatoFornecedorId = table.Column<int>(type: "int", nullable: false),
                    EnderecoFornecedorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.FornecedorId);
                    table.ForeignKey(
                        name: "FK_Fornecedores_ContatosFornecedores_ContatoFornecedorId",
                        column: x => x.ContatoFornecedorId,
                        principalTable: "ContatosFornecedores",
                        principalColumn: "ContatoFornecedorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fornecedores_EnderecosFornecedores_EnderecoFornecedorId",
                        column: x => x.EnderecoFornecedorId,
                        principalTable: "EnderecosFornecedores",
                        principalColumn: "EnderecoFornecedorId",
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
                name: "IX_Fornecedores_ContatoFornecedorId",
                table: "Fornecedores",
                column: "ContatoFornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_EnderecoFornecedorId",
                table: "Fornecedores",
                column: "EnderecoFornecedorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Livro_EditoraId",
                table: "Livro",
                column: "EditoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Livro_StatusLivroId",
                table: "Livro",
                column: "StatusLivroId");

            migrationBuilder.CreateIndex(
                name: "IX_LivroEstoque_EstoqueId",
                table: "LivroEstoque",
                column: "EstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_LivroEstoque_LivroId",
                table: "LivroEstoque",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_LivroPessoa_LivroId",
                table: "LivroPessoa",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_LivroPessoa_PessoaId",
                table: "LivroPessoa",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_TipoPessoaId",
                table: "Pessoa",
                column: "TipoPessoaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EditorasFornecedores");

            migrationBuilder.DropTable(
                name: "LivroEstoque");

            migrationBuilder.DropTable(
                name: "LivroPessoa");

            migrationBuilder.DropTable(
                name: "Fornecedores");

            migrationBuilder.DropTable(
                name: "Estoque");

            migrationBuilder.DropTable(
                name: "Livro");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "ContatosFornecedores");

            migrationBuilder.DropTable(
                name: "EnderecosFornecedores");

            migrationBuilder.DropTable(
                name: "Editoras");

            migrationBuilder.DropTable(
                name: "StatusLivro");

            migrationBuilder.DropTable(
                name: "TipoPessoa");

            migrationBuilder.DropTable(
                name: "TiposTelefones");
        }
    }
}
