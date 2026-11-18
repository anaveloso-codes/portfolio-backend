using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Data;
using PortfolioApi.Models;

namespace PortfolioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TurmaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Turma  -> lista todas as turmas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Turma>>> GetTurmas()
        {
            return await _context.Turmas.ToListAsync();
        }

        // GET: api/Turma/1  -> busca uma turma pelo Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Turma>> GetTurma(int id)
        {
            var turma = await _context.Turmas.FindAsync(id);
            if (turma == null)
                return NotFound("Turma não encontrada.");

            return turma;
        }

        // POST: api/Turma  -> cadastra uma turma
        [HttpPost]
        public async Task<ActionResult<Turma>> CriarTurma(Turma turma)
        {
            _context.Turmas.Add(turma);
            await _context.SaveChangesAsync();
            return Ok(turma);
        }

        // PUT: api/Turma/1  -> edita uma turma
        [HttpPut("{id}")]
        public async Task<ActionResult> EditarTurma(int id, Turma turma)
        {
            var existente = await _context.Turmas.FindAsync(id);
            if (existente == null)
                return NotFound("Turma não encontrada.");

            existente.Nome = turma.Nome;
            existente.Curso = turma.Curso;
            existente.Periodo = turma.Periodo;
            await _context.SaveChangesAsync();
            return Ok(existente);
        }

        // DELETE: api/Turma/1  -> exclui uma turma (só se não tiver alunos)
        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirTurma(int id)
        {
            var turma = await _context.Turmas.FindAsync(id);
            if (turma == null)
                return NotFound("Turma não encontrada.");

            if (await _context.Alunos.AnyAsync(a => a.TurmaId == id))
                return BadRequest("Não é possível excluir: a turma tem alunos cadastrados.");

            _context.Turmas.Remove(turma);
            await _context.SaveChangesAsync();
            return Ok("Turma excluída com sucesso!");
        }
    }
}
