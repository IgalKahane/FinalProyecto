using Microsoft.Data.SqlClient;
using ProyectoFinalAppi.Models;
using System.Data;

namespace ProyectoFinalAppi.ADO_.NET
{
    public static class InicioSesionHandler
    {
        //Variable DataBase.
        public const string ConnectionString = "Server=DESKTOP-VMN25V6\\LEOGESTIO;DataBase=SistemaGestion;Trusted_connection=True";

        //Verificar usuario.
        public static bool VerificarUsuario(string nombre, string password)
        {
            int cont = 0;
            bool logingExitoso = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryVerificarUsuario = "SELECT * FROM [SistemaGestion].[dbo].[Usuario] WHERE Nombre = @nombre, Contraseña = @contraseña";

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryVerificarUsuario, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Nombre", SqlDbType.VarChar) { Value = nombre });
                        sqlCommand.Parameters.Add(new SqlParameter("Contraseña", SqlDbType.VarChar) { Value = password });

                        sqlCommand.ExecuteNonQuery();

                        do
                        {
                            Console.WriteLine("Por favor ingrese su nombre: ");
                            nombre = Console.ReadLine();

                            Console.WriteLine("Por favor Ingrese su contraseña: ");
                            password = Console.ReadLine();

                            if (password == password)
                            {
                                logingExitoso = true;
                            }
                            else
                            {
                                Console.WriteLine("Contraseña incorrecta, por favor vuelva a intentarlo");
                            }

                            cont++;

                            if (cont > 5)
                            {
                                if (cont == 4)
                                {
                                    Console.WriteLine("Ultimo intento para iniciar sesion");
                                }
                                break;
                            }

                        } while (logingExitoso is false);


                        if (logingExitoso)
                        {
                            Console.WriteLine($"Bienvenido a la plataforma !!!");
                            return logingExitoso = true;
                        }
                        else
                        {
                            Console.WriteLine("Error al logearse");
                            return logingExitoso = false;
                        }

                    }

                    sqlConnection.Open();
                }
                catch (Exception ex)
                {

                    throw new Exception("Query definition error " + ex.Message);
                }
            }
            return logingExitoso;
        }
    }
}
