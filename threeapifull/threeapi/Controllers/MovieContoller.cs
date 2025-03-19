using THREEAPI.Services;
using Microsoft.AspNetCore.Mvc;
using THREEAPI.Models;  // Ensure this namespace matches your project

namespace THREEAPI.Controllers;

[ApiController]
[Route("api/movie")]
public class MovieController : ControllerBase
{
    private readonly MovieService _movieService;

    public MovieController(MovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet("{title}")]
    public async Task<IActionResult> GetMovieData(string title)
    {
        try
        {
            // Fetch the data from the service
            var movieData = await _movieService.GetMovieAsync(title);

            // Return the response wrapped in Ok()
            return Ok(movieData);
        }
        catch (Exception ex)
        {
            // Log the error (if necessary) and return a Problem response
            Console.WriteLine($"Error fetching movie data: {ex.Message}");
            return Problem("An error occurred while fetching the movie data.");
        }
    }
}