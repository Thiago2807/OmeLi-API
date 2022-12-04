using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OmeLi.Models;

public class TipoTelefone
{
    public TipoTelefone()
    {
        ContatosFornecedores = new Collection<ContatoFornecedor>();
    }

    [Key]
    public int TipoTelefoneId { get; set; }

    [Required]
    public string DescTipoTelefone { get; set; }

    [JsonIgnore]
    public ICollection<ContatoFornecedor> ContatosFornecedores { get; set; }
}
