using Microsoft.EntityFrameworkCore;
using APB.AccessControl.Application.Services.Interfaces;
using APB.AccessControl.Application.Services;
using APB.AccessControl.DataAccess;
using APB.AccessControl.Application.Common;
using APB.AccessControl.DataAccess.Common;
using System.Reflection;



var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<AccessControlDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//services
builder.Services.AddApplicationServices();

using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
ILogger logger = factory.CreateLogger("Program");

//repositories
builder.Services.AddRepositories();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

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
//app.UseAuthorization();

//add error handling
app.ConfigureExceptionHandler(logger);

app.MapControllers();

app.Run();
