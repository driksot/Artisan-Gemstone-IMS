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

        builder.HasData(
            new Inventory
            {
                Id = new Guid("8917aa6d-2655-4108-a520-b0da674bc44c"),
                ProductId = new Guid("ffbc3199-8546-4699-a532-c10a32c564cc"),
                QuantityOnHand = 4,
                IdealQuantity = 10
            },
            new Inventory
            {
                Id = new Guid("999d4d12-8d9d-4315-a389-16b210e28dbd"),
                ProductId = new Guid("b8552865-4078-4e4b-8d20-ff0d14d87d8d"),
                QuantityOnHand = 7,
                IdealQuantity = 10
            },
            new Inventory
            {
                Id = new Guid("297c9f85-d80c-40e5-810f-38ace3e79155"),
                ProductId = new Guid("6f6977f5-a099-4add-94f3-1fdcb5e06b92"),
                QuantityOnHand = 3,
                IdealQuantity = 10
            },
            new Inventory
            {
                Id = new Guid("afcd2641-40ae-4e23-afbc-0266e68ee293"),
                ProductId = new Guid("4ef32bc9-536f-4231-8934-f3ce9d48d111"),
                QuantityOnHand = 4,
                IdealQuantity = 10
            },
            new Inventory
            {
                Id = new Guid("b3f5dc4d-0a08-44c4-8248-88e0f984662f"),
                ProductId = new Guid("9af4201d-22d7-4579-bc40-341f345cb747"),
                QuantityOnHand = 12,
                IdealQuantity = 10
            },
            new Inventory
            {
                Id = new Guid("b71b18b6-cd89-4ab8-9bf1-8aa662ae36a1"),
                ProductId = new Guid("1c5ab034-4ba0-4fb5-9f07-13b06d8f155b"),
                QuantityOnHand = 8,
                IdealQuantity = 10
            },
            new Inventory
            {
                Id = new Guid("167671fc-f78d-43cf-ba73-cdee13baf1cd"),
                ProductId = new Guid("7aad8902-45d5-4185-a2e6-cf466abbbb84"),
                QuantityOnHand = 11,
                IdealQuantity = 10
            },
            new Inventory
            {
                Id = new Guid("2b599210-d7ed-44e6-aa8f-8a27f0d9d057"),
                ProductId = new Guid("ae5e0036-8551-4dab-9e41-674d27b4a8b2"),
                QuantityOnHand = 9,
                IdealQuantity = 10
            },
            new Inventory
            {
                Id = new Guid("8601d89f-fcb0-4575-9814-ec813127d1ce"),
                ProductId = new Guid("57aea388-8f33-4975-aea7-a587855d87ee"),
                QuantityOnHand = 6,
                IdealQuantity = 10
            },
            new Inventory
            {
                Id = new Guid("3b362269-0518-40aa-b540-cc66a2c89ba9"),
                ProductId = new Guid("6fc19f3c-5426-4dd4-a1e2-aaebc14ce18a"),
                QuantityOnHand = 10,
                IdealQuantity = 10
            },
            new Inventory
            {
                Id = new Guid("845e18ef-bcba-4dd5-af16-ab50a6ef93b6"),
                ProductId = new Guid("6b001338-1a4f-496c-8d26-dee9e111c24d"),
                QuantityOnHand = 5,
                IdealQuantity = 10
            },
            new Inventory
            {
                Id = new Guid("fe0bf302-19b3-46f0-95b5-1c5f32734071"),
                ProductId = new Guid("ba12294f-779c-425e-a2d0-9a6a69e8c009"),
                QuantityOnHand = 9,
                IdealQuantity = 10
            },
            new Inventory
            {
                Id = new Guid("cb7a6bf2-c1e1-44e5-8b0a-c6b4723f32ce"),
                ProductId = new Guid("4d1e2f73-94db-4559-b47b-5d7619e39dba"),
                QuantityOnHand = 10,
                IdealQuantity = 10
            },
            new Inventory
            {
                Id = new Guid("cd659b08-d7ae-438e-935b-729bdef5c54f"),
                ProductId = new Guid("4f8e0392-db1c-4768-8a4f-c54b018f2f81"),
                QuantityOnHand = 3,
                IdealQuantity = 10
            },
            new Inventory
            {
                Id = new Guid("66f04724-681b-4086-8650-2359bb7357e7"),
                ProductId = new Guid("bc7e516c-5e5b-4949-8384-414cac54e563"),
                QuantityOnHand = 7,
                IdealQuantity = 10
            },
            new Inventory
            {
                Id = new Guid("bb1d4d10-153a-47c5-9751-9413f4a3f7fc"),
                ProductId = new Guid("9465fec5-3ee4-4d25-ba84-69f3ec21336a"),
                QuantityOnHand = 5,
                IdealQuantity = 10
            });
    }
}
