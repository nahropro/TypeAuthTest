using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using ShiftSoftware.TypeAuth.Core;
using System.Security.Claims;
using TypeAuthTests;
using System.Net;

namespace TypeAuthTest.General
{
    public class TypeAuthAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly Type actionTreeType;
        private readonly string actionName;
        private readonly Access access;

        public TypeAuthAttribute(Type actionTreeType, string actionName, Access access)
        {
            this.actionTreeType = actionTreeType;
            this.actionName = actionName;
            this.access = access;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var tAuth = AccessTreeHelper.GetTypeAuthContext(AccessTreeFiles.CRMAgent);

            if (context.HttpContext.User.Identity?.IsAuthenticated??false)
            {
                if (!tAuth.Can(actionTreeType, actionName, access))
                {
                    context.Result = new ForbidResult();
                }
            }
        }
    }
}
