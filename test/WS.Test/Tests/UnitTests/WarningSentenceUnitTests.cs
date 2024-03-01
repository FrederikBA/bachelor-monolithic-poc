using Ardalis.Specification;
using Moq;
using WS.Core.Entities.ChemicalAggregate;
using WS.Core.Entities.WSAggregate;
using WS.Core.Exceptions;
using WS.Core.Interfaces.DomainServices;
using WS.Core.Interfaces.Repositories;
using WS.Core.Services;
using WS.Core.Specifications;
using WS.Test.Helpers;

namespace WS.Test.Tests.UnitTests;

public class WarningSentenceUnitTests
{
    private readonly IWarningSentenceService _warningSentenceService;
    private readonly Mock<IReadRepository<WarningSentence>> _warningSentenceReadRepositoryMock = new();
    private readonly Mock<IRepository<WarningSentence>> _warningSentenceRepositoryMock = new();
    
    public WarningSentenceUnitTests()
    {
        _warningSentenceService = new WarningSentenceService(_warningSentenceReadRepositoryMock.Object, _warningSentenceRepositoryMock.Object);
    }
    
    [Fact]
    public async Task GetWarningSentencesAsync_ReturnsListOfWarningSentences()
    {
        //Arrange
        var testWarningSentences = WarningSentenceTestHelper.GetTestWarningSentences();

        _warningSentenceReadRepositoryMock.Setup(x =>
                x.ListAsync(It.IsAny<ISpecification<WarningSentence>>(), new CancellationToken()))
            .ReturnsAsync(testWarningSentences);

        //Act
        var result = await _warningSentenceService.GetAllWarningSentencesAsync();

        //Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count); //Expecting 2 warning sentences
    }
    
    
    [Fact]
    public async Task GetWarningSentencesAsync_ThrowsWarningSentencesNotFoundException()
    {
        //Arrange
        _warningSentenceReadRepositoryMock.Setup(x =>
                x.ListAsync(It.IsAny<ISpecification<WarningSentence>>(), new CancellationToken()))
            .ReturnsAsync(new List<WarningSentence>());

        //Act
        var exception = await Assert.ThrowsAsync<WarningSentencesNotFoundException>(() => _warningSentenceService.GetAllWarningSentencesAsync());

        //Assert
        Assert.NotNull(exception);
    }
    
    [Fact]
    public async Task GetWarningSentenceByIdAsync_ReturnsWarningSentence()
    {
        //Arrange
        var testWarningSentences = WarningSentenceTestHelper.GetTestWarningSentences();
        var testWarningSentence = testWarningSentences.First();

        _warningSentenceReadRepositoryMock.Setup(x =>
                x.FirstOrDefaultAsync(It.IsAny<Specification<WarningSentence>>(), new CancellationToken()))
            .ReturnsAsync(testWarningSentence);

        //Act
        var result = await _warningSentenceService.GetWarningSentenceByIdAsync(testWarningSentence.Id);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(testWarningSentence.Id, result.Id);
    }
    
    [Fact]
    public async Task GetWarningSentenceByIdAsync_ThrowsWarningSentenceNotFoundException()
    {
        //Arrange
        var testWarningSentences = WarningSentenceTestHelper.GetTestWarningSentences();
        var testWarningSentence = testWarningSentences.First();

        _warningSentenceReadRepositoryMock.Setup(x =>
                x.ListAsync(It.IsAny<ISpecification<WarningSentence>>(), new CancellationToken()))
            .ReturnsAsync(testWarningSentences);

        //Act
        var exception = await Assert.ThrowsAsync<WarningSentenceNotFoundException>(() => _warningSentenceService.GetWarningSentenceByIdAsync(0));

        //Assert
        Assert.NotNull(exception);
    }
    
    [Fact]
    public async Task AddWarningSentenceAsync_ReturnsWarningSentence()
    {
        //Arrange
        var testWarningSentenceDto = WarningSentenceTestHelper.GetTestWarningSentenceDto();
        var testWarningSentence = WarningSentenceTestHelper.GetTestWarningSentences().First();

        _warningSentenceRepositoryMock.Setup(x =>
                x.AddAsync(It.IsAny<WarningSentence>(), new CancellationToken()))
            .ReturnsAsync(testWarningSentence);

        //Act
        var result = await _warningSentenceService.AddWarningSentenceAsync(testWarningSentenceDto);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(testWarningSentence.Id, result.Id);
    }
    
    [Fact]
    public async Task CloneWarningSentenceAsync_ReturnsWarningSentence()
    {
        //Arrange
        var testWarningSentence = WarningSentenceTestHelper.GetTestWarningSentences().First();

        _warningSentenceReadRepositoryMock.Setup(x =>
                x.GetByIdAsync(testWarningSentence.Id, new CancellationToken()))
            .ReturnsAsync(testWarningSentence);

        _warningSentenceRepositoryMock.Setup(x =>
                x.AddAsync(It.IsAny<WarningSentence>(), new CancellationToken()))
            .ReturnsAsync(testWarningSentence);

        //Act
        var result = await _warningSentenceService.CloneWarningSentenceAsync(testWarningSentence.Id);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(testWarningSentence.Id, result.Id);
    }
    
    [Fact]
    public async Task CloneWarningSentenceAsync_ThrowsWarningSentenceNotFoundException()
    {
        //Arrange
        _warningSentenceReadRepositoryMock.Setup(x =>
                x.FirstOrDefaultAsync(It.IsAny<Specification<WarningSentence>>(), new CancellationToken()))
            .ReturnsAsync((WarningSentence)null!);

        //Act
        var exception = await Assert.ThrowsAsync<WarningSentenceNotFoundException>(() => _warningSentenceService.CloneWarningSentenceAsync(0));

        //Assert
        Assert.NotNull(exception);
    }
    
    [Fact]
    public async Task RenameWarningSentenceAsync_ReturnsWarningSentence()
    {
        //Arrange
        var testWarningSentence = WarningSentenceTestHelper.GetTestWarningSentences().First();
        const string newName = "New Name";

        _warningSentenceReadRepositoryMock.Setup(x =>
                x.GetByIdAsync(testWarningSentence.Id, new CancellationToken()))
            .ReturnsAsync(testWarningSentence);
        
        //Act
        var result = await _warningSentenceService.RenameWarningSentenceAsync(testWarningSentence.Id, newName);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(newName, result.Code);
    }
    
    [Fact]
    public async Task RenameWarningSentenceAsync_ThrowsWarningSentenceNotFoundException()
    {
        //Arrange
        _warningSentenceReadRepositoryMock.Setup(x =>
                x.FirstOrDefaultAsync(It.IsAny<Specification<WarningSentence>>(), new CancellationToken()))
            .ReturnsAsync((WarningSentence)null!);

        //Act
        var exception = await Assert.ThrowsAsync<WarningSentenceNotFoundException>(() => _warningSentenceService.RenameWarningSentenceAsync(0, "New Name"));

        //Assert
        Assert.NotNull(exception);
    }
    
    [Fact]
    public async Task DeleteWarningSentenceAsync_ReturnsTrue()
    {
        //Arrange
        var testWarningSentence = WarningSentenceTestHelper.GetTestWarningSentences().First();
        
        var idsToDelete = new List<int> {testWarningSentence.Id};


        _warningSentenceReadRepositoryMock.Setup(x =>
                x.FirstOrDefaultAsync(It.IsAny<Specification<WarningSentence>>(), new CancellationToken()))
            .ReturnsAsync(testWarningSentence);

        _warningSentenceRepositoryMock.Setup(x =>
            x.DeleteAsync(testWarningSentence, new CancellationToken()));

        //Act
        var result = await _warningSentenceService.DeleteWarningSentenceAsync(idsToDelete);

        //Assert
        Assert.True(result);
    }
    
    [Fact]
    public async Task DeleteWarningSentenceAsync_ThrowsWarningSentenceNotFoundException()
    {
        //Arrange
        _warningSentenceReadRepositoryMock.Setup(x =>
                x.FirstOrDefaultAsync(It.IsAny<Specification<WarningSentence>>(), new CancellationToken()))
            .ReturnsAsync((WarningSentence)null!);

        //Act
        var exception = await Assert.ThrowsAsync<WarningSentenceNotFoundException>(() => _warningSentenceService.DeleteWarningSentenceAsync(new List<int>{0}));

        //Assert
        Assert.NotNull(exception);
    }
    
    [Fact]
    public async Task DeleteWarningSentenceAsync_ThrowsWarningSentenceInUseException()
    {
        //Arrange
        var testWarningSentence = WarningSentenceTestHelper.GetTestWarningSentences().First();
        var testProduct = ProductTestHelper.GetTestProducts().First();
        testWarningSentence.Products!.Add(testProduct);
        
        var idsToDelete = new List<int> {testWarningSentence.Id};

        _warningSentenceReadRepositoryMock.Setup(x =>
                x.FirstOrDefaultAsync(It.IsAny<Specification<WarningSentence>>(), new CancellationToken()))
            .ReturnsAsync(testWarningSentence);
        
        //Act
        var exception = await Assert.ThrowsAsync<WarningSentenceInUseException>(() => _warningSentenceService.DeleteWarningSentenceAsync(idsToDelete));

        //Assert
        Assert.NotNull(exception);
    }
}