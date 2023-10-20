

namespace Domain.Entities;
    public class InventatioTalla : BaseEntity
    {
        public int IdInventarioFk { get; set; }
        public Inventario Inventario { get; set; }
        public int IdTallaFK { get; set; }
        public Talla Talla { get; set; }

        public int Cantidad { get; set; }
    }
