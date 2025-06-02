using Microsoft.EntityFrameworkCore;
using APB.AccessControl.DataAccess;
using APB.AccessControl.Application.Common;
using APB.AccessControl.DataAccess.Common;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using APB.AccessControl.WebApi.Common;
using FluentValidation;
using APB.AccessControl.Application.Validators;
using APB.AccessControl.WebApi.Validators;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Настройка логирования
builder.Logging.ClearProviders()
    .AddConsole()
    .AddDebug()
    .AddFile(builder.Configuration); // Используем расширение, которое читает настройки из конфигурации

// Add services to the container.
builder.Services.AddDbContext<AccessControlDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//services
builder.Services.AddApplicationServices();

builder.Services.AddApplicationMappings();
builder.Services.AddValidatorsFromAssemblyContaining<EmployeeValidator>(ServiceLifetime.Transient);
builder.Services.AddValidatorsFromAssemblyContaining<CreateEmployeeReqValidator>(ServiceLifetime.Transient);

//repositories
builder.Services.AddRepositories();

builder.Services.AddIdentity<IdentityUser, IdentityRole>( opt =>
    {
        opt.Password.RequireNonAlphanumeric = false;
        opt.Password.RequireDigit = true;
        opt.Password.RequireUppercase = true;
    })
    .AddEntityFrameworkStores<AccessControlDbContext>()
    .AddDefaultTokenProviders()
    .AddRoleManager<RoleManager<IdentityRole>>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
    options.AddPolicy("UserPolicy", policy => policy.RequireRole("User"));
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRouting(ctx => ctx.LowercaseUrls = true);
builder.Services.AddSwaggerGen( opt =>
{
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
}
);

var app = builder.Build();

//var mapperConfig = app.Services.GetRequiredService<AutoMapper.IConfigurationProvider>();
//mapperConfig.AssertConfigurationIsValid();

// Получаем логгер из DI-контейнера
var appLogger = app.Services.GetRequiredService<ILogger<Program>>();
appLogger.LogInformation("Приложение запущено");

//add admin 
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await services.SeedAdminAsync(builder.Configuration["AdminCredentials:Username"], builder.Configuration["AdminCredentials:Password"], appLogger);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

//add error handling
app.ConfigureExceptionHandler(appLogger);

app.MapControllers();

appLogger.LogInformation("Настройка приложения завершена. Сервер запущен и готов к обработке запросов.");

app.Run();
