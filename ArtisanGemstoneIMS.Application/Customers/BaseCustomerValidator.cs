using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.WebUI.Shared.Customers;
using FluentValidation;

namespace ArtisanGemstoneIMS.Application.Customers;

public class BaseCustomerValidator : AbstractValidator<BaseCustomerDto>
{
    private readonly IAddressRepository _addressRepository;

    public BaseCustomerValidator(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;

        //RuleFor(c => c.PrimaryAddressId)
        //    .NotNull()
        //    .MustAsync(AddressMustExist)
        //    .WithMessage("{PropertyName} does not exist.");
    }

    private async Task<bool> AddressMustExist(Guid id, CancellationToken token)
    {
        var address = await _addressRepository.GetByIdAsync(id);
        return address != null;
    }
}
