using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Pai
{
    public int PaisId { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Area> Areas { get; set; } = new List<Area>();
}
