namespace PortfolioApi.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? FotoUrl { get; set; }
        public string? Sobre { get; set; }          // "Quem é você"
        public string? AreasAtuacao { get; set; }   // Áreas de atuação e experiências
        public string? Tecnologias { get; set; }    // separadas por vírgula
        public string? Habilidades { get; set; }    // habilidades e certificados
        public string? Ferramentas { get; set; }    // separadas por vírgula
        public string? GithubUrl { get; set; }
        public string? LinkedinUrl { get; set; }
        public int TurmaId { get; set; }
    }
}
