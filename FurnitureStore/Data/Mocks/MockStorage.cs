using FurnitureStore.Data.Interfaces;
using FurnitureStore.Data.Models;
namespace FurnitureStore.Data.Mocks;

public class MockStorage : IAllStorages
{
    public IEnumerable<Storage> Storages =>
	    new List<Storage>
	    {
		    new Storage {
			    Name = "storage1",
			    City = "city1",
			    Street = "street1",
			    House = "1",
			    PostalCode = 192342
		    },
		    new Storage {
			    Name = "storage2",
			    City = "city2",
			    Street = "street2",
			    House = "2",
			    PostalCode = 192342
		    },
		    new Storage {
			    Name = "storage3",
			    City = "city3",
			    Street = "street3",
			    House = "1",
			    PostalCode = 192342
		    },
		    new Storage {
			    Name = "storage4",
			    City = "city4",
			    Street = "street4",
			    House = "4",
			    PostalCode = 192342
		    },
		    new Storage {
			    Name = "storage5",
			    City = "city5",
			    Street = "street5",
			    House = "5",
			    PostalCode = 192342
		    },
	    };

    public Storage GetStorage(int storageId)
    {
        return Storages.First();
    }
}
