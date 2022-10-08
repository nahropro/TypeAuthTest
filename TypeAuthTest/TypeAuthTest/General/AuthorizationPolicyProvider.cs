using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Text.Json;
using TypeAuthTest.AccessTree;

namespace TypeAuthTest.General
{
    public class AuthorizationPolicyProvider : DefaultAuthorizationPolicyProvider
    {
        private readonly AuthorizationOptions _options;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AuthorizationPolicyProvider(IOptions<AuthorizationOptions> options, IHttpContextAccessor httpContextAccessor) 
            : base(options)
        {
            _options = options.Value;
            this.httpContextAccessor = httpContextAccessor;
        }

        public override async Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            // Check static policies first
            var policy = await base.GetPolicyAsync(policyName);

            if (policy == null)
            {
                var accessTreesJson = httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(c => c.Type == "AccessTrees").Value;
                var accessTrees = JsonSerializer.Deserialize<BaseAction[]>(accessTreesJson);

                accessTrees[0].ComputeAction();

                policy = new AuthorizationPolicyBuilder().RequireAssertion(c => true)
                    .Build();

                // Add policy to the AuthorizationOptions, so we don't have to re-create it each time
                _options.AddPolicy(policyName, policy);
            }

            return policy;
        }

        //public override async Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        //{
        //    // Check static policies first
        //    var policy = await base.GetPolicyAsync(policyName);

        //    if (policy == null)
        //    {
        //        var accessTreesJson = httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(c => c.Type == "AccessTrees").Value;
        //        var accessTrees = JsonSerializer.Deserialize<BaseAction[]>(accessTreesJson);

        //        accessTrees[0].ComputeAction();

        //        policy = new AuthorizationPolicyBuilder().RequireAssertion(c => PolicyAssertion(accessTrees[0],policyName))
        //            .Build();

        //        // Add policy to the AuthorizationOptions, so we don't have to re-create it each time
        //        _options.AddPolicy(policyName, policy);
        //    }

        //    return policy;
        //}

        //private bool PolicyAssertion(PolicyConfiguration acessTree, string policyName, PolicyConfiguration parent = null)
        //{
        //    if (acessTree.ActionName.ToLower() == policyName.ToLower())
        //    {
        //        return acessTree.ComputePolicy();
        //    }
        //    else
        //    {
        //        var bojType = acessTree.GetType();
        //        IList<PropertyInfo> props = new List<PropertyInfo>(bojType.GetProperties())
        //            .Where(x =>
        //                x.PropertyType.BaseType.Name == nameof(PolicyConfiguration)
        //                && x.PropertyType != parent?.GetType()
        //            ).ToList();

        //        foreach (var prop in props)
        //        {
        //            if(PolicyAssertion((PolicyConfiguration)prop.GetValue(acessTree), policyName, acessTree))
        //                return true;
        //        }
        //    }

        //    return false;
        //}
    }
}
