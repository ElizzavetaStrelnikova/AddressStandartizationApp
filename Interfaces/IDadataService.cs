using AddressStandartizationService.Models;

namespace AddressStandartizationService.Interfaces
{
    public interface IDadataService
    {
        Task<AddressResponse> CleanAddressAsync(string address);
    }
}
