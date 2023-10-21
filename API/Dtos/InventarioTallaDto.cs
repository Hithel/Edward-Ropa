

using Domain.Entities;

namespace API.Dtos;
    public class InventarioTallaDto : BaseEntity
    {
        public int IdInventarioFk { get; set; }

        public int IdTallaFK { get; set; }

    }
