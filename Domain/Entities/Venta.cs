
namespace Domain.Entities;
    public class Venta : BaseEntity
    {
        public DateTime Fecha { get; set; }
        public int IdEmpleadoFK{ get; set; }
        public Empleado Empleado { get; set; }
        public int IdCliente { get; set; }
        public Cliente Cliente{ get; set; }
        public int IdFormaPago { get; set; }
        public FormaPago FormaPago { get; set; }
        
        public ICollection<DetalleVenta> DetalleVentas { get; set; }
        
    }
