using FurnitureStore.Data.Interfaces;
using FurnitureStore.Data.Models;
namespace FurnitureStore.Data.Repository;

public class WorkerRepository : IAllWorkers
{
	private readonly AppDataBaseContext _appDataBaseContent;
	public IEnumerable<Worker> Workers => _appDataBaseContent.Worker.ToList();
	public Worker GetWorker(int workerId) => _appDataBaseContent.Worker.FirstOrDefault(w => w.Id == workerId);

	public WorkerRepository(AppDataBaseContext content)
	{
		_appDataBaseContent = content;
	}
}
