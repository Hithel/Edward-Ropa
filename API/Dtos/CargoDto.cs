
using Domain.Entities;

namespace API.Dtos;
    public class CargoDto : BaseEntity
    {
        public string Descripcion { get; set; }
        public double SueldoBase { get; set; }
    }
