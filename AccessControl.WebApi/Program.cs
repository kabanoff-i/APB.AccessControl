using Microsoft.EntityFrameworkCore;
using APB.AccessControl.Application.Services.Interfaces;
using APB.AccessControl.Application.Services;
using APB.AccessControl.DataAccess;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<AccessControlDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//services
builder.Services.AddScoped<IAccessCheckService, AccessCheckService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IAccessPointService, AccessPointService>();
builder.Services.AddScoped<IAccessGroupService, AccessGroupService>();
builder.Services.AddScoped<IAccessRuleService, AccessRuleService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<ITriggerService, TriggerService>();
builder.Services.AddScoped<IAccessLogService, AccessLogService>();
builder.Services.AddScoped<IAccessTriggerLogService, AccessTriggerLogService>();

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

app.MapControllers();

app.Run();
