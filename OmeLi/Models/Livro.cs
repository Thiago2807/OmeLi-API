using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OmeLi.Models;

public class Livro
{
    public Livro()
    {
        LivrosEstoque = new Collection<LivroEstoque>();
        LivrosPessoas = new Collection<LivroPessoa>();
    }

    [Key]
    public int LivroId { get; set; }

    [Required]
    [Column(TypeName = "varchar(60)")]
    public string? NomeLivro { get; set; }

    [Required]
    [MaxLength(350)]
    public string? DescLivro { get; set; }

    public int StatusLivroId { get; set; }
    public StatusLivro? StatusLivro { get; set; }

    public int EditoraId { get; set; }
    public Editora? Editora { get; set; }

    public ICollection<LivroEstoque>? LivrosEstoque { get; set; }

    public ICollection<LivroPessoa>? LivrosPessoas { get; set; }
}