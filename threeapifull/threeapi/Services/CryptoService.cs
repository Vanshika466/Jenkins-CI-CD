using System.Text.Json;
using THREEAPI.Models;

namespace THREEAPI.Services;

public class CryptoService
{
    private readonly HttpClient _httpClient;

    public CryptoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CryptoModel> GetCryptoPriceAsync(string id)
    {
        var url =$"https://api.coingecko.com/api/v3/simple/price?ids={id}&vs_currencies=usd";
        var response = await _httpClient.GetAsync(url);
        var responseContent = await response.Content.ReadAsStringAsync();
        var cryptoData = JsonSerializer.Deserialize<JsonElement>(responseContent);
        
        return new CryptoModel
        {
            Crypto = id,
            Price = cryptoData.GetProperty(id).GetProperty("usd").GetDecimal()
        };
    }
}
