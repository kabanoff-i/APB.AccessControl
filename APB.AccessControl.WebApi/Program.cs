using Microsoft.EntityFrameworkCore;
using APB.AccessControl.Application.Services.Interfaces;
using APB.AccessControl.Application.Services;
using APB.AccessControl.DataAccess;
using APB.AccessControl.Application.Common;
using APB.AccessControl.DataAccess.Common;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using APB.AccessControl.DataAccess.Identity;
using APB.AccessControl.WebApi.Services;



var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<AccessControlDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//services
builder.Services.AddApplicationServices();

builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(APB.AccessControl.Application.MappingProfiles.EmployeeProfile)));

using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
ILogger logger = factory.CreateLogger("Program");

//repositories
builder.Services.AddRepositories();

//auth 
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<AccessControlDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

//add error handling
app.ConfigureExceptionHandler(logger);

app.MapControllers();

app.Run();
