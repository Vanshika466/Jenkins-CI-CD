using THREEAPI.Services;
using Microsoft.AspNetCore.Mvc;
using THREEAPI.Models;  // Ensure this namespace matches your project

namespace THREEAPI.Controllers;

[ApiController]
[Route("api/crypto")]
public class CryptoController : ControllerBase
{
    private readonly CryptoService _cryptoService;

    public CryptoController(CryptoService cryptoService)
    {
        _cryptoService = cryptoService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCryptoPrice(string id)
    {
        try
        {
            // Fetch the price from the service
            var cryptoData = await _cryptoService.GetCryptoPriceAsync(id);

            // Return the response wrapped in Ok()
            return Ok(cryptoData);
        }
        catch (Exception ex)
        {
            // Log the error (if necessary) and return a Problem response
            Console.WriteLine($"Error fetching crypto price: {ex.Message}");
            return Problem("An error occurred while fetching the crypto price.");
        }
    }
}
