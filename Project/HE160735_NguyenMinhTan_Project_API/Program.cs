using HE160735_NguyenMinhTan_Project_API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<He160735NguyenMinhTanProjectContext>(
        options => options.UseSqlServer(
            new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build().GetConnectionString("DbConnect")));
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
