using DC.WebApi.Api;
using DC.WebApi.Api.Services;
using DC.WebApi.Api.Services.Permissions;
using DC.WebApi.Core;
using DC.WebApi.Core.Data;
using DC.WebApi.Core.Data.Repositories;
using DC.WebApi.Core.Domain;
using DreamCleaning;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOptions<ApiSettings>().Bind(builder.Configuration.GetSection(Constants.ApiSettingsKey)).ValidateDataAnnotations();

string connectionString = "";


if(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == Constants.StagingEnviroment)
{
    connectionString = Environment.GetEnvironmentVariable("ConnectionString").ToString();
}else if(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == Constants.DevelopmentEnviroment)
{
    connectionString = builder.Configuration.GetConnectionString("LocalConection");
}


builder.Services.AddDbContext<DCDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddSingleton<IPasswordHelper, PasswordHelper>();
builder.Services.AddSingleton<IUserPermissionService, UserPermissionService>();
builder.Services.AddSingleton<IJwtHelper, JwtHelper>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserDomain, UserDomain>();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeDomain, EmployeeDomain>();



builder.Services.AddHttpContextAccessor()
    .AddAuthorization()
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["ApiSettings:JwtIssuer"],
        ValidAudience = builder.Configuration["ApiSettings:JwtAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["ApiSettings:JwtSigningKey"]))
    });

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

    builder.Services.AddCors(options =>
    {
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://dream-cleaning-front.herokuapp.com");
                          policy.AllowAnyOrigin();
                          policy.AllowAnyMethod();
                          policy.AllowAnyHeader();
                      });
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//do migration
using var scope = app.Services.CreateScope();
var apiOptions = scope.ServiceProvider.GetRequiredService<IOptions<ApiSettings>>();
if (apiOptions.Value.DoMigration)
{
    var db = scope.ServiceProvider.GetRequiredService<DCDbContext>();
    db.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
