

namespace API.Dtos;
    public class ClienteDto
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public int IdTipoPersonaFK { get; set; }

        public DateTime FechaRegistro { get; set; }
        public int IdMunicipioFk { get; set; }

    }
