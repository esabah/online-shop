using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey("CategoryId")]
        public Category Category { get; set; } = null!;
        [Required]
        public int CategoryId { get; set; }

    }
}
