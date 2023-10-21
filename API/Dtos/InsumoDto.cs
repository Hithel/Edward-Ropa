

using Domain.Entities;

namespace API.Dtos;
    public class InsumoDto : BaseEntity
    {
        
        public string Nombre { get; set; }
        public double ValorUnidad { get; set; }
        public int StockMin { get; set; }
        public int Stockmax { get; set; }
    }
