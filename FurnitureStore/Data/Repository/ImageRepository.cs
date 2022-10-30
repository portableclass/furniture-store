using FurnitureStore.Data.Interfaces;
using FurnitureStore.Data.Models;

namespace FurnitureStore.Data.Repository;

public class ImageRepository : IAllImages
{
	private readonly AppDataBaseContext _appDataBaseContent;
	private readonly IWebHostEnvironment _hostEnv;
	public IEnumerable<Image> Images => _appDataBaseContent.Image.ToList();
	public Image GetImage(int imageId) => _appDataBaseContent.Image.FirstOrDefault(i => i.Id == imageId);
	public async Task CreateImage(Image image)
	{
		string rootPath = _hostEnv.WebRootPath;
		string distPath = "/img/products/";

		DirectoryInfo dInfo = new DirectoryInfo(rootPath + distPath);
		if (!dInfo.Exists)
			dInfo.Create();

		string fName = Path.GetFileNameWithoutExtension(image.Name);
		string fExt = Path.GetExtension(image.File.FileName);
		string temp = fName + DateTime.Now + fExt;
		image.Name = distPath + fName + DateTime.Now + fExt;

		string path = Path.Combine(rootPath, dInfo + temp);
		await using (var fs = new FileStream(path, FileMode.Create))
		{
			await image.File.CopyToAsync(fs);

		}

		await _appDataBaseContent.Image.AddAsync(image);
		await _appDataBaseContent.SaveChangesAsync();
	}

	public ImageRepository(AppDataBaseContext content, IWebHostEnvironment env)
	{
		_appDataBaseContent = content;
		_hostEnv = env;
	}
}
