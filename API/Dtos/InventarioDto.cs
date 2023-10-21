

using Domain.Entities;

namespace API.Dtos;
    public class InventarioDto : BaseEntity
    {
        public int CodInv { get; set; }
        public int IdPrendaFk   { get; set; }
        public double ValorVtaCop { get; set; }
        public double ValorVtaUsd { get; set; }
    }
