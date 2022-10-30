using FurnitureStore.Areas.Identity.Data;
using FurnitureStore.Data;
using FurnitureStore.Data.Interfaces;
using FurnitureStore.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
// var connectionString = builder
// 	.Configuration
// 	.GetConnectionString("IdentityContextConnection") ?? throw new InvalidOperationException("Connection string 'IdentityContextConnection' not found.");

// Add services to the container.
builder.Services.AddDbContext<AppDataBaseContext>(options =>
	options.UseSqlServer(
		builder
			.Configuration
			.GetConnectionString("DefaultConnection")
		)
	);

// builder.Services
// 	.AddDefaultIdentity<ApplicationUser>(options =>
// 		options
// 			.SignIn
// 			.RequireConfirmedAccount = true
// 	)
//     .AddEntityFrameworkStores<IdentityContext>();

builder.Services.AddTransient<IAllStorages, StorageRepository>();
builder.Services.AddTransient<IAllProducts, ProductRepository>();
builder.Services.AddTransient<IAllOrders, OrderRepository>();
builder.Services.AddTransient<IAllWorkers, WorkerRepository>();
builder.Services.AddTransient<IAllCustomers, CustomerRepository>();
builder.Services.AddTransient<IAllImages, ImageRepository>();
builder.Services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	//app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseRouting();
// app.UseCors();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope()) {
	var ctx = scope.ServiceProvider.GetRequiredService<AppDataBaseContext>();
	DbObjects.Initial(ctx);
}
// app.UseAuthentication();

app.Run();
