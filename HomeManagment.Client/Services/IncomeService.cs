using HomeManagment.Client.Interfaces;
using HomeManagment.Client.Models.Income;
using System.Net.Http.Json;
using System.Text.Json;

namespace HomeManagment.Client.Services;

public class IncomeService : IIncomeService
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions options;

    public IncomeService(HttpClient httpClient)
    {
        _client = httpClient;
        options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<List<GetIncomeRequest>> GetAllIncomes()
    {
        var response = await _client.GetAsync("api/Income");
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        return JsonSerializer.Deserialize<List<GetIncomeRequest>>(content, options);
    }
    public async Task CreateIncome(CreateIncomeRequest createIncomeRequest)
    {
        var response = await _client.PostAsJsonAsync("api/Income", createIncomeRequest);
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
    }
}
