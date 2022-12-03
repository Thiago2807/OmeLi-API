using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OmeLi.Models;

public class ContatoFornecedor
{
    [Key]
    public int ContatoFornecedorId { get; set; }

    [Required]
    [Column(TypeName = "varchar(20)")]
    public string? NumeroTelefone { get; set; }

    [Column(TypeName = "varchar(150)")]
    public string? EnderecoEmail { get; set; }

    [Required]
    public int DddTelefone { get; set; }

    public int TipoTelefoneId { get; set; }
    public TipoTelefone? TipoTelefone { get; set; }

    public int FornecedorId { get; set; }
    public Fornecedor? Fornecedor { get; set; }
}
