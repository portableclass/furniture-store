﻿using FurnitureStore.Data;
using FurnitureStore.Data.Interfaces;
using FurnitureStore.Data.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDataBaseContext>(options =>
	options.UseSqlServer(
		builder
			.Configuration
			.GetConnectionString("DefaultConnection")
		)
	);
builder.Services.AddTransient<IAllStorages, StorageRepository>();
builder.Services.AddTransient<IAllProducts, ProductRepository>();
builder.Services.AddTransient<IAllOrders, OrderRepository>();
builder.Services.AddTransient<IAllWorkers, WorkerRepository>();
builder.Services.AddTransient<IAllCustomers, CustomerRepository>();
//builder.Services.AddTransient<IAllStorages, MockStorage>();
//builder.Services.AddTransient<IAllProducts, MockProduct>();
//builder.Services.AddTransient<IAllOrders, MockOrder>();
//builder.Services.AddTransient<IAllWorkers, MockWorker>();
//builder.Services.AddTransient<IAllCustomers, MockCustomer>();
builder.Services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	//app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	//app.UseHsts();
}

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Products}/{action=List}");

using (var scope = app.Services.CreateScope()) {
	AppDataBaseContext ctx = scope.ServiceProvider.GetRequiredService<AppDataBaseContext>();
	DbObjects.Initial(ctx);
}

app.Run();
