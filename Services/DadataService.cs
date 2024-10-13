using AddressStandartizationService.Interfaces;
using AddressStandartizationService.Models;
using System.Net.Http.Headers;

public class DadataService : IDadataService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;

    public DadataService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }

    public async Task<AddressResponse> CleanAddressAsync(string address)
    {
        var apiKey = _configuration["Dadata:ApiKey"];
        var secretKey = _configuration["Dadata:SecretKey"];

        var client = _httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.Add("Authorization", $"Token {apiKey}");
        client.DefaultRequestHeaders.Add("X-Secret", secretKey);

        var requestBody = new[] { address };
        var response = await client.PostAsJsonAsync("https://cleaner.dadata.ru/api/v1/clean/address", requestBody);

        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<AddressResponse[]>();
        return result?.FirstOrDefault();
    }
}