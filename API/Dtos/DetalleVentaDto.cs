
using Domain.Entities;

namespace API.Dtos;
    public class DetalleVentaDto : BaseEntity
    {
        public int IdVentaFk { get; set; }

        public int Idproducto { get; set; }

        public int IdTallaFk { get; set; }
        
        public int Cantidad { get; set; }
        public double ValorUnidad { get; set; }
    }
