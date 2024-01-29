using ClassWork_WebApp_17._12._2023.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using ClassWork_WebApp_17._12._2023.Models;
using Microsoft.EntityFrameworkCore;
using ClassWork_WebApp_17._12._2023.Services;
using Serilog;


Log.Logger = new LoggerConfiguration()
	.WriteTo.Console()
	.CreateLogger();
try
{
	Log.Information("Starting web application");
	var builder = WebApplication.CreateBuilder(args);
	builder.Services.AddRazorPages();
	builder.Services.AddServerSideBlazor();
	//var builder = WebApplication.CreateBuilder(args);
	builder.Host.UseSerilog(); // <-- Add this line
	builder.Services.AddOptions<SmtpConfig>()
   .BindConfiguration("SmtpConfig");
	builder.Services.AddSingleton<IEmailSender, SmtpEmailSender>();
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
}
catch (Exception ex)
{
	Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
	Log.CloseAndFlush();
}


