using AdministradorContactosAPI.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace AdministradorContactosAPI.DTOs
{
    public class ContactoCreacionDTO
    {

        [Required(ErrorMessage = "El Grupo es obligatorio.")]
        public int? IdGrupo { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El Nombre debe tener entre 2 y 100 caracteres.")]
        [PrimeraLetraMayuscula]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no tiene un formato válido.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [Phone(ErrorMessage = "El número de teléfono no tiene un formato válido.")]
        [StringLength(20, ErrorMessage = "El número de teléfono no debe superar los 20 caracteres.")]
        public string? Telefono { get; set; }


    }
}
