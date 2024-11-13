using xbiz_store.Context;
using Microsoft.EntityFrameworkCore;
using xbiz_store.Repository;
using store_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Configura la cadena de conexión (ConnectionString) a SQL Server
var connectionString = builder.Configuration.GetConnectionString("cnx");
builder.Services.AddDbContext<StoreContext>(opt => opt.UseSqlServer(connectionString));

// Add services to the container.

builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddScoped<IStoreContext, StoreContext>();
builder.Services.AddScoped<ISalesForce, SalesForce>();


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
