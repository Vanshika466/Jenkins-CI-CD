using THREEAPI.Services;
using Microsoft.AspNetCore.Mvc;
using THREEAPI.Models;  // Ensure this namespace matches your project

namespace THREEAPI.Controllers;

[ApiController]
[Route("api/covid")]

public class CovidController : ControllerBase
{
    private readonly CovidService _covidService;

    public CovidController(CovidService covidService)
    {
        _covidService = covidService;
    }

    [HttpGet("{country}")]
    public async Task<IActionResult> GetCovidData(string country)
    {
        try
        {
            // Fetch the data from the service
            var covidData = await _covidService.GetCovidStatsAsync(country);

            // Return the response wrapped in Ok()
            return Ok(covidData);
        }
        catch (Exception ex)
        {
            // Log the error (if necessary) and return a Problem response
            Console.WriteLine($"Error fetching covid data: {ex.Message}");
            return Problem("An error occurred while fetching the covid data.");
        }
    }
}