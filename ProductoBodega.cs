using System;
using System.Collections.Generic;

namespace bodega;

public partial class ProductoBodega
{
    public int IdProducto { get; set; }

    public int IdBodega { get; set; }

    public int Cantidad { get; set; }

    public virtual Bodega IdBodegaNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
