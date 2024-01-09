using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class SubArea
{
    public int SubAreaId { get; set; }

    public string? Nombre { get; set; }

    public int? AreaId { get; set; }

    public virtual Area? Area { get; set; }
}
