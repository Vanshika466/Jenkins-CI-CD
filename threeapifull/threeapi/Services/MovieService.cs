using System.Text.Json;
using THREEAPI.Models;
using Microsoft.Extensions.Configuration;


namespace THREEAPI.Services;

public class MovieService
{
    private readonly HttpClient _httpClient;
    private readonly  string _apiKey;

    public MovieService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiKey = configuration["OMDB:ApiKey"] ?? throw new ArgumentNullException(nameof(configuration), "API key is missing in configuration.");
    }
    public async Task<MovieModel> GetMovieAsync(string title)
    {
        var url = $"http://www.omdbapi.com/?apikey={_apiKey}&t={title}";
        var response = await _httpClient.GetAsync(url);
        var responseContent = await response.Content.ReadAsStringAsync();
        var movieData = JsonSerializer.Deserialize<JsonElement>(responseContent);
        if (movieData.GetProperty("Response").GetString() == "True")
        {
          
        return new MovieModel
        {
            Title = movieData.GetProperty("Title").GetString() ?? string.Empty,
            Year = movieData.GetProperty("Year").GetString() ?? string.Empty,
            Genre = movieData.GetProperty("Genre").GetString() ?? string.Empty,
            Director = movieData.GetProperty("Director").GetString() ?? string.Empty,
            Actors = movieData.GetProperty("Actors").GetString() ?? string.Empty,
            Plot = movieData.GetProperty("Plot").GetString() ?? string.Empty
        };
        }
        else
        {
            throw new Exception("Movie Not Found");
        }
    }

   
}