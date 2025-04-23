using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HomeManagment.Client.Providers;

public class ApiAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _storage;
    private readonly JwtSecurityTokenHandler _jwtHandler = new();

    public ApiAuthenticationStateProvider(ILocalStorageService storage)
    {
        _storage = storage;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await _storage.GetItemAsync<string>("authToken");
        if (string.IsNullOrWhiteSpace(token))
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

        var jwt = _jwtHandler.ReadJwtToken(token);
        var claims = jwt.Claims;
        var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
        return new AuthenticationState(user);
    }

    public void MarkUserAsAuthenticated(string token)
    {
        var jwt = _jwtHandler.ReadJwtToken(token);
        var user = new ClaimsPrincipal(new ClaimsIdentity(jwt.Claims, "jwt"));
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
    }

    public void MarkUserAsLoggedOut()
    {
        NotifyAuthenticationStateChanged(Task.FromResult(
            new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()))
        ));
    }

}
