using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace bodega.Pages
{
    public class CargarArchivoModel : PageModel
    {
        private readonly ILogger<CargarArchivoModel> _logger;
        
        public string Datos = "";

        public CargarArchivoModel(ILogger<CargarArchivoModel> logger)
        {
            _logger = logger;
        }

        public void OnPost(IFormFile archivo)
        {

            if (archivo == null || archivo.Length == 0)
            {
                Datos = "No se ha seleccionado ningún archivo.";
                return;
            }

            try
            {
                StreamReader reader = new StreamReader(archivo.OpenReadStream());
                Datos = reader.ReadToEnd();
                
                List<ProductoBodega>? lista = JsonSerializer.Deserialize<List<ProductoBodega>>(Datos);
                
                if (lista != null)
                {
                    SupermercadoDbContext context = new SupermercadoDbContext();
                    Datos = reader.ReadToEnd();
                    foreach (var item in lista)
                    {
                        ProductoBodega? pb = context.ProductoBodegas
                            .FirstOrDefault(x => x.IdBodega == item.IdBodega && x.IdProducto == item.IdProducto);

                        if (pb != null)
                        {
                            pb.Cantidad += item.Cantidad;
                        }
                        else
                        {
                            context.ProductoBodegas.Add(new ProductoBodega
                            {
                                IdBodega = item.IdBodega,
                                IdProducto = item.IdProducto,
                                Cantidad = item.Cantidad
                            });
                        }
                    }

                    context.SaveChanges();
                    Datos = "El archivo se ha procesado correctamente.";
                }
                else
                {
                    Datos = "El archivo no contiene datos válidos.";
                }
            }
            catch (Exception ex)
            {
                Datos = "Error al procesar el archivo: " + ex.Message;
            }

        }
    }
}
