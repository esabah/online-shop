using MassTransit;
using MediatR;
using OrderMicroservice.DataAccess;
using OrderMicroservice.DataAccess.Repositories;
using OrderMicroservice.MessageConsumer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dbConnectionString = builder.Configuration.GetSection("ConnectionStrings:DefaultDbConnectionString").Value;
builder.Services.AddSqlite<OrderCommandContext>(dbConnectionString);

var queryConnectionString = builder.Configuration.GetSection("ConnectionStrings:QueryDbConnectionString").Value;
builder.Services.AddSqlite<ViewContext>(queryConnectionString);

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderViewRepository, OrderViewRepository>();
builder.Services.AddScoped<ICustomerViewRepository, CustomerViewRepository>();
builder.Services.AddScoped<IProductViewRepository, ProductViewRepository>();


builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddAutoMapper(typeof(Program).Assembly);



// MassTransit-RabbitMQ Configuration
builder.Services.AddMassTransit(config => {

    config.AddConsumer<CustomerCreateEventConsumer>();
    config.AddConsumer<ProductCreateEventConsumer>();
    config.AddConsumer<OrderViewCreateEventConsumer>();


    config.UsingRabbitMq((ctx, cfg) => {
        cfg.Host(builder.Configuration["RabbitMqSettings:HostAddress"]);
        cfg.ReceiveEndpoint("ercan", c => {
            c.ConfigureConsumer<CustomerCreateEventConsumer>(ctx);
        });
        cfg.ReceiveEndpoint("ercan1", c => {
            c.ConfigureConsumer<ProductCreateEventConsumer>(ctx);
        });
        cfg.ReceiveEndpoint("ercan2", c => {
            c.ConfigureConsumer<OrderViewCreateEventConsumer>(ctx);
        });
    });
});

// General Configuration
builder.Services.AddScoped<CustomerCreateEventConsumer>();
builder.Services.AddScoped<ProductCreateEventConsumer>();
builder.Services.AddScoped<OrderViewCreateEventConsumer>();


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
