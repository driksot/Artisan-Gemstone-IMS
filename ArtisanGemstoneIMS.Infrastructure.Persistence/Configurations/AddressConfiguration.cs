using ArtisanGemstoneIMS.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtisanGemstoneIMS.Infrastructure.Persistence.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(address => address.Id);

        builder.HasData(
            new Address
            {
                Id = new Guid("e5a502ae-571b-4fd1-8fc5-8bb023903b39"),
                AddressLine1 = "123 Main St.",
                AddressLine2 = "Apt. 14",
                City = "Central City",
                State = "MO",
                PostalCode = "12345",
                Country = "USA"
            },
            new Address
            {
                Id = new Guid("f5bb9f11-dab1-4006-bf02-e29b6edebe5b"),
                AddressLine1 = "45 E Elm St.",
                City = "Keystone City",
                State = "KS",
                PostalCode = "23456",
                Country = "USA"
            },
            new Address
            {
                Id = new Guid("5550cd39-04fd-46ea-b5ec-827336ff9994"),
                AddressLine1 = "3705 9th Ave",
                AddressLine2 = "Apt. 37",
                City = "Star City",
                State = "CA",
                PostalCode = "34567",
                Country = "USA"
            },
            new Address
            {
                Id = new Guid("abb58bf7-395f-4cf6-a11e-449a0a92230a"),
                AddressLine1 = "94 Main St.",
                AddressLine2 = "Ste. 2002",
                City = "Gotham City",
                State = "NJ",
                PostalCode = "45678",
                Country = "USA"
            });
    }
}
