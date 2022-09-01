using System.Data;

namespace ProyectoFinalAppi.ADO_.NET
{
    public static class ProductoVendidoHandler
    {
        //Variable DataBase.
        public const string ConnectionString = "Server=DESKTOP-VMN25V6\\LEOGESTIO;DataBase=SistemaGestion;Trusted_connection=True";

        //Funciones.

        //Borrar Producto Vendido.
        public static bool EliminarProductoVendido(int id)
        {
            bool productoVendidoEliminado = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "DELETE FROM [SistemaGestion].[dbo].[ProductoVendido] WHERE Id = @Id;";

                SqlParameter sqlParameter = new SqlParameter("Id", SqlDbType.BigInt) { Value = id };

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(sqlParameter);

                        int cantidadDeProductoVendidoEliminado = sqlCommand.ExecuteNonQuery();

                        if (cantidadDeProductoVendidoEliminado > 1)
                        {
                            Console.WriteLine("Producto YA VENDIDO eliminado correctamente.");
                            return productoVendidoEliminado = true;
                        }
                        else
                        {
                            Console.WriteLine("ERROR! El producto YA VENDIDO no pudo ser eliminado, intentelo nuevamente.");
                            return productoVendidoEliminado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Query definition error" + ex.Message);
                }
            }
            return productoVendidoEliminado;
        }

        internal static bool ModificarProductoVendido(ProductoVendido productoVendido)
        {
            throw new NotImplementedException();
        }

        //Agregar Producto vendido.
        public static bool CreacionProductoVendido(ProductoVendido productoVentadido)
        {
            bool productoVendidoCreado = false;


            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryAdd = "INSERT INTO [SistemaGestion].[dbo].[ProductoVendido] (Stock, IdProducto, IdVenta)" +
                    "VALUES(@stock, @idProducto, @idVenta)";

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryAdd, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int) { Value = productoVentadido.productoVendido_Stock });
                        sqlCommand.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.VarChar) { Value = productoVentadido.productoVendido_IdProducto });
                        sqlCommand.Parameters.Add(new SqlParameter("IdVenta", SqlDbType.VarChar) { Value = productoVentadido.productoVendido_IdVenta });

                        int cantidadProductoVendidoCreado = sqlCommand.ExecuteNonQuery();

                        if (cantidadProductoVendidoCreado > 1)
                        {
                            Console.WriteLine("Producto Vendido con exito!!");
                            return productoVendidoCreado = true;
                        }
                        else
                        {
                            Console.WriteLine("ERROR! el producto no pudo ser creado, intentelo nuevamente.");
                            return productoVendidoCreado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Querry definition error " + ex.Message);
                }
            }
            return productoVendidoCreado;
        }

        //Actualizar Producto Vendido.
        public static bool ModificarProducto(ProductoVendido productoVendido)
        {
            bool productoModificado = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryUpdate = "UPDATE [SistemaGestion].[dbo].[ProductoVendido ]" +
                    "SET " +
                        "Stock = @stock," +
                        "IdProducto = @idProducto," +
                        "IdVenta = @idVenta," +
                    "WHERE Id = @id";

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Stock", SqlDbType.BigInt) { Value = productoVendido.productoVendido_Stock });
                        sqlCommand.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.VarChar) { Value = productoVendido.productoVendido_IdProducto });
                        sqlCommand.Parameters.Add(new SqlParameter("IdVenta", SqlDbType.VarChar) { Value = productoVendido.productoVendido_IdVenta });

                        int cantidadDeProductoVendidoModificado = sqlCommand.ExecuteNonQuery();

                        if (cantidadDeProductoVendidoModificado > 1)
                        {
                            Console.WriteLine("Producto Vendido Modificado con ¡EXITO!");
                            return productoModificado = true;
                        }
                        else
                        {
                            Console.WriteLine("ERROR! El producto no pudo ser creado correctamente, intentelo nuevamente.");
                            return productoModificado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Querry definition error " + ex.Message); ;
                }
            }
            return productoModificado;
        }

        //Obtener Productos Vendidos.
        public static List<ProductoVendidoObtenido> GetProductosVendidos()
        {
            Console.WriteLine(" MOSTRANDO TODOS LOS PRODUCTOS VENDIDOS  ");

            List<ProductoVendidoObtenido> listaProductoVendidos = new List<ProductoVendido>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryGetProductosVendidos = "SELECT * FROM [SistemaGestion].[dbo].[ProductoVendido]";

                using (SqlCommand sqlCommand = new SqlCommand(queryGetProductosVendidos, sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    ProductoVendido productoVendido = new ProductoVendido();
                                    productoVendido.productoVendido_Id = Convert.ToInt32(dataReader["Id"]);
                                    productoVendido.productoVendido_Stock = Convert.ToInt32(dataReader["Stock"]);
                                    productoVendido.productoVendido_IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                                    productoVendido.productoVendido_IdVenta = Convert.ToInt32(dataReader["IdVenta"]);
                                    listaProductoVendidos.Add(productoVendido);
                                }
                            }

                            dataReader.Close();
                        }
                        sqlConnection.Close();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Query error definition " + ex.Message);
                    }
                }
            }

            foreach (ProductoVendido productoVenta in listaProductoVendidos)
            {
                Console.WriteLine($"Id: {productoVenta.productoVendido_Id}\n" +
                    $"Stock: {productoVenta.productoVendido_Stock}\n" +
                    $"IdProducto: {productoVenta.productoVendido_IdProducto}\n" +
                    $"IdVenta: {productoVenta.productoVendido_IdProducto}");
            }
            return listaProductoVendidos;
        }

        //Obtener productos vendidos por id.
        public static List<ProductoVendido> GetProductosVendidosPorId(int id)
        {
            Console.WriteLine("   MOSTRANDO TODOS LOS PRODUCTOS VENDIDOS POR ID  ");

            List<ProductoVendido> listaProductosVendidosPorId = new List<ProductoVendido>();


            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryGetProductosVendidosPorId = "SELECT Id, Stock, IdProducto, IdVenta FROM [SistemaGestion].[dbo].[ProductoVendido]" +
                    "WHERE Id = @id";

                using (SqlCommand sqlCommand = new SqlCommand(queryGetProductosVendidosPorId, sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("Id", SqlDbType.Int) { Value = id });

                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    ProductoVendido productoVendido = new ProductoVendido();
                                    productoVendido.productoVendido_Id = Convert.ToInt32(dataReader["Id"]);
                                    productoVendido.productoVendido_Stock = Convert.ToInt32(dataReader["Stock"]);
                                    productoVendido.productoVendido_IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                                    productoVendido.productoVendido_IdVenta = Convert.ToInt32(dataReader["IdVenta"]);
                                    listaProductosVendidosPorId.Add(productoVendido);
                                }
                            }
                            dataReader.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Query definition error " + ex.Message);
                    }
                }
                sqlConnection.Close();
            }
            return listaProductosVendidosPorId;
        }
    }
}