

namespace Domain.Entities;
    public class InventatioTalla 
    {
        public int IdInventarioFk { get; set; }
        public Inventario Inventario { get; set; }
        public int IdTallaFK { get; set; }
        public Talla Talla { get; set; }
    }
