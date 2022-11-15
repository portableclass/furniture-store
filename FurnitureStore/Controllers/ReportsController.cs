using System.Diagnostics;
using FurnitureStore.Data;
using Microsoft.AspNetCore.Mvc;
using FurnitureStore.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace FurnitureStore.Controllers;

[Authorize(Policy = "User")]
public class ReportsController : Controller
{
    private readonly AppDbContext _context;
    private readonly ILogger<ReportsController> _logger;

    public ReportsController(AppDbContext context, ILogger<ReportsController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
