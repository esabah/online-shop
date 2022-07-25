using System.ComponentModel.DataAnnotations;

namespace ProductMicroservice.DataAccess.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Description { get; set; } = null!;

    }
}
