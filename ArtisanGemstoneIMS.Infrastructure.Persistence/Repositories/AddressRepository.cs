using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.Domain.Customers;

namespace ArtisanGemstoneIMS.Infrastructure.Persistence.Repositories;

public class AddressRepository : GenericRepository<Address>, IAddressRepository
{
    public AddressRepository(IMSDatabaseContext context) : base(context)
    {
    }
}
