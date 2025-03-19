using System.Text.Json;
using THREEAPI.Models;

namespace THREEAPI.Services;

public class CovidService
{
    private readonly HttpClient _httpClient;

    public CovidService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CovidModel> GetCovidStatsAsync(string country)
    {
        var url = $"https://disease.sh/v3/covid-19/countries/{country}";
        var response = await _httpClient.GetAsync(url);
        var responseContent = await response.Content.ReadAsStringAsync();
        var covidData = JsonSerializer.Deserialize<JsonElement>(responseContent);

        return new CovidModel
        {
            Country = covidData.GetProperty("country").GetString() ?? string.Empty,
            Cases = covidData.GetProperty("cases").GetInt32(),
            Deaths = covidData.GetProperty("deaths").GetInt32(),
            Recovered = covidData.GetProperty("recovered").GetInt32(),
            Active = covidData.GetProperty("active").GetInt32()
        };
}
}