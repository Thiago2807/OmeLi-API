using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OmeLi.Data;
using OmeLi.Models;
using OmeLi.Ultils;

namespace OmeLi.Controllers;

[ApiController]
[Route("[Controller]")]
public class PessoasController : ControllerBase
{
    private readonly BDContext _context;
    public PessoasController(BDContext context) { _context = context; }

    [HttpGet("ListarPer")]
    public async Task<ActionResult> ListarPessoas()
    {
        try
        {
            ICollection<Pessoa> pessoa = await _context.Pessoas
                                                    .AsNoTracking()
                                                    .Take(10)
                                                    .ToListAsync();

            if (pessoa is null)
                throw new Exception("Não existe nenhuma pessoa cadastrado.");

            return Ok(pessoa);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("ListarContatoPe/{id:int}")]
    public async Task<ActionResult> ConsultarContatoPessoa(int id)
    {
        try
        {
                Pessoa contatoPes = await _context.Pessoas
                    .Include(pe => pe.ContatosPessoas)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(pe => pe.PessoaId == id);

            if (contatoPes is null)
                return NotFound("Pessoa não cadastrada.");

            return Ok(contatoPes);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("ListarEnderecoPe/{id:int}")]
    public async Task<ActionResult> ListarEnderecoPessoa(int id)
    {
        try
        {
            Pessoa endereco = await _context.Pessoas
                .Include(pe => pe.EnderecoPessoa)
                .AsNoTracking()
                .FirstOrDefaultAsync(endFor => endFor.PessoaId == id);

            if (endereco is null)
                return NotFound("Não foi possível encontrar uma pessoa.");

            return Ok(endereco);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("InserirPessoa")]
    public async Task<ActionResult> InserirPessoa(Pessoa pessoa)
    {
        try
        {
            Verificar ver = new Verificar();

            if ((pessoa.NomePessoa == string.Empty || pessoa.NomePessoa.Length >= 60) ||
                (pessoa.SobrenomePessoa == string.Empty || pessoa.SobrenomePessoa.Length >= 60))
                throw new Exception("Nome do fornecedor inválido.");

            if (!ver.VerificarPriDigito(pessoa.CpfPessoa.ToCharArray()))
                throw new Exception("Cpf da pessoa inválido.");
            if (!ver.VerificarSegDigito(pessoa.CpfPessoa.ToCharArray()))
                throw new Exception("Cpf da pessoa inválido.");

            await _context.Pessoas.AddAsync(pessoa);
            await _context.SaveChangesAsync();

            return Ok($"Pessoa '{pessoa.NomePessoa} {pessoa.SobrenomePessoa}' cadastrado com sucesso!");
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("DeletarPe/{id:int}")]
    public async Task<ActionResult> DeletarPessoa(int id)
    {
        try
        {
            Pessoa pessoa = await _context.Pessoas
                .Include(end => end.EnderecoPessoa)
                .Include(con => con.ContatosPessoas)
                .FirstOrDefaultAsync(fo => fo.PessoaId == id);

            if (pessoa is null)
                throw new Exception("Não foi possível encontrar uma pessoa.");

            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();

            string mensagemConclusao = string.Format($"Pessoa '{pessoa.NomePessoa}'" +
                $" excluido com sucesso!");

            return Ok(mensagemConclusao);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
