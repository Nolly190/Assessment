using System.Linq;
using System.Threading.Tasks;
using Assessment.PolicyAuthorization;
using Microsoft.AspNetCore.Authorization;

namespace Assessment.PolicyAuthorization
{
    public class PolicyRequirementHandler : AuthorizationHandler<PolicyRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PolicyRequirement requirement)
        {
            var actionClaim = context.User.Claims.Where(x => x.Type.ToLower() == "permissions").ToList();
            if (!actionClaim.Any() || !actionClaim.Any(x => x.Value.Contains(requirement.Status)))
            {
                return Task.CompletedTask;
            }
            context.Succeed(requirement);
            return Task.CompletedTask;

        }
    }
}
