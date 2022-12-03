using OmeLi.Models;

namespace OmeLi.Ultils;

public class Verificar
{
    public bool VerificarEndereco(EnderecoFornecedor endereco)
    {
        if ((endereco.EnderecoForn.Length <= 5) || (endereco.BairroEndereco.Length <= 5) ||
                (endereco.CidadeEndereco.Length <= 5))
            return false;
        if (endereco.NumeroEndereco.Length < 1)
            return false;
        if (endereco.CepEndereo.Length != 8)
            return false;
        if (endereco.UfEndereco.Length != 2)
            return false;

        return true;
    }
}
