namespace FurnitureStore.Tests.Controllers;

public class ProductsControllerTest
{
	private AppDbContext _context;
	private IWebHostEnvironment _hostEnv;
	private ILogger<ProductsController> _logger;
	private ProductsController _controller;

	public ProductsControllerTest()
	{
		// Arrange
		_context = GetTestAppDbContext().GetAwaiter().GetResult();
		_logger = new Mock<ILogger<ProductsController>>().Object;
		_hostEnv = new Mock<IWebHostEnvironment>().Object;

		_controller = new ProductsController(
			_context,
			_logger,
			_hostEnv
		);
	}
	private IEnumerable<Product> GetTestProducts()
	{
		var products = new List<Product>
		{
			new() { Name = "name1", Description = "desc1", Price = 100, ImageId = 1, StorageId = 1 },
			new() { Name = "name2", Description = "desc2", Price = 200, ImageId = 1, StorageId = 1 },
			new() { Name = "name3", Description = "desc3", Price = 300, ImageId = 1, StorageId = 1 },
			new() { Name = "name4", Description = "desc4", Price = 400, ImageId = 1, StorageId = 1 },
			new() { Name = "name5", Description = "desc5", Price = 500, ImageId = 1, StorageId = 1 },
		};
		return products;
	}

	private async Task<AppDbContext> GetTestAppDbContext()
	{
		var options = new DbContextOptionsBuilder<AppDbContext>()
			.UseInMemoryDatabase(Guid.NewGuid().ToString())
			.Options;
		var appDbContext = new AppDbContext(options);

		if (await appDbContext.Product.AnyAsync()) return appDbContext;

		await appDbContext.Image.AddAsync(new Image()
			{ Name = "/img/products/img1.png"});
		await appDbContext.Storage.AddAsync(new Storage()
			{ Name = "Залесный", City = "Санкт-Петербург", Street = "Крамерная", House = "16", PostalCode = 197626 });
		await appDbContext.Product.AddRangeAsync(GetTestProducts());

		await appDbContext.SaveChangesAsync();
		return appDbContext;
	}

	[Fact]
	public void IndexViewResultObjectsExists()
	{
		// Act
		var result = _controller.Index();

		// Assert
		var viewResult = Assert.IsType<ViewResult>(result);
		var model = Assert.IsAssignableFrom<ProductIndexViewModel>(viewResult.Model);
		var expected = _context.Product.Count();
		var actual = model.Products.Count();
		Assert.Equal(expected, actual);
	}

	[Fact]
	public async Task DetailsReturnsViewResultWithObject()
	{
		// Arrange
		var testId1 = 1;

		// Act
		var result = await _controller.Details(testId1);

		// Assert
		var viewResult = Assert.IsType<ViewResult>(result);
		var model = Assert.IsType<Product>(viewResult.ViewData.Model);
		Assert.Equal("name1", model.Name);
		Assert.Equal("desc1", model.Description);
		Assert.Equal((uint)100, model.Price);
	}

	[Fact]
	public async Task DetailsReturnsNotFoundResultWhenIdNotExists()
	{
		// Arrange
		var testId1 = 0;
		var testId2 = 100;

		// Act
		var result1 = await _controller.Details(testId1);
		var result2 = await _controller.Details(testId2);

		// Assert
		Assert.IsType<NotFoundResult>(result1);
		Assert.IsType<NotFoundResult>(result2);
	}

	[Fact]
	public async Task CreateObjectIsAddedToDb()
	{
		// Arrange
		var newProduct = new Product()
			{ Name = "name1", Description = "desc1", Price = 100, ImageId = 1, StorageId = 1};

		// Act
		await _controller.Create(newProduct);

		// Assert
		Assert.NotNull(await _context.Product
			.Include(p => p.Image)
			.Include(p => p.Storage)
			.FirstOrDefaultAsync(p => p.Name == newProduct.Name));
	}

	[Fact]
	public void CreateViewEqualCreateCshtml()
	{
		// Act
		var result = _controller.Create();

		// Assert
		var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
		Assert.Equal("Create", viewResult.ViewName);
	}


	[Fact]
	public async Task EditReturnsNotFoundResultWhenIdNotExists()
	{
		// Arrange
		var changes = new Product()
			{ Name = "changed", Description = "desc1", Price = 100, ImageId = 1, StorageId = 1};

		// Act
		var result = await _controller.Edit(changes);

		// Assert
		Assert.IsType<NotFoundResult>(result);
	}

	[Fact]
	public async Task DeleteReturnsNotFoundResultWhenIdNotExists()
	{
		// Arrange
		var testId1 = 0;
		var testId2 = 100;
		var testId3 = new Product()
			{ Name = "changed", Description = "desc1", Price = 100, ImageId = 1, StorageId = 1};

		// Act
		var result1 = await _controller.Delete(testId1);
		var result2 = await _controller.Delete(testId2);
		var result3 = await _controller.Delete(testId3.Id);

		// Assert
		Assert.IsType<NotFoundResult>(result1);
		Assert.IsType<NotFoundResult>(result2);
		Assert.IsType<NotFoundResult>(result3);
	}

	[Fact]
	public async Task DeleteObjectRemovesFromDb()
	{
		// Arrange
		var testId = 1;

		// Act
		await _controller.Delete(testId);

		// Assert
		Assert.Null(await _context.Product
			.Include(p => p.Image)
			.Include(p => p.Storage)
			.FirstOrDefaultAsync(p => p.Id == testId));
	}
}
