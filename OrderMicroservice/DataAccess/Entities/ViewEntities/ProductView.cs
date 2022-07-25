using System.ComponentModel.DataAnnotations;

namespace OrderMicroservice.DataAccess.Entities
{
    public class ProductView
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
