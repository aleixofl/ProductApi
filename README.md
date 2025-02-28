# API de Produtos

## Descrição
Esta é uma API RESTful desenvolvida com **.NET 8** para gerenciamento de produtos. A API permite realizar operações CRUD (Criar, Ler, Atualizar e Deletar) para produtos armazenados em um banco de dados **SQL Server**.

A API utiliza **Swagger** para documentar e testar os endpoints de forma interativa.

## Tecnologias Utilizadas

- **.NET 8**: Framework para desenvolvimento da aplicação backend.
- **SQL Server**: Banco de dados relacional utilizado para armazenar os produtos.
- **Entity Framework Core (EF Core)**: ORM utilizado para interagir com o banco de dados.
- **Swagger**: Para documentação e testes interativos da API.
- **Postman** ou **cURL**: Alternativas para testar a API, além do Swagger.

## Pré-requisitos

- **.NET 8 SDK** (https://dotnet.microsoft.com/download/dotnet/8.0)
- **SQL Server** (local ou remoto)
- **Git** (https://git-scm.com/downloads)
- **Editor de código** como [Visual Studio](https://visualstudio.microsoft.com/) ou [VS Code](https://code.visualstudio.com/)
- **Postman** ou **cURL** para testar a API, se preferir não usar o Swagger.

## Instruções para rodar o projeto localmente

### Passos para configurar o projeto

1. **Clone o repositório**:
   Abra o terminal e execute o seguinte comando para clonar o repositório:
   ```bash
   git clone https://github.com/usuario/nome-do-repositorio.git

2. Configuração do banco de dados:

	- Crie um banco de dados SQL Server.
		- Para criar a tabela pegue o Script do arquivo: "Script-CreateTabelaProducts.sql" execute no Sql Server  		Management Studio

	- Adapte a string de conexão no arquivo appsettings.json
	- Certifique-se de que a conta de usuário tenha permissões para criar tabelas no banco.

3. Restaurar as dependências: Navegue até a pasta do projeto e execute o comando abaixo para restaurar as dependências:

	dotnet restore

4. Rodar o projeto: Após restaurar as dependências, execute o comando para rodar a API localmente:

	dotnet run --project ProdutoAPI/ProdutoAPI.csproj

	O Swagger abrirá uma interface gráfica com todos os endpoints da API e permitirá que você faça requisições para cada um 	deles diretamente pelo navegador.


Endpoints Disponíveis
	Produtos
		- GET /api/produtos: Lista todos os produtos.
		- GET /api/produtos/{id}: Obtém um produto específico pelo ID.
		- POST /api/produtos: Cria um novo produto.
		- PUT /api/produtos/{id}: Atualiza um produto existente.
		- DELETE /api/produtos/{id}: Exclui um produto pelo ID

