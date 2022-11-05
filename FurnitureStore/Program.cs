using System.Security.Claims;
using FurnitureStore.Data;
using FurnitureStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure Database context
builder.Services
    .AddDbContext<AppDbContext>(options =>
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
    .AddEntityFrameworkStores<AppDbContext>();

// Configure cookies
builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = "/Account/Login";
    config.AccessDeniedPath = "/Account/AccessDenied";
});

// Configure user rights
builder.Services
    .AddAuthorization(options =>
    {
        options.AddPolicy("Administrator", builder =>
        { builder.RequireClaim(ClaimTypes.Role, "Administrator"); });
        options.AddPolicy("User", builder =>
        {
            builder.RequireAssertion(x =>
                x.User.HasClaim(ClaimTypes.Role, "User") ||
                x.User.HasClaim(ClaimTypes.Role, "Administrator"));
        });
    });

builder.Services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

    //
    app.UseDeveloperExceptionPage();
    app.UseStatusCodePages();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var userManager = scope.ServiceProvider.GetService<UserManager<User>>();
    DbObjects.Initial(ctx, userManager);
}

app.Run();

