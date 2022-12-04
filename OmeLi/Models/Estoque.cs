using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OmeLi.Models;

public class Estoque
{
    public Estoque()
    {
        EstoqueLivros = new Collection<LivroEstoque>();
    }

    [Key]
    public int EstoqueId { get; set; }

    [Column]
    public int QtdLivroEstoque { get; set; }

    public string NomeEstoque { get; set; }

    public string DescEstoque { get; set; }

    public int QtdLimiteEstoque { get; set; }

    [JsonIgnore]
    public ICollection<LivroEstoque>? EstoqueLivros { get; set; }
}
