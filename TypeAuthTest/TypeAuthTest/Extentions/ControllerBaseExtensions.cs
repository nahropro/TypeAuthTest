using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TypeAuthTest.AccessTree;

namespace TypeAuthTest.Extentions
{
    public static class ControllerBaseExtensions
    {
        public static BaseAction GetAccessTree(this ControllerBase controller)
        {
            //Get the user id form jwt token claims
            var accessTreesJson = controller.User.Claims.SingleOrDefault(c => c.Type == "AccessTrees").Value;
            var accessTrees= JsonSerializer.Deserialize<BaseAction[]>(accessTreesJson);

            accessTrees[0].ComputeAction();

            return accessTrees[0];
        }
    }
}
