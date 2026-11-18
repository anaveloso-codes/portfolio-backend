# Sistema de Portfólio — Back-end (API)

API do Sistema de Portfólio (SENAI · Análise e Desenvolvimento de Sistemas).
Cadastra turmas, alunos e projetos para montar o portfólio de cada aluno.

## Tecnologias

- C# com ASP.NET Core Web API (.NET 10)
- Entity Framework Core + SQL Server
- Swagger (documentação das rotas)

## Estrutura

```
banco/script_banco.sql   script manual de criação do banco (versão da Sprint 1)
banco/dados_exemplo.sql  turma 1DTM, aluna e 6 projetos para a apresentação
PortfolioApi/            projeto da API (Models, Data, Controllers, Migrations)
PortfolioApi.slnx        solução (abrir no Visual Studio)
```

## Modelo de entidades

```
Turma (1) ──── (N) Aluno (1) ──── (N) Projeto
```

## Como abrir o projeto

Precisa de: Visual Studio (com .NET 10 e a carga "ASP.NET e desenvolvimento para a Web") e SQL Server (o LocalDB já vem com o Visual Studio).

1. **Baixar:** botão verde **Code → Download ZIP** (ou `git clone`) e descompactar.
2. **Abrir:** no Visual Studio, abrir o arquivo `PortfolioApi.slnx`.
3. **ConnectionString:** em `PortfolioApi/appsettings.json`. Vem apontando para o LocalDB:
   ```
   Server=(localdb)\MSSQLLocalDB; Database=PortfolioDB; Trusted_Connection=True; TrustServerCertificate=True;
   ```
   No laboratório, trocar pelo servidor da sala (`Server=NOME_DO_SERVIDOR; ... User Id=sa; Password=...`).
4. **Criar o banco:** Ferramentas → Gerenciador de Pacotes do NuGet → Console, e rodar:
   ```
   Update-Database
   ```
   Se der erro de certificado, rodar no terminal `dotnet dev-certs https --trust` e tentar de novo.
5. **Dados de exemplo (opcional):** no SQL Server Management Studio, conectar no mesmo servidor e executar `banco/dados_exemplo.sql` (uma vez só).
6. **Ligar a API:** escolher o perfil **http** e apertar **F5**. O Swagger fica em http://localhost:5117/swagger
7. **Telas:** com a API ligada, abrir o `index.html` do repositório [portfolio-frontend](https://github.com/anaveloso-codes/portfolio-frontend).

> Use o `Update-Database` **ou** o `script_banco.sql`, não os dois.

## Rotas

| Recurso | Rotas |
|---|---|
| Turma | `GET /api/Turma` · `GET /api/Turma/{id}` · `POST /api/Turma` · `PUT /api/Turma/{id}` · `DELETE /api/Turma/{id}` |
| Aluno | as mesmas + `GET /api/Aluno?turmaId=1` · `GET /api/Aluno/{id}/portfolio` |
| Projeto | as mesmas + `GET /api/Projeto?alunoId=1` (máximo de 10 projetos por aluno) |

## Sprints

- [x] Sprint 0 — Planejamento (briefing, requisitos, entidades, protótipo)
- [x] Sprint 1 — Script do banco, projeto da API, repositórios
- [x] Sprint 2 — Models, DbContext, ConnectionString, Controllers (GET, POST, PUT, DELETE)
- [x] Sprint 3 — Front-end consumindo a API (manipulação do DOM)
