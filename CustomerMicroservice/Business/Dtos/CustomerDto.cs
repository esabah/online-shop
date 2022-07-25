using System.ComponentModel.DataAnnotations;

namespace CustomerMicroservice.Business.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; } = null!;
        [MaxLength(50)]
        [Required]
        public string Surname { get; set; } = null!;
        [MaxLength(50)]
        [Required]
        public string? Email { get; set; }
        [MaxLength(15)]
        [Required]
        public string? PhoneNumber { get; set; }
        [MaxLength(255)]
        public string? Address { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
