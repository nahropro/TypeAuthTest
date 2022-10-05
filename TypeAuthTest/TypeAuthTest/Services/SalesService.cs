using System.Security.Authentication;
using System.Security.Claims;
using TypeAuthTest.DTOs.SalesDTOs;
using TypeAuthTest.Extentions;
using TypeAuthTest.Services.Interfaces;

namespace TypeAuthTest.Services
{
    public class SalesService : ISalesService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public SalesService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public string GetArchives()
        {
            if(!httpContextAccessor.GetAccessTree().Sales.ViewArchive.ComputePolicy())
                throw new AuthenticationException("You don't have this permistion!");

            return "List of archive sales";
        }
    }
}
