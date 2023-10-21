

using Domain.Entities;

namespace API.Dtos;
    public class OrdenDto : BaseEntity
    {
        public DateTime Fecha { get; set; }
        public int IdEmpleadoFK { get; set; }

        public int IdClienteFk { get; set; }

        public int IdEstadoFk { get; set; }

    }
