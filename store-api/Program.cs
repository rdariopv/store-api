using xbiz_store.Context;
using Microsoft.EntityFrameworkCore;
using xbiz_store.Repository;
using store_api.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using store_api.Mapping;
using AutoMapper;


var builder = WebApplication.CreateBuilder(args);

// 👉 Registrar AutoMapper y escanear todos los profiles del ensamblado
builder.Services.AddAutoMapper(typeof(ProductProfile).Assembly);

// Configura la cadena de conexión (ConnectionString) a SQL Server
var connectionString = builder.Configuration.GetConnectionString("cnx");
builder.Services.AddDbContext<IStoreContext, StoreContext>(opt => opt.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();


builder.Services.AddScoped<IStoreRepository, StoreRepository>();
// Si IStoreContext es necesario:
//builder.Services.AddScoped<IStoreContext>(provider => provider.GetService<StoreContext>()!);
builder.Services.AddScoped<ISalesForce, SalesForce>();
builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

// **Configuración para Render:** Kestrel debería detectar la variable PORT, 
// pero se puede asegurar el arranque en un puerto común si PORT no se detecta
if (app.Environment.IsProduction() && Environment.GetEnvironmentVariable("PORT") == null)
{
    // Esto es solo un respaldo, normalmente Render inyecta PORT
    app.Urls.Add("http://0.0.0.0:8080");
}

app.UseAuthorization();

app.MapControllers();

app.Run();

//store_api /
//├── Controllers /
//│   ├── ProductsController.cs
//│   ├── CatalogsController.cs
//│   ├── CartController.cs
//│   ├── OrdersController.cs
//│   └── UsersController.cs
//├── DTOs /
//│   ├── ProductDto.cs
//│   ├── CartDto.cs
//│   └── OrderDto.cs
//├── Services /
//│   ├── ProductService.cs
//│   ├── CartService.cs
//│   ├── OrderService.cs
//│   └── UserService.cs
//└── Program.cs
//store_api /
//├── Repository /
//│   ├── IProductRepository.cs
//│   ├── ProductRepository.cs
//│   ├── IStoreRepository.cs
//│   ├── StoreRepository.cs
//├── Models /
//│   ├── Product.cs
//│   ├── Category.cs
//│   ├── Cart.cs
//│   ├── CartItem.cs
//│   ├── Order.cs
//│   └── User.cs
//└── Data /
//    ├── AppDbContext.cs
//    └── SeedData.cs

