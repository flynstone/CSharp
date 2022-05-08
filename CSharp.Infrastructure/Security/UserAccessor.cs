using CSharp.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CSharp.Infrastructure.Security
{
    public class UserAccessor : IUserAccessor
    {
        public readonly IHttpContextAccessor _httpContextAccessor;
        public UserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUsername()
        {
            return _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        }
    }
}
