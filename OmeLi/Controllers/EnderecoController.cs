using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OmeLi.Ultils;
using OmeLi.Data;
using OmeLi.Models;

namespace OmeLi.Controllers;

[ApiController]
[Route("[Controller]")]
public class EnderecoController : ControllerBase
{
    private readonly BDContext _context;
    public EnderecoController(BDContext context) { _context = context; }
    public Verificar ver = new Verificar();

    [HttpGet("{id:int}")]
    public async Task<ActionResult> ListarEnderecoFornecedor(int id)
    {
        try
        {
            EnderecoFornecedor endereco = await _context.EnderecosFornecedores
                .Include(fo => fo.Fornecedor)
                .FirstOrDefaultAsync(endFor => endFor.FornecedorId == id);

            if (endereco is null)
                return NotFound("Não foi possível encontrar um fornecedor.");

            return Ok(endereco);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> InserirEnderecoFornecedor(EnderecoFornecedor endereco, int id)
    {
        try
        {
            if (!ver.VerificarEndereco(endereco))
                throw new Exception("Endereço inválido.");

            await _context.EnderecosFornecedores.AddAsync(endereco);
            await _context.SaveChangesAsync();

            return Ok("Endereço adicionado com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /*[HttpPut]
    public async Task<ActionResult> AlterarEnderecoFornecedor(int id, EnderecoFornecedor endereco)
    {
        try
        {
            Fornecedor fornecedor = await _context.Fornecedores
                .FirstOrDefaultAsync(idFor => idFor.FornecedorId == id);

            if (fornecedor is null)
                throw new Exception("Fornecedor não encontrado.");

            if (!ver.VerificarEndereco(endereco))
                throw new Exception("Endereço inválido.");

            await _context.EnderecosFornecedores.AddAsync(endereco);
            await _context.SaveChangesAsync();

            string mensagemConclusao = string.Format($"Endereço do fornecedor '{fornecedor.NomeFornecedor}' " +
                $"foi atualizado com sucesso!");

            return Ok(mensagemConclusao);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }*/
}
