using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;
using API.Middleware;
using Models.Context;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Models.Dao;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
    .AddIdentityCookies();
builder.Services.AddAuthorizationBuilder();

builder.Services.AddIdentityCore<User>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<StiveContext>()
    .AddApiEndpoints();

//chaine de connexion, recuperee dans le fichier appsettings.json/appsettings.Development.json
string connexionString = builder.Configuration.GetConnectionString("MainConnectionString") ??
    throw (new Exception("Connection string is missing"));

builder.Services.AddDbContext<StiveContext>(options => options
        .UseMySql(connexionString, ServerVersion.AutoDetect(connexionString)));

// Add services to the container.
builder.Services.AddScoped<StiveContext>();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuration nLog
builder.Logging.ClearProviders();
builder.Logging.AddNLog("NLog.config");

var app = builder.Build();

app.MapIdentityApi<User>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<LoggingMiddleware>();

app.Run();
