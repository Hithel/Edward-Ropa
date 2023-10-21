

namespace API.Dtos;
    public class PrendaDto
    {
        public int IdPrenda { get; set; }
        public string Nombre { get; set; }
        public double ValorUnidadCop { get; set; }
        public double ValorUnidadUSD { get; set; }
        public int IdEstadoFk { get; set; }

        public int IdTipoProteccionFk { get; set; }

        public int IdGeneroFk { get; set; }

        
    }
