using Microsoft.Data.SqlClient;
using ProyectoFinalAppi.Models;
using System.Data;

namespace ProyectoFinalAppi.ADO_.NET
{
    public static class VentaHandler
    {
        //Variable DataBase.
        public const string ConnectionString = "Server=DESKTOP-VMN25V6\\LEOGESTIO;DataBase=SistemaGestion;Trusted_connection=True";

        //Funciones.

        //Borrar Venta.
        public static bool EliminacionVenta(int id)
        {
            bool ventaEliminada = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {

                string queryDelete = "DELETE FROM [SistemaGestion].[dbo].[Venta] WHERE Id = @Id;";

                SqlParameter sqlParameter = new SqlParameter("Id", SqlDbType.BigInt) { Value = id };

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                    {

                        sqlCommand.Parameters.Add(sqlParameter);

                        int cantidadDeVentaEliminada = sqlCommand.ExecuteNonQuery();

                        if (cantidadDeVentaEliminada > 1)
                        {
                            Console.WriteLine("Venta Eliminada conn ¡EXITO! ");
                            return ventaEliminada = true;
                        }
                        else
                        {
                            Console.WriteLine("ERROR, la venta no pudo ser eliminada, intentelo nuevamente.");
                            return ventaEliminada = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Query definition error " + ex.Message);
                }
            }
            return ventaEliminada;

        }

        //Agregar Venta.
        public static bool CreacionVenta(Venta venta)
        {
            bool ventaCreada = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryAdd = "INSERT INTO [SistemaGestion].[dbo].[Venta] (Comentarios)" +
                    "VALUES(@comentarios)";

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryAdd, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Nombre", SqlDbType.VarChar) { Value = venta.venta_Comentarios });

                        int cantidadDeVentasCreadas = sqlCommand.ExecuteNonQuery();

                        if (cantidadDeVentasCreadas > 1)
                        {
                            Console.WriteLine("Venta Creada con exitosamente!!");
                            return ventaCreada = true;
                        }
                        else
                        {
                            Console.WriteLine("ERROR, la venta no pudo ser eliminada, intentelo nuevamente.");
                            return ventaCreada = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Query definition error " + ex.Message);
                }
            }
            return ventaCreada;
        }

        //Actualizar Ventas.
        public static bool ModificacionVenta(Venta venta)
        {
            bool ventaModificada = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryUpdate = "UPDATE [SistemaGestion].[dbo].[Venta]" +
                    "SET " +
                        "Comentarios = @comentarios," +
                    "WHERE Id = @id";

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = venta.venta_Id });
                        sqlCommand.Parameters.Add(new SqlParameter("Nombre", SqlDbType.VarChar) { Value = venta.venta_Comentarios });

                        int cantidadDeVentasModificadas = sqlCommand.ExecuteNonQuery();

                        if (cantidadDeVentasModificadas > 1)
                        {
                            Console.WriteLine("Venta Modificada exitosamente!!");
                            return ventaModificada = true;
                        }
                        else
                        {
                            Console.WriteLine("ERROR, la venta no pudo ser eliminada, intentelo nuevamente.");
                            return ventaModificada = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Query definition error " + ex.Message);
                }
            }
            return ventaModificada;
        }

        //Obtener Ventas.
        public static List<Venta> GetVentas()
        {
            List<Venta> listaVentas = new List<Venta>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryGetVentas = "SELECT * FROM [SistemaGestion].[dbo].[Usuario]";

                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand(queryGetVentas, sqlConnection))
                    {
                        sqlConnection.Open();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    Venta venta = new Venta();
                                    venta.venta_Id = Convert.ToInt32(dataReader["Id"]);
                                    venta.venta_Comentarios = dataReader["Nombre"].ToString();
                                    listaVentas.Add(venta);
                                }
                            }
                            dataReader.Close();
                        }
                        sqlConnection.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Query error definition " + ex.Message);
                }
            }

            foreach (Venta venta in listaVentas)
            {
                Console.WriteLine($"Id: {venta.venta_Id}\n" +
                    $"Comentarios: {venta.venta_Comentarios}\n");
            }
            return listaVentas;
        }

    }
}
