using eMovies.Controllers;
using eMovies.Data;
using eMovies.Data.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//eshte si translator mes c# classes dhe database ,e kem definu edhe sql serverin permes connection stringut.
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

//Services configuration
//actors service configuration
builder.Services.AddScoped<IActorsService, ActorsService>();
builder.Services.AddScoped<IProducersService, ProducersService>();
builder.Services.AddScoped<ICinemasService, CinemasService>();

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

//Seed database
AppDbInitializer.Seed(app);


app.Run();
