

namespace Domain.Entities;
    public class DetalleOrden : BaseEntity
    {
        public int IdOrdenFK { get; set; }
        public Orden Orden { get; set; }
        public int IdPrendaFk { get; set; }
        public Prenda Prenda { get; set; }

        public int CantidadProducir { get; set; }
        public int IdColorFK { get; set; }
        public Color Color  { get; set; }

        public int CantidadProducidad { get; set; }
        
        public int IdEstadoFk { get; set; }
        public Estado Estado { get; set; }

    }
