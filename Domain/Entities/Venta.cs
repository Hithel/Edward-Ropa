
namespace Domain.Entities;
    public class Venta : BaseEntity
    {
        public DateTime Fecha { get; set; }
        public int IdEmpleadoFK{ get; set; }
        public Empleado Empleado { get; set; }
        public int IdClienteFK { get; set; }
        public Cliente Cliente{ get; set; }
        public int IdFormaPagoFk { get; set; }
        public FormaPago FormaPago { get; set; }
        
        public ICollection<DetalleVenta> DetalleVentas { get; set; }
        
    }
