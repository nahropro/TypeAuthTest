namespace TypeAuthTest.DTOs.UserDTOs
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public IEnumerable<RoleDTO> Roles { get; set; }
    }
}
