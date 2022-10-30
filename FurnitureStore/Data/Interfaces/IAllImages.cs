using FurnitureStore.Data.Models;

namespace FurnitureStore.Data.Interfaces;

public interface IAllImages
{
	IEnumerable<Image> Images { get; }
	Image GetImage(int imageId);
	Task CreateImage(Image image);
}
