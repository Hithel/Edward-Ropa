

namespace API.Dtos;
    public class InventarioDto
    {
        public int CodInv { get; set; }
        public int IdPrendaFk   { get; set; }
        public double ValorVtaCop { get; set; }
        public double ValorVtaUsd { get; set; }
    }
