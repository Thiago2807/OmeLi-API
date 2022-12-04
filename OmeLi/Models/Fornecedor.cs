using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;

namespace OmeLi.Models;

public class Fornecedor
{
    public Fornecedor()
    {
        Fornecedores = new Collection<EditoraFornecedor>();
        ContatosFornecedor = new Collection<ContatoFornecedor>();
    }

    [Key]
    public int FornecedorId { get; set; }

    [Column(TypeName = "varchar(60)")]
    public string? NomeFornecedor { get; set; }

    [Column(TypeName = "char(14)")]
    public string? CnpjFornecedor { get; set; }

    public ICollection<ContatoFornecedor> ContatosFornecedor { get; set; }

    public EnderecoFornecedor EnderecoFornecedor { get; set; }

    public ICollection<EditoraFornecedor> Fornecedores { get; set; }
}
