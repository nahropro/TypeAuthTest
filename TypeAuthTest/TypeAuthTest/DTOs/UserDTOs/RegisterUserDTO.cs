using System.ComponentModel.DataAnnotations;

namespace TypeAuthTest.DTOs.UserDTOs
{
    public class RegisterUserDTO
    {
        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }
    }
}
