using System.ComponentModel.DataAnnotations;

namespace OmeLi.Models;

public class LivroEstoque
{
    [Key]
    public int LivroEstoqueId { get; set; }

    public float QtdLivro { get; set; }
    public float QtdLimiteLivro { get; set; }

    public int LivroId { get; set; }
    public Livro? Livro { get; set; }

    public int EstoqueId { get; set; }
    public Estoque? Estoque { get; set; }
}
