using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using ShiftSoftware.TypeAuth.Core;
using System.Security.Claims;

namespace TypeAuthTest.General
{
    public class TypeAuthAttribute : TypeFilterAttribute
    {
        private readonly Type actionTreeType;
        private readonly string actionName;
        private readonly Access access;

        public TypeAuthAttribute(Type actionTreeType, string actionName, Access access) : base(typeof(TypeAuthFilter))
        {
            this.actionTreeType = actionTreeType;
            this.actionName = actionName;
            this.access = access;
            Arguments
        }
    }

    public class TypeAuthFilter : IAuthorizationFilter
    {
        readonly Claim _claim;

        public TypeAuthFilter(Claim claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var hasClaim = context.HttpContext.User.Claims.Any(c => c.Type == _claim.Type && c.Value == _claim.Value);
            if (!hasClaim)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
