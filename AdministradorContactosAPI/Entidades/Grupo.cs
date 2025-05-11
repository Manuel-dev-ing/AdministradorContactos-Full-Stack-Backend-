using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AdministradorContactosAPI.Validaciones;

namespace AdministradorContactosAPI.Entidades;

public class Grupo
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public List<Contacto> Contactos { get; set; }
}
