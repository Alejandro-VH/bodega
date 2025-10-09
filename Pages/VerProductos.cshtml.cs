using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace bodega.Pages
{
    public class VerProductosModel : PageModel
    {
        public List<Bodega> lista_bodegas { get; set; } = new();
        public List<ProductoCantidad> lista_productos { get; set; } = new();

        public void OnGet()
        {
            SupermercadoDbContext context = new SupermercadoDbContext();
            lista_bodegas = context.Bodegas.OrderBy(x => x.Nombre).ToList();
        }

        public void OnPost(int idBodega)
        {
            SupermercadoDbContext context = new SupermercadoDbContext();
            lista_bodegas = context.Bodegas.OrderBy(x => x.Nombre).ToList();

            lista_productos = context.Productos
            .Where(p => p.ProductoBodegas.Any(pb => pb.IdBodega == idBodega))
            .Select(p => new ProductoCantidad
            {
                Id = p.Id,
                Nombre = p.Nombre,
                UnidadMedida = p.UnidadMedida,
                Cantidad = p.ProductoBodegas
                .Where(pb => pb.IdBodega == idBodega)
                .Select(pb => pb.Cantidad)
                .FirstOrDefault()
            })
            .OrderBy(p => p.Nombre)
            .ToList();
        }

    }
}

// Se crea una clase auxiliar para ser capaces de mostrar la cantidad de productos en la misma tabla
public class ProductoCantidad
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? UnidadMedida { get; set; }
    public int Cantidad { get; set; }
}