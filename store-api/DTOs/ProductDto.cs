namespace store_api.DTOs
{
    public class ProductDto
    {
        public string Codigo { get; set; } = "";
        public string CodigoBarras { get; set; } = "";
        public string Nombre { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public string UnidadMedida { get; set; } = "";
        public string Imagen { get; set; } = "";  // ← representará la imagen
        public string MarcaDescripcion { get; set; } = "";
        public decimal StockActual { get; set; }
        public decimal PrecioVenta { get; set; }
    }
}
