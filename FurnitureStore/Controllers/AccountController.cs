using FurnitureStore.Data;
using FurnitureStore.Data.Models;
using FurnitureStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureStore.Controllers;

[Authorize]
public class AccountController : Controller
{
	private readonly ILogger<AccountController> _logger;
	private readonly UserManager<User> _userManager;
	private readonly RoleManager<Role> _roleManager;
	private readonly SignInManager<User> _signInManager;
	private readonly AppDbContext _context;
	private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

	public AccountController(
		ILogger<AccountController> logger,
		UserManager<User> userManager,
		SignInManager<User> signInManager,
		AppDbContext context,
		RoleManager<Role> roleManager
		)
	{
		_logger = logger;
		_userManager = userManager;
		_roleManager = roleManager;
		_signInManager = signInManager;
		_context = context;
	}

	[HttpGet]
	public async Task<IActionResult> Index()
	{
		var user = await GetCurrentUserAsync();
		var worker = await _context.Worker.FindAsync(user.WorkerId);
		var model = new AccountIndexViewModel()
		{
			Worker = worker
		};

		return View(model);
	}

	[HttpGet]
	[AllowAnonymous]
	public IActionResult Login() => View(new AccountIndexViewModel());

	[HttpPost]
	[AllowAnonymous]
	public async Task<IActionResult> Login(AccountIndexViewModel model)
	{
		model.IsValid = "is-invalid";
		if (!ModelState.IsValid)
			return View(model);

		var check = await _userManager.FindByNameAsync(model.Username);
		if (check == null)
		{
			ModelState.AddModelError("", "User not found");
			return View(model);
		}

		var result = await _signInManager.PasswordSignInAsync(check, model.Password, false, false);
		if (result.Succeeded)
			return Redirect("/Home/Index");

		ModelState.AddModelError("", "Password not correct");
		return View(model);
	}

	[HttpGet]
	public async Task<IActionResult> Logout()
	{
		await _signInManager.SignOutAsync();
		return Redirect("/Account/Login");
	}

	[HttpGet]
	[AllowAnonymous]
	public IActionResult AccessDenied() => View();
}
