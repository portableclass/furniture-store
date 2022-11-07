namespace FurnitureStore.Tests.Controllers;

public class HomeControllerTest
{
	private ILogger<HomeController> _logger;
	private HomeController _controller;
	private ViewResult _result;

	public HomeControllerTest()
	{
		// Arrange
		_logger = new Mock<ILogger<HomeController>>().Object;
		_controller = new HomeController(_logger);

		// Act
		_result = _controller.Index() as ViewResult;
	}

	[Fact]
	public void IndexViewResultNotNull()
	{
		// Assert
		Assert.NotNull(_result);
	}

	[Fact]
	public void IndexViewEqualIndexCshtml()
	{
		// Assert
		Assert.Equal("Index", _result.ViewName);
	}
}
