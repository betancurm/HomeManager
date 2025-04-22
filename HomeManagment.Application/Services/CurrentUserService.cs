using HomeManagment.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace HomeManagment.Application.Services;
public class CurrentUserService : ICurrentUserService
{
    public Guid UserId { get; }
    public CurrentUserService(IHttpContextAccessor http)
    {
        var id = http.HttpContext?.User.FindFirst("uid")?.Value;
        UserId = id is not null ? Guid.Parse(id) : Guid.Empty;
    }
}
