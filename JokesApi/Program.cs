using AutoMapper;
using JokesApi_BAL.Extensions;
using JokesApi_BAL.Services;
using JokesApi_DAL.Contracts;
using JokesApi_DAL.Data;
using JokesApi_DAL.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
}
);
builder.Services.AddAutoMapper(typeof(AppMapperProfile));
var Configuration = builder.Configuration;
builder.Services.AddDbContext<AppDbContext>(options =>  
        options.UseNpgsql(Configuration.GetConnectionString("WebApiDbConnection")));

builder.Services.AddScoped<ServiceCategory, ServiceCategory>();
builder.Services.AddScoped<IRepositoryCategory, RepositoryCategory>();
builder.Services.AddScoped<ServiceJoke, ServiceJoke>();
builder.Services.AddScoped<IRepositoryJoke, RepositoryJoke>();
builder.Services.AddScoped<IMapper, Mapper>();

//builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
//builder.Services.AddProblemDetails();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

//app.UseExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();
