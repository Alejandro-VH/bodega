using System;
using System.Collections.Generic;

namespace bodega;

public partial class Bodega
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<ProductoBodega> ProductoBodegas { get; set; } = new List<ProductoBodega>();
}
