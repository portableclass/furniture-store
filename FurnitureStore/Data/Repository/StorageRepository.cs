using FurnitureStore.Data.Interfaces;
using FurnitureStore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FurnitureStore.Data.Repository;

public class StorageRepository : IAllStorages
{
	private readonly AppDataBaseContent _appDataBaseContent;

	public StorageRepository(AppDataBaseContent content)
	{
		_appDataBaseContent = content;
	}

	public IEnumerable<Storage> Storages => _appDataBaseContent.Storage.Include(s => s);
	public Storage GetStorage(int storageId) => _appDataBaseContent.Storage.FirstOrDefault(s => s.Id == storageId);
}
