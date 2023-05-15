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

        builder.HasData(
            new Customer
            {
                Id = new Guid("9507cfc3-83f7-417f-b98e-ed8b225c159c"),
                FirstName = "Wally",
                LastName = "West",
                PrimaryAddressId = new Guid("e5a502ae-571b-4fd1-8fc5-8bb023903b39"),
                PhoneNumber = "5555234567",
                Email = "wally.west@flash.com"
            },
            new Customer
            {
                Id = new Guid("63b41c8e-e050-4eb2-8a21-ddee8ca8c95e"),
                FirstName = "Jay",
                LastName = "Garrick",
                PrimaryAddressId = new Guid("f5bb9f11-dab1-4006-bf02-e29b6edebe5b"),
                PhoneNumber = "5555345678",
                Email = "jay.garrick@flash.com"
            },
            new Customer
            {
                Id = new Guid("d37a00d6-c2bd-4a52-a369-b88f1499f149"),
                FirstName = "Oliver",
                LastName = "Queen",
                PrimaryAddressId = new Guid("5550cd39-04fd-46ea-b5ec-827336ff9994"),
                PhoneNumber = "5555456789",
                Email = "oliver.queen@greenarrow.com"
            },
            new Customer
            {
                Id = new Guid("7c6ded20-1f31-4460-8c3c-b719c9fe0a7b"),
                FirstName = "Dick",
                LastName = "Grayson",
                PrimaryAddressId = new Guid("abb58bf7-395f-4cf6-a11e-449a0a92230a"),
                PhoneNumber = "5555567891",
                Email = "dick.grayson@nightwing.com"
            });
    }
}
