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

    [Required]
    public int QtdLivroEstoque { get; set; }

    [Required]
    [Column(TypeName = "varchar(60)")]
    public string NomeEstoque { get; set; }

    [Column(TypeName = "varchar(150)")]
    public string DescEstoque { get; set; }

    public int QtdLimiteEstoque { get; set; }

    [JsonIgnore]
    public ICollection<LivroEstoque> EstoqueLivros { get; set; }
}
