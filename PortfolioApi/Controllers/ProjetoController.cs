using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Data;
using PortfolioApi.Models;

namespace PortfolioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly AppDbContext _context;
        private const int MaximoDeProjetos = 10;

        public ProjetoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Projeto            -> lista todos os projetos
        // GET: api/Projeto?alunoId=1  -> lista só os projetos de um aluno
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projeto>>> GetProjetos(int? alunoId)
        {
            var consulta = _context.Projetos.AsQueryable();
            if (alunoId != null)
                consulta = consulta.Where(p => p.AlunoId == alunoId);

            return await consulta.ToListAsync();
        }

        // GET: api/Projeto/1  -> busca um projeto pelo Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Projeto>> GetProjeto(int id)
        {
            var projeto = await _context.Projetos.FindAsync(id);
            if (projeto == null)
                return NotFound("Projeto não encontrado.");

            return projeto;
        }

        // POST: api/Projeto  -> cadastra um projeto (no máximo 10 por aluno)
        [HttpPost]
        public async Task<ActionResult<Projeto>> CriarProjeto(Projeto projeto)
        {
            if (!await _context.Alunos.AnyAsync(a => a.Id == projeto.AlunoId))
                return BadRequest("Aluno não encontrado.");

            int quantidade = await _context.Projetos.CountAsync(p => p.AlunoId == projeto.AlunoId);
            if (quantidade >= MaximoDeProjetos)
                return BadRequest("Esse aluno já tem 10 projetos, que é o limite do portfólio.");

            _context.Projetos.Add(projeto);
            await _context.SaveChangesAsync();
            return Ok(projeto);
        }

        // PUT: api/Projeto/1  -> edita um projeto
        [HttpPut("{id}")]
        public async Task<ActionResult> EditarProjeto(int id, Projeto projeto)
        {
            var existente = await _context.Projetos.FindAsync(id);
            if (existente == null)
                return NotFound("Projeto não encontrado.");

            existente.Titulo = projeto.Titulo;
            existente.Descricao = projeto.Descricao;
            existente.Tecnologias = projeto.Tecnologias;
            existente.LinkAcesso = projeto.LinkAcesso;
            existente.ImagemUrl = projeto.ImagemUrl;
            await _context.SaveChangesAsync();
            return Ok(existente);
        }

        // DELETE: api/Projeto/1  -> exclui um projeto
        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirProjeto(int id)
        {
            var projeto = await _context.Projetos.FindAsync(id);
            if (projeto == null)
                return NotFound("Projeto não encontrado.");

            _context.Projetos.Remove(projeto);
            await _context.SaveChangesAsync();
            return Ok("Projeto excluído com sucesso!");
        }
    }
}
