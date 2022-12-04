using Microsoft.EntityFrameworkCore;
using OmeLi.Models;

namespace OmeLi.Data;

public class BDContext : DbContext
{
    public BDContext(DbContextOptions<BDContext> options) : base(options) { }

    public DbSet<TipoTelefone>? TiposTelefones { get; set; }
    public DbSet<ContatoFornecedor>? ContatosFornecedores { get; set; }
    public DbSet<EnderecoFornecedor>? EnderecosFornecedores { get; set; }
    public DbSet<Fornecedor>? Fornecedores { get; set; }
    public DbSet<EditoraFornecedor>? EditorasFornecedores { get; set; }
    public DbSet<TipoPessoa>? TiposPessoas { get; set; }
    public DbSet<StatusLivro>? StatusLivros { get; set; }
    public DbSet<Pessoa>? Pessoas { get; set; }
    public DbSet<LivroPessoa>? LivrosPessoas { get; set; }
    public DbSet<LivroEstoque>? LivrosEstoque { get; set; }
    public DbSet<Livro>? Livros { get; set; }
    public DbSet<Estoque>? Estoques { get; set; }
    public DbSet<Editora>? Editoras { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StatusLivro>().HasData(
            new StatusLivro { StatusLivroId = 1, DescStatusLivroId = "Default" },
            new StatusLivro { StatusLivroId = 2, DescStatusLivroId = "Ativo" },
            new StatusLivro { StatusLivroId = 3, DescStatusLivroId = "Desativado" },
            new StatusLivro { StatusLivroId = 4, DescStatusLivroId = "Emprestado" }
        );

        modelBuilder.Entity<TipoTelefone>().HasData(
            new TipoTelefone { TipoTelefoneId = 1, DescTipoTelefone = "Celular" },
            new TipoTelefone { TipoTelefoneId = 2, DescTipoTelefone = "Residencial" },
            new TipoTelefone { TipoTelefoneId = 3, DescTipoTelefone = "Comercial" },
            new TipoTelefone { TipoTelefoneId = 4, DescTipoTelefone = "Recado" }
        );
    }
}
