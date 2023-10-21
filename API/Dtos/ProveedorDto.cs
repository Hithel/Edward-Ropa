
namespace API.Dtos;
    public class ProveedorDto
    {
         public int NitProveedor {	 get; set; }
        public string Nombre { get; set; }
        public int IdTipoPersonaFK { get; set; }

        public int IdMunicipioFk { get; set; }

    }
