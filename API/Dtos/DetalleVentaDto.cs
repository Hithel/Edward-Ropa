
namespace API.Dtos;
    public class DetalleVentaDto
    {
        public int IdVentaFk { get; set; }

        public int Idproducto { get; set; }

        public int IdTallaFk { get; set; }
        
        public int Cantidad { get; set; }
        public double ValorUnidad { get; set; }
    }
