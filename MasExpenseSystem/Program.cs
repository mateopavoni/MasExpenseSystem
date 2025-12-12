using DotNetEnv;
using MasExpenseSystem.Context;
using MasExpenseSystem.Managers;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

Env.Load();

var sqlString = builder.Configuration.GetConnectionString("SqlString");

sqlString = sqlString
    .Replace("{SQLSERVER}", Environment.GetEnvironmentVariable("SQLSERVER"))
    .Replace("{DBNAME}", Environment.GetEnvironmentVariable("DBNAME"))
    .Replace("{DBUSER}", Environment.GetEnvironmentVariable("DBUSER"))
    .Replace("{DBPASSWORD}", Environment.GetEnvironmentVariable("DBPASSWORD"));

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(sqlString);
});

builder.Services.AddScoped<ServiceManager>();
builder.Services.AddScoped<TransactionManager>();
builder.Services.AddScoped<UserManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}")
    .WithStaticAssets();


app.Run();
