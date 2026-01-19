using System.Text.Json;
using PolishHolidayCalendar.Domain.Entities;
using PolishHolidayCalendar.Domain.Interfaces;

namespace PolishHolidayCalendar.Infrastructure.Services;

public class HttpService : IHttpService
{
    private readonly HttpClient _httpClient;

    public HttpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<PublicHoliday>> GetPublicHolidaysAsync(int year, string countryCode)
    {
        var url = $"https://date.nager.at/api/v3/PublicHolidays/{year}/{countryCode}";
        
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        
        var json = await response.Content.ReadAsStringAsync();
        var holidays = JsonSerializer.Deserialize<List<PublicHoliday>>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        
        return holidays ?? new List<PublicHoliday>();
    }
}
