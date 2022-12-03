using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OmeLi.Models;

public class EnderecoFornecedor
{
    [Key]
    public int EnderecoFornecedorId { get; set; }

    [Required]
    [Column(TypeName = "varchar(100)")]
    public string? EnderecoForn { get; set; }

    [Column(TypeName = "varchar(10)")]
    public string? NumeroEndereco { get; set; }

    [Column(TypeName = "varchar(20)")]
    public string? ComplementoEndereco { get; set; }

    [Column(TypeName = "varchar(40)")]
    public string? BairroEndereco { get; set; }

    [Column(TypeName = "varchar(50)")]
    public string? CidadeEndereco { get; set; }

    [Column(TypeName = "varchar(13)")]
    public string? CepEndereo { get; set; }

    [Column(TypeName = "char(2)")]
    public string? UfEndereco { get; set; }

    //Criando o relacionamento de um para um
    public int FornecedorId { get; set; }
    public Fornecedor? Fornecedor { get; set; }
}
