using TypeAuthTest.AccessTree;

namespace TypeAuthTest.DTOs.RoleDTOs
{
    public class RoleDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public BaseAction AccessTree { get; set; }
    }
}
