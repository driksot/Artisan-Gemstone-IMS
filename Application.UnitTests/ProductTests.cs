using Application.UnitTests.Mocks;
using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.Application.Products;
using ArtisanGemstoneIMS.Application.Products.Commands;
using ArtisanGemstoneIMS.Application.Products.Queries;
using ArtisanGemstoneIMS.WebUI.Shared.Products;
using AutoMapper;
using Moq;
using Shouldly;

namespace Application.UnitTests;

public class ProductTests
{
    private readonly Mock<IProductRepository> _mockRepo;
    private IMapper _mapper;

    public ProductTests()
    {
        _mockRepo = MockProductRepository.GetMockProductRepository();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<ProductMapping>();
        });

        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnProduct_WhenProductExists()
    {
        // Arrange
        var productId = new Guid("ffbc3199-8546-4699-a532-c10a32c564cc");
        var handler = new GetProductDetailsQueryHandler(_mapper, _mockRepo.Object);

        // Act
        var result = await handler.Handle(new GetProductDetailsQuery { Id = productId }, CancellationToken.None);

        // Assert
        result.ShouldBeOfType<ProductDetailsDto>();
        result.Id.ShouldBe(new Guid("ffbc3199-8546-4699-a532-c10a32c564cc"));
        result.Sku.ShouldBe("MINLABRA0000001");
        result.Name.ShouldBe("Labradorite");
        result.Description.ShouldBe("Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.");
        result.Price.ShouldBe(35);
        result.IsArchived.ShouldBeFalse();
    }

    [Fact]
    public async Task GetAsync_Should_Return4Products_When4ProductsExist()
    {
        // Arrange
        var query = new GetProductsListQuery();

        var handler = new GetProductsListQueryHandler(_mapper, _mockRepo.Object);

        // Act
        var result = await handler.Handle(query, default);

        // Assert
        result.ShouldBeOfType<List<ProductsListDto>>();
        result.Count.ShouldBe(4);
    }

    [Fact]
    public async Task GetUnArchivedAsync_Should_Return3Products_When3ProductsUnArchived()
    {
        // Arrange
        var query = new GetUnarchivedProductsListQuery();

        var handler = new GetUnarchivedProductsListQueryHandler(_mapper, _mockRepo.Object);

        // Act
        var result = await handler.Handle(query, default);

        // Assert
        result.ShouldBeOfType<List<ProductsListDto>>();
        result.Count.ShouldBe(3);
    }
}
