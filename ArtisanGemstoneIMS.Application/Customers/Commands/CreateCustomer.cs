using ArtisanGemstoneIMS.Application.Common.Exceptions;
using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.Domain.Customers;
using ArtisanGemstoneIMS.WebUI.Shared.Customers;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace ArtisanGemstoneIMS.Application.Customers.Commands;

public class CreateCustomerCommand : BaseCustomerDto, IRequest<Unit>
{

}

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    private readonly IAddressRepository _addressRepository;

    public CreateCustomerCommandValidator(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
        Include(new BaseCustomerValidator(_addressRepository));
    }
}

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;
    private readonly IAddressRepository _addressRepository;

    public CreateCustomerCommandHandler(
        IMapper mapper,
        ICustomerRepository customerRepository,
        IAddressRepository addressRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
        _addressRepository = addressRepository;
    }

    public async Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateCustomerCommandValidator(_addressRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid Customer", validationResult);

        var customer = _mapper.Map<Customer>(request);
        await _customerRepository.CreateAsync(customer);

        return Unit.Value;
    }
}
