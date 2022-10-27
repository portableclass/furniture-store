using FurnitureStore.Data.Interfaces;
using FurnitureStore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FurnitureStore.Data.Repository;

public class WorkerRepository : IAllWorkers
{
	private readonly AppDataBaseContent _appDataBaseContent;

	public WorkerRepository(AppDataBaseContent content)
	{
		_appDataBaseContent = content;
	}

	public IEnumerable<Worker> Workers => _appDataBaseContent.Worker.Include(w => w);
	public Worker GetWorker(int workerId) => _appDataBaseContent.Worker.FirstOrDefault(w => w.Id == workerId);
}
