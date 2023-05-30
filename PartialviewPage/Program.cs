using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PartialviewPage.DAL;
using PartialviewPage.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlServer("Server=DESKTOP-2AMCOF0\\SQLEXPRESS;Database=PartialviewPage;Trusted_Connection=true");
});
builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequiredLength = 8;
}).AddDefaultTokenProviders().AddEntityFrameworkStores<DataContext>();

var app = builder.Build();
app.MapControllerRoute("default",
    "{controller=home}/{action=index}/{id?}");
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.Run();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

