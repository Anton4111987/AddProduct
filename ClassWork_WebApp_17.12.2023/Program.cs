using ClassWork_WebApp_17._12._2023.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using ClassWork_WebApp_17._12._2023.Models;
using Microsoft.EntityFrameworkCore;
using ClassWork_WebApp_17._12._2023.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

/*builder.Services.AddOptions<SmtpConfig>()
	.BindConfiguration("SmtpConfig")
	.ValidateDataAnnotations()
	.ValidateOnStart();*/

//builder.Host.UseSerilog((_, conf) => conf.WriteTo.Console());
/*builder.Services.Configure<SmtpConfig>(options =>
{
	builder.Configuration.GetSection("SmtpConfig").Bind(options);
});*/

builder.Services.AddOptions<SmtpConfig>()
   .BindConfiguration("SmtpConfig");

builder.Services.AddScoped<IEmailSender, SmtpEmailSender>();

builder.Services.AddScoped<IProductRepository, InDbSQLiteCatalog>();             //      InMemoryCatalog>();                            
builder.Services.AddSingleton<INowTime, NowTimeInUTC>();
builder.Services.AddDbContext<AppDbContext>(options =>
{
	options.UseSqlite(builder.Configuration.GetConnectionString("AppDb"));
});



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
