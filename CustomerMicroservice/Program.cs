using Microsoft.EntityFrameworkCore;
using AutoMapper;
using CustomerMicroservice.Business.Interfaces;
using CustomerMicroservice.Business.Services;
using CustomerMicroservice.DataAccess.Repositories;
using CustomerMicroservice.DataAccess;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dbConnectionString = builder.Configuration.GetSection("ConnectionStrings:DefaultDbConnectionString").Value;
builder.Services.AddSqlite<CustomerContext>(dbConnectionString);

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

// MassTransit-RabbitMQ Configuration

builder.Services.AddMassTransit(config => {
    config.UsingRabbitMq((ctx, cfg) => {
        cfg.Host(builder.Configuration["RabbitMqSettings:HostAddress"]);
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

app.UseAuthorization();

app.MapControllers();

app.Run();
