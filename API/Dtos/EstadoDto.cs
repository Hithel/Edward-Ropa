

using Domain.Entities;

namespace API.Dtos;
    public class EstadoDto : BaseEntity
    {
        public string Descripcion { get; set; }
        
        public int IdTipoEstadoFk { get; set; }

    }
