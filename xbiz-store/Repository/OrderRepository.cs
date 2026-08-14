using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xbiz_store.Context;
using xbiz_store.DTOs;

namespace xbiz_store.Repository
{
    /// <summary>
    /// Repositorio de órdenes.
    /// Sigue el mismo patrón que ProductRepository:
    /// usa StoreContext + FromSqlRaw para ejecutar queries SQL.
    ///
    /// TODO: Reemplazar los datos estáticos con queries reales
    /// a tus tablas de órdenes cuando identifiques los nombres de columnas.
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreContext _context;

        public OrderRepository(StoreContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Guarda una nueva orden en la BD.
        /// TODO: Implementar el INSERT a tus tablas reales.
        /// </summary>
        public async Task<string> SaveAsync(OrderRequest request)
        {
            var orderId = Guid.NewGuid().ToString()[..8].ToUpper();

            // ── TODO: INSERT cabecera de orden ────────────────────────────
            // Ejemplo de cómo se vería con tus tablas reales:
            //
            // var sqlCabecera = @"
            //     INSERT INTO tu_tabla_ordenes (
            //         orden_id, orden_fecha, orden_estado,
            //         cliente_nombre, cliente_apellido, cliente_email,
            //         metodo_pago, total
            //     ) VALUES (
            //         @orderId, GETDATE(), 'Confirmado',
            //         @firstName, @lastName, @email,
            //         @paymentMethod, @total
            //     )";
            //
            // await _context.Database.ExecuteSqlRawAsync(sqlCabecera,
            //     new SqlParameter("@orderId", orderId),
            //     new SqlParameter("@firstName", request.Customer.FirstName),
            //     new SqlParameter("@lastName", request.Customer.LastName),
            //     new SqlParameter("@email", request.Customer.Email),
            //     new SqlParameter("@paymentMethod", request.PaymentMethod),
            //     new SqlParameter("@total", request.Items.Sum(i => i.Price * i.Quantity))
            // );

            // ── TODO: INSERT detalle de orden (por cada item) ─────────────
            // foreach (var item in request.Items)
            // {
            //     var sqlDetalle = @"
            //         INSERT INTO tu_tabla_detalle_ordenes (
            //             orden_id, producto_id, nombre,
            //             precio, cantidad, subtotal
            //         ) VALUES (
            //             @orderId, @productId, @name,
            //             @price, @quantity, @subtotal
            //         )";
            //
            //     await _context.Database.ExecuteSqlRawAsync(sqlDetalle,
            //         new SqlParameter("@orderId", orderId),
            //         new SqlParameter("@productId", item.ProductId),
            //         new SqlParameter("@name", item.Name),
            //         new SqlParameter("@price", item.Price),
            //         new SqlParameter("@quantity", item.Quantity),
            //         new SqlParameter("@subtotal", item.Price * item.Quantity)
            //     );
            // }
            // ─────────────────────────────────────────────────────────────

            await Task.CompletedTask; // quitar cuando se implemente el INSERT real
            return orderId;
        }

        /// <summary>
        /// Obtiene el detalle de una orden por ID.
        /// TODO: Reemplazar datos estáticos con query real a tus tablas.
        /// </summary>
        public async Task<OrderDetailDto?> GetByIdAsync(string orderId)
        {
            // ── TODO: SELECT cabecera de orden ────────────────────────────
            // Cuando identifiques tus tablas, la query seguirá este patrón
            // (igual que GetByIdAsync en ProductRepository):
            //
            // var sqlCabecera = @"
            //     SELECT
            //         orden_id         AS OrderId,
            //         orden_fecha      AS CreatedAt,
            //         metodo_pago      AS PaymentMethod,
            //         orden_estado     AS Status,
            //         cliente_nombre   AS CustomerFirstName,
            //         cliente_apellido AS CustomerLastName,
            //         cliente_email    AS CustomerEmail,
            //         total            AS Total
            //     FROM tu_tabla_ordenes
            //     WHERE orden_id = @orderId";
            //
            // var orderRow = await _context.Set<OrderQuery>()
            //     .FromSqlRaw(sqlCabecera, new SqlParameter("@orderId", orderId))
            //     .AsNoTracking()
            //     .FirstOrDefaultAsync();
            //
            // if (orderRow == null) return null;

            // ── TODO: SELECT detalle de items ─────────────────────────────
            // var sqlItems = @"
            //     SELECT
            //         orden_id     AS OrderId,
            //         producto_id  AS ProductId,
            //         nombre       AS Name,
            //         precio       AS Price,
            //         cantidad     AS Quantity,
            //         subtotal     AS Subtotal
            //     FROM tu_tabla_detalle_ordenes
            //     WHERE orden_id = @orderId";
            //
            // var items = await _context.Set<OrderItemQuery>()
            //     .FromSqlRaw(sqlItems, new SqlParameter("@orderId", orderId))
            //     .AsNoTracking()
            //     .ToListAsync();
            //
            // return new OrderDetailDto
            // {
            //     OrderId       = orderRow.OrderId,
            //     CreatedAt     = orderRow.CreatedAt,
            //     PaymentMethod = orderRow.PaymentMethod,
            //     Status        = orderRow.Status,
            //     Customer = new CustomerInfo
            //     {
            //         FirstName = orderRow.CustomerFirstName,
            //         LastName  = orderRow.CustomerLastName,
            //         Email     = orderRow.CustomerEmail
            //     },
            //     Items = items.Select(i => new OrderItemDto
            //     {
            //         ProductId = i.ProductId,
            //         Name      = i.Name,
            //         Price     = i.Price,
            //         Quantity  = i.Quantity,
            //         Subtotal  = i.Subtotal
            //     }).ToList(),
            //     Total = orderRow.Total
            // };
            // ─────────────────────────────────────────────────────────────

            // ── Datos estáticos de demostración ──────────────────────────
            // Quitar este bloque cuando se implementen los SELECT reales.
            await Task.Delay(100);

            if (string.IsNullOrWhiteSpace(orderId))
                return null;

            return new OrderDetailDto
            {
                OrderId = orderId,
                CreatedAt = DateTime.Now,
                PaymentMethod = "Tarjeta de Crédito",
                Status = "Confirmado",
                Customer = new CustomerInfo
                {
                    FirstName = "Juan",
                    LastName = "Pérez",
                    Email = "juan@ejemplo.com"
                },
                Items = new List<OrderItemDto>
                {
                    new() { ProductId = "1", Name = "Producto Demo A", Price = 29.99m, Quantity = 2, Subtotal = 59.98m },
                    new() { ProductId = "2", Name = "Producto Demo B", Price = 15.50m, Quantity = 1, Subtotal = 15.50m },
                    new() { ProductId = "3", Name = "Producto Demo C", Price = 49.00m, Quantity = 1, Subtotal = 49.00m },
                },
                Total = 124.48m
            };
            // ─────────────────────────────────────────────────────────────
        }
    }
}
