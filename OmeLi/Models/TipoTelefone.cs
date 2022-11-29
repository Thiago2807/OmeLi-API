using System.Collections.ObjectModel;

namespace OmeLi.Models;

public class TipoTelefone
{
    public TipoTelefone()
    {
        ContatosFornecedores = new Collection<ContatoFornecedor>();
    }

    public int TipoTelefoneId { get; set; }
    public string? DescTipoTelefone { get; set; }

    public ICollection<ContatoFornecedor>? ContatosFornecedores { get; set; }
}
