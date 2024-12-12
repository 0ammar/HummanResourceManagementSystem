using HummanResourceManagementSystem.Context;
using HummanResourceManagementSystem.Implementation;
using HummanResourceManagementSystem.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Add Swagger generation
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Mango HR API",
        Version = "first version",
        Description = "An API For Control and Manage Humman Resourse Management System",
        Contact = new OpenApiContact
        {
            Name = "Ammar Arab",
            Email = "oammar@outlook.sa",
            Url = new Uri("https://0ammar.github.io/Personal-site/")
            
        }
    });
    //enabling xml comments
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    option.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

// Configure the database connection
builder.Services.AddDbContext<HRMSDbContext>(con => con.UseSqlServer(
	"Data Source=AMMAR-ARAB\\SQLEXPRESS;Initial Catalog=HRMS;Integrated Security=True;Trust Server Certificate=True"));

// Dependency injection for DepartmentService
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<ILookupService, LookupService>();
builder.Services.AddScoped<IContractService, ContractService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IAuthanticationService, AuthanticationService>();
//Configure Serilog 
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
//string loggerPath = configuration.GetSection("LoggerPath").Value;
Serilog.Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).
                WriteTo.File(Path.Combine(Directory.GetCurrentDirectory(), "Logs/HRLogging.txt"), rollingInterval: RollingInterval.Day).
                CreateLogger();
var app = builder.Build();

// Configure the HTTP request pipeline for Swagger
app.UseSwagger();
app.UseSwaggerUI();

// HTTPS redirection
app.UseHttpsRedirection();

//Configure Static File
app.UseStaticFiles();
var imagesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(imagesDirectory),
    RequestPath = "/Uploads"
});


// Authorization middleware
app.UseAuthorization();

// Map controllers
app.MapControllers();

// Start the application
try
{
    Log.Information("Start Running The API");
    Log.Information("App Runs Successfully");
    app.Run();
    
}
catch (Exception ex)
{
    Log.Information("An Error Occured");
    Log.Error($"Error {ex.Message} was Prevernt Application from run successfully");
}
finally
{
    Log.Warning("Test Warning");
}

