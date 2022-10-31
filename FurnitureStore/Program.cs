using System.Security.Claims;
using FurnitureStore.Data;
using FurnitureStore.Data.Interfaces;
using FurnitureStore.Data.Models;
using FurnitureStore.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
// var connectionString = builder
// 	.Configuration
// 	.GetConnectionString("IdentityContextConnection") ?? throw new InvalidOperationException("Connection string 'IdentityContextConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services
	.AddDbContext<AppDataBaseContext>(options =>
		options.UseSqlServer(
			builder
				.Configuration
				.GetConnectionString("DefaultConnection")
		)
	)
	.AddIdentity<User, Role>(config =>
	{
		config.Password.RequireDigit = false;
		config.Password.RequiredLength = 1;
		config.Password.RequireLowercase = false;
		config.Password.RequireUppercase = false;
		config.Password.RequireNonAlphanumeric = false;
	})
	.AddEntityFrameworkStores<AppDataBaseContext>();

builder.Services.ConfigureApplicationCookie(config =>
{
	config.LoginPath = "/Account/Login";
	config.AccessDeniedPath = "/Account/AccessDenied";
});

// builder.Services
// 	.AddAuthentication("Cookie")
// 	.AddCookie("Cookie", config =>
// 	{
// 		config.LoginPath = "/Account/Login";
// 		config.AccessDeniedPath = "/Home/AccessDenied";
// 	});
builder.Services
	.AddAuthorization(options =>
	{
		options.AddPolicy("Administrator", builder
			=> { builder.RequireClaim(ClaimTypes.Role, "Administrator"); });
		// {
		// 	builder.RequireAssertion(x =>
		// 		x.User.HasClaim(ClaimTypes.Role, "User") || x.User.HasClaim(ClaimTypes.Role, "Administrator"));
		// });
		options.AddPolicy("User", builder =>
			// => { builder.RequireClaim(ClaimTypes.Role, "User"); });
		{
			builder.RequireAssertion(x => x.User.HasClaim(ClaimTypes.Role, "User") || x.User.HasClaim(ClaimTypes.Role, "Administrator"));
		});
	});

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
// builder.Services.AddTransient<IAllUsers, UserRepository>();
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
// app.UseHttpsRedirection();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
// app.UseCors();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Account}/{action=Index}/{id?}");

// app.UseEndpoints(
// 	endpoints =>
// 		endpoints.MapDefaultControllerRoute()
// );

using (var scope = app.Services.CreateScope())
{
	var ctx = scope.ServiceProvider.GetRequiredService<AppDataBaseContext>();
	var userManager = scope.ServiceProvider.GetService<UserManager<User>>();
	DbObjects.Initial(ctx, userManager);
}
// app.UseAuthentication();

app.Run();
