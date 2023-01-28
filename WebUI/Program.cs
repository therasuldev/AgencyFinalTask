using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var constr = builder.Configuration.GetConnectionString("Default");


builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(constr);
});

builder.Services.AddScoped<IPortfolioRepository,PortfolioRepository>();
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 8;
})
    .AddDefaultTokenProviders()
        .AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
});


app.Run();
