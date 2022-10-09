using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using ShiftSoftware.TypeAuth.Core.Actions;
using System.Reflection;
using System.Text.Json;
using TypeAuth.AccessTree;
using TypeAuth.AccessTree.ActionTrees;
using TypeAuthTest.AccessTree;
using static TypeAuth.AccessTree.ActionTrees.SystemActions;

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
                var policyNameSplit= policyName.Split('.');
                var department = policyNameSplit[0];
                var action = policyNameSplit[1];

                var tAuth = AccessTreeHelper.GetTypeAuthContext(AccessTreeFiles.Affiliates);
                var depFieldInfo = GetDepartment(department);
                var depVal = depFieldInfo.GetValue(depFieldInfo);
                
                if (action.ToLower() == "read")
                {
                    policy = new AuthorizationPolicyBuilder().RequireAssertion(c => 
                    tAuth.CanRead((ReadWriteDeleteAction)depVal))
                    .Build();
                }
                else if (action.ToLower() == "write")
                {
                    policy = new AuthorizationPolicyBuilder().RequireAssertion(c =>
                    tAuth.CanWrite((ReadWriteDeleteAction)depVal))
                    .Build();
                }
                else if (action.ToLower() == "delete")
                {
                    policy = new AuthorizationPolicyBuilder().RequireAssertion(c =>
                    tAuth.CanDelete((ReadWriteDeleteAction)depVal))
                    .Build();
                }

                // Add policy to the AuthorizationOptions, so we don't have to re-create it each time
                _options.AddPolicy(policyName, policy);
            }

            return policy;
        }

        private FieldInfo GetDepartment(string name)
        {
            var crmType = typeof(CRMActions);
            var loginType = typeof(Login);
            var userModelType = typeof(UserModule);

            List<FieldInfo> fields = new List<FieldInfo>();

            fields.AddRange(crmType.GetFields().Where(x => x.FieldType == typeof(ReadAction) ||
                x.FieldType == typeof(ReadWriteAction) ||
                x.FieldType == typeof(ReadWriteDeleteAction) ||
                x.FieldType == typeof(BooleanAction)));

            fields.AddRange(loginType.GetFields().Where(x => x.FieldType == typeof(ReadAction) ||
                x.FieldType == typeof(ReadWriteAction) ||
                x.FieldType == typeof(ReadWriteDeleteAction) ||
                x.FieldType == typeof(BooleanAction)));

            fields.AddRange(userModelType.GetFields().Where(x => x.FieldType == typeof(ReadAction) ||
                x.FieldType == typeof(ReadWriteAction) ||
                x.FieldType == typeof(ReadWriteDeleteAction) ||
                x.FieldType == typeof(BooleanAction)));

            return fields?.FirstOrDefault(x => x.Name?.ToLower() == name.ToLower());
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
