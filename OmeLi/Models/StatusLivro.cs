using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OmeLi.Models;

public class StatusLivro
{
    [Key]
    public int StatusLivroId { get; set; }

    [Column(TypeName = "varchar(15)")]
    public string? DescStatusLivroId { get; set; }

    public ICollection<Livro>? Livros { get; set; }
}
