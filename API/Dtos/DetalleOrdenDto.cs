

using Domain.Entities;

namespace API.Dtos;
    public class DetalleOrdenDto : BaseEntity
    {
        public int IdOrdenFK { get; set; }
        public int IdPrendaFk { get; set; }

        public int CantidadProducir { get; set; }
        public int IdColorFK { get; set; }

        public int CantidadProducidad { get; set; }
    }
