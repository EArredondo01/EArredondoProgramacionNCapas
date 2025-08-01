using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Producto
    {
        public static void Add()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Nombre del producto:");
            producto.Nombre = Console.ReadLine();

            Console.WriteLine("Descripcion:");
            producto.Descripcion = Console.ReadLine();

            Console.WriteLine("Costo:");
            producto.Costo = Convert.ToDecimal(Console.ReadLine());

            ML.Result result = BL.Producto.Add(producto);

            if (result.Correct)
            {
                Console.WriteLine("Tus datos han sido guardados con exito \n");
            }
            else
            {
                Console.WriteLine("Error al guardar tus datos ");
            }
        }

        public static void Update()
        {

            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Id producto:");
            producto.IdProducto = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Nombre del producto:");
            producto.Nombre = Console.ReadLine();

            Console.WriteLine("Descripcion:");
            producto.Descripcion = Console.ReadLine();

            Console.WriteLine("Costo:");
            producto.Costo = Convert.ToDecimal(Console.ReadLine());

            ML.Result result = BL.Producto.Update(producto);
            if (result.Correct)
            {
                Console.WriteLine("Tus datos se han actualizado correctamente. \n");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error al actualizar tus datos");
            }

        }

        public static void Delete()
        {

            Console.WriteLine("Id producto:");
            int IdProducto = Convert.ToInt32(Console.ReadLine());

            ML.Result result = BL.Producto.Delete(IdProducto);

            if (result.Correct)
            {
                Console.WriteLine("El producto ha sido eliminado correctamente. \n");
            }
            else
            {
                Console.WriteLine("Error al eliminar el producto ");
            }
        }

        public static void GetAll()
        {
            ML.Result result = BL.Producto.GetAll();
            if (result.Correct)
            {
                foreach (ML.Producto producto in result.Objects)
                {
                    Console.WriteLine("ID: " + producto.IdProducto);
                    Console.WriteLine("Nombre: " + producto.Nombre);
                    Console.WriteLine("Descripcion: " + producto.Descripcion);
                    Console.WriteLine("Costo: " + producto.Costo);
                }
            }
            else
            {
                Console.WriteLine("Productos no encontrados.");
            }
        }

        public static void GetById()
        {
            Console.WriteLine("Ingresa el ID del producto: ");
            int IdProducto = Convert.ToByte(Console.ReadLine());

            ML.Result result = BL.Producto.GetById(IdProducto);

            if (result.Correct)
            {
                ML.Producto producto = (ML.Producto)result.Object;

                Console.WriteLine("ID: " + producto.IdProducto);
                Console.WriteLine("Nombre: " + producto.Nombre);
                Console.WriteLine("Descripcion: " + producto.Descripcion);
                Console.WriteLine("Costo: " + producto.Costo);

                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }
    }
}
