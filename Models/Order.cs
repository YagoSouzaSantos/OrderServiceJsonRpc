namespace OrderServiceJsonRpc.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string? Item { get; set; }
        public int Quantity { get; set; }
    }
}
