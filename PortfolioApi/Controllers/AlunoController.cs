using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Data;
using PortfolioApi.Models;

namespace PortfolioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AlunoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Aluno            -> lista todos os alunos
        // GET: api/Aluno?turmaId=1  -> lista só os alunos de uma turma
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos(int? turmaId)
        {
            var consulta = _context.Alunos.AsQueryable();
            if (turmaId != null)
                consulta = consulta.Where(a => a.TurmaId == turmaId);

            return await consulta.ToListAsync();
        }

        // GET: api/Aluno/1  -> busca um aluno pelo Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
                return NotFound("Aluno não encontrado.");

            return aluno;
        }

        // GET: api/Aluno/1/portfolio  -> dados do aluno + projetos dele
        [HttpGet("{id}/portfolio")]
        public async Task<ActionResult> GetPortfolio(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
                return NotFound("Aluno não encontrado.");

            var projetos = await _context.Projetos.Where(p => p.AlunoId == id).ToListAsync();
            return Ok(new { aluno, projetos });
        }

        // POST: api/Aluno  -> cadastra um aluno
        [HttpPost]
        public async Task<ActionResult<Aluno>> CriarAluno(Aluno aluno)
        {
            if (!await _context.Turmas.AnyAsync(t => t.Id == aluno.TurmaId))
                return BadRequest("Turma não encontrada.");

            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
            return Ok(aluno);
        }

        // PUT: api/Aluno/1  -> edita um aluno
        [HttpPut("{id}")]
        public async Task<ActionResult> EditarAluno(int id, Aluno aluno)
        {
            var existente = await _context.Alunos.FindAsync(id);
            if (existente == null)
                return NotFound("Aluno não encontrado.");

            if (!await _context.Turmas.AnyAsync(t => t.Id == aluno.TurmaId))
                return BadRequest("Turma não encontrada.");

            existente.Nome = aluno.Nome;
            existente.Email = aluno.Email;
            existente.FotoUrl = aluno.FotoUrl;
            existente.Sobre = aluno.Sobre;
            existente.AreasAtuacao = aluno.AreasAtuacao;
            existente.Tecnologias = aluno.Tecnologias;
            existente.Habilidades = aluno.Habilidades;
            existente.Ferramentas = aluno.Ferramentas;
            existente.GithubUrl = aluno.GithubUrl;
            existente.LinkedinUrl = aluno.LinkedinUrl;
            existente.TurmaId = aluno.TurmaId;
            await _context.SaveChangesAsync();
            return Ok(existente);
        }

        // DELETE: api/Aluno/1  -> exclui o aluno (os projetos dele saem junto)
        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirAluno(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
                return NotFound("Aluno não encontrado.");

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
            return Ok("Aluno excluído com sucesso!");
        }
    }
}
