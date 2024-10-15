using AddressStandartizationService.Interfaces;
using AddressStandartizationService.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AddressController : ControllerBase
{
    private readonly IDadataService _dadataService;
    private readonly IMapper _mapper;

    public AddressController(IDadataService dadataService, IMapper mapper)
    {
        _dadataService = dadataService;
        _mapper = mapper;
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

            var response = _mapper.Map<AddressResponse>(cleanedAddress);

            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error.");
        }
    }
}