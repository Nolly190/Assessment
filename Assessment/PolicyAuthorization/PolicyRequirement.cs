using Microsoft.AspNetCore.Authorization;

namespace Assessment.PolicyAuthorization
{
    public class PolicyRequirement : IAuthorizationRequirement
    {
        public string Status { get; set; }
        public PolicyRequirement(string status)
        {
            Status = status;
        }
    }
}
