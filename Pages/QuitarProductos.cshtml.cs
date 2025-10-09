using bodega;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace bodega.Pages
{
    public class QuitarProductosModel : PageModel
    {
        public List<Bodega> lista_bodegas { get; set; } = new();
        public List<Producto> lista_productos { get; set; } = new();

        public String estado = "";
        public void OnGet()
        {
            SupermercadoDbContext context = new SupermercadoDbContext();
            lista_bodegas = context.Bodegas.OrderBy(x => x.Nombre).ToList();
            lista_productos = context.Productos.OrderBy(x => x.Id).ToList();
        }
        public void OnPost(int idBodega, int idProducto, int cantidad)
        {
            SupermercadoDbContext context = new SupermercadoDbContext();

            ProductoBodega? pb = context.ProductoBodegas.FirstOrDefault(x => x.IdBodega == idBodega && x.IdProducto == idProducto);

            if (pb != null)
            {
                pb.Cantidad -= cantidad;

                if (pb.Cantidad <= 0)
                {
                    context.ProductoBodegas.Remove(pb);
                }

                context.SaveChanges();
                lista_bodegas = context.Bodegas.OrderBy(x => x.Nombre).ToList();
                lista_productos = context.Productos.OrderBy(x => x.Nombre).ToList();
                estado = "Se ha quitado el stock correctamente";
            }else {
                estado = "No hay suficiente cantidad en la bodega o el producto no existe.";
            }
        }
    }
}
