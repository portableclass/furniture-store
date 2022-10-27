using FurnitureStore.Data.Models;
namespace FurnitureStore.Data.Interfaces;

public interface IAllWorkers
{
	IEnumerable<Worker> Workers { get; }
	Worker GetWorker(int workerId);
}
