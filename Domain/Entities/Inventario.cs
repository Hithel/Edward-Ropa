

namespace Domain.Entities;
    public class Inventario : BaseEntity
    {
        public int CodInv { get; set; }
        public int IdPrendaFk   { get; set; }
        public Prenda Prenda { get; set; }
        public double ValorVtaCop { get; set; }
        public double ValorVtaUsd { get; set; }

        public ICollection<InventatioTalla> InventatioTallas { get; set; }
        // public ICollection<Talla> Tallas { get; set; }


    }
