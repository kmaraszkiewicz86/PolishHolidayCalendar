using System.Text.Json;
using PolishHolidayCalendar.Domain.Entities;

namespace PolishHolidayCalendar.Infrastructure.HttpServices;

public class PolishHolidayHttpService : IPolishHolidayHttpService
{
    private readonly HttpClient _httpClient;

    public PolishHolidayHttpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<PublicHoliday>> GetPublicHolidaysAsync(int year, string countryCode)
    {
        var url = $"https://date.nager.at/api/v3/PublicHolidays/{year}/{countryCode}";
        
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        
        var json = await response.Content.ReadAsStringAsync();
        
        try
        {
            var holidays = JsonSerializer.Deserialize<List<PublicHoliday>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            
            return holidays ?? new List<PublicHoliday>();
        }
        catch (JsonException ex)
        {
            throw new InvalidOperationException(
                $"Failed to deserialize public holidays response from {url}. Response: {json}", ex);
        }
    }
}
