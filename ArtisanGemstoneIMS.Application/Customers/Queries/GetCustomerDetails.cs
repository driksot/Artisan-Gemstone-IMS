using ArtisanGemstoneIMS.Application.Common.Exceptions;
using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.WebUI.Shared.Customers;
using AutoMapper;
using MediatR;

namespace ArtisanGemstoneIMS.Application.Customers.Queries;

public class GetCustomerDetailsQuery : IRequest<CustomerDetailsDto>
{
    public Guid Id { get; set; }
}

public class GetCustomerDetailsQueryHandler : IRequestHandler<GetCustomerDetailsQuery, CustomerDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerDetailsQueryHandler(
        IMapper mapper,
        ICustomerRepository customerRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }

    public async Task<CustomerDetailsDto> Handle(GetCustomerDetailsQuery request, CancellationToken cancellationToken)
    {
        // Query database
        var customer = await _customerRepository.GetWithDetailsByIdAsync(request.Id);

        // Verify the customer record exists
        if (customer == null)
            throw new NotFoundException(nameof(customer), request.Id);

        // Convert to CustomerDetailsDto
        var customerDetailsDto = _mapper.Map<CustomerDetailsDto>(customer);

        // Return CustomerDetailsDto
        return customerDetailsDto;
    }
}
