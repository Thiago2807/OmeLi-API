using System.Text.Json.Serialization;

namespace OmeLi.Models;

public class LivroPessoa
{

    public int LivroPessoaId { get; set; }

    public int LivroId { get; set; }
    [JsonIgnore]
    public Livro? Livro { get; set; }

    public int PessoaId { get; set; }
    [JsonIgnore]
    public Pessoa? Pessoa { get; set; }

}
