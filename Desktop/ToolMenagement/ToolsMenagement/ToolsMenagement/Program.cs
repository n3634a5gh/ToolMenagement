using Microsoft.EntityFrameworkCore;
using System.Configuration;
using ToolsMenagement.Interfaces;
using ToolsMenagement.Models;
using ToolsMenagement.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ToolsBaseContext>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IToolRepository, ToolRepository>();
builder.Services.AddScoped<ITechnologyRepository, TechnologyRepository>();

builder.Services.AddControllersWithViews();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
