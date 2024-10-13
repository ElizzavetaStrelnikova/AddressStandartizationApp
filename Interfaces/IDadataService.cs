using AddressStandartizationService.Models;

namespace AddressStandartizationService.Interfaces
{
    public interface IDadataService
    {
        Task<List<AddressResponse>> CleanClientAsync(string rawAddress);
    }
}
