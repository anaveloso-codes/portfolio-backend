using Microsoft.EntityFrameworkCore;
using PortfolioApi.Models;

namespace PortfolioApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Projeto> Projetos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Nomes das tabelas iguais ao script do banco (no singular)
            modelBuilder.Entity<Turma>().ToTable("Turma");
            modelBuilder.Entity<Aluno>().ToTable("Aluno");
            modelBuilder.Entity<Projeto>().ToTable("Projeto");

            // Um aluno pertence a uma turma
            modelBuilder.Entity<Aluno>()
                .HasOne<Turma>()
                .WithMany()
                .HasForeignKey(a => a.TurmaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Um projeto pertence a um aluno (excluiu o aluno, excluem os projetos)
            modelBuilder.Entity<Projeto>()
                .HasOne<Aluno>()
                .WithMany()
                .HasForeignKey(p => p.AlunoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
