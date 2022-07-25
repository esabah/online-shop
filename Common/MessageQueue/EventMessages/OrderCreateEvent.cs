using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.MessageQueue.EventMessages
{
    public class OrderCreateEvent
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; } = null!;
        public string CustomerSurName { get; set; } = null!;
        public string CustomerEmail { get; set; } = null!;
        public string CustomerPhoneNumber { get; set; } = null!;
        public string BillingAddress { get; set; } = null!;
        public string ShippingAddress { get; set; } = null!;
        public IEnumerable<OrderDetailCreateEvent>? OrderDetails { get; set; }
    }

    public class OrderDetailCreateEvent
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
