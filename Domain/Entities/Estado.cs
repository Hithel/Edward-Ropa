

namespace Domain.Entities;
    public class Estado : BaseEntity
    {
        public string Descripcion { get; set; }
        public int IdTipoEstadoFk { get; set; }
        public TipoEstado TipoEstado { get; set; }

        public ICollection<Prenda> Prendas { get; set; }

        
    }
