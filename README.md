# Sistema de Pedidos Simples

Este é um sistema simples de gerenciamento de pedidos, desenvolvido com ASP.NET Core e Entity Framework Core.

## Funcionalidades

- Listar todos os pedidos
- Buscar um pedido específico por ID
- Criar um novo pedido

## Tecnologias Utilizadas

- C# 12.0
- .NET 8
- ASP.NET Core
- Entity Framework Core

## Estrutura do Projeto

- **Controllers**
  - `PedidosController.cs`: Controlador responsável pelas operações de CRUD dos pedidos.
- **Models**
  - `Pedido.cs`: Modelo que representa um pedido.
  - `PedidoItem.cs`: Modelo que representa um item de pedido.
- **Data**
  - `ApiDbContext.cs`: Contexto do banco de dados.

## Instalação

1. Clone o repositório:
   git clone https://github.com/seu-usuario/sistema-de-pedidos-simples.git

2. Navegue até o diretório do projeto:
   cd sistema-de-pedidos-simples

3. Restaure as dependências do projeto:
   dotnet restore

4. Atualize o banco de dados:
   dotnet ef database update

5. Execute o projeto:
   dotnet run


## Uso

### Listar Pedidos

Endpoint: `GET /api/Pedidos/ListarPedidos`

### Buscar Pedido por ID

Endpoint: `GET /api/Pedidos/BuscarPedido/{id}`

### Criar Pedido

Endpoint: `POST /api/Pedidos`

Exemplo de corpo da requisição:
  { "cliente": "Henrick Adrian", "dataPedido": "2025-04-01T14:00:00", "itens": [ { "produto": "Mouse Gamer", "quantidade": 2, "precoUnitario": 150.00 }, { "produto": "Teclado Mecânico", "quantidade": 1, "precoUnitario": 300.00 } ] }

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir uma issue ou enviar um pull request.

## Licença

Este projeto está licenciado sob a [MIT License](LICENSE).




