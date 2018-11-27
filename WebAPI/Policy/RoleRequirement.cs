using Microsoft.AspNetCore.Authorization;
using SERVICE.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAPI.Policy
{
    public class RoleRequirement : IAuthorizationRequirement
    {
        public string Role { get; set; }

        public RoleRequirement(string Role)
        {
            this.Role = Role;
        }
    }

    public class RoleRequirementHandler : AuthorizationHandler<RoleRequirement>
    {
        private IUserService userService;
        private IRoleService roleService;

        public RoleRequirementHandler(IUserService userService, IRoleService roleService)
        {
            this.userService = userService;
            this.roleService = roleService;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.Role) || !context.User.HasClaim(c => c.Type == ClaimTypes.Name))
            {
                return Task.CompletedTask;
            }

            var accountName = context.User.FindFirst(c => c.Type == ClaimTypes.Name).Value.ToString();
            var roleName = context.User.FindFirst(c => c.Type == ClaimTypes.Role).Value.ToString();
            var user = userService.GetUser(accountName);
            var role = roleService.GetRole(roleName);
            if (user == null || role == null)
            {
                return Task.CompletedTask;
            }
            else
            {
                if (roleName == requirement.Role && requirement.Role == role.Name && user.RoleId == role.Id)
                {
                    context.Succeed(requirement);
                }
            }
            return Task.CompletedTask;
        }
    }
}
