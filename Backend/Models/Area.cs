using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Area
{
    public int AreaId { get; set; }

    public string? Nombre { get; set; }

    public int? PaisId { get; set; }

    public virtual Pai? Pais { get; set; }

    public virtual ICollection<SubArea> SubAreas { get; set; } = new List<SubArea>();
}
