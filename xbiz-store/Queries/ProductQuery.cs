using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xbiz_store.Queries
{
    public class ProductQuery
    {
        [Key]
        public int Codigo { get; set; }
        public string CodigoBarras { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public byte[]? Imagen { get; set; }
        public decimal PrecioVenta { get; set; }
    }
}
