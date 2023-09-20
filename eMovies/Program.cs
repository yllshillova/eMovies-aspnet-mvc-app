using eMovies.Controllers;
using eMovies.Data;
using eMovies.Data.Cart;
using eMovies.Data.Services;
using eMovies.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//eshte si translator mes c# classes dhe database ,e kem definu edhe sql serverin permes connection stringut.
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
//builder.Services.AddSwaggerGen();
//Services configuration
//actors service configuration
builder.Services.AddScoped<IActorsService, ActorsService>();
builder.Services.AddScoped<IProducersService, ProducersService>();
builder.Services.AddScoped<ICinemasService, CinemasService>();
builder.Services.AddScoped<IMoviesService, MoviesService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(delegate (IServiceProvider sc)
{
    return ShoppingCart.GetShoppingCart(sc);
});
builder.Services.AddScoped<IOrdersService, OrdersService>();


//Authentication and authorization
//addidentity i ka 2 parametra i pari osht identityuser class(applicationUser) edhe i dyti identityRole
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.Configure<IdentityOptions>(options =>
{
    // Other identity configurations...

    options.Password.RequireDigit = false; // Do not require a digit (number).
    options.Password.RequireLowercase = false; // Do not require a lowercase letter.
    options.Password.RequireUppercase = false; // Do not require an uppercase letter.
    options.Password.RequireNonAlphanumeric = false; // Do not require a special character.
    options.Password.RequiredLength = 1; // Set the minimum password length you desire.
});
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(options => {
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
});



var app = builder.Build();


//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
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

//Authentication and authorization

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Seed database
AppDbInitializer.Seed(app);
AppDbInitializer.SeedUsersAndRolesAsync(app).Wait();

app.Run();
