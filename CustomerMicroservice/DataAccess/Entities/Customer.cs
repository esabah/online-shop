using System.ComponentModel.DataAnnotations;

namespace CustomerMicroservice.DataAccess.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        [MaxLength(50)]
        public string Surname { get; set; } = null!;
        [MaxLength(50)]
        public string? Email { get; set; }
        [MaxLength(15)]
        public string? PhoneNumber { get; set; }
        [MaxLength(255)]
        public string? Address { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
