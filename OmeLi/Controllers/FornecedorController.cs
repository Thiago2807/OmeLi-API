using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OmeLi.Data;
using OmeLi.Models;

namespace OmeLi.Controllers;

[ApiController]
[Route("[Controller]")]
public class FornecedorController : ControllerBase
{
    private readonly BDContext _context;
    public FornecedorController(BDContext context) { _context = context; }

    [HttpGet]
    public async Task<ActionResult> ListarFornecedores()
    {
        try
        {
            List<Fornecedor> fornecedores = await _context.Fornecedores.ToListAsync();

            if (fornecedores is null)
                throw new Exception("Não existe nenhum fornecedor cadastrado.");

            return Ok(fornecedores);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> InserirFornecedor(Fornecedor fornecedor)
    {
        try
        {
            if (fornecedor.NomeFornecedor == string.Empty || fornecedor.NomeFornecedor.Length >= 60)
                throw new Exception("Nome do fornecedor inválido.");

            if (fornecedor.CnpjFornecedor == string.Empty)
                throw new Exception("Cnpj do fornecedor inválido.");

            await _context.Fornecedores.AddAsync(fornecedor);
            await _context.SaveChangesAsync();

            return Ok($"Fornecedor '{fornecedor.NomeFornecedor}' cadastrado com sucesso!");
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
