using System;
using System.Collections.Generic;

namespace FurnitureManufacturing.Models;

public partial class Unit
{
    public int UnitId { get; set; }

    public string UnitName { get; set; } = null!;

    public string UnitCode { get; set; } = null!;

    public virtual ICollection<Nomenclature> Nomenclatures { get; set; } = new List<Nomenclature>();
}
