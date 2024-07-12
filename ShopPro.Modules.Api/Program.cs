using Microsoft.EntityFrameworkCore;
using ShopPro.Modules.Persistence.Context;
using ShopPro.Modules.IOC.Dependencies;
using ShopPro.Infraestructure.Logger.Interfaces;
using ShopPro.Infraestructure.Logger.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ShopContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ShopContext")));

builder.Services.AddEmployeesDependency();
builder.Services.AddOrderDetailsDependency();

builder.Services.AddScoped(typeof(ILoggerService<>), typeof(LoggerService<>));


//Dependencias de los modulos



builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
