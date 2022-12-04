using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OmeLi.Ultils;
using OmeLi.Data;
using OmeLi.Models;

namespace OmeLi.Controllers;

[ApiController]
[Route("[Controller]")]
public class EnderecoPessoaController : ControllerBase
{
    private readonly BDContext _context;
    public EnderecoPessoaController(BDContext context) { _context = context; }
    public Verificar ver = new Verificar();

    [HttpPost]
    public async Task<ActionResult> InserirEnderecoPessoa(EnderecoPessoa endereco)
    {
        try
        {
            if (!ver.VerificarEndereco(endereco))
                throw new Exception("Endereço inválido.");

            await _context.EnderecosPessoas.AddAsync(endereco);
            await _context.SaveChangesAsync();

            return Ok("Endereço adicionado com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> AlterarEnderecoPessoa(int id, EnderecoPessoa endereco)
    {
        try
        {
            Pessoa pessoa = await _context.Pessoas
                .FirstOrDefaultAsync(idFor => idFor.PessoaId == id);

            if (pessoa is null)
                throw new Exception("Fornecedor não encontrado.");

            if (!ver.VerificarEndereco(endereco))
                throw new Exception("Endereço inválido.");

            _context.EnderecosPessoas.Update(endereco);
            await _context.SaveChangesAsync();

            string mensagemConclusao = string.Format($"Endereço da pessoa '{pessoa.NomePessoa}' " +
                $"foi atualizado com sucesso!");

            return Ok(mensagemConclusao);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
