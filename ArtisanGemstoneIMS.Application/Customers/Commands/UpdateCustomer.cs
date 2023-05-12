using ArtisanGemstoneIMS.Application.Common.Exceptions;
using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.Domain.Customers;
using ArtisanGemstoneIMS.WebUI.Shared.Customers;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace ArtisanGemstoneIMS.Application.Customers.Commands;

public class UpdateCustomerCommand : BaseCustomerDto, IRequest<Unit>
{
    public Guid Id { get; set; }
}

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    private readonly IAddressRepository _addressRepository;

    public UpdateCustomerCommandValidator(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
        Include(new BaseCustomerValidator(_addressRepository));
    }
}

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;
    private readonly IAddressRepository _addressRepository;

    public UpdateCustomerCommandHandler(
        IMapper mapper,
        ICustomerRepository customerRepository,
        IAddressRepository addressRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
        _addressRepository = addressRepository;
    }

    public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(request.Id);

        if (customer == null)
            throw new NotFoundException(nameof(Customer), request.Id);

        var validator = new UpdateCustomerCommandValidator(_addressRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid Customer", validationResult);

        _mapper.Map(request, customer);

        await _customerRepository.UpdateAsync(customer);

        return Unit.Value;
    }
}
