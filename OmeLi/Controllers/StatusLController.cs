using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OmeLi.Data;
using OmeLi.Models;

namespace OmeLi.Controllers;

[Route("[controller]")]
[ApiController]
public class StatusLController : ControllerBase
{
    private readonly BDContext _context;

    public StatusLController(BDContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult> ListarStatus()
    {
        try
        {
            var lista = _context.StatusLivros.ToList();

            return Ok(lista);
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> DefaultStatus(int id)
    {
        try
        {
            StatusLivro status = _context.StatusLivros.FirstOrDefault(sta => sta.StatusLivroId == id);

            if (status is null)
                throw new Exception("Não foi possível encontrar um status com esse endereço Id.");

            while (true)
            {
                Livro liStatus = _context.Livros.FirstOrDefault(li => li.StatusLivroId == id);

                if (liStatus is null)
                    return Ok("Informações atualizadas com sucesso!");

                liStatus.StatusLivroId = 1;

                _context.Livros.Update(liStatus);
                await _context.SaveChangesAsync();

            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
