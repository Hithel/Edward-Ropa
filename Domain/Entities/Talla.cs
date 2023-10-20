
namespace Domain.Entities;
    public class Talla : BaseEntity
    {
        public string Descripcion { get; set; }

        public ICollection<InventatioTalla> InventatioTallas { get; set; }
        // public ICollection<Inventario> Inventarios { get; set; }

        public ICollection<DetalleVenta> DetalleVentas{ get; set; }


    }
