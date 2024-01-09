using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Registro
{
    public int IdRegistro { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public string? TipoDocumento { get; set; }

    public int? NumeroDocumento { get; set; }

    public string? FechaContratación { get; set; }

    public string? País { get; set; }

    public string? Área { get; set; }

    public string? SubÁrea { get; set; }
}
