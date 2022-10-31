using FurnitureStore.Data.Models;

namespace FurnitureStore.Data.Interfaces;

public interface IAllUsers
{
	IEnumerable<User> Users { get; }
	User? GetUser(string username, string password);
	Task CreateUser(User userId);
}
