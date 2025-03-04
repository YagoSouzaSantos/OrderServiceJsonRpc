using System.Text.Json;
using System.Text.Json.Serialization;

namespace OrderServiceJsonRpc.Models
{
    public class JsonRpcRequest
    {
        [JsonPropertyName("jsonrpc")]
        public string? Jsonrpc { get; set; }

        [JsonPropertyName("method")]
        public string? Method { get; set; }

        [JsonPropertyName("params")]
        public JsonElement Params { get; set; }

        [JsonPropertyName("id")]
        public int? Id { get; set; }
    }
}


public class JsonRpcResponse
{
    public string? Jsonrpc { get; set; }
    public object? Result { get; set; }
    public object? Error { get; set; }
    public int? Id { get; set; }
}

