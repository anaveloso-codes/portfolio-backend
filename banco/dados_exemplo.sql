/* =========================================================
   Dados de exemplo para a apresentação
   Rodar DEPOIS do Update-Database (as tabelas já precisam existir).
   Cadastra a turma 1DTM, a aluna Ana Luiza e os 6 projetos do portfólio.
   ========================================================= */

USE PortfolioDB;
GO

INSERT INTO Turma (Nome, Curso, Periodo) VALUES
    (N'1DTM', N'Análise e Desenvolvimento de Sistemas', N'Manhã');

DECLARE @turma INT = SCOPE_IDENTITY();

INSERT INTO Aluno (Nome, Email, FotoUrl, Sobre, AreasAtuacao, Tecnologias, Habilidades, Ferramentas, GithubUrl, LinkedinUrl, TurmaId) VALUES
    (N'Ana Luiza Veloso Barbosa', N'ana.luiza@exemplo.com', N'img/foto-ana.png',
     N'Faço o curso de Análise e Desenvolvimento de Sistemas no SENAI. Gosto de criar sistemas completos, do banco de dados até a tela.',
     N'Desenvolvimento web, criação de APIs REST em C# e banco de dados SQL Server. Projetos feitos no curso de ADS do SENAI.',
     N'C#, ASP.NET Core, Entity Framework, SQL Server, HTML, CSS, JavaScript',
     N'Trabalho em equipe, Resolução de problemas, Aprendizado rápido',
     N'Visual Studio, VS Code, Git, GitHub, Figma',
     N'https://github.com/anaveloso-codes', NULL, @turma);

DECLARE @aluna INT = SCOPE_IDENTITY();

INSERT INTO Projeto (Titulo, Descricao, Tecnologias, LinkAcesso, ImagemUrl, AlunoId) VALUES
    (N'Sistema de Portfólio', N'Cadastro de turmas, alunos e projetos com o portfólio de cada aluno. API em C# com SQL Server e telas em HTML e CSS.', N'C#, SQL Server, HTML, CSS', N'https://github.com/anaveloso-codes/portfolio-backend', NULL, @aluna),
    (N'Projeto Mecânica API', N'API para oficina mecânica: cadastro de clientes, veículos e usuários e agendamento de serviços.', N'C#, ASP.NET Core, EF Core', N'https://github.com/anaveloso-codes/ProjetoMecanica.Api', NULL, @aluna),
    (N'Clínica Veterinária API', N'API para clínica veterinária: cadastro de tutores, pets e veterinários e agendamento de consultas.', N'C#, EF Core, SQL Server', N'https://github.com/anaveloso-codes/ClinicaVeterinaria', NULL, @aluna),
    (N'Biblioteca Central API', N'API de biblioteca para cadastrar e consultar livros, com título, autor e ano de publicação.', N'C#, ASP.NET Core, EF Core', N'https://github.com/anaveloso-codes/biblioteca_central', NULL, @aluna),
    (N'Carrinho de Compras', N'Contador de itens do carrinho: a cada clique no botão a quantidade é atualizada na tela com JavaScript.', N'HTML, CSS, JavaScript', N'https://github.com/anaveloso-codes/Carrinho-de-compras', NULL, @aluna),
    (N'Bio', N'Cartão de perfil com foto, nome, cidade e uma frase de apresentação, publicado no GitHub Pages.', N'HTML, CSS', N'https://anaveloso-codes.github.io/Bio/', NULL, @aluna);
GO

SELECT * FROM Turma;
SELECT Id, Nome, TurmaId FROM Aluno;
SELECT Id, Titulo, AlunoId FROM Projeto;
