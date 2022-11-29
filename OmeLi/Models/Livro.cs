using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OmeLi.Models;

public class Livro
{
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
}