using System;
using System.Collections.Generic;

namespace bodega;

public partial class Producto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int Precio { get; set; }

    public string UnidadMedida { get; set; } = null!;

    public virtual ICollection<ProductoBodega> ProductoBodegas { get; set; } = new List<ProductoBodega>();
}
