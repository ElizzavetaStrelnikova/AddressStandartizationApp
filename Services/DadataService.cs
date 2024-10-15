using AddressStandartizationService.Interfaces;
using AddressStandartizationService.Models;
using Microsoft.Extensions.Options;

public class DadataService : IDadataService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly DadataSettings _settings;

    public DadataService(IHttpClientFactory httpClientFactory, IOptions<DadataSettings> options)
    {
        _httpClientFactory = httpClientFactory;
        _settings = options.Value;
    }

    public async Task<AddressResponse> CleanAddressAsync(string address)
    {
        var client = _httpClientFactory.CreateClient();

        client.DefaultRequestHeaders.Add("Authorization", $"Token {_settings.ApiKey}");
        client.DefaultRequestHeaders.Add("X-Secret", _settings.SecretKey);

        var requestBody = new[] { address };
        var response = await client.PostAsJsonAsync("https://cleaner.dadata.ru/api/v1/clean/address", requestBody);

        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<AddressResponse[]>();
        return result?.FirstOrDefault();
    }
}