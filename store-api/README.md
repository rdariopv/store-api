# 🏪 Store API

API REST construida con **ASP.NET Core Web API (.NET 8)** que expone los endpoints de productos y órdenes para el frontend Blazor (`shop_cart`). La lógica de negocio, repositorios y acceso a datos está encapsulada en el proyecto de librería `xbiz-store`.

---

## 📐 Arquitectura de la Solución

La solución contiene **dos proyectos**:

```
store-api.sln
├── store-api/          ← Capa de presentación (Controllers, Program.cs)
└── xbiz-store/         ← Lógica de negocio (Repositorios, Contexto, Entidades, DTOs)
```

```
┌─────────────────────────────────────────────────────────────┐
│                        store-api.sln                        │
│                                                             │
│  ┌──────────────────────────┐   ┌─────────────────────────┐ │
│  │       store-api          │   │      xbiz-store         │ │
│  │  (Web API — Presentación)│   │  (Librería — Negocio)   │ │
│  │                          │   │                         │ │
│  │  Controllers/            │   │  Entities/              │ │
│  │   ├─ ProductsController  │──►│   ├─ ivprd.cs           │ │
│  │   ├─ OrdersController    │   │   ├─ ivcat.cs           │ │
│  │   └─ StoreController     │   │   └─ ivimg.cs           │ │
│  │                          │   │                         │ │
│  │  Services/               │   │  Repository/            │ │
│  │  Program.cs              │   │   ├─ ProductRepository  │ │
│  │  appsettings.json        │   │   ├─ StoreRepository    │ │
│  │                          │   │   └─ IProductRepository │ │
│  │                          │   │                        │  │
│  │                          │   │  Data/                 │  │
│  │                          │   │   ├─ StoreContext      │  │
│  │                          │   │   ├─ IStoreContext     │  │
│  │                          │   │   └─ SqlHelper         │  │
│  │                          │   │                        │  │
│  │                          │   │  DTOs/                 │  │
│  │                          │   │   ├─ ProductDto        │  │
│  │                          │   │   ├─ OrderRequest      │  │
│  │                          │   │   ├─ OrderResponse     │  │
│  │                          │   │   ├─ OrderItemDto      │  │
│  │                          │   │   ├─ CustomerInfo      │  │
│  │                          │   │   └─ CardInfo          │  │
│  │                          │   │                        │  │
│  │                          │   │  Queries/              │  │
│  │                          │   │   └─ ProductQuery      │  │
│  └──────────────────────────┘   └───────────────────────┘  │
│                                          │                  │
└──────────────────────────────────────────┼──────────────────┘
                                           │
                                           ▼
                               ┌───────────────────────┐
                               │   SQL Server           │
                               │   (Base de datos)      │
                               └───────────────────────┘
```

---

## 🗂️ Estructura de Archivos

### `store-api` — Capa de Presentación

```
store-api/
├── Controllers/
│   ├── ProductsController.cs      # GET /api/products, GET /api/products/{id}
│   ├── OrdersController.cs        # POST /api/orders
│   ├── StoreController.cs         # Endpoints adicionales de la tienda
│   └── WeatherForecastController.cs
├── Services/                      # Servicios específicos de la API
├── appsettings.json               # Cadena de conexión y configuración
├── Program.cs                     # DI, CORS, middleware
└── store-api.http                 # Pruebas de endpoints (HTTP Client)
```

### `xbiz-store` — Capa de Negocio y Datos

```
xbiz-store/
├── Data/
│   ├── IStoreContext.cs           # Interfaz del contexto de BD
│   ├── StoreContext.cs            # Implementación (DbContext / SqlHelper)
│   └── SqlHelper.cs               # Helpers para queries SQL
│
├── DTOs/
│   ├── ProductDto.cs              # Producto expuesto al cliente
│   ├── OrderRequest.cs            # Datos de la orden entrante
│   ├── OrderResponse.cs           # Respuesta al cliente tras crear orden
│   ├── OrderItemDto.cs            # Item individual de la orden
│   ├── CustomerInfo.cs            # Datos del comprador
│   └── CardInfo.cs                # Datos de tarjeta de crédito
│
├── Entities/
│   ├── ivprd.cs                   # Entidad Producto (tabla BD)
│   ├── ivcat.cs                   # Entidad Categoría
│   └── ivimg.cs                   # Entidad Imagen de producto
│
├── Queries/
│   └── ProductQuery.cs            # Queries SQL para productos
│
└── Repository/
    ├── IProductRepository.cs      # Interfaz del repositorio de productos
    ├── IStoreRepository.cs        # Interfaz del repositorio de tienda
    ├── ProductRepository.cs       # Implementación — consultas de productos
    └── StoreRepository.cs         # Implementación — lógica de tienda
```

---

## 🌐 Endpoints

### Productos

| Método | Ruta | Descripción |
|---|---|---|
| `GET` | `/api/products` | Lista todos los productos |
| `GET` | `/api/products/{id}` | Producto por ID |
| `GET` | `/api/products/image/{id}` | Imagen del producto |

### Órdenes

| Método | Ruta | Descripción |
|---|---|---|
| `POST` | `/api/orders` | Crea una nueva orden |

#### Request — `POST /api/orders`

```json
{
  "customer": {
    "firstName": "Juan",
    "lastName": "Pérez",
    "email": "juan@ejemplo.com"
  },
  "paymentMethod": "card",
  "card": {
    "cardName": "JUAN PEREZ",
    "cardNumber": "4111111111111111",
    "expiration": "12/26",
    "cvv": "123"
  },
  "items": [
    {
      "productId": "42",
      "name": "Producto Ejemplo",
      "price": 29.99,
      "quantity": 2,
      "subtotal": 59.98
    }
  ],
  "total": 59.98
}
```

#### Response — `200 OK`

```json
{
  "success": true,
  "orderId": "A3F9C2D1",
  "message": "Orden creada exitosamente.",
  "total": 59.98
}
```

#### Response — `400 Bad Request`

```json
{
  "success": false,
  "message": "El carrito está vacío."
}
```

---

## 🔁 Patrón Repositorio

`xbiz-store` implementa el patrón repositorio para desacoplar el acceso a datos:

```
Controller
    │  inyecta IProductRepository
    ▼
IProductRepository  ◄──────────────────────────────┐
    │                                               │
    ▼                                               │
ProductRepository                          (registrado en DI
    │  usa StoreContext / SqlHelper          como Scoped)
    ▼
SQL Server
```

Esto permite cambiar la implementación del repositorio (por ejemplo, de Dapper a EF Core) sin tocar los controllers.

---

## ⚙️ Configuración

### `appsettings.json`

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=StoreDb;Trusted_Connection=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### CORS — `Program.cs`

La API debe permitir requests desde el frontend Blazor:

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorClient", policy =>
        policy.WithOrigins("https://localhost:7153")
              .AllowAnyHeader()
              .AllowAnyMethod());
});

app.UseCors("BlazorClient");
```

---

## 🚀 Ejecución

### Requisitos

- .NET 8 SDK
- SQL Server (local o remoto)
- Base de datos configurada en `appsettings.json`

### Pasos

```bash
# 1. Clonar
git clone https://github.com/tu-usuario/store-api.git
cd store-api

# 2. Restaurar dependencias
dotnet restore

# 3. Configurar cadena de conexión en appsettings.json

# 4. Ejecutar
dotnet run --project store-api
```

La API queda disponible en `https://localhost:7179`.

---

## 📦 Dependencias NuGet

| Paquete | Uso |
|---|---|
| `Microsoft.AspNetCore.OpenApi` | Swagger / documentación de endpoints |
| `Swashbuckle.AspNetCore` | UI de Swagger |
| `Dapper` *(si aplica)* | Micro-ORM para queries SQL |
| `Microsoft.Data.SqlClient` | Conexión a SQL Server |

---

## 🔗 Proyectos relacionados

| Proyecto | Descripción | Repositorio |
|---|---|---|
| `shop_cart` | Frontend Blazor Web App que consume esta API | [ver README](../shop_cart/README.md) |