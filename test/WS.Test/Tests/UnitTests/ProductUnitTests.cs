using Ardalis.Specification;
using Moq;
using WS.Core.Entities.ChemicalAggregate;
using WS.Core.Interfaces.DomainServices;
using WS.Core.Interfaces.Repositories;
using WS.Core.Services;
using WS.Test.Helpers;

namespace WS.Test.Tests.UnitTests;

public class ProductUnitTests
{
    private readonly IProductService _productService;
    private readonly Mock<IReadRepository<Product>> _productReadRepositoryMock = new();

    public ProductUnitTests()
    {
        _productService = new ProductService(_productReadRepositoryMock.Object);
    }

    [Fact]
    public async Task GetProductsAsync_ReturnsListOfProducts()
    {
        //Arrange
        var testProducts = ProductTestHelper.GetTestProducts();
        
        _productReadRepositoryMock.Setup(x => 
            x.ListAsync(It.IsAny<ISpecification<Product>>(), new CancellationToken()));

        //Act
        var result = await _productService.GetAllProductsAsync();

        //Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count); //Expecting 2 products
    }
}