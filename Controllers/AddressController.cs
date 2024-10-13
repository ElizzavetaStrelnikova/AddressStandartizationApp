using AddressStandartizationService.Interfaces;
using AddressStandartizationService.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AddressController : ControllerBase
{
    private readonly IDadataService _dadataService;
    private readonly ILogger<AddressController> _logger;

    public AddressController(IDadataService dadataService, ILogger<AddressController> logger)
    {
        _dadataService = dadataService;
        _logger = logger;
    }

    [HttpPost("clean")]
    public async Task<IActionResult> CleanAddress([FromBody] AddressRequest request)
    {
        if (string.IsNullOrEmpty(request.RawAddress))
        {
            return BadRequest("The rawAddress field is required.");
        }

        try
        {
            var cleanedAddresses = await _dadataService.CleanClientAsync(request.RawAddress);
            return Ok(cleanedAddresses);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while cleaning address.");
            return StatusCode(500, "An error occurred while trying to clean the address.");
        }
    }
}