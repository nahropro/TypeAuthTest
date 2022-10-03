using TypeAuthTest.DTOs.RoleDTOs;

namespace TypeAuthTest.DTOs.UserDTOs
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public List<RoleDTO> Roles { get; set; }

        public UserDTO()
        {
            Roles = new();
        }
    }
}
