using ArtisanGemstoneIMS.Application.Common.Exceptions;
using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.WebUI.Shared.Customers;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace ArtisanGemstoneIMS.Application.Addresses.Commands;

public class UpdateAddressCommand : BaseAddressDto, IRequest<Unit>
{
    public Guid Id { get; set; }
}

public class UpdateAddressCommandValidator : AbstractValidator<UpdateAddressCommand>
{
    public UpdateAddressCommandValidator()
    {
        Include(new BaseAddressValidator());
    }
}

public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IAddressRepository _addressRepository;

    public UpdateAddressCommandHandler(
        IMapper mapper,
        IAddressRepository addressRepository)
    {
        _mapper = mapper;
        _addressRepository = addressRepository;
    }

    public async Task<Unit> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        var address = await _addressRepository.GetByIdAsync(request.Id);

        if (address == null)
            throw new NotFoundException(nameof(address), request.Id);

        var validator = new UpdateAddressCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid Address", validationResult);

        _mapper.Map(request, address);

        await _addressRepository.UpdateAsync(address);

        return Unit.Value;
    }
}
