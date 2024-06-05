using denemelog.Data;
using denemelog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Configure services for IdentityDbContext
var identityConnectionString = builder.Configuration.GetConnectionString("IdentityConnection");
builder.Services.AddDbContext<IdentityDbContext>(options =>
    options.UseSqlite(identityConnectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<IdentityDbContext>();

// Configure services for CoffeeDbContext
var coffeeConnectionString = builder.Configuration.GetConnectionString("CoffeeConnection");
builder.Services.AddDbContext<CoffeeDbContext>(options =>
    options.UseSqlite(coffeeConnectionString));

// Configure services for RestaurantDbContext
var restaurantConnectionString = builder.Configuration.GetConnectionString("RestaurantConnection");
builder.Services.AddDbContext<RestaurantDbContext>(options =>
    options.UseSqlite(restaurantConnectionString));

// Add other services
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); // Ensure Razor Pages are added

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages(); // Ensure Razor Pages are mapped

app.Run();