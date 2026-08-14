using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xbiz_store.Queries
{
    /// <summary>
    /// Resultado de la query SQL de órdenes.
    /// TODO: Mapear las columnas reales de tus tablas de órdenes.
    /// Sigue el mismo patrón que ProductQuery.
    /// </summary>
    [Keyless]
    public class OrderQuery
    {
        // TODO: Reemplazar con el nombre real de columna de tu tabla de órdenes
        // Ejemplo: si tu tabla se llama "ventas" y la columna es "venccorr", 
        // el alias en el SQL sería: venccorr AS OrderId
        public string OrderId { get; set; } = "";
        public DateTime CreatedAt { get; set; }
        public string PaymentMethod { get; set; } = "";
        public string Status { get; set; } = "";

        // Datos del cliente
        public string CustomerFirstName { get; set; } = "";
        public string CustomerLastName { get; set; } = "";
        public string CustomerEmail { get; set; } = "";

        // Total de la orden
        public decimal Total { get; set; }
    }

    /// <summary>
    /// Resultado de la query SQL de items de una orden.
    /// TODO: Mapear las columnas reales de tu tabla de detalle de órdenes.
    /// </summary>
    [Keyless]
    public class OrderItemQuery
    {
        public string OrderId { get; set; } = "";
        public string ProductId { get; set; } = "";
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
    }
}
