using FurnitureStore.Data.Models;
using FurnitureStore.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureStore.Controllers;

[Authorize]
public class AccountController : Controller
{
	private readonly ILogger<AccountController> _logger;
	private readonly UserManager<User> _userManager;
	private readonly SignInManager<User> _signInManager;

	public AccountController(
		ILogger<AccountController> logger,
		UserManager<User> userManager,
		SignInManager<User> signInManager)
	{
		_logger = logger;
		_userManager = userManager;
		_signInManager = signInManager;
	}

	[HttpGet]
	[AllowAnonymous]
	public IActionResult Index() => View();

	[HttpPost]
	[AllowAnonymous]
	public async Task<IActionResult> Index(AccountIndexViewModel model)
	{
		if (!ModelState.IsValid)
		{
			return View(model);
		}

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
		return Redirect("/Account/Index");
	}

	[HttpGet]
	[AllowAnonymous]
	public IActionResult AccessDenied() => View();
}
