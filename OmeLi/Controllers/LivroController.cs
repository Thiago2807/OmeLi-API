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
    public LivroController  (BDContext context) 
    { 
        _context = context; 
    }

    [HttpGet]
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

    [HttpPost("InserirLivro")]
    public async Task<ActionResult> InserirLivro(Livro livro)
    {
        try
        {
            Editora livroEditora = await _context.Editoras
                .FirstOrDefaultAsync(le => le.EditoraId == livro.EditoraId);

            StatusLivro livroStatus = await _context.StatusLivros
                .FirstOrDefaultAsync(ls => ls.StatusLivroId == livro.StatusLivroId);

            if (livroEditora is null)
                return NotFound("Editora não encontrada.");
            if (livroStatus is null)
                return NotFound("Status não cadastrado.");

            if (livro.NomeLivro.Length <= 1)
                throw new Exception("Nome do livro inválido.");
            if (livro.DescLivro.Length <= 30)
                throw new Exception("Descrição do livro inválido");

            if (livro.QtdeLivro < 0)
                throw new Exception("Quantidade do livro inválida.");

            Estoque estoque = await _context.Estoques.FirstOrDefaultAsync(es => es.EstoqueId == 1);
            int QtdeAtualEstoque = estoque.QtdLivroEstoque;

            estoque.QtdLivroEstoque = QtdeAtualEstoque + livro.QtdeLivro;

            _context.Estoques.Update(estoque);
            await _context.Livros.AddAsync(livro);
            await _context.SaveChangesAsync();

            return Ok($"Livro cadastrado com sucesso, o seu id é '{livro.LivroId}'.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("AtEditora")]
    public async Task<ActionResult> AtualizarEditora(int idLivro, int idEditora)
    {
        try
        {
            Livro livro = await _context.Livros.FirstOrDefaultAsync(li => li.LivroId == idLivro);

            if (livro is null)
                throw new Exception("Livro não encontrado.");

            Editora editora = await _context.Editoras.FirstOrDefaultAsync(edi => edi.EditoraId == idEditora);

            if (editora is null)
                throw new Exception("Editora não cadastrada.");

            livro.EditoraId = idEditora;

            _context.Livros.Update(livro);
            await _context.SaveChangesAsync();

            return Ok($"Editora do livro '{livro.NomeLivro}' atualizado com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("AtEditoraMassa")]
    public async Task<ActionResult> AtualizarEditoraMass(int idEditoraAntigo, int idEditoraNovo)
    {
        try
        {
            int contQtdLivro = 0;

            while (true)
            {
                Livro liEditora = _context.Livros.FirstOrDefault(li => li.EditoraId == idEditoraAntigo);

                if (liEditora is null && contQtdLivro >= 1)
                    return Ok($"{contQtdLivro} livros atualizados com sucesso!");
                if (liEditora is null && contQtdLivro == 1)
                    return Ok($"{contQtdLivro} livro atualizado com sucesso!");

                if (liEditora is null && contQtdLivro == 0)
                    return Ok($"Não existe um livro associado a editora com id '{idEditoraAntigo}'.");

                liEditora.EditoraId = idEditoraNovo;

                _context.Livros.Update(liEditora);
                await _context.SaveChangesAsync();

                contQtdLivro++;
            }
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("AtQtde")]
    public async Task<ActionResult> AtualizarQtdeEstoque(int idLivro, int qtdeLivro)
    {
        try
        {
            Livro livro = await _context.Livros.FirstOrDefaultAsync(li => li.LivroId == idLivro);
            Estoque estoque = await _context.Estoques.FirstOrDefaultAsync(es => es.EstoqueId == 1);

            if (livro is null)
                return NotFound("Livro não encontrado.");

            int QtdeEstoqueAtual = (estoque.QtdLivroEstoque - livro.QtdeLivro) + qtdeLivro;

            livro.QtdeLivro = qtdeLivro;
            estoque.QtdLivroEstoque = QtdeEstoqueAtual;

            _context.Estoques.Update(estoque);
            _context.Livros.Update(livro);
            await _context.SaveChangesAsync();

            return Ok("Quantidade de livros atualizada com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpDelete]
    public async Task<ActionResult> ExcluirLivro(int idLivro)
    {
        try
        {
            Livro livro = await _context.Livros.FirstOrDefaultAsync(li => li.LivroId == idLivro);

            if (livro is null)
                return NotFound("Livro não encontrado.");

            //LivroPessoa livroPessoa = await _context.LivrosPessoas
            //.FirstOrDefaultAsync(li => li.LivroId == idLivro && li.StatusAssociacao == 1);

            //Pessoa pessoaLivro = await _context.Pessoas.FirstOrDefaultAsync(pe => pe.PessoaId == livroPessoa.PessoaId);

            //if (livroPessoa != null)
            //throw new Exception($"Não foi possível excluir um livro" +
            // $", pois algum cliente está com associada a esse livro" +
            // $" ,por favor mude os status de associação para continuar.");

            Estoque estoque = await _context.Estoques.FirstOrDefaultAsync(es => es.EstoqueId == 1);

            estoque.QtdLivroEstoque = estoque.QtdLivroEstoque - livro.QtdeLivro;

            _context.Estoques.Update(estoque);
            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();

            return Ok($"Livro '{livro.NomeLivro}' foi removido com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
