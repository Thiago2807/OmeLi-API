using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OmeLi.Models;

public class LivroEstoque
{
    [Key]
    public int LivroEstoqueId { get; set; }

    [Required]
    public int QtdLivro { get; set; }
    public int QtdLimiteLivro { get; set; }

    [Required]
    public int LivroId { get; set; }
    [JsonIgnore]
    public Livro Livro { get; set; }

    [Required]
    public int EstoqueId { get; set; }
    [JsonIgnore]
    public Estoque Estoque { get; set; }
}
