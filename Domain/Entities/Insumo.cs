

namespace Domain.Entities;
    public class Insumo : BaseEntity
    {
        public string Nombre { get; set; }
        public double ValorUnidad { get; set; }
        public int StockMin { get; set; }
        public int Stockmax { get; set; }
        

        public ICollection<InsumoProveedor> InsumoProveedores { get; set; }
        public ICollection<Proveedor> Proveedores { get; set;}

        public ICollection<InsumoPrenda> InsumoPrendas { get; set; }
        public ICollection<Prenda> Prendas { get; set; }
    }
