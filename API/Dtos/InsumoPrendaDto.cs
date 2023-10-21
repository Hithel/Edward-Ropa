

using Domain.Entities;

namespace API.Dtos;

    public class InsumoPrendaDto : BaseEntity
    {
        public int IdInsumoFK { get; set; }

        public int IdPrendaFk { get; set; }

        public int Cantidad { get; set; }
    }
