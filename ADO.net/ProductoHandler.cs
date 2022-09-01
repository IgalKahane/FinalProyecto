using Microsoft.Data.SqlClient;
using ProyectoFinalAppi.Models;
using System.Data;


namespace ProyectoFinalAppi.ADO_.NET
{
    public static class ProductoHandler
    {
        //Variable DataBase.
        public const string ConnectionString = "Server=DESKTOP-VMN25V6\\LEOGESTIO;DataBase=SistemaGestion;Trusted_connection=True";

        //Funciones.

        //Borrar producto.
        public static bool EliminarProducto(int id)
        {
            bool productoEliminado = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "DELETE FROM [SistemaGestion].[dbo].[Producto] WHERE Id = @Id;";

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = id });

                        int cantidadDeProductoEleiminado = sqlCommand.ExecuteNonQuery();

                        if (cantidadDeProductoEleiminado > 1)
                        {
                            Console.WriteLine("Producto Eliminado");
                            return productoBorrado = true;
                        }
                        else
                        {
                            Console.WriteLine("ERROR! El producto no se puedo eliminar, intentelo nuevamente");
                            return productoBorrado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Query definition error" + ex.Message);
                }
            }
            return productoBorrado = true;
        }

        //Agregar producto.
        public static bool CreacionProducto(Producto producto)
        {
            bool productoCreado = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryAdd = "INSERT INTO [SistemaGestion].[dbo].[Producto] (Descripcion, Costo, PrecioDeVenta, Stock, IdUsuario)" +
                    "VALUES(@descripncion, @costo, @precioDeVenta, @stock, @idUsuario)";

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryAdd, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Descripcion", SqlDbType.VarChar) { Value = producto.producto_Descipcion });
                        sqlCommand.Parameters.Add(new SqlParameter("Costo", SqlDbType.BigInt) { Value = producto.producto_Costo });
                        sqlCommand.Parameters.Add(new SqlParameter("PrecioDeVenta", SqlDbType.BigInt) { Value = producto.producto_PrecioDeVenta });
                        sqlCommand.Parameters.Add(new SqlParameter("Stock", SqlDbType.BigInt) { Value = producto.producto_Stock });
                        sqlCommand.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.VarChar) { Value = producto.producto_IdUsuario });

                        int cantidadDeProductoCreado = sqlCommand.ExecuteNonQuery();

                        if (cantidadDeProductoCreado > 1)
                        {
                            Console.WriteLine("El producto se fabricó correctamente");
                            return productoCreado = true;
                        }
                        else
                        {
                            Console.WriteLine("ERROR! el producto no pudo ser creado, intentelo nuevamente.");
                            return productoCreado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Querry definition error " + ex.Message);
                }
            }
            return productoCreado;
        }

        //Actualizar producto.
        public static bool ModificarProducto(Producto producto)
        {
            bool productoModificado = false;


            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryUpdate = "UPDATE [SistemaGestion].[dbo].[Producto]" +
                    "SET " +
                        "Descripciones = @descripcion," +
                        "Costo = @id," +
                        "PrecioVenta = @precioDeVenta," +
                        "Stock = @stock," +
                        "Categorias = @idUsuario" +
                    "WHERE Codigo = @id";

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommando = new SqlCommand(queryUpdate, sqlConnection))
                    {
                        sqlCommando.Parameters.Add(new SqlParameter("Descripcion", SqlDbType.VarChar) { Value = producto.producto_Descipcion });
                        sqlCommando.Parameters.Add(new SqlParameter("Costo", SqlDbType.BigInt) { Value = producto.producto_Costo });
                        sqlCommando.Parameters.Add(new SqlParameter("PrecioDeVenta", SqlDbType.BigInt) { Value = producto.producto_PrecioDeVenta });
                        sqlCommando.Parameters.Add(new SqlParameter("Stock", SqlDbType.BigInt) { Value = producto.producto_Stock });
                        sqlCommando.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.VarChar) { Value = producto.producto_IdUsuario });

                        int cantidadDeProductosModificados = sqlCommando.ExecuteNonQuery();

                        if (cantidadDeProductosModificados > 1)
                        {
                            Console.WriteLine("El Producto fue modificado correctamente");
                            return productoModificado = true;
                        }
                        else
                        {
                            Console.WriteLine("EEROR! el producto no pudo ser modificado, intentelo nuevamente.");
                            return productoModificado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Querry definition error " + ex.Message);
                }
            }
            return productoModificado;
        }

        //Obtener productos.
        public static List<Producto> GetProductos()
        {
            Console.WriteLine("      MOSTRANDO TODOS LOS PRODUCTOS      ");

            List<Producto> listaProductos = new List<Producto>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryGetProductos = "SELECT * FROM [SistemaGestion].[dbo].[Producto]";

                    using (SqlCommand sqlCommand = new SqlCommand(queryGetProductos, sqlConnection))
                    {
                        sqlConnection.Open();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    Producto producto = new Producto();
                                    producto.producto_Id = Convert.ToInt32(dataReader["Id"]);
                                    producto.producto_Stock = Convert.ToInt32(dataReader["Stock"]);
                                    producto.producto_IdUsuario = Convert.ToInt32(dataReader["IdUsuario"]);
                                    producto.producto_Costo = Convert.ToInt32(dataReader["Costo"]);
                                    producto.producto_PrecioDeVenta = Convert.ToInt32(dataReader["PrecioVenta"]);
                                    producto.producto_Descipcion = dataReader["Descripciones"].ToString();
                                    listaProductos.Add(producto);
                                }
                            }

                            dataReader.Close();
                        }
                        sqlConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Query error definition " + ex.Message);
            }

            foreach (Producto producto in listaProductos)
            {
                Console.WriteLine($"Id: {producto.producto_Id}\n" +
                    $"Stock: {producto.producto_Stock}\n" +
                    $"Costo: {producto.producto_Costo}\n" +
                    $"Precio de venta: {producto.producto_PrecioDeVenta}\n" +
                    $"Descripcion: {producto.producto_Descipcion}\n" +
                    $"Id usuario: {producto.producto_IdUsuario}");
            }
            return listaProductos;
        }

        //Obtener Productos por id.
        public static List<Producto> GetProductosPorId(int id)
        {
            Console.WriteLine("        MOSTRANDO PRODUCTOS POR ID       ");

            List<Producto> listaProductosPorId = new List<Producto>();


            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryGetProductoPorId = "SELECT Id, Descripciones, Costo, PrecioVenta, Stock, IdUsuario FROM [SistemaGestion].[dbo].[Producto]" +
                    "WHERE Id = @id";

                using (SqlCommand sqlCommand = new SqlCommand(queryGetProductoPorId, sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = id });

                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    Producto producto = new Producto();
                                    producto.producto_Id = Convert.ToInt32(dataReader["Id"]);
                                    producto.producto_Stock = Convert.ToInt32(dataReader["Stock"]);
                                    producto.producto_IdUsuario = Convert.ToInt32(dataReader["IdUsuario"]);
                                    producto.producto_Costo = Convert.ToInt32(dataReader["Costo"]);
                                    producto.producto_PrecioDeVenta = Convert.ToInt32(dataReader["PrecioVenta"]);
                                    producto.producto_Descipcion = dataReader["Descripciones"].ToString();
                                    listaProductosPorId.Add(producto);
                                }
                            }
                            dataReader.Close();
                        }
                        sqlConnection.Close();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Query definition error " + ex.Message);
                    }
                }
            }

            foreach (Producto producto in listaProductosPorId)
            {
                Console.WriteLine($"Id: {producto.producto_Id}\n" +
                    $"Stock: {producto.producto_Stock}\n" +
                    $"Costo: {producto.producto_Costo}\n" +
                    $"Precio de venta: {producto.producto_PrecioDeVenta}\n" +
                    $"Descripcion: {producto.producto_Descipcion}\n" +
                    $"Id usuario: {producto.producto_IdUsuario}");
            }
            return listaProductosPorId;
        }

    }
}