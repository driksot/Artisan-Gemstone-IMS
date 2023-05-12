using ArtisanGemstoneIMS.Application.Common.Exceptions;
using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.Domain.Customers;
using MediatR;

namespace ArtisanGemstoneIMS.Application.Customers.Commands;

public class DeleteCustomerCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Unit>
{
    private readonly ICustomerRepository _customerRepository;

    public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(request.Id);

        if (customer == null)
            throw new NotFoundException(nameof(Customer), request.Id);

        await _customerRepository.DeleteAsync(customer);
        return Unit.Value;
    }
}
