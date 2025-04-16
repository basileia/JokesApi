using AutoMapper;
using JokesApi_BAL.Extensions;
using JokesApi_BAL.Services;
using JokesApi_DAL.Contracts;
using JokesApi_DAL.Data;
using JokesApi_DAL.Entities;
using JokesApi_DAL.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
}
);
builder.Services.AddAutoMapper(typeof(JokeProfile), typeof(CategoryProfile));

var Configuration = builder.Configuration;
builder.Services.AddDbContext<AppDbContext>(options =>  
        options.UseNpgsql(Configuration.GetConnectionString("WebApiDbConnection")));

builder.Services.AddScoped<ServiceCategory, ServiceCategory>();
builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
builder.Services.AddScoped<ServiceJoke, ServiceJoke>();
builder.Services.AddScoped<IRepositoryJoke, RepositoryJoke>();
builder.Services.AddScoped<IRepositoryCategory, RepositoryCategory>();
builder.Services.AddScoped<IMapper, Mapper>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Jokes API",
        Version = "v1",
        Description = "API for Managing Jokes and Categories"
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
