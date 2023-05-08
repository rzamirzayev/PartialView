using Microsoft.EntityFrameworkCore;
using PartialviewPage.DAL;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlServer("Server=DESKTOP-2AMCOF0\\SQLEXPRESS;Database=PartialviewPage;Trusted_Connection=true");
});

var app = builder.Build();
app.MapControllerRoute("default",
    "{controller=home}/{action=index}/{id?}");
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.Run();


