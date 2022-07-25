using System.ComponentModel.DataAnnotations;

namespace ProductMicroservice.DataAccess.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        [MaxLength(255)]
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; } = null!;

    }
}
