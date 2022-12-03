using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OmeLi.Data;
using OmeLi.Models;

namespace OmeLi.Controllers;

[ApiController]
[Route("[Controller]")]
public class EnderecoController : ControllerBase
{
    private readonly BDContext _context;
    public EnderecoController(BDContext context) { _context = context; } 

    [HttpGet("{id:int}")]
    public async Task<ActionResult> ListarEnderecoFornecedor(int id)
    {
        try
        {
            Fornecedor endereco = await _context.Fornecedores
                .Include(endereco => endereco.EnderecoFornecedor)
                .FirstOrDefaultAsync(endFor => endFor.EnderecoFornecedorId == id);

            if (endereco is null)
                return NotFound("Não foi possível encontrar um fornecedor.");

            return Ok(endereco);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
