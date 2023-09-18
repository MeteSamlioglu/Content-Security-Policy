using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Data;
using RunGroopWebApp.Repository;
using RunGroopWebApp.Interfaces;
using RunGroopWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using HtmlAgilityPack;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

builder.Services.AddScoped<IClubRepository, ClubRepository>( );

builder.Services.AddScoped<IRaceRepository, RaceRepository>( );

builder.Services.AddScoped<ICspRepository, CspRepository>( );

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}
);


builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddMemoryCache( );
builder.Services.AddSession( );

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie( );


var app = builder.Build();

if(args.Length == 1 && args[0].ToLower() == "seeddata")
{
    await Seed.SeedUsersAndRolesAsync(app);
    //Seed.SeedData(app);

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
app.UseAuthentication( );
app.UseAuthorization();

app.Use(async (context, next) =>

{
    if (context.Request.Path == "/csp-report-endpoint")
    {
        // Set the Content-Type header for CSP reports
        context.Request.ContentType = "application/json";
    }
    
    context.Response.Headers.Add("Content-Security-Policy", "default-src 'self'; script-src 'self'; report-uri /csp-report-endpoint;");

    await next();

});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

    