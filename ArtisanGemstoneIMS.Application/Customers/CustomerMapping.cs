using ArtisanGemstoneIMS.Application.Customers.Commands;
using ArtisanGemstoneIMS.Domain.Customers;
using ArtisanGemstoneIMS.WebUI.Shared.Customers;
using AutoMapper;

namespace ArtisanGemstoneIMS.Application.Customers;

public class CustomerMapping : Profile
{
    public CustomerMapping()
    {
        CreateMap<Customer, CustomersListDto>();
        CreateMap<Customer, CustomerDetailsDto>();
        CreateMap<BaseCustomerDto, Customer>();
        CreateMap<CreateCustomerCommand, Customer>();
        CreateMap<UpdateCustomerCommand, Customer>();

        CreateMap<Address, AddressDto>().ReverseMap();
        CreateMap<BaseAddressDto, Address>();
    }
}
