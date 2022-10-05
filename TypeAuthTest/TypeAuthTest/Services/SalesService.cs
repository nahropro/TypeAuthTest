using TypeAuthTest.DTOs.SalesDTOs;
using TypeAuthTest.Services.Interfaces;

namespace TypeAuthTest.Services
{
    public class SalesService : ISalesService
    {
        public string GetArchives()
        {
            return "List of archive sales";
        }
    }
}
