# Order Service JSON-RPC
## Descrição do Projeto:
Este projeto implementa um serviço de pedidos utilizando a arquitetura JSON-RPC e o framework .NET. O objetivo é fornecer uma API que permita criar, consultar e listar pedidos.
Não há utilização de banco de dados, e os pedidos são armazenados em memória (uma lista na aplicação). A comunicação com o serviço é feita através do protocolo JSON-RPC.

## Arquitetura MVC:
- Model: Define a estrutura dos pedidos.
- Controller: Gerencia a lógica dos pedidos (criação, consulta e listagem).
- View: Implementa a API JSON-RPC que expõe os métodos.

## Dependências:
- .NET 9.0
- ASP.NET Core
- JSON-RPC 2.0

# Objetivos:
- Criar, consultar e listar pedidos.
- Utilizar JSON-RPC para a comunicação com a API.
- Armazenar pedidos em uma lista em memória (sem banco de dados).

# Orientações:
- Endpoints: Todos os endpoints são acessados via POST para a URL /rpc.
- Métodos JSON-RPC: Os métodos suportados são createOrder, getOrder e listOrders.
- Parâmetros de Entrada: A entrada é enviada como um objeto JSON, conforme especificado nos exemplos de requisição.
- Respostas: As respostas seguem o formato JSON-RPC 2.0, incluindo os campos jsonrpc, result, error e id.
- Armazenamento: Os pedidos são armazenados em memória durante a execução do servidor, portanto, os dados não são persistidos entre reinicializações.



