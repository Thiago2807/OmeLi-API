using System.ComponentModel.DataAnnotations;

namespace OmeLi.Models;

public class Livro
{
    [Key]
    public int LivroId { get; set; }
}