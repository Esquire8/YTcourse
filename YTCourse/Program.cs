using YTCourse.Interfaces;
using Microsoft.EntityFrameworkCore;
using YTCourse.Data;
using YTCourse.Data.Repository;
using YTCourse.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

//Реализация интерфейсов
builder.Services.AddTransient<ICars, CarRepository>();
builder.Services.AddTransient<ICarsCategories, CategoryRepository>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp => Basket.GetItem(sp));

builder.Services.AddMemoryCache();
builder.Services.AddSession();


string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<AppDBContent>(options => options.UseSqlServer(connection));

//Build app
var app = builder.Build();


//Create a scope
using (var scope = app.Services.CreateScope())
{
    AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
    DBObjects.Itinial(content);
}

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
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cars}/{action=ListCars}/{id?}");

app.Run();
