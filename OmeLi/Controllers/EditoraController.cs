using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OmeLi.Data;
using OmeLi.Models;

namespace OmeLi.Controllers;

[ApiController]
[Route("[Controller]")]
public class EditoraController : ControllerBase
{
    private readonly BDContext _context;
    public EditoraController(BDContext context)
    {
        _context = context;
    }

    public async Task<ActionResult> ListarEditora()
    {
        try
        {
            ICollection<Editora> editoras = await _context.Editoras.ToListAsync();

            if (editoras is null)
                return NotFound("Não foi possível exibir as editoras, " +
                    "por favor verifique se existe alguma editora cadastrada.");

            return Ok(editoras);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
