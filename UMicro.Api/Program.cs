
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UMicro.Core;
using UMicro.Persistence;
using UMicro.Persistence.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCore();
builder.Services.AddPersistence();

//inyeccion de dbContext
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
     sqlOptions => sqlOptions.MigrationsAssembly("UMicro.Persistence")));

//inyecion de UnitofWork y Repositorio

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

app.UseAuthorization();

app.MapControllers();

app.Run();
