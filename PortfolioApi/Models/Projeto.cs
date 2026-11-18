namespace PortfolioApi.Models
{
    public class Projeto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string? Tecnologias { get; set; }
        public string? LinkAcesso { get; set; }
        public string? ImagemUrl { get; set; }      // link da imagem ou do vídeo
        public int AlunoId { get; set; }
    }
}
