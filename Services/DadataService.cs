using AddressStandartizationService.Interfaces;
using AddressStandartizationService.Models;
using System.Net.Http.Headers;

public class DadataService : IDadataService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    private readonly ILogger<DadataService> _logger;

    public DadataService(IHttpClientFactory httpClientFactory, IConfiguration configuration, ILogger<DadataService> logger)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<List<AddressResponse>?> CleanClientAsync(string rawAddress)
    {
        var client = _httpClientFactory.CreateClient();

        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Authorization", _configuration["Dadata:ApiKey"]);
        client.DefaultRequestHeaders.Add("X-Secret", _configuration["Dadata:X-Secret"]);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_configuration["Dadata:Accept"]));

        var requestBody = new AddressRequest { RawAddress = rawAddress };

        try
        {
            var response = await client.PostAsJsonAsync(_configuration["Dadata:Url"], requestBody);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<AddressResponse>>() ?? new List<AddressResponse>();
            }

            var errorContent = await response.Content.ReadAsStringAsync();
            _logger.LogError($"Error calling Dadata API: {response.ReasonPhrase}. Content: {errorContent}");
            throw new Exception("Error calling external API.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while trying to clean the address: {Message}", ex.Message);
            throw new Exception("An error occurred while trying to clean the address.", ex);
        }
    }
}