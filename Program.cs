using Microsoft.EntityFrameworkCore;
using MVC_Aptech.Models;
using MVC_Aptech.Repository;
using MVC_Aptech.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string? connectionString = builder.Configuration?.GetConnectionString("MyConnection");
builder.Services.AddDbContext<UserDBContext>(options => options.UseSqlServer(connectionString));

// Register Repository
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Register Service
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
