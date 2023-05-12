using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.Domain.Customers;
using Microsoft.EntityFrameworkCore;

namespace ArtisanGemstoneIMS.Infrastructure.Persistence.Repositories;

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(IMSDatabaseContext context) : base(context)
    {
    }

    public async Task<List<Customer>> GetWithDetailsAsync()
    {
        var customers = await _context.Customers
            .Include(c => c.PrimaryAddress)
            .ToListAsync();
        return customers;
    }

    public async Task<Customer> GetWithDetailsByIdAsync(Guid id)
    {
        var customer = await _context.Customers
            .Include(c => c.PrimaryAddress)
            .FirstOrDefaultAsync(c => c.Id == id);
        return customer;
    }
}
