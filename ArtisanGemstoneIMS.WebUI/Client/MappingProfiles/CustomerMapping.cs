using ArtisanGemstoneIMS.Application.Addresses.Commands;
using ArtisanGemstoneIMS.Application.Customers.Commands;
using ArtisanGemstoneIMS.WebUI.Shared.Customers;
using AutoMapper;

namespace ArtisanGemstoneIMS.WebUI.Client.MappingProfiles;

public class CustomerMapping : Profile
{
    public CustomerMapping()
    {
        CreateMap<CustomerDetailsDto, CreateCustomerCommand>();
        CreateMap<CustomerDetailsDto, UpdateCustomerCommand>();

        CreateMap<CustomersListDto, CustomerDetailsDto>();

        CreateMap<AddressDto, CreateAddressCommand>();
        CreateMap<AddressDto, UpdateAddressCommand>();
    }
}
