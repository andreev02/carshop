using WebApplication2.Data;
using WebApplication2.Data.Interfaces;
using WebApplication2.Data.Mocks;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data.Repository;
using WebApplication2.Data.Models;


//---
var builder = WebApplication.CreateBuilder(args);

IConfigurationRoot _configString;
_configString = new ConfigurationBuilder().SetBasePath(builder.Environment.ContentRootPath).AddJsonFile("db_settings.json").Build();

builder.Services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_configString.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IAllCars, CarRepository>();
builder.Services.AddTransient<ICarsCategory, CategoryRepository>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp => ShopCart.GetCart(sp));

builder.Services.AddMvc(option => option.EnableEndpointRouting = false);
builder.Services.AddMemoryCache();
builder.Services.AddSession();

//---
var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseSession();
app.UseMvcWithDefaultRoute();

using (var scope = app.Services.CreateScope())
{
    AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
    DBObjects.Initialize(content);
}

//---
app.MapGet("/", () => "Hello World!");
app.Run();

