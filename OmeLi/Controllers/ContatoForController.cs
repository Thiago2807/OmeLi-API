using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OmeLi.Data;
using OmeLi.Models;

namespace OmeLi.Controllers;

[ApiController]
[Route("[Controller]")]
public class ContatoForController : ControllerBase
{
    private readonly BDContext _context;
    public ContatoForController(BDContext context) { _context = context; }

    [HttpGet]
    public async Task<ActionResult> ListarTiposTelefone()
    {   
        try
        {
            List<TipoTelefone> tipos = _context.TiposTelefones
                .Include(con => con.ContatosFornecedores)
                .AsNoTracking()
                .Take(25)
                .ToList();

            if (tipos.Count() < 1)
                return NotFound("Não foi possível listar os tipos de telefone.");

            return Ok(tipos);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> InserirContato(ContatoFornecedor contato)
    {
        try
        {
            await _context.ContatosFornecedores.AddAsync(contato);
            await _context.SaveChangesAsync();

            return Ok("Contato cadastrado com sucesso!");
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
