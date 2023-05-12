using ArtisanGemstoneIMS.Domain.Customers;

namespace ArtisanGemstoneIMS.Application.Contracts.Persistence;

public interface ICustomerRepository : IGenericRepository<Customer>
{
    Task<Customer> GetWithDetailsByIdAsync(Guid id);
    Task<List<Customer>> GetWithDetailsAsync();
}
