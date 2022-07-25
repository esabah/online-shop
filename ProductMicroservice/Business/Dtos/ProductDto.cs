using System.ComponentModel.DataAnnotations;

namespace ProductMicroservice.Business.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; } = null!;
        [MaxLength(255)]
        [Required]
        public string? Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
