using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OmeLi.Data;
using OmeLi.Models;

namespace OmeLi.Controllers;

[ApiController]
[Route("[Controller]")]
public class LivroController : ControllerBase
{
    private readonly BDContext _context;
    public LivroController  (BDContext context) { context = _context; }

    public async Task<ActionResult> ListarLivros()
    {
        try
        {
            ICollection<Livro> livros = await _context.Livros.Take(25)
                                                .AsNoTracking().ToListAsync();
            if (livros is null)
                return NotFound("Não foi possível exibir os livros cadastrados" +
                    ", por favor, verifique se existe algum livro cadastro.");

            return Ok(livros);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
