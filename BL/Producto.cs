using Microsoft.Data.SqlClient;
using System.Data;

namespace BL
{
    public class Producto
    {
        private readonly DL.Conexion _connectionString;
        public Producto(DL.Conexion connectionString)
        {
            _connectionString = connectionString;
        }
        public ML.Result Add(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(_connectionString.Get()))
                {
                    string query = "INSERT INTO Producto (Nombre, Descripcion, Costo) VALUES (@Nombre, @Descripcion, @Costo)";

                    SqlCommand cmd = new SqlCommand(query, context);

                    cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@Costo", producto.Costo);

                    context.Open();

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ha ocurrido un error al insertar los datos";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public ML.Result Update(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (SqlConnection context = new SqlConnection(_connectionString.Get()))
                {
                    string query = "UPDATE Producto SET Nombre = @Nombre ,Descripcion = @Descripcion , Costo = @Costo WHERE IdProducto = @IdProducto";

                    SqlCommand cmd = new SqlCommand(query, context);

                    cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@Costo", producto.Costo);
                    cmd.Parameters.AddWithValue("@IdProducto", producto.IdProducto);


                    context.Open();

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ha ocurrido un error al insertar los datos";
                    }


                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public ML.Result Delete(int IdProducto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(_connectionString.Get()))
                {
                    string query = "DELETE FROM Producto WHERE IdProducto = @IdProducto";

                    SqlCommand cmd = new SqlCommand(query, context);

                    cmd.Parameters.AddWithValue("@IdProducto", IdProducto);

                    context.Open();

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ha ocurrido un error al eliminar el producto";
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(_connectionString.Get()))
                {
                    string query = "SELECT IdProducto ,Nombre, Descripcion, Costo  FROM Producto";

                    SqlCommand cmd = new SqlCommand(query, context);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (DataRow row in dataTable.Rows)
                        {
                            ML.Producto producto = new ML.Producto();

                            producto.IdProducto = Convert.ToInt32(row[0]);
                            producto.Nombre = row[1].ToString();
                            producto.Descripcion = row[2].ToString();
                            producto.Costo = Convert.ToDecimal(row[3].ToString());

                            result.Objects.Add(producto);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "La tabla no tiene registros aun.";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public ML.Result GetById(int IdProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(_connectionString.Get()))
                {
                    string query = "SELECT IdProducto ,Nombre, Descripcion, Costo  FROM Producto WHERE IdProducto = @IdProducto;";

                    SqlCommand cmd = new SqlCommand(query, context);

                    cmd.Parameters.AddWithValue("@IdProducto", IdProducto);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        DataRow row = dataTable.Rows[0];
                        ML.Producto producto = new ML.Producto();

                        producto.IdProducto = Convert.ToInt32(row["IdProducto"]);
                        producto.Nombre = row["Nombre"].ToString();
                        producto.Descripcion = row["Descripcion"].ToString();
                        producto.Costo = Convert.ToDecimal(row["Costo"]);

                        result.Object = producto;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron los datos de ese usuario";
                    }


                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
