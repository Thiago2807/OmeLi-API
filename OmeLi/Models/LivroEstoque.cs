using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OmeLi.Models;

public class LivroEstoque
{
    [Key]
    public int LivroEstoqueId { get; set; }

    public float QtdLivro { get; set; }
    public float QtdLimiteLivro { get; set; }

    public int LivroId { get; set; }
    [JsonIgnore]
    public Livro? Livro { get; set; }

    public int EstoqueId { get; set; }
    [JsonIgnore]
    public Estoque? Estoque { get; set; }
}
