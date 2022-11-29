using System.ComponentModel.DataAnnotations;

namespace OmeLi.Models;

public class EditoraFornecedor
{
    [Key]
    public int EditoraFornecedorId { get; set; }

    public int FornecedorId { get; set; }
    public Fornecedor? Fornecedor { get; set; }

    public int EditoraId { get; set; }
    public Editora? Editora { get; set; }
}
