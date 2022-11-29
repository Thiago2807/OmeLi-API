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
    public DbSet<Editora>? Editoras { get; set; }
}
