# 🚀 .NET API REST — DDD + SOLID + PostgreSQL

Este repositório contém uma API REST desenvolvida em **.NET**, estruturada com **Domain-Driven Design (DDD)** e princípios **SOLID**.  
O projeto está conectado ao **PostgreSQL**, utiliza **Entity Framework Core** com **Migrations**, e atualmente possui um endpoint principal: **CreateUser**.  
Também foram implementados **testes unitários** para garantir a qualidade e confiabilidade da aplicação.

---

## 📁 Estrutura do Projeto (DDD + SOLID)

├── Api
│ └── Controllers
│
├── Application
│ ├── DTOs
│ ├── Interfaces
│ └── Services
│
├── Domain
│ ├── Entities
│ ├── Interfaces
│ └── Services
│
├── Infrastructure
│ ├── Context
│ ├── Migrations
│ └── Repositories
│
├── Tests
│ ├── ApplicationTests
│ ├── DomainTests
│ └── InfrastructureTests
│
└── webApiSocietyProject.sln

## 🧪 Testes Unitários

O projeto contém testes unitários cobrindo:

- Serviços da **camada Application**

## Configurações do Banco de dados
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=SocietyDb;Username=postgres;Password=SEU_PASSWORD"
}

Host=localhost → se o banco estiver local; mude para o IP ou URL se estiver em servidor.
Port=5432 → porta padrão do PostgreSQL.
Database=nome_do_banco → nome da sua base.
Username=seu_usuario
Password=sua_senha
