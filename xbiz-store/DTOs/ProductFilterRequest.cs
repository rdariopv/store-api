using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xbiz_store.DTOs
{
    public class ProductFilterRequest
    {
        public string? SearchTerm { get; set; }
        public string? Categoria { get; set; }
        public string? Marca { get; set; }
        public decimal? PrecioMin { get; set; }
        public decimal? PrecioMax { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;

        // Futuros filtros — solo agrega propiedades aquí:
        // public bool? SoloEnStock { get; set; }
        // public string? OrderBy   { get; set; }
    }
}
