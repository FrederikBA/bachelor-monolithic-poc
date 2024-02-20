using Moq;
using Ardalis.Specification;
using WS.Core.Entities.ChemicalAggregate;
using WS.Core.Exceptions;
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
                x.ListAsync(It.IsAny<ISpecification<Product>>(), new CancellationToken()))
            .ReturnsAsync(testProducts);

        //Act
        var result = await _productService.GetAllProductsAsync();

        //Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count); //Expecting 2 products
    }
    
    [Fact]
    public async Task GetProductsAsync_ThrowsProductsNotFoundException()
    {
        //Arrange
        _productReadRepositoryMock.Setup(x =>
                x.ListAsync(It.IsAny<ISpecification<Product>>(), new CancellationToken()))
            .ReturnsAsync(new List<Product>());

        //Act
        var exception = await Assert.ThrowsAsync<ProductsNotFoundException>(() => _productService.GetAllProductsAsync());

        //Assert
        Assert.NotNull(exception);
    }
    
    [Fact]
    public async Task GetProductByIdAsync_ReturnsProduct()
    {
        //Arrange
        var testProduct = ProductTestHelper.GetTestProducts()[0];

        _productReadRepositoryMock.Setup(x =>
                x.FirstOrDefaultAsync(It.IsAny<Specification<Product>>(), new CancellationToken()))
            .ReturnsAsync(testProduct);

        //Act
        var result = await _productService.GetProductByIdAsync(1);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(testProduct, result);
    }
    
    [Fact]
    public async Task GetProductByIdAsync_ThrowsProductNotFoundException()
    {
        //Arrange
        _productReadRepositoryMock.Setup(x =>
                x.GetByIdAsync(It.IsAny<int>(), new CancellationToken()))
            .ReturnsAsync((Product)null);

        //Act
        var exception = await Assert.ThrowsAsync<ProductNotFoundException>(() => _productService.GetProductByIdAsync(1));

        //Assert
        Assert.NotNull(exception);
    }
}