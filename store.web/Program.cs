using Application.Services.Account;
using DataLayer.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IUserService,UserService>();

builder.Services.AddDbContext<DBContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DBConnectionString"));
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
