using System.ComponentModel.DataAnnotations;

namespace OrderMicroservice.DataAccess.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Status { get; set; } = null!;
        public DateTime OrderDate { get; set; } = DateTime.Now;
        [MaxLength(255)]
        public string? BillingAddress { get; set; }
        [MaxLength(255)]
        public string? ShippingAddress { get; set; }
        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
