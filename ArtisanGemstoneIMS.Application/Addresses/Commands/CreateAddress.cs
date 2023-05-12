using ArtisanGemstoneIMS.Application.Common.Exceptions;
using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.Domain.Customers;
using ArtisanGemstoneIMS.WebUI.Shared.Customers;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace ArtisanGemstoneIMS.Application.Addresses.Commands;

public class CreateAddressCommand : BaseAddressDto, IRequest<Unit>
{

}

public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
{
    public CreateAddressCommandValidator()
    {
        Include(new BaseAddressValidator());
    }
}

public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IAddressRepository _addressRepository;

    public CreateAddressCommandHandler(
        IMapper mapper,
        IAddressRepository addressRepository)
    {
        _mapper = mapper;
        _addressRepository = addressRepository;
    }

    public async Task<Unit> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateAddressCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid Address", validationResult);

        var address = _mapper.Map<Address>(request);
        await _addressRepository.CreateAsync(address);

        return Unit.Value;
    }
}
