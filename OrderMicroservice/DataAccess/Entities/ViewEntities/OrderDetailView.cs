using System.ComponentModel.DataAnnotations;

namespace OrderMicroservice.DataAccess.Entities
{
    public class OrderDetailView
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        [MaxLength(50)]
        public string ProductName { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
