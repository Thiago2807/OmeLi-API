namespace OmeLi.Models;

public class LivroPessoa
{

    public int LivroPessoaId { get; set; }

    public int LivroId { get; set; }
    public Livro? Livro { get; set; }

    public int PessoaId { get; set; }
    public Pessoa? Pessoa { get; set; }

}
