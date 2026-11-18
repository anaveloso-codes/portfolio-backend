/* =========================================================
   Sistema de Portfólio — SENAI ADS
   Script do banco de dados (SQL Server)
   Entidades: Turma (1) ---- (N) Aluno (1) ---- (N) Projeto
   ========================================================= */

-- 1. Criar o banco
IF DB_ID('PortfolioDB') IS NULL
    CREATE DATABASE PortfolioDB;
GO

USE PortfolioDB;
GO

-- 2. Tabela Turma
CREATE TABLE Turma (
    Id        INT IDENTITY(1,1) PRIMARY KEY,
    Nome      NVARCHAR(100) NOT NULL,
    Curso     NVARCHAR(150) NOT NULL,
    Periodo   NVARCHAR(20)  NOT NULL   -- Manhã, Tarde ou Noite
);
GO

-- 3. Tabela Aluno (cada aluno pertence a uma turma)
CREATE TABLE Aluno (
    Id            INT IDENTITY(1,1) PRIMARY KEY,
    Nome          NVARCHAR(150) NOT NULL,
    Email         NVARCHAR(150) NOT NULL,
    FotoUrl       NVARCHAR(500) NULL,
    Sobre         NVARCHAR(1000) NULL,  -- "Quem é você"
    AreasAtuacao  NVARCHAR(1000) NULL,  -- Áreas de atuação e experiências
    Tecnologias   NVARCHAR(500) NULL,   -- separadas por vírgula
    Habilidades   NVARCHAR(500) NULL,   -- habilidades e certificados
    Ferramentas   NVARCHAR(500) NULL,   -- separadas por vírgula
    GithubUrl     NVARCHAR(300) NULL,
    LinkedinUrl   NVARCHAR(300) NULL,
    TurmaId       INT NOT NULL,
    CONSTRAINT FK_Aluno_Turma FOREIGN KEY (TurmaId) REFERENCES Turma(Id)
);
GO

-- 4. Tabela Projeto (cada projeto pertence a um aluno)
CREATE TABLE Projeto (
    Id           INT IDENTITY(1,1) PRIMARY KEY,
    Titulo       NVARCHAR(150) NOT NULL,
    Descricao    NVARCHAR(1000) NOT NULL,
    Tecnologias  NVARCHAR(500) NULL,
    LinkAcesso   NVARCHAR(500) NULL,
    ImagemUrl    NVARCHAR(500) NULL,   -- link da imagem ou do vídeo
    AlunoId      INT NOT NULL,
    CONSTRAINT FK_Projeto_Aluno FOREIGN KEY (AlunoId) REFERENCES Aluno(Id) ON DELETE CASCADE
);
GO

-- 5. Dados de exemplo
INSERT INTO Turma (Nome, Curso, Periodo) VALUES
    (N'1DTM', N'Análise e Desenvolvimento de Sistemas', N'Manhã');

INSERT INTO Aluno (Nome, Email, Sobre, AreasAtuacao, Tecnologias, Habilidades, Ferramentas, TurmaId) VALUES
    (N'Ana Luiza Veloso Barbosa', N'ana.luiza@exemplo.com',
     N'Estudante de ADS no SENAI. Gosto de criar sistemas que resolvem problemas reais.',
     N'Desenvolvimento web full stack, APIs REST e banco de dados.',
     N'C#, .NET, HTML, CSS, JavaScript, SQL Server',
     N'Trabalho em equipe, Certificado Git e GitHub',
     N'Visual Studio, VS Code, Git, Figma', 1);

INSERT INTO Projeto (Titulo, Descricao, Tecnologias, LinkAcesso, AlunoId) VALUES
    (N'Sistema de Portfólio', N'Cadastro de turmas, alunos e projetos com portfólio online.', N'C#, SQL Server, HTML, CSS', NULL, 1),
    (N'Projeto Mecânica API', N'API para oficina mecânica: clientes, veículos, usuários e agendamentos.', N'C#, ASP.NET Core, EF Core', N'https://github.com/anaveloso-codes/ProjetoMecanica.Api', 1),
    (N'Clínica Veterinária API', N'API para clínica veterinária: tutores, pets, veterinários e consultas.', N'C#, EF Core, SQL Server', N'https://github.com/anaveloso-codes/ClinicaVeterinaria', 1);
GO

-- 6. Conferir
SELECT * FROM Turma;
SELECT * FROM Aluno;
SELECT * FROM Projeto;
