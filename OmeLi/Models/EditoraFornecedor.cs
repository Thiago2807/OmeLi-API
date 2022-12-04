using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OmeLi.Models;

public class EditoraFornecedor
{
    [Key]
    public int EditoraFornecedorId { get; set; }

    public int FornecedorId { get; set; }
    [JsonIgnore]
    public Fornecedor? Fornecedor { get; set; }

    public int EditoraId { get; set; }
    [JsonIgnore]
    public Editora? Editora { get; set; }
}
