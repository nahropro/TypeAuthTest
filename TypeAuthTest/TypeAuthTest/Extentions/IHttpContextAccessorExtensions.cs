using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TypeAuthTest.AccessTree;

namespace TypeAuthTest.Extentions
{
    public static class IHttpContextAccessorExtensions
    {
        public static BaseAction GetAccessTree(this IHttpContextAccessor context)
        {
            //Get the user id form jwt token claims
            var accessTreesJson = context.HttpContext.User.Claims.SingleOrDefault(c => c.Type == "AccessTrees").Value;
            var accessTrees = JsonSerializer.Deserialize<BaseAction[]>(accessTreesJson);

            accessTrees[0].ComputeAction();

            return accessTrees[0];
        }
    }
}
