using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Context;
using Models.Dao;

var builder = WebApplication.CreateBuilder(args);

var connexionString = builder.Configuration.GetConnectionString("MainConnectionString");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StiveContext>(
    options => options.UseMySql(connexionString, ServerVersion.AutoDetect(connexionString)));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<StiveContext>().AddDefaultTokenProviders();

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
    //pattern: "{controller=Produits}/{action=Index}/{id?}");

app.Run();
