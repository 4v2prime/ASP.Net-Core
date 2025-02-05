using Microsoft.EntityFrameworkCore;
using WebAppDemo.Data;
using WebAppDemo.Data.Infrastructure;
using WebAppDemo.Data.Repository;
using WebAppDemo.Data.Services;
using static WebAppDemo.Data.Repository.ItblUserRepository;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<UM_DBContext>(option => {
    option.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnectionString"));
});


builder.Services.AddScoped<ItblUserRepository, tblUserRepository>();
builder.Services.AddScoped<IDatabaseFactory, DatabaseFactory>();
builder.Services.AddScoped<UserService, UserService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


var app = builder.Build();

// Configure the HTTP request pipeline.
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
