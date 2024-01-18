using ClassWork_WebApp_17._12._2023.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using ClassWork_WebApp_17._12._2023.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddTransient<IProductRepository, InDbSQLiteCatalog>();             //      InMemoryCatalog>();                            
builder.Services.AddTransient<INowTime, NowTimeInUTC>();
builder.Services.AddDbContext<AppDbContext>(options =>
{
	options.UseSqlite(builder.Configuration.GetConnectionString("AppDb"));
});
//builder.Services.AddSingleton<ICatalog> (new InJsonFileCatalog("products.json"));


builder.Services.AddTransient<ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
