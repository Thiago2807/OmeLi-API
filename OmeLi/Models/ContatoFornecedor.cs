using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OmeLi.Models;

public class ContatoFornecedor
{
    [Key]
    public int ContatoFornecedorId { get; set; }

    [Required]
    [Column(TypeName = "varchar(20)")]
    public string NumeroTelefone { get; set; }

    [Column(TypeName = "varchar(150)")]
    public string EnderecoEmail { get; set; }

    [Required]
    public int DddTelefone { get; set; }

    [Required]
    public int TipoTelefoneId { get; set; }
    [JsonIgnore]
    public TipoTelefone TipoTelefone { get; set; }

    [Required]
    public int FornecedorId { get; set; }
    [JsonIgnore]
    public Fornecedor Fornecedor { get; set; }
}
