using System.Globalization;
using System.Security.Claims;
using FurnitureStore.Data.Models;
using FurnitureStore.Helpers;
using Microsoft.AspNetCore.Identity;

namespace FurnitureStore.Data;

public class DbObjects
{
	private static Dictionary<string, Product> _products;
	private static Dictionary<string, Storage> _storages;
	private static Dictionary<string, Order> _orders;
	private static Dictionary<string, Customer> _customers;
	private static Dictionary<string, Worker> _workers;
	private static Dictionary<string, Image> _images;
	// private static Dictionary<string, User> _users;
	//
	// public static Dictionary<string, User> Users
	// {
	// 	get
	// 	{
	// 		if (_users != null) return _users;
	// 		var list2 = new[]
	// 		{
	// 			new User()
	// 			{
	// 				Username = "admin",
	// 				Password = HashPasswordHelper.HashPassword("1234"),
	// 				// Role = Role.Administrator,
	// 				Worker = Workers["Федотова"]
	// 			},
	// 			new User()
	// 			{
	// 				Username = "user",
	// 				Password = HashPasswordHelper.HashPassword("1234"),
	// 				// Role = Role.User,
	// 				Worker = Workers["Елисеев"]
	// 			},
	// 		};
	// 		_users = new Dictionary<string, User>();
	// 		foreach (var el in list2)
	// 			_users.Add(el.Username, el);
	//
	// 		return _users;
	// 	}
	// }
	public static Dictionary<string, Image> Images
	{
		get
		{
			if (_images != null) return _images;
			var list2 = new[]
			{
				new Image()
				{
					Name = "/img/products/img1.png"
				},
				new Image()
				{
					Name = "/img/products/img2.png"
				},
				new Image()
				{
					Name = "/img/products/img3.png"
				},
				new Image()
				{
					Name = "/img/products/img4.png"
				},
				new Image()
				{
					Name = "/img/products/img5.png"
				},
				new Image()
				{
					Name = "/img/products/img6.png"
				},
				new Image()
				{
					Name = "/img/products/img7.png"
				},
				new Image()
				{
					Name = "/img/products/img8.png"
				},
				new Image()
				{
					Name = "/img/products/img9.png"
				},
				new Image()
				{
					Name = "/img/products/img10.png"
				},
			};
			_images = new Dictionary<string, Image>();
			foreach (var el in list2)
				_images.Add(el.Name, el);

			return _images;
		}
	}
	public static Dictionary<string, Product> Products
	{
		get
		{
			if (_products != null) return _products;
			var list = new[]
			{
				new Product
				{
					Name = "name1",
					Description = "desc1",
					// Image = new Image() {
					// 	Name = "img1.png"},
					Image = Images["/img/products/img1.png"],
					Price = 100,
					Storage = Storages["Залесный"]
				},
				new Product
				{
					Name = "name2",
					Description = "desc2",
					// Image = new Image() {
					// 	Name = "img2.png"},
					Image = Images["/img/products/img2.png"],
					Price = 200,
					Storage = Storages["Корегный"]
				},
				new Product
				{
					Name = "name3",
					Description = "desc3",
					// Image = new Image() {
					// 	Name = "img3.png"},
					Image = Images["/img/products/img3.png"],
					Price = 300,
					Storage = Storages["Дальный"]
				},
				new Product
				{
					Name = "name4",
					Description = "desc4",
					// Image = new Image() {
					// 	Name = "img4.png"},
					Image = Images["/img/products/img4.png"],
					Price = 400,
					Storage = Storages["Перечный"]
				},
				new Product
				{
					Name = "name5",
					Description = "desc5",
					// Image = new Image() {
					// 	Name = "img5.png"},
					Image = Images["/img/products/img5.png"],
					Price = 500,
					Storage = Storages["Юный"]
				},
				new Product
				{
					Name = "name6",
					Description = "desc6",
					// Image = new Image() {
					// 	Name = "img6.png"},
					Image = Images["/img/products/img6.png"],
					Price = 600,
					Storage = Storages["Картонный"]
				},
				new Product
				{
					Name = "name7",
					Description = "desc7",
					// Image = new Image() {
					// 	Name = "img7.png"},
					Image = Images["/img/products/img7.png"],
					Price = 700,
					Storage = Storages["Картонный"]
				},
				new Product
				{
					Name = "name8",
					Description = "desc8",
					// Image = new Image() {
					// 	Name = "img8.png"},
					Image = Images["/img/products/img8.png"],
					Price = 800,
					Storage = Storages["Перерабатывающий"]
				},
				new Product
				{
					Name = "name9",
					Description = "desc9",
					// Image = new Image() {
					// 	Name = "img9.png"},
					Image = Images["/img/products/img9.png"],
					Price = 900,
					Storage = Storages["Перерабатывающий"]
				},
				new Product
				{
					Name = "name10",
					Description = "desc10",
					// Image = new Image() {
					// 	Name = "img10.png"
					// },
					Image = Images["/img/products/img10.png"],
					Price = 1000,
					Storage = Storages["Перерабатывающий"]
				}
			};
			_products = new Dictionary<string, Product>();
			foreach (var el in list)
				_products.Add(el.Name, el);

			return _products;
		}
	}
	public static Dictionary<string, Storage> Storages
	{
		get
		{
			if (_storages != null) return _storages;
			var list2 = new[]
			{
				new Storage
				{
					Name = "Залесный",
					City = "Санкт-Петербург",
					Street = "Крамерная",
					House = "16",
					PostalCode = 197626
				},
				new Storage
				{
					Name = "Корегный",
					City = "Москва",
					Street = "Равельная",
					House = "2",
					PostalCode = 192301
				},
				new Storage
				{
					Name = "Дальный",
					City = "Санкт-Петербург",
					Street = "Югославная",
					House = "3",
					PostalCode = 194392
				},
				new Storage
				{
					Name = "Перечный",
					City = "Санкт-Петербург",
					Street = "Графская",
					House = "9",
					PostalCode = 192020
				},
				new Storage
				{
					Name = "Юный",
					City = "Санкт-Петербур",
					Street = "Ленина",
					House = "13",
					PostalCode = 192838
				},
				new Storage
				{
					Name = "Картонный",
					City = "Саратов",
					Street = "Петровская",
					House = "34",
					PostalCode = 191382
				},
				new Storage
				{
					Name = "Перерабатывающий",
					City = "Саратов",
					Street = "Длинная",
					House = "14",
					PostalCode = 193239
				},
				new Storage
				{
					Name = "Крупный",
					City = "Москва",
					Street = "Нейлора",
					House = "65",
					PostalCode = 193913
				},
				new Storage
				{
					Name = "Горный",
					City = "Сочи",
					Street = "Красная",
					House = "11",
					PostalCode = 192323
				},
				new Storage
				{
					Name = "Монастырный",
					City = "Сочи",
					Street = "Гвардейская",
					House = "9",
					PostalCode = 192324
				},
			};
			_storages = new Dictionary<string, Storage>();
			foreach (var el in list2)
				_storages.Add(el.Name, el);

			return _storages;
		}
	}
	public static Dictionary<string, Order> Orders
	{
		get
		{
			if (_orders != null) return _orders;
			var list = new[]
			{
				new Order
				{
					Date = new DateTime(2022, 1, 1),
					Customer = Customers["Ларионова"],
					Worker = Workers["Федотова"],
					Products = new List<Product> {
						Products["name1"],
						Products["name2"],
					}
				},
				new Order
				{
					Date = new DateTime(2022, 1, 2),
					Customer = Customers["Ларионова"],
					Worker = Workers["Федотова"],
					Products = new List<Product> {
						Products["name2"]
					}
				},
				new Order
				{
					Date = new DateTime(2022, 1, 3),
					Customer = Customers["Лазарева"],
					Worker = Workers["Федотова"],
					Products = new List<Product> {
						Products["name3"]
					}
				},
				new Order
				{
					Date = new DateTime(2022, 1, 4),
					Customer = Customers["Лазарева"],
					Worker = Workers["Федотова"],
					Products = new List<Product> {
						Products["name4"]
					}
				},
				new Order
				{
					Date = new DateTime(2022, 1, 5),
					Customer = Customers["Ларионова"],
					Worker = Workers["Елисеев"],
					Products = new List<Product> {
						Products["name5"]
					}
				},
				new Order
				{
					Date = new DateTime(2022, 1, 6),
					Customer = Customers["Наумова"],
					Worker = Workers["Федотова"],
					Products = new List<Product> {
						Products["name6"]
					}
				},
				new Order
				{
					Date = new DateTime(2022, 1, 7),
					Customer = Customers["Бобылёва"],
					Worker = Workers["Елисеев"],
					Products = new List<Product> {
						Products["name7"]
					}
				},
				new Order
				{
					Date = new DateTime(2022, 1, 8),
					Customer = Customers["Ларионова"],
					Worker = Workers["Елисеев"],
					Products = new List<Product> {
						Products["name8"]
					}
				},
				new Order
				{
					Date = new DateTime(2022, 1, 9),
					Customer = Customers["Наумова"],
					Worker = Workers["Елисеев"],
					Products = new List<Product> {
						Products["name9"]
					}
				},
				new Order
				{
					Date = new DateTime(2022, 1, 10),
					Customer = Customers["Бобылёва"],
					Worker = Workers["Елисеев"],
					Products = new List<Product> {
						Products["name10"]
					}
				},
			};
			_orders = new Dictionary<string, Order>();
			foreach (var el in list)
				_orders.Add(el.Date.ToString(CultureInfo.InvariantCulture), el);

			return _orders;
		}
	}
	public static Dictionary<string, Customer> Customers
	{
		get
		{
			if (_customers != null) return _customers;
			var list = new[]
			{
				new Customer {
					Name = "Лилия",
					Patronymic = "Авдеевна",
					Surname = "Анисимова",
					Phone = "7(931)859-97-61",
					City = "Санкт-Петербург",
					Street = "Строителей",
					House = "12",
					PostalCode = 199221,
					Discount = 10
				},
				new Customer {
					Name = "Святослава",
					Patronymic = "Генадиевна",
					Surname = "Федосеева",
					Phone = "7(911)132-59-31",
					City = "Санкт-Петербург",
					Street = "Морская",
					House = "16",
					PostalCode = 191202,
					Discount = 20
				},
				new Customer {
					Name = "Нега",
					Patronymic = "Геласьвна",
					Surname = "Наумова",
					Phone = "7(931)995-38-62",
					City = "Санкт-Петербург",
					Street = "Конная",
					House = "12",
					PostalCode = 192992,
					Discount = 20
				},
				new Customer {
					Name = "Екатерина",
					Patronymic = "Константивна",
					Surname = "Ларионова",
					Phone = "7(911)101-91-30",
					City = "Санкт-Петербург",
					Street = "Дельная",
					House = "2",
					PostalCode = 197283,
					Discount = 10
				},
				new Customer {
					Name = "Гелла",
					Patronymic = "Максимовна",
					Surname = "Лазарева",
					Phone = "7(931)742-51-49",
					City = "Москва",
					Street = "Дельная",
					House = "2",
					PostalCode = 197283,
					Discount = 20
				},
				new Customer {
					Name = "Петр",
					Patronymic = "Никитич",
					Surname = "Лавров",
					Phone = "7(931)859-97-60",
					City = "Саратов",
					Street = "Питейная",
					House = "25",
					PostalCode = 192132,
					Discount = 0
				},
				new Customer {
					Name = "Дарьяна",
					Patronymic = "Максимовна",
					Surname = "Бобылёва",
					Phone = "7(931)762-17-75",
					City = "Санкт-Петербург",
					Street = "Цукетова",
					House = "9",
					PostalCode = 197283,
					Discount = 10
				},
				new Customer {
					Name = "Евгений",
					Patronymic = "Васильевич",
					Surname = "Сидоров",
					Phone = "7(911)729-66-09",
					City = "Саратов",
					Street = "Камчатская",
					House = "11",
					PostalCode = 198723,
					Discount = 3
				},
				new Customer {
					Name = "Алексей",
					Patronymic = "Андеевич",
					Surname = "Крылов",
					Phone = "7(999)999-99-94",
					City = "Москва",
					Street = "Юбилейна",
					House = "13",
					PostalCode = 199283,
					Discount = 40
				},
				new Customer {
					Name = "Юлий",
					Patronymic = "Генадьевич",
					Surname = "Южный",
					Phone = "7(999)999-99-95",
					City = "Москва",
					Street = "Отрочества",
					House = "50",
					PostalCode = 192393,
					Discount = 5
				},
			};
			_customers = new Dictionary<string, Customer>();
			foreach (var el in list)
				_customers.Add(el.Surname, el);

			return _customers;
		}
	}
	public static Dictionary<string, Worker> Workers
	{
		get
		{
			if (_workers != null) return _workers;
			var list = new[]
			{
				new Worker {
					Name = "Денис",
					Patronymic = "Яковлевич",
					Surname = "Елисеев",
					BirthDate = new DateTime(1999, 3, 10),
					Image = "img/workers/img1.png",
					Phone = "7(234)587-88-83",
					Position = "Продавец-консультант",
				},
				new Worker {
					Name = "Юлий",
					Patronymic = "Михаилович",
					Surname = "Горшков",
					BirthDate = new DateTime(1987, 7, 12),
					Image = "/img/workers/img2.png",
					Phone = "7(008)015-81-44",
					Position = "Кладовщик",
				},
				new Worker {
					Name = "Макар",
					Patronymic = "Анатольевич",
					Surname = "Игнатов",
					BirthDate = new DateTime(1989, 12, 12),
					Image = "/img/workers/img3.png",
					Phone = "7(495)197-76-54",
					Position = "Кладовщик",
				},
				new Worker {
					Name = "Гарри",
					Patronymic = "Юрьевич",
					Surname = "Калашников",
					BirthDate = new DateTime(1996, 4, 7),
					Image = "/img/workers/img4.png",
					Phone = "7(495)819-47-48",
					Position = "Консультант",
				},
				new Worker {
					Name = "Элизабет",
					Patronymic = "Валентиновна",
					Surname = "Игнатьева",
					BirthDate = new DateTime(191, 1, 9),
					Image = "/img/workers/img5.png",
					Phone = "7(495)758-40-26",
					Position = "Администратор",
				},
				new Worker {
					Name = "Борислава",
					Patronymic = "Авдеевна",
					Surname = "Федотова",
					BirthDate = new DateTime(1973, 5, 8),
					Image = "img/workers/img6.png",
					Phone = "7(495)758-40-28",
					Position = "Продавец-консультант",
				},
				new Worker {
					Name = "Джон",
					Patronymic = "Юрьевич",
					Surname = "Усупов",
					BirthDate = new DateTime(1995, 3, 9),
					Image = "/img/workers/img7.png",
					Phone = "7(911)729-66-09",
					Position = "Кладовщик",
				},
				new Worker {
					Name = "Кондратий",
					Patronymic = "Афганович",
					Surname = "Норсон",
					BirthDate = new DateTime(1991, 10, 1),
					Image = "/img/workers/img8.png",
					Phone = "7(999)999-99-93",
					Position = "Кладовщик",
				},
				new Worker {
					Name = "Карл",
					Patronymic = "Сергеевич",
					Surname = "Василььев",
					BirthDate = new DateTime(1983, 7, 11),
					Image = "/img/workers/img9.png",
					Phone = "7(911)729-48-29",
					Position = "Бухгалтер",
				},
				new Worker {
					Name = "worker5",
					Patronymic = "patronymic5",
					Surname = "surname5",
					BirthDate = new DateTime(1990, 1, 5),
					Image = "/img/workers/img10.png",
					Phone = "7(999)999-99-95",
					Position = "Консультант",
				},
			};
			_workers = new Dictionary<string, Worker>();
			foreach (var el in list)
				_workers.Add(el.Surname, el);

			return _workers;
		}
	}

	public static void Initial(AppDataBaseContext ctx, UserManager<User> userManager)
	{
		if (!ctx.Users.Any())
		{
			var user = new User()
			{
				UserName = "admin",
				Worker = Workers["Федотова"],
			};
			var result = userManager.CreateAsync(user, "1234").GetAwaiter().GetResult();
			if (result.Succeeded)
			{
				// var claims = new List<Claim>
				// {
				// 	new Claim(ClaimTypes.Name,user.UserName),
				// 	new Claim(ClaimTypes.Role,"Administrator")
				// };
				userManager.AddClaimAsync(user,
					new Claim(ClaimTypes.Role, "Administrator"))
					.GetAwaiter()
					.GetResult();
			}

			var user2 = new User()
			{
				UserName = "user",
				Worker = Workers["Елисеев"],
			};
			var result2 = userManager.CreateAsync(user2, "1234").GetAwaiter().GetResult();
			if (result2.Succeeded)
				userManager.AddClaimAsync(user2,
						new Claim(ClaimTypes.Role, "User"))
					.GetAwaiter()
					.GetResult();
		}

		if (!ctx.Product.Any())
			ctx.Product.AddRange(Products.Select(p => p.Value));
		if (!ctx.Storage.Any())
			ctx.Storage.AddRange(Storages.Select(s => s.Value));
		if (!ctx.Order.Any())
			ctx.Order.AddRange(Orders.Select(o => o.Value));
		if (!ctx.Customer.Any())
			ctx.Customer.AddRange(Customers.Select(c => c.Value));
		if (!ctx.Worker.Any())
			ctx.Worker.AddRange(Workers.Select(w => w.Value));

		ctx.SaveChanges();
	}
}
