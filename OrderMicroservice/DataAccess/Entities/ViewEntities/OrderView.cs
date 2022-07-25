using System.ComponentModel.DataAnnotations;

namespace OrderMicroservice.DataAccess.Entities
{
    public class OrderView
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        [MaxLength(50)]
        public string CustomerName { get; set; } = null!;
        [MaxLength(50)]
        public string CustomerSurName { get; set; } = null!;
        [MaxLength(50)]
        public string? CustomerEmail { get; set; }
        [MaxLength(15)]
        public string? CustomerPhoneNumber { get; set; }
        [MaxLength(255)]
        public string? BillingAddress { get; set; }
        [MaxLength(255)]
        public string? ShippingAddress { get; set; }
        public IEnumerable<OrderDetailView>? OrderDetails { get; set; }
    }
}
