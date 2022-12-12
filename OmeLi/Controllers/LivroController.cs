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

    [HttpGet("ListLi")]
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

    [HttpPost("InserirLi")]
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

    [HttpPut("AtEd")]
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

    [HttpPut("AtEdMassa")]
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

    [HttpPost("EmpreLi")]
    public async Task<ActionResult> EmpresLivro(int idCliente, int idLivro, int qtde)
    {
        try
        {
            if (idCliente == 2)
                throw new Exception("Não será possível emprestar um livro para essa pessoa.");

            Pessoa cliente = await _context.Pessoas.FirstOrDefaultAsync(cli => cli.PessoaId == idCliente);
            Livro livro = await _context.Livros.FirstOrDefaultAsync(li => li.LivroId == idLivro);
            Estoque estoque = await _context.Estoques.FirstOrDefaultAsync(es => es.EstoqueId == 1);

            if (livro.QtdeLivro <= 0)
                throw new Exception($"O livro '{livro.NomeLivro}' estar indisponível no momento, verifique a quantidade.");

            if (livro.StatusLivroId == 3)
                throw new Exception($"O livro '{livro.NomeLivro}' estar indisponível no momento, verifique o status do livro ");

            LivroPessoa associacao = new LivroPessoa();

            associacao.LivroId = idLivro;
            associacao.PessoaId = idCliente;
            associacao.StatusAssociacao = 2;
            associacao.QtdeEmprestada = qtde;
            associacao.DataDevolucao = DateTime.Now.AddMonths(1);

            int qtdeLivro = livro.QtdeLivro - qtde;
            int QtdeEstoqueAtual = (estoque.QtdLivroEstoque - livro.QtdeLivro) + qtdeLivro;

            livro.QtdeLivro = qtdeLivro;
            estoque.QtdLivroEstoque = QtdeEstoqueAtual;

            await _context.LivrosPessoas.AddAsync(associacao);
            _context.Estoques.Update(estoque);
            _context.Livros.Update(livro);
            await _context.SaveChangesAsync();

            string mensagem = string.Format("Livro '{0}' foi emprestado para '{1} {2}' " +
                "A data de devolução é {3:dd} de {3:MMMM} de {3:yyyy}",
                livro.NomeLivro, cliente.NomePessoa, cliente.SobrenomePessoa, associacao.DataDevolucao);

            return Ok(mensagem);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPost("DevLi")]
    public async Task<ActionResult> DevolverLivro(int idAssociacao)
    {
        try
        {
            LivroPessoa livroPessoa = await _context.LivrosPessoas.FirstOrDefaultAsync(lp => lp.LivroPessoaId == idAssociacao);

            if (livroPessoa is null)
                return NotFound("Não foi possível encontrar.");
            if (livroPessoa.StatusAssociacao != 2)
                throw new Exception("Esse livro não pode ser devolvido.");

            livroPessoa.StatusAssociacao = 3;

            Livro livro = await _context.Livros.FirstOrDefaultAsync(li => li.LivroId == livroPessoa.LivroId);
            Estoque estoque = await _context.Estoques.FirstOrDefaultAsync(es => es.EstoqueId == 1);

            estoque.QtdLivroEstoque = (estoque.QtdLivroEstoque - livro.QtdeLivro) + (livro.QtdeLivro + livroPessoa.QtdeEmprestada);
            livro.QtdeLivro = livro.QtdeLivro + livroPessoa.QtdeEmprestada;

            _context.LivrosPessoas.Update(livroPessoa);
            _context.Estoques.Update(estoque);
            _context.Livros.Update(livro);
            await _context.SaveChangesAsync();

            string mensagem = string.Format($"Livro '{livro.NomeLivro}' devolvido com sucesso.\n" +
                $"Estoque atualizado com sucesso!\n" +
                $"Quantidade de livros atualizados com sucesso!");

            return Ok(mensagem);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
