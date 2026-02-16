# 🚗 Blacklist API --- ASP.NET

API REST desenvolvida em **ASP.NET** para gerenciamento de uma blacklist
de carros, inspirada no universo de *Need for Speed Most Wanted*.\
O objetivo principal do projeto é praticar conceitos reais de
desenvolvimento back-end e fluxo de trabalho com Git.

------------------------------------------------------------------------

## 🎯 Objetivo do projeto

Este projeto foi criado com foco em aprendizado prático, aplicando
conceitos comuns em ambientes profissionais, como:

-   Criação de APIs REST
-   Separação entre **Entity** e **DTO**
-   Uso correto de verbos HTTP
-   Retornos com status codes apropriados
-   Versionamento com **Git e GitHub**
-   Fluxo de trabalho com **branches e Pull Requests**

------------------------------------------------------------------------

## 🧱 Estrutura do projeto

O projeto segue uma estrutura simples e clara:

    Controllers/
        BlacklistController.cs

    DTOs/
        CreateBlacklistRequest.cs
        UpdateBlacklistRequest.cs
        BlacklistResponse.cs

    Models/
        Blacklist.cs

------------------------------------------------------------------------

## 🔌 Endpoints disponíveis

### 🔍 Listar todos os itens

    GET /api/blacklists

Retorna todos os carros da blacklist.

------------------------------------------------------------------------

### 🔎 Buscar por id

    GET /api/blacklists/{id}

Retorna um item específico da blacklist.

**Respostas:** - `200 OK` → item encontrado - `404 Not Found` → item não
existe

------------------------------------------------------------------------

### ➕ Criar item

    POST /api/blacklists

**Body:**

``` json
{
  "carName": "BMW M3 GTR",
  "reason": "Dominou todas as corridas"
}
```

**Resposta:** - `200 Ok` → item criado

------------------------------------------------------------------------

### ✏️ Atualizar item

    PUT /api/blacklists/{id}

**Body:**

``` json
{
  "carName": "Toyota Supra",
  "reason": "Atualizado"
}
```

**Respostas:** - `204 No Content` → atualização realizada -
`404 Not Found` → item não existe

------------------------------------------------------------------------

### ❌ Deletar item

    DELETE /api/blacklists/{id}

**Respostas:** - `204 No Content` → item removido - `404 Not Found` →
item não existe

------------------------------------------------------------------------

## 🔄 Fluxo de dados (DTO → Entity)

A API utiliza DTOs para separar o contrato da API da estrutura interna:

    Request DTO → Controller → Entity → "Banco"
    Banco → Entity → Response DTO → Cliente

Isso permite:

-   Maior segurança
-   Flexibilidade para evoluir o sistema
-   Melhor organização do código

------------------------------------------------------------------------

## 🧪 Persistência

Atualmente, os dados são armazenados em **lista em memória**, apenas
para fins de estudo.

**Futuras melhorias:** - Integração com banco de dados - Entity
Framework - Camada de serviços

------------------------------------------------------------------------

## 🌿 Fluxo de trabalho com Git

Durante o desenvolvimento, foi utilizado um fluxo semelhante ao de
ambientes profissionais:

-   Criação de branch para a feature
-   Commits organizados por alteração
-   Push da branch
-   Abertura de Pull Request
-   Ajustes após code review

------------------------------------------------------------------------

## 🚀 Tecnologias utilizadas

-   .NET / ASP.NET
-   C#
-   Git
-   GitHub

------------------------------------------------------------------------

## 📌 Próximos passos

-   Integração com banco de dados
-   Validações com Data Annotations
-   Camada de serviços
-   Testes automatizados
