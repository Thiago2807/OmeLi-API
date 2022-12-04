using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

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

    [JsonIgnore]
    public ICollection<ContatoFornecedor> ContatosFornecedor { get; set; }

    [JsonIgnore]
    public EnderecoFornecedor EnderecoFornecedor { get; set; }

    [JsonIgnore]
    public ICollection<EditoraFornecedor> Fornecedores { get; set; }
}
