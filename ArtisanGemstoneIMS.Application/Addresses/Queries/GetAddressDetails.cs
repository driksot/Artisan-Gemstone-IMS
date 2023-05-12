using ArtisanGemstoneIMS.Application.Common.Exceptions;
using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.WebUI.Shared.Customers;
using AutoMapper;
using MediatR;

namespace ArtisanGemstoneIMS.Application.Addresses.Queries;

public class GetAddressDetailsQuery : IRequest<AddressDto>
{
    public Guid Id { get; set; }
}

public class GetAddressDetailsQueryHandler : IRequestHandler<GetAddressDetailsQuery, AddressDto>
{
    private readonly IMapper _mapper;
    private readonly IAddressRepository _addressRepository;

    public GetAddressDetailsQueryHandler(
        IMapper mapper,
        IAddressRepository addressRepository)
    {
        _mapper = mapper;
        _addressRepository = addressRepository;
    }

    public async Task<AddressDto> Handle(GetAddressDetailsQuery request, CancellationToken cancellationToken)
    {
        var address = await _addressRepository.GetByIdAsync(request.Id);

        if (address == null)
            throw new NotFoundException(nameof(address), request.Id);

        var addressDto = _mapper.Map<AddressDto>(address);

        return addressDto;
    }
}
