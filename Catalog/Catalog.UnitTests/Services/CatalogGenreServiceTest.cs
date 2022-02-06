using System.Threading;
using Catalog.Host.Data.Entities;

namespace Catalog.UnitTests.Services;

public class CatalogGenreServiceTest
{
    private readonly ICatalogGenreService _catalogGenreService;
    private readonly Mock<ICatalogGenreRepository> _catalogGenreRepository;
    private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
    private readonly Mock<ILogger<CatalogGenreService>> _logger;

    private readonly CatalogGenre _testItem = new CatalogGenre()
    {
        Id = 1,
        Genre = "Genre"
    };

    public CatalogGenreServiceTest()
    {
        _catalogGenreRepository = new Mock<ICatalogGenreRepository>();
        _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
        _logger = new Mock<ILogger<CatalogGenreService>>();

        var dbContextTransaction = new Mock<IDbContextTransaction>();
        _dbContextWrapper.Setup(s => s.BeginTransactionAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(dbContextTransaction.Object);

        _catalogGenreService = new CatalogGenreService(
            _dbContextWrapper.Object,
            _logger.Object,
            _catalogGenreRepository.Object);
    }

    [Fact]
    public async Task CreateAsync_Success()
    {
        // arrange
        var testResult = 1;

        _catalogGenreRepository.Setup(s => s.CreateAsync(It.IsAny<string>()))
            .ReturnsAsync(testResult);

        // act
        var result = await _catalogGenreService.CreateAsync(_testItem.Genre);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task CreateAsync_Failed()
    {
        // arrange
        int? testResult = null;

        _catalogGenreRepository.Setup(s => s.CreateAsync(It.IsAny<string>()))
            .ReturnsAsync(testResult);

        // act
        var result = await _catalogGenreService.CreateAsync(_testItem.Genre);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task UpdateAsync_Success()
    {
        // arrange
        var testResult = true;

        _catalogGenreRepository.Setup(
            s => s.UpdateAsync(
                It.IsAny<int>(),
                It.IsAny<string>())).ReturnsAsync(testResult);

        // act
        var result = await _catalogGenreService.UpdateAsync(_testItem.Id, _testItem.Genre);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task UpdateAsync_Failed()
    {
        // arrange
        var testResult = false;

        _catalogGenreRepository.Setup(
            s => s.UpdateAsync(
                It.IsAny<int>(),
                It.IsAny<string>())).ReturnsAsync(testResult);

        // act
        var result = await _catalogGenreService.UpdateAsync(_testItem.Id, _testItem.Genre);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task DeleteAsync_Success()
    {
        // arrange
        var testResult = true;

        _catalogGenreRepository.Setup(s => s.DeleteAsync(It.IsAny<int>()))
            .ReturnsAsync(testResult);

        // act
        var result = await _catalogGenreService.DeleteAsync(_testItem.Id);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task DeleteAsync_Failed()
    {
        // arrange
        var testResult = false;

        _catalogGenreRepository.Setup(s => s.DeleteAsync(It.IsAny<int>())).ReturnsAsync(testResult);

        // act
        var result = await _catalogGenreService.DeleteAsync(_testItem.Id);

        // assert
        result.Should().Be(testResult);
    }
}