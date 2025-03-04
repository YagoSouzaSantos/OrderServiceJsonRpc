using System.Text.Json;
using OrderServiceJsonRpc.Controllers;
using OrderServiceJsonRpc.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseHttpsRedirection();

app.MapPost("/rpc", async (HttpContext context) =>
{
    using var reader = new StreamReader(context.Request.Body);
    var requestBody = await reader.ReadToEndAsync();

    Console.WriteLine($"Recebido: {requestBody}");

    var request = System.Text.Json.JsonSerializer.Deserialize<JsonRpcRequest>(requestBody);

    Console.WriteLine($"Método recebido: {request?.Method}");

    var orderController = new OrderController();

    var response = new JsonRpcResponse();
    
    if (request?.Method == "createOrder" && request.Params.ValueKind != JsonValueKind.Undefined)
    {
        var customerId = request.Params.GetProperty("customerId").GetInt32();
        var item = request.Params.GetProperty("item").GetString() ?? string.Empty;
        var quantity = request.Params.GetProperty("quantity").GetInt32();
        
        var order = orderController.CreateOrder(customerId, item, quantity);
        response = new JsonRpcResponse
        {
            Jsonrpc = "2.0",
            Result = order,
            Id = request.Id
        };
    }
    else if (request?.Method == "getOrder" && request.Params.ValueKind != JsonValueKind.Undefined)
    {
        var id = request.Params.GetProperty("id").GetInt32();
        var order = orderController.GetOrder(id);
        response = new JsonRpcResponse
        {
            Jsonrpc = "2.0",
            Result = order,
            Id = request.Id
        };
    }
    else if (request?.Method == "listOrders")
    {
        var orders = orderController.ListOrders();
        response = new JsonRpcResponse
        {
            Jsonrpc = "2.0",
            Result = orders,
            Id = request.Id
        };
    }
    else
    {
        response = new JsonRpcResponse
        {
            Jsonrpc = "2.0",
            Error = new { code = -32601, message = "Método não encontrado" },
            Id = request?.Id
        };
    }

    return Results.Json(response);
});

app.Run();
