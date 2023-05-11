using ArtisanGemstoneIMS.Domain.Inventories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtisanGemstoneIMS.Infrastructure.Persistence.Configurations;

public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.HasKey(inv => inv.Id);

        builder.HasOne(inv => inv.Product)
            .WithMany()
            .HasForeignKey(inv => inv.ProductId);
    }
}
