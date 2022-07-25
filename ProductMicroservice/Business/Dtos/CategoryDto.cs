using System.ComponentModel.DataAnnotations;

namespace ProductMicroservice.Business.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Description { get; set; } = null!;
    }
}
