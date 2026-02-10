# 📦 Projeto API .NET com DDD, Autenticação JWT e Logger

Este é um projeto de API desenvolvida em **C#** utilizando os princípios do **DDD (Domain-Driven Design)**, com persistência de dados em **SQL Server**, **Entity Framework Core** como ORM, e autenticação baseada em **JWT (JSON Web Tokens)**. O projeto também utiliza **bcrypt** para hashing de senhas, **autorização de acesso por roles**, e **Serilog** para logging estruturado.

---

## 🚀 Tecnologias Utilizadas

- [.NET](https://dotnet.microsoft.com/)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- [SQL Server](https://www.microsoft.com/sql-server/)
- [JWT (JSON Web Token)](https://jwt.io/)
- [BCrypt.Net](https://github.com/BcryptNet/bcrypt.net)
- [Serilog](https://serilog.net/)
- [DDD (Domain-Driven Design)](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures#domain-driven-design)
- [MyMemory Translation API (Open Source)](https://translatedlabs.com/mymemory-pt)

---

## 🧱 Arquitetura do Projeto

O projeto segue a estrutura baseada em DDD, separando responsabilidades em diferentes camadas:

```
/src
├── Store # Camada de Apresentação (Controllers, Extensions, Configurações etc)
├── Domain # Entidades, Interfaces e ViewModels
├── Service # Serviços de Domínio
├── Infra # Implementações de Repositórios, Configurações EF, Logger, etc.
```
---

## 🔐 Segurança

- **Autenticação JWT**: Geração e validação de tokens para garantir o acesso seguro.
- **Autorização baseada em roles**: Controle de acesso às rotas via políticas e roles de usuários.
- **Criptografia de Senhas com Bcrypt**: As senhas são armazenadas de forma segura utilizando hashing com sal.

---

## 🌍 Sistema de Tradução de Mensagens (i18n)
A API conta com um sistema de tradução de mensagens de erro e sucesso, permitindo que as respostas dos endpoints sejam retornadas no idioma desejado pelo cliente.

### 🎯 Objetivo

- Padronizar mensagens de retorno.
- Facilitar internacionalização da API.
- Melhorar a experiência de consumo por aplicações front-end e mobile.

---
## 📄 Principais Funcionalidades

- ✅ CRUD completo com EF Core
- ✅ Autenticação com login e geração de JWT
- ✅ Autorização com roles (usuário, admin, etc.)
- ✅ Logger configurado com Serilog (saída para console, arquivos, etc.)
- ✅ Estrutura limpa e escalável com base em DDD

---
Desenvolvido por Kauê Correia
