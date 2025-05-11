using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AdministradorContactosAPI.Validaciones;

namespace AdministradorContactosAPI.Entidades;

public partial class Contacto
{
    public int Id { get; set; }

    public int? IdGrupo { get; set; }

    public string? Nombre { get; set; }
    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public virtual Grupo? IdGrupoNavigation { get; set; }
}
