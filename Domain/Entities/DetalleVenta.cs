

namespace Domain.Entities;
    public class DetalleVenta : BaseEntity
    {
        public int IdVentaFk { get; set; }
        public Venta Venta { get; set; }
        public int Idproducto { get; set; }
        public int IdTallaFk { get; set; }
        public Talla Talla { get; set; }
        public int Cantidad { get; set; }
        public double ValorUnidad { get; set; }
    }
