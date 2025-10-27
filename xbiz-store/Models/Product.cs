using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xbiz_store.Models
{
    public class Product
    {
        [Key]
        public int Codigo { get; set; }            // ivprdcprd
        public string CodigoBarras { get; set; } = string.Empty; // ivprdcbrr
       // public string CodigoAlterno { get; set; } = string.Empty; // ivprdcode
     //   public string MarcaCodigo { get; set; } = string.Empty;   // ivprdmarc
     //   public string LineaCodigo { get; set; } = string.Empty;   // ivprdclin
        public string Nombre { get; set; } = string.Empty;        // ivprdnomb
        public string Descripcion { get; set; } = string.Empty;   // ivprddesc
     //   public string TipoItem { get; set; } = string.Empty;      // ivprdtitm
     //   public decimal Peso { get; set; }                         // ivprdpeso
     //   public decimal Volumen { get; set; }                      // ivprdvoll
        public string UnidadMedida { get; set; } = string.Empty;  // dUmba
        public string MarcaDescripcion { get; set; } = string.Empty; // dMarc
       // public int AlmacenCodigo { get; set; }                    // Calm
      //  public string AlmacenNombre { get; set; } = string.Empty; // dCalm
        public decimal StockActual { get; set; }                  // SAct
     //   public decimal PrecioNoficial { get; set; }               // ivpreNofi
        public decimal PrecioVenta { get; set; }                  // ivprePmve
        public byte[]? Imagen { get; set; }                       // ivprdimag
    }

}
