using FurnitureStore.Data.Interfaces;
using FurnitureStore.Data.Models;
namespace FurnitureStore.Data.Repository;

public class StorageRepository : IAllStorages
{
	private readonly AppDataBaseContext _appDataBaseContent;
	public IEnumerable<Storage> Storages => _appDataBaseContent.Storage.ToList();
	public Storage GetStorage(int storageId) => _appDataBaseContent.Storage.FirstOrDefault(s => s.Id == storageId);

	public StorageRepository(AppDataBaseContext content)
	{
		_appDataBaseContent = content;
	}
}
