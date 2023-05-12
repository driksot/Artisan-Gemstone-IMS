using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.WebUI.Shared.Customers;
using AutoMapper;
using MediatR;

namespace ArtisanGemstoneIMS.Application.Addresses.Queries;

public record GetAddressesListQuery : IRequest<List<AddressDto>>;

public class GetAddressesListQueryHandler : IRequestHandler<GetAddressesListQuery, List<AddressDto>>
{
    private readonly IMapper _mapper;
    private readonly IAddressRepository _addressRepository;

    public GetAddressesListQueryHandler(
        IMapper mapper,
        IAddressRepository addressRepository)
    {
        _mapper = mapper;
        _addressRepository = addressRepository;
    }

    public async Task<List<AddressDto>> Handle(GetAddressesListQuery request, CancellationToken cancellationToken)
    {
        // Query database
        var addresses = await _addressRepository.GetAsync();

        // Convert to AddressesListDto
        var addressDtos = _mapper.Map<List<AddressDto>>(addresses);

        // Return list of AddressesListDtos
        return addressDtos;
    }
}
