using JobPortal.Api;
using JobPortal.Data;
using JobPortal.IRepositories;
using JobPortal.IServices;
using JobPortal.Model;
using JobPortal.Repositories;
using JobPortal.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);



var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("DefaultConnection");


builder.Services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

builder.Services.AddDbContext<JobPortalDbContext>(options =>
{
    options.UseSqlServer(connectionString,b => b.MigrationsAssembly("JobPortal.Api"));

});

builder.Services.AddControllers();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


builder.Services.AddScoped<IPersonalInfoService, PersonalInfoService>();
builder.Services.AddScoped<IPersonalInfoRepository, PersonalInfoRepository>();

builder.Services.AddScoped<IAcademicInfoService, AcademicInfoService>();
builder.Services.AddScoped<IAcademicInfoRepository, AcademicInfoRepository>();


builder.Services.AddScoped<IEmploymentInfoService, EmploymentInfoService>();
builder.Services.AddScoped<IEmploymentInfoRepository, EmploymentInfoRepository>();


builder.Services.AddScoped<IExperienceInfoService, ExperienceInfoService>();
builder.Services.AddScoped<IExperienceInfoRepository, ExperienceInfoRepository>();


builder.Services.AddScoped<IAddressInfoService, AddressInfoService>();
builder.Services.AddScoped<IAddressInfoRepository, AddressInfoRepository>();


builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJwtService, JwtService>();


//ServiceRegistration.AddScopedServices(builder.Services);

// Add services to the container.

var app = builder.Build();



// Configure the HTTP request pipeline.

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
});
app.MapControllers();
app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
