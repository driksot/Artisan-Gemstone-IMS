using ArtisanGemstoneIMS.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtisanGemstoneIMS.Infrastructure.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    private const string BaseUrl = $"products";

    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(prod => prod.Id);

        builder.HasData(
            new Product
            {
                Id = new Guid("ffbc3199-8546-4699-a532-c10a32c564cc"),
                Sku = "MINLABRA0000001",
                Name = "Labradorite",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                Price = 35,
                ImageUrl = $"{BaseUrl}/images/labradorite.png"
            },
            new Product
            {
                Id = new Guid("b8552865-4078-4e4b-8d20-ff0d14d87d8d"),
                Sku = "MINTURQU0000002",
                Name = "Turquoise",
                Description = "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.",
                Price = 20,
                ImageUrl = $"{BaseUrl}/images/turquoise.png"
            },
            new Product
            {
                Id = new Guid("6f6977f5-a099-4add-94f3-1fdcb5e06b92"),
                Sku = "MINSTARG0000003",
                Name = "Star Garnet",
                Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                Price = 25,
                ImageUrl = $"{BaseUrl}/images/star-garnet.jpg"
            },
            new Product
            {
                Id = new Guid("4ef32bc9-536f-4231-8934-f3ce9d48d111"),
                Sku = "MINJASPE0000004",
                Name = "Jasper",
                Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                Price = 20,
                ImageUrl = $"{BaseUrl}/images/jasper.jpg"
            },
            new Product
            {
                Id = new Guid("9af4201d-22d7-4579-bc40-341f345cb747"),
                Sku = "MINFIREO0000005",
                Name = "Fire Opal",
                Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                Price = 18,
                ImageUrl = $"{BaseUrl}/images/fire-opal.jpg"
            },
            new Product
            {
                Id = new Guid("1c5ab034-4ba0-4fb5-9f07-13b06d8f155b"),
                Sku = "MINAMETH0000006",
                Name = "Amethyst",
                Description = "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.",
                Price = 22,
                ImageUrl = $"{BaseUrl}/images/amethyst.jpg"
            },
            new Product
            {
                Id = new Guid("7aad8902-45d5-4185-a2e6-cf466abbbb84"),
                Sku = "WIR26GOL0000001",
                Name = "26 Gauge Gold Wire",
                Description = "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.",
                Price = 9,
                ImageUrl = $"{BaseUrl}/images/gold-wire.jpg"
            },
            new Product
            {
                Id = new Guid("ae5e0036-8551-4dab-9e41-674d27b4a8b2"),
                Sku = "WIR24GOL0000002",
                Name = "24 Gauge Gold Wire",
                Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                Price = 8,
                ImageUrl = $"{BaseUrl}/images/gold-wire.jpg"
            },
            new Product
            {
                Id = new Guid("57aea388-8f33-4975-aea7-a587855d87ee"),
                Sku = "MINAGATE0000007",
                Name = "Agate",
                Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                Price = 38,
                ImageUrl = $"{BaseUrl}/images/agate.jpg"
            },
            new Product
            {
                Id = new Guid("6fc19f3c-5426-4dd4-a1e2-aaebc14ce18a"),
                Sku = "MINCARNE0000008",
                Name = "Carnelian",
                Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                Price = 18,
                ImageUrl = $"{BaseUrl}/images/carnelian.jpg"
            },
            new Product
            {
                Id = new Guid("6b001338-1a4f-496c-8d26-dee9e111c24d"),
                Sku = "MINMALAC0000009",
                Name = "Malachite",
                Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                Price = 23,
                ImageUrl = $"{BaseUrl}/images/malachite.jpg"
            },
            new Product
            {
                Id = new Guid("ba12294f-779c-425e-a2d0-9a6a69e8c009"),
                Sku = "WIR26SIL0000003",
                Name = "26 Gauge Silver Wire",
                Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                Price = 8,
                ImageUrl = $"{BaseUrl}/images/silver-wire.jpg",
            },
            new Product
            {
                Id = new Guid("4d1e2f73-94db-4559-b47b-5d7619e39dba"),
                Sku = "WIR24SIL0000004",
                Name = "24 Gauge Silver Wire",
                Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                Price = 7,
                ImageUrl = $"{BaseUrl}/images/silver-wire.jpg",
            },
            new Product
            {
                Id = new Guid("4f8e0392-db1c-4768-8a4f-c54b018f2f81"),
                Sku = "WIR26COP0000005",
                Name = "26 Gauge Copper Wire",
                Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                Price = 7,
                ImageUrl = $"{BaseUrl}/images/copper-wire.jpg"
            },
            new Product
            {
                Id = new Guid("bc7e516c-5e5b-4949-8384-414cac54e563"),
                Sku = "WIR24COP0000006",
                Name = "24 Gauge Copper Wire",
                Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                Price = 6,
                ImageUrl = $"{BaseUrl}/images/copper-wire.jpg"
            },
            new Product
            {
                Id = new Guid("9465fec5-3ee4-4d25-ba84-69f3ec21336a"),
                Sku = "MINSAPPH0000010",
                Name = "Sapphire",
                Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                Price = 25,
                ImageUrl = $"{BaseUrl}/images/sapphire.jpg"
            });
    }
}
