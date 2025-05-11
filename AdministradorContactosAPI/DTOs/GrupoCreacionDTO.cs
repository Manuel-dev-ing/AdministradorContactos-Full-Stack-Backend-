using AdministradorContactosAPI.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace AdministradorContactosAPI.DTOs
{
    public class GrupoCreacionDTO
    {

        [PrimeraLetraMayuscula]
        [Required(ErrorMessage = "El Nombre del grupo es obligatorio.")]
        public string? Nombre { get; set; }

    }
}
