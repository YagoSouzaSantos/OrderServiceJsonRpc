using System.Collections.Generic;
using OrderServiceJsonRpc.Models;

namespace OrderServiceJsonRpc.Controllers
{
    public class OrderController
    {
        private static readonly List<Order> orders = new List<Order>();
        private static int nextId = 1;

        public Order CreateOrder(int customerId, string item, int quantity)
        {
            var order = new Order
            {
                Id = nextId++,
                CustomerId = customerId,
                Item = item,
                Quantity = quantity
            };
            orders.Add(order);
            return order;
        }

        public Order GetOrder(int id)
        {
            var order = orders.FirstOrDefault(o => o.Id == id);
            return order ?? throw new InvalidOperationException("Pedido não encontrado.");
        }

        public List<Order> ListOrders()
        {
            return orders;
        }
    }
}
