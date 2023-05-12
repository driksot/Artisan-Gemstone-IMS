using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.WebUI.Shared.Customers;
using AutoMapper;
using MediatR;

namespace ArtisanGemstoneIMS.Application.Customers.Queries;

public record GetCustomersListQuery : IRequest<List<CustomersListDto>>;

public class GetCustomersListQueryHandler : IRequestHandler<GetCustomersListQuery, List<CustomersListDto>>
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;

    public GetCustomersListQueryHandler(
        IMapper mapper,
        ICustomerRepository customerRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }

    public async Task<List<CustomersListDto>> Handle(GetCustomersListQuery request, CancellationToken cancellationToken)
    {
        // Query database
        var customers = await _customerRepository.GetWithDetailsAsync();

        // Convert to CustomersListDto
        var customersListDtos = _mapper.Map<List<CustomersListDto>>(customers);

        // Return list of CustomersListDtos
        return customersListDtos;
    }
}
