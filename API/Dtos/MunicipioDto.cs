

using Domain.Entities;

namespace API.Dtos;
    public class MunicipioDto : BaseEntity
    {
        public string Nombre { get; set; }
        public int IdDepartamentoFk { get; set; }

    }
