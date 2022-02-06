using System.Threading;
using Catalog.Host.Data.Entities;

namespace Catalog.UnitTests.Services;

public class CatalogItemServiceTest
{
    private readonly ICatalogItemService _catalogService;

    private readonly Mock<ICatalogItemRepository> _catalogItemRepository;
    private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
    private readonly Mock<ILogger<CatalogService>> _logger;

    private readonly CatalogItem _testItem = new CatalogItem()
    {
        Title = "Title",
        CoverFileName = "fileName.png",
        Imdb = 7.8,
        Year = 1985,
        Description = "Description",
        Price = 4.5,
    };

    public CatalogItemServiceTest()
    {
        _catalogItemRepository = new Mock<ICatalogItemRepository>();
        _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
        _logger = new Mock<ILogger<CatalogService>>();

        var dbContextTransaction = new Mock<IDbContextTransaction>();
        _dbContextWrapper.Setup(s => s.BeginTransactionAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(dbContextTransaction.Object);

        _catalogService = new CatalogItemService(
            _dbContextWrapper.Object,
            _logger.Object,
            _catalogItemRepository.Object);
    }

    [Fact]
    public async Task AddAsync_Success()
    {
        // arrange
        var testResult = 1;

        _catalogItemRepository.Setup(
            s => s.CreateAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<double>(),
                It.IsAny<int>(),
                It.IsAny<double>())).ReturnsAsync(testResult);

        // act
        var result = await _catalogService.CreateAsync(
            _testItem.Title,
            _testItem.CoverFileName,
            _testItem.Description,
            _testItem.Imdb,
            _testItem.Year,
            _testItem.Price);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task AddAsync_Failed()
    {
        // arrange
        int? testResult = null;

        _catalogItemRepository.Setup(
            s => s.CreateAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<double>(),
                It.IsAny<int>(),
                It.IsAny<double>())).ReturnsAsync(testResult);

        // act
        var result = await _catalogService.CreateAsync(
            _testItem.Title,
            _testItem.CoverFileName,
            _testItem.Description,
            _testItem.Imdb,
            _testItem.Year,
            _testItem.Price);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task UpdateAsync_Success()
    {
        // arrange
        var testResult = true;

        _catalogItemRepository.Setup(
            s => s.UpdateAsync(
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<double>(),
                It.IsAny<int>(),
                It.IsAny<double>())).ReturnsAsync(testResult);

        // act
        var result = await _catalogService.UpdateAsync(
            _testItem.Id,
            _testItem.Title,
            _testItem.CoverFileName,
            _testItem.Description,
            _testItem.Imdb,
            _testItem.Year,
            _testItem.Price);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task UpdateAsync_Failed()
    {
        // arrange
        var testResult = false;

        _catalogItemRepository.Setup(
            s => s.UpdateAsync(
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<double>(),
                It.IsAny<int>(),
                It.IsAny<double>())).ReturnsAsync(testResult);

        // act
        var result = await _catalogService.UpdateAsync(
            _testItem.Id,
            _testItem.Title,
            _testItem.CoverFileName,
            _testItem.Description,
            _testItem.Imdb,
            _testItem.Year,
            _testItem.Price);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task DeleteAsync_Success()
    {
        // arrange
        var testResult = true;

        _catalogItemRepository.Setup(s => s.DeleteAsync(It.IsAny<int>()))
            .ReturnsAsync(testResult);

        // act
        var result = await _catalogService.DeleteAsync(_testItem.Id);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task DeleteAsync_Failed()
    {
        // arrange
        var testResult = false;

        _catalogItemRepository.Setup(s => s.DeleteAsync(It.IsAny<int>())).ReturnsAsync(testResult);

        // act
        var result = await _catalogService.DeleteAsync(_testItem.Id);

        // assert
        result.Should().Be(testResult);
    }
}