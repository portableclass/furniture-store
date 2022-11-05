using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FurnitureStore.Data;
using FurnitureStore.Data.Models;
using FurnitureStore.ViewModels;

namespace FurnitureStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _hostEnv;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(
            AppDbContext context,
            ILogger<ProductsController> logger,
            IWebHostEnvironment hostEnv
        )
        {
            _context = context;
            _hostEnv = hostEnv;
            _logger = logger;
        }

        // GET: Products
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Product
                .Include(p => p.Image)
                .Include(p => p.Storage);
            // return View(await appDbContext.ToListAsync());

            var model = new ProductIndexViewModel
            {
                Products = appDbContext
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(ProductIndexViewModel model)
        {
            // var newModel = new ProductIndexViewModel()
            // {
            //     Products = _products.ProductsOrderBy(model.SortingField, model.SortingTrend)
            // };
            // return View(newModel);

            string sortingField = model.SortingField;
            string sortingTrend = model.SortingTrend;

            var appDbContext = sortingTrend switch
            {
                "1" => sortingField switch
                {
                    "1" => _context.Product.OrderBy(p => p.Name).Include(i => i.Image).Include(s => s.Storage),
                    "2" => _context.Product.OrderBy(p => p.Price).Include(i => i.Image).Include(s => s.Storage),
                    "3" => _context.Product.OrderBy(p => p.Description)
                        .Include(i => i.Image)
                        .Include(s => s.Storage),
                    _ => _context.Product.Include(i => i.Image).Include(s => s.Storage)
                },
                "2" => sortingField switch
                {
                    "1" => _context.Product.OrderByDescending(p => p.Name)
                        .Include(i => i.Image)
                        .Include(s => s.Storage),
                    "2" => _context.Product.OrderByDescending(p => p.Price)
                        .Include(i => i.Image)
                        .Include(s => s.Storage),
                    "3" => _context.Product.OrderByDescending(p => p.Description)
                        .Include(i => i.Image)
                        .Include(s => s.Storage),
                    _ => _context.Product.OrderByDescending(p => p.Name)
                        .Include(i => i.Image)
                        .Include(s => s.Storage)
                },
                _ => _context.Product.Include(i => i.Image).Include(s => s.Storage)
            };

            var newModel = new ProductIndexViewModel()
            {
                Products = appDbContext
            };
            return View(newModel);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Image)
                .Include(p => p.Storage)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            // ViewData["ImageId"] = new SelectList(_context.Image, "Id", "Id");
            // ViewData["StorageId"] = new SelectList(_context.Storage, "Id", "Id");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Name,Description,Price,StorageId,ImageId,Image")]
            Product product
        )
        {
            if (!ModelState.IsValid) return View(product);

            // _context.Add(product);
            // await _context.SaveChangesAsync();

            // create new image
            var image = new Image()
            {
                Name = product.Name,
                File = product.Image.File
            };

            var rootPath = _hostEnv.WebRootPath;
            const string distPath = "/img/products/";

            DirectoryInfo dInfo = new DirectoryInfo(rootPath + distPath);
            if (!dInfo.Exists)
                dInfo.Create();

            var fName = Path.GetFileNameWithoutExtension(image.Name);
            var fExt = Path.GetExtension(image.File.FileName);
            var temp = fName + DateTime.Now + fExt;
            image.Name = distPath + fName + DateTime.Now + fExt;

            var path = Path.Combine(rootPath, dInfo + temp);
            await using (var fs = new FileStream(path, FileMode.Create))
            {
                await image.File.CopyToAsync(fs);
            }

            await _context.Image.AddAsync(image);
            await _context.SaveChangesAsync();

            // create new product
            var newProduct = new Product()
            {
                Name = product.Name,
                Description = product.Description,
                Image = image,
                Price = product.Price,
                StorageId = 1,
            };

            await _context.Product.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
            // ViewData["ImageId"] = new SelectList(_context.Image, "Id", "Id", product.ImageId);
            // ViewData["StorageId"] = new SelectList(_context.Storage, "Id", "Id", product.StorageId);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            // ViewData["ImageId"] = new SelectList(_context.Image, "Id", "Id", product.ImageId);
            // ViewData["StorageName"] = new SelectList(_context.Storage, "Name", "Name", product.Storage.Name);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            // int id,
            // [Bind("Id,Name,Description,Price,StorageId,ImageId")]
            Product product
        )
        {
            // if (id != product.Id)
            // {
            //     return NotFound();
            // }

            // if (ModelState.IsValid)
            // {
            //     try
            //     {
            //         _context.Update(product);
            //         await _context.SaveChangesAsync();
            //     }
            //     catch (DbUpdateConcurrencyException)
            //     {
            //         if (!ProductExists(product.Id))
            //         {
            //             return NotFound();
            //         }
            //         else
            //         {
            //             throw;
            //         }
            //     }
            //     return RedirectToAction(nameof(Index));
            // }
            // ViewData["ImageId"] = new SelectList(_context.Image, "Id", "Id", product.ImageId);
            // ViewData["StorageId"] = new SelectList(_context.Storage, "Id", "Id", product.StorageId);
            // return View(product);

            // if (!ModelState.IsValid)
            //     return View(product);

            if (product.Id != 0)
            {
                _context.Product.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Image)
                .Include(p => p.Storage)
                .FirstOrDefaultAsync(m => m.Id == id);

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            // var product = await _context.Product
            //     .Include(p => p.Image)
            //     .Include(p => p.Storage)
            //     .FirstOrDefaultAsync(m => m.Id == id);
            // if (product == null)
            // {
            //     return NotFound();
            // }
            //
            // return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Product == null)
            {
                return Problem("Entity set 'AppDbContext.Product'  is null.");
            }

            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult ExportData(ProductIndexViewModel model)
        {
            var appDbContext = _context.Product
                .Include(p => p.Image)
                .Include(p => p.Storage);

            // object bobik = new dog();
            // foreach(FieldInfo field in bobik.GetType().GetFields())
            // {
	           //  Console.WriteLine("{0} {1} {2}", field.FieldType, field.Name, field.GetValue(bobik));
            // }
            switch (model.ExportType)
            {
                case "1":
                {
                    var builder = new StringBuilder();
                    builder.AppendLine("Id,Name,Description,Price,StorageId,ImageId");
                    foreach (var product in appDbContext)
                    {
	                    // string line = String.Empty;
	                    // foreach (var field in product.GetType().GetFields())
	                    // {
		                   //  line += $"{field.GetValue(product)},";
		                   //  int f = 1;
	                    // }

	                    // builder.AppendLine(line);
	                    builder.AppendLine($"{product.Id}," +
	                                       $"{product.Name}," +
	                                       $"{product.Description}," +
	                                       $"{product.Price}," +
	                                       $"{product.StorageId}," +
	                                       $"{product.ImageId}");
                    }

                    return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "products.csv");
                }
                case "2":
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Products");
                        var currentRow = 1;
                        worksheet.Cell(currentRow, 1).Value = "Id";
                        worksheet.Cell(currentRow, 2).Value = "Name";
                        worksheet.Cell(currentRow, 3).Value = "Description";
                        worksheet.Cell(currentRow, 4).Value = "Price";
                        worksheet.Cell(currentRow, 5).Value = "StorageId";
                        worksheet.Cell(currentRow, 6).Value = "ImageId";
                        foreach (var product in appDbContext)
                        {
                            currentRow++;
                            worksheet.Cell(currentRow, 1).Value = product.Id;
                            worksheet.Cell(currentRow, 2).Value = product.Name;
                            worksheet.Cell(currentRow, 3).Value = product.Description;
                            worksheet.Cell(currentRow, 4).Value = product.Price;
                            worksheet.Cell(currentRow, 5).Value = product.StorageId;
                            worksheet.Cell(currentRow, 6).Value = product.ImageId;
                        }

                        using (var stream = new MemoryStream())
                        {
                            workbook.SaveAs(stream);
                            var content = stream.ToArray();
                            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                                "products.xlsx");
                        }
                    }
                }
                case "3":
                {
                    var xDoc = new XDocument();
                    xDoc.Declaration = new XDeclaration("1.0", "utf-8", "no");
                    xDoc.Add(new XElement("Products",
                        appDbContext.ToList().Select(product => new XElement("Product",
                            new XAttribute("Id", product.Id),
                            new XElement("Name", product.Name),
                            new XElement("Description", product.Description),
                            new XElement("Price", product.Price),
                            new XElement("StorageId", product.StorageId),
                            new XElement("ImageId", product.ImageId)
                        ))
                    ));

                    var sw = new StringWriter();
                    xDoc.Save(sw);
                    // return Content(sw.ToString(), "text/xml");
                    return File(Encoding.UTF8.GetBytes(sw.ToString()), "text/xml", "products.xml");
                }
                default: return NotFound();
            }
        }

        private bool ProductExists(int id)
        {
            return (_context.Product?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
	        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
