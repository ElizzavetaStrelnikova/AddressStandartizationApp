using AddressStandartizationService.Models;
using AutoMapper;

namespace AddressStandartizationService.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddressRequest, AddressResponse>();
        }
    }
}
