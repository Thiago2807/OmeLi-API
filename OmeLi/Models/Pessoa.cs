using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OmeLi.Models;

public class Pessoa
{
    public Pessoa()
    {
        PessoasLivros = new Collection<LivroPessoa>();
    }

    [Key]
    public int PessoaId { get; set; }

    [Column(TypeName = "varchar(60)")]
    public string? NomePessoa { get; set; }

    [Column(TypeName = "varchar(60)")]
    public string? SobrenomePessoa { get; set; }

    [Column(TypeName = "char(11)")]
    public string? CpfPessoa { get; set; }

    public DateTime DtNascimento { get; set; }

    public int TipoPessoaId { get; set; }
    [JsonIgnore]
    public TipoPessoa? TipoPessoa { get; set; }

    [JsonIgnore]
    public ICollection<LivroPessoa>? PessoasLivros { get; set; }
}
