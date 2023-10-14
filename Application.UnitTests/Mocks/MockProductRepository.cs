using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.Domain.Products;
using Moq;

namespace Application.UnitTests.Mocks;

public class MockProductRepository
{
    public static Mock<IProductRepository> GetMockProductRepository()
    {
        var products = new List<Product>
        {
            new Product
            {
                Id = new Guid("ffbc3199-8546-4699-a532-c10a32c564cc"),
                Sku = "MINLABRA0000001",
                Name = "Labradorite",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                Price = 35,
                ImageUrl = $"products/images/labradorite.png"
            },
            new Product
            {
                Id = new Guid("b8552865-4078-4e4b-8d20-ff0d14d87d8d"),
                Sku = "MINTURQU0000002",
                Name = "Turquoise",
                Description = "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.",
                Price = 20,
                ImageUrl = $"products/images/turquoise.png"
            },
            new Product
            {
                Id = new Guid("6f6977f5-a099-4add-94f3-1fdcb5e06b92"),
                Sku = "MINSTARG0000003",
                Name = "Star Garnet",
                Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                Price = 25,
                ImageUrl = $"products/images/star-garnet.jpg"
            },
            new Product
            {
                Id = new Guid("4ef32bc9-536f-4231-8934-f3ce9d48d111"),
                Sku = "MINJASPE0000004",
                Name = "Jasper",
                Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                Price = 20,
                ImageUrl = $"products/images/jasper.jpg",
                IsArchived = true
            }
        };

        var mockRepo = new Mock<IProductRepository>();

        mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(products);

        mockRepo.Setup(r => r.GetUnArchivedAsync())
            .ReturnsAsync(() =>
            {
                return products.Where(p => p.IsArchived == false).ToList();
            });

        mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync((Guid productId) =>
            {
                return products.FirstOrDefault(p => p.Id == productId);
            });

        mockRepo.Setup(r => r.CreateProductWithInventory(It.IsAny<Product>()))
            .Returns((Product product) =>
            {
                products.Add(product);
                return Task.CompletedTask;
            });

        mockRepo.Setup(r => r.UpdateAsync(It.IsAny<Product>()))
            .Returns(Task.CompletedTask);

        mockRepo.Setup(r => r.ArchiveAsync(It.IsAny<Guid>()))
            .Returns(Task.CompletedTask);

        //mockRepo.Setup(r => r.UpdateAsync(It.IsAny<Product>()))
        //    .Returns((Product product) =>
        //    {
        //        var prod = products.FirstOrDefault(p => p.Id == product.Id);
        //        if (prod != null)
        //        {
        //            prod.Sku = product.Sku;
        //            prod.Name = product.Name;
        //            prod.Description = product.Description;
        //            prod.Price = product.Price;
        //            prod.ImageUrl = product.ImageUrl;
        //        }
        //        return Task.CompletedTask;
        //    });

        //mockRepo.Setup(r => r.ArchiveAsync(It.IsAny<Guid>()))
        //    .Returns((Product product) =>
        //    {
        //        var prod = products.FirstOrDefault(p => p.Id == product.Id);
        //        if (prod != null)
        //        {
        //            prod.IsArchived = true;
        //        }
        //        return Task.CompletedTask;
        //    });

        return mockRepo;
    }
}
