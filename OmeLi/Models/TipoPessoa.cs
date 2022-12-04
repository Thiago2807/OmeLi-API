using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OmeLi.Models;

public class TipoPessoa
{
    public TipoPessoa ()
    {
        Pessoas = new Collection<Pessoa>();
    }

    [Key]
    public int TipoPessoaId { get; set; }

    [Required]
    [Column(TypeName = "varchar(15)")]
    public string DescTipoPessoa { get; set; }

    public ICollection<Pessoa> Pessoas { get; set; }
}
