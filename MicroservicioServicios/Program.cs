using Application.Interfaces;
using Application.UseCases;
using Infraestructure.Commands;
using Infraestructure.Persistence;
using Infraestructure.Queries;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Custom
var connectionString = builder.Configuration["ConnectionString"];

builder.Services.AddDbContext<ServiciosContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IViajeServicioService, ViajeServicioService>();
builder.Services.AddScoped<IViajeServicioQuery, ViajeServicioQuery>();
builder.Services.AddScoped<IViajeServicioCommand, ViajeServicioCommand>();

builder.Services.AddScoped<IServicioService, ServicioService>();
builder.Services.AddScoped<IServicioQuery, ServicioQuery>();
builder.Services.AddScoped<IServicioCommand, ServicioCommand>();


//CORS deshabilitar
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
