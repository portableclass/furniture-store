using FurnitureStore.Data.Interfaces;
using FurnitureStore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FurnitureStore.Data.Repository;

// public class UserRepository : IAllUsers
// {
// 	private readonly AppDataBaseContext _appDataBaseContent;
//
// 	public IEnumerable<User> Users => _appDataBaseContent.User.Include(w => w.Worker);
// 	public User? GetUser(string username, string password) => _appDataBaseContent.User.SingleOrDefault(x => x.Username == username && x.Password == password);
// 	public async Task CreateUser(User user)
// 	{
// 		await _appDataBaseContent.User.AddAsync(user);
// 		await _appDataBaseContent.SaveChangesAsync();
// 	}
//
// 	public UserRepository(AppDataBaseContext content)
// 	{
// 		_appDataBaseContent = content;
// 	}
// }
