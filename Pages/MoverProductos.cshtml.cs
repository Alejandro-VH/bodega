using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace bodega.Pages
{
    public class MoverProductosModel : PageModel
    {
        public List<Bodega> lista_bodegas { get; set; } = new();
        public List<Producto> lista_productos { get; set; } = new();
        public String estado = "";
        public void OnGet()
        {
            SupermercadoDbContext context = new SupermercadoDbContext();
            lista_bodegas = context.Bodegas.OrderBy(x => x.Nombre).ToList();
            lista_productos = context.Productos.OrderBy(x => x.Nombre).ToList();
        }

        public void OnPost(int idBodega1, int idBodega2, int idProducto, int cantidad)
        {
            SupermercadoDbContext context = new SupermercadoDbContext();

            if (idBodega1 == idBodega2)
            {
                estado = "La bodega de origen y destino no pueden ser la misma.";
                lista_bodegas = context.Bodegas.OrderBy(x => x.Nombre).ToList();
                lista_productos = context.Productos.OrderBy(x => x.Nombre).ToList();
                return;
            }

            ProductoBodega? pb1 = context.ProductoBodegas.FirstOrDefault(pb => pb.IdBodega == idBodega1 && pb.IdProducto == idProducto);

            if (pb1 != null && pb1.Cantidad >= cantidad)
            {
                pb1.Cantidad -= cantidad;

                ProductoBodega? pb2 = context.ProductoBodegas.FirstOrDefault(pb => pb.IdBodega == idBodega2 && pb.IdProducto == idProducto);

                if (pb2 != null)
                {
                    pb2.Cantidad += cantidad;
                }
                else
                {
                    pb2 = new ProductoBodega
                    {
                        IdBodega = idBodega2,
                        IdProducto = idProducto,
                        Cantidad = cantidad
                    };
                    context.ProductoBodegas.Add(pb2);
                }

                context.SaveChanges();
                estado = "Se ha movido el producto  correctamente";
            }
            else
            {
                estado = "No hay suficiente cantidad en la bodega de origen o el producto no existe.";
            }
        }
    }
}
