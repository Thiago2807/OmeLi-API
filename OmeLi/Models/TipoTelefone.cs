using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

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

    public ICollection<ContatoFornecedor> ContatosFornecedores { get; set; }
}
