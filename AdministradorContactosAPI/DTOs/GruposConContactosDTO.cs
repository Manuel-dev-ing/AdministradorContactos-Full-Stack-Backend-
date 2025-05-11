using AdministradorContactosAPI.Entidades;

namespace AdministradorContactosAPI.DTOs
{
    public class GruposConContactosDTO:GrupoDTO
    {
        public  List<ContactDTO> Contactos { get; set; }

    }
}
