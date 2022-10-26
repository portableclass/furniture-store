using FurnitureStore.Data.Interfaces;
using FurnitureStore.Data.Models;

namespace FurnitureStore.Data.Mocks;
public class MockWorker : IAllWorkers
{
    public IEnumerable<Worker> Workers
    {
        get
        {
            return new List<Worker>
            {
                new Worker {
                    Name = "worker1",
                    Patronymic = "patronymic1",
                    Surname = "surname1",
                    BirthDate = new DateTime(1990, 1, 1),
                    Image = "img1",
                    Phone = "79999999991",
                    Position = "pos1",
                },
                new Worker {
                    Name = "worker2",
                    Patronymic = "patronymic2",
                    Surname = "surname2",
                    BirthDate = new DateTime(1990, 1, 2),
                    Image = "img2",
                    Phone = "79999999992",
                    Position = "pos2",
                },
                new Worker {
                    Name = "worker3",
                    Patronymic = "patronymic3",
                    Surname = "surname3",
                    BirthDate = new DateTime(1990, 1, 3),
                    Image = "img3",
                    Phone = "79999999993",
                    Position = "pos3",
                },
                new Worker {
                    Name = "worker4",
                    Patronymic = "patronymic4",
                    Surname = "surname4",
                    BirthDate = new DateTime(1990, 1, 4),
                    Image = "img4",
                    Phone = "79999999994",
                    Position = "pos4",
                },
                new Worker {
                    Name = "worker5",
                    Patronymic = "patronymic5",
                    Surname = "surname5",
                    BirthDate = new DateTime(1990, 1, 5),
                    Image = "img5",
                    Phone = "79999999995",
                    Position = "pos5",
                },
            };
        }
    }

    public Worker GetWorker(int workerId)
    {
        return Workers.First();
    }
}