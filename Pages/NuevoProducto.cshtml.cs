using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace bodega.Pages
{
    public class NuevoProductoModel : PageModel
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
        public void OnPost(string nombre, string unidad, int precio)
        {
            try
            {
                SupermercadoDbContext context = new SupermercadoDbContext();
                Producto p = new Producto() { Nombre = nombre, UnidadMedida = unidad, Precio = precio };
                context.Productos.Add(p);

                context.SaveChanges();
                estado = "Se ha registrado el producto " + nombre + " correctamente";
            }
            catch (Exception ex)
            {
                estado = "Error al registrar el producto, revise los datos : " + ex.Message;
            }

        }
    }
}
