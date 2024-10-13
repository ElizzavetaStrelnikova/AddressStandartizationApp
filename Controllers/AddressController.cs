using AddressStandartizationService.Interfaces;
using AddressStandartizationService.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AddressController : ControllerBase
{
    private readonly IDadataService _dadataService;

    public AddressController(IDadataService dadataService)
    {
        _dadataService = dadataService;
    }

    [HttpPost("clean")]
    public async Task<IActionResult> CleanAddress([FromBody] AddressRequest request)
    {
        if (string.IsNullOrEmpty(request.Address))
        {
            return BadRequest("Address cannot be empty.");
        }

        try
        {
            var cleanedAddress = await _dadataService.CleanAddressAsync(request.Address);
            return Ok(cleanedAddress);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error.");
        }
    }
}