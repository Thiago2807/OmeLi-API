
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OmeLi.Models;

public class Editora
{
    public Editora()
    {
        Editoras = new Collection<EditoraFornecedor>();
        Livros = new Collection<Livro>();
    }

    [Key]
    public int EditoraId { get; set; }

    [Column(TypeName = "varchar(60)")]
    public string? NomeEditora { get; set; }

    [Column(TypeName = "varchar(150)")]
    public string? DescEditora { get; set; }

    [Column(TypeName = "char(14)")]
    public string? CnpjEditora { get; set; }

    public ICollection<EditoraFornecedor>? Editoras { get; set; }
    public ICollection<Livro>? Livros { get; set; }
}
