using System.ComponentModel.DataAnnotations;
using TypeAuthTest.AccessTree;

namespace TypeAuthTest.DTOs.RoleDTOs
{
    public class CreateRoleDTO
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public BaseAction AccessTree { get; set; }
    }
}
