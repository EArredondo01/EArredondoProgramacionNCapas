using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace PL_MVC.Controllers
{
    public class ProductoController : Controller
    {
        private readonly BL.Producto _productoService;

        public ProductoController(BL.Producto productoService)
        {
            _productoService = productoService;
        }

        public IActionResult GetAll()
        {

            ML.Producto producto = new ML.Producto();
            producto.Productos = new List<object>();

            ML.Result result = _productoService.GetAll();

            if (result.Correct)
            {
                producto.Productos = result.Objects;
            }

            return View(producto);
        }
    }
}
