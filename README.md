# Sistema de Portfólio — Back-end (API)

API do Sistema de Portfólio (SENAI · Análise e Desenvolvimento de Sistemas).
Cadastra turmas, alunos e projetos para montar o portfólio de cada aluno.

## Tecnologias

- C# com ASP.NET Core Web API (.NET 10)
- Entity Framework Core + SQL Server
- Swagger (documentação das rotas)

## Estrutura

```
banco/script_banco.sql   script de criação do banco (Turma, Aluno, Projeto)
PortfolioApi/            projeto da API
PortfolioApi.slnx        solução (abrir no Visual Studio)
```

## Modelo de entidades

```
Turma (1) ──── (N) Aluno (1) ──── (N) Projeto
```

## Como rodar

1. Abrir `PortfolioApi.slnx` no Visual Studio.
2. Rodar o projeto (F5). O Swagger abre no navegador.

Se der erro no `Add-Migration` ou no `Update-Database`, rodar no terminal:

```
dotnet dev-certs https --trust
```

## Sprints

- [x] Sprint 0 — Planejamento (briefing, requisitos, entidades, protótipo)
- [x] Sprint 1 — Script do banco, projeto da API, repositórios
- [x] Sprint 2 — Models, DbContext, ConnectionString, Controllers (GET, POST, PUT, DELETE)
- [x] Sprint 3 — Front-end consumindo a API (manipulação do DOM)
