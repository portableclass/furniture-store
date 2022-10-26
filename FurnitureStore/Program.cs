using FurnitureStore.Data.Interfaces;
using FurnitureStore.Data.Mocks;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IAllStorages, MockStorage>();
builder.Services.AddTransient<IAllProducts, MockProduct>();
builder.Services.AddTransient<IAllOrders, MockOrder>();
builder.Services.AddTransient<IAllWorkers, MockWorker>();
builder.Services.AddTransient<IAllCustomers, MockCustomer>();
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

app.Run();

