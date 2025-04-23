using Blazored.LocalStorage;
using HomeManagment.Client.Models.Auth;
using HomeManagment.Client.Providers;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace HomeManagment.Client.Services;

public class AuthService
{
    private readonly HttpClient _http;
    private readonly ILocalStorageService _storage;
    private readonly ApiAuthenticationStateProvider _authProvider;

    public AuthService(HttpClient http,
                       ILocalStorageService storage,
                       AuthenticationStateProvider authProvider)
    {
        _http = http;
        _storage = storage;
        _authProvider = (ApiAuthenticationStateProvider)authProvider;
    }

    public async Task<bool> LoginAsync(LoginRequest dto)
    {
        var res = await _http.PostAsJsonAsync("api/Auth/login", dto);
        if (!res.IsSuccessStatusCode) return false;

        var json = await res.Content.ReadAsStringAsync();
        var token = JsonDocument.Parse(json).RootElement.GetProperty("token").GetString();
        await _storage.SetItemAsync("authToken", token);

        _http.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

        _authProvider.MarkUserAsAuthenticated(token);
        return true;
    }

    public async Task LogoutAsync()
    {
        await _storage.RemoveItemAsync("authToken");
        _http.DefaultRequestHeaders.Authorization = null;
        _authProvider.MarkUserAsLoggedOut();
    }
}

