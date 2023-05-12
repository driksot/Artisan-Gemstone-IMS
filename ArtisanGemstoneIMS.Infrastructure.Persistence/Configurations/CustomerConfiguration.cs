using ArtisanGemstoneIMS.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtisanGemstoneIMS.Infrastructure.Persistence.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(cust => cust.Id);

        builder.HasOne(cust => cust.PrimaryAddress)
            .WithMany()
            .HasForeignKey(cust => cust.PrimaryAddressId);
    }
}
