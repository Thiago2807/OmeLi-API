using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace OmeLi.Models;

public class Estoque
{
    public Estoque()
    {
        EstoqueLivros = new Collection<LivroEstoque>();
    }

    [Key]
    public int EstoqueId { get; set; }


    public ICollection<LivroEstoque>? EstoqueLivros { get; set; }
}
