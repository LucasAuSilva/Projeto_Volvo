using Microsoft.EntityFrameworkCore;
using Projeto_Volvo.Api.Models;
using Projeto_Volvo.Api.Contracts;
using Projeto_Volvo.Api.Repository;
using Microsoft.AspNetCore.Builder;
using Projeto_Volvo.Api.Middlewares;
using Projeto_Volvo.Api.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connection = builder.Configuration["DbConnection"];

// TODO: Achar um jeito melhor de fazer isso.
// Repositorios da aplicacao.
builder.Services.AddScoped<IAcessoriesCategoryRepository, AcessoriesCategoryRepository>();
builder.Services.AddScoped<IAcessoryRepository, AcessoryRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IBuyerRepository, BuyerRepository>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IDealershipRepository, DealershipRepository>();
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<IWorkerRepository, WorkerRepository>();

// Services da aplicacao
builder.Services.AddScoped<IWorkerService, WorkerService>();
builder.Services.AddScoped<IBuyerService, BuyerService>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IDealershipService, DealershipService>();
builder.Services.AddScoped<IAcessoryService, AcessoryService>();
builder.Services.AddScoped<IOwnerService, OwnerService>();

builder.Services.AddDbContext<VolvoContext>(c => c.UseSqlServer(connection));

var app = builder.Build();

app.UseMiddleware(typeof(ErrorMiddleware));

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
