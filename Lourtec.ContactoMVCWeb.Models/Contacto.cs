using System;
using System.Collections.Generic;

namespace Lourtec.ContactoMVC.Models;

public partial class Contacto
{
    public int IdContacto { get; set; }

    public string? Nombre { get; set; }

    public string? Telefono { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public DateTime? FechaRegistro { get; set; }
}
