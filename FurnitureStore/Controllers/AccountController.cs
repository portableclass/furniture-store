using System.Security.Claims;
using FurnitureStore.Data;
using FurnitureStore.Data.Interfaces;
using FurnitureStore.Data.Models;
using FurnitureStore.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureStore.Controllers;

[Authorize]
public class AccountController : Controller
{
	private readonly ILogger<AccountController> _logger;
	// private readonly IAllUsers _users;
	private readonly UserManager<User> _userManager;
	private readonly SignInManager<User> _signInManager;

	public AccountController(
		ILogger<AccountController> logger,
		// IAllUsers allUsers,
		UserManager<User> userManager,
		SignInManager<User> signInManager)
	{
		_logger = logger;
		// _users = allUsers;
		_userManager = userManager;
		_signInManager = signInManager;
	}

	public IActionResult Index() => Redirect("/Home/Index");

	// [Authorize(Policy = "Administrator")]
	// public IActionResult Administrator()
	// {
	// 	return View();
	// }
	//
	// [Authorize(Policy = "User")]
	// public IActionResult User()
	// {
	// 	return View();
	// }

	[HttpGet]
	[AllowAnonymous]
	public IActionResult Login(string returnUrl) => View();


	[HttpPost]
	[AllowAnonymous]
	public async Task<IActionResult> Login(UserViewModel user)
	{
		if (!ModelState.IsValid)
			return View(user);


		// var check = _users.GetUser(user.Username, user.Password);
		var check = await _userManager.FindByNameAsync(user.Username);
		if (check == null)
		{
			ModelState.AddModelError("", "User not found");
			return View(user);
		}

		var result = await _signInManager.PasswordSignInAsync(check, user.Password, false, false);
		if (result.Succeeded)
			return Redirect("/Home/Index");

		return View(user);

		// var claims = new List<Claim>
		// {
		// 	new Claim(ClaimTypes.Name,user.Username),
		// 	new Claim(ClaimTypes.Role,"Administrator")
		// };
		// var claimIdentity = new ClaimsIdentity(claims, "Cookie");
		// var claimPrincipal = new ClaimsPrincipal(claimIdentity);
		// await HttpContext.SignInAsync("Cookie", claimPrincipal);
		//
		// return Redirect(user.ReturnUrl);
	}

	public async Task<IActionResult> Logout()
	{
		// HttpContext.SignOutAsync("Cookie");
		await _signInManager.SignOutAsync();
		return Redirect("/Account/Login?ReturnUrl=%2F");
	}

	[AllowAnonymous]
	public IActionResult AccessDenied() => View();
}
