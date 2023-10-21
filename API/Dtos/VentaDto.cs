

namespace API.Dtos;
    public class VentaDto
    {
        public DateTime Fecha { get; set; }
        public int IdEmpleadoFK{ get; set; }

        public int IdClienteFK { get; set; }

        public int IdFormaPagoFk { get; set; }

    }
