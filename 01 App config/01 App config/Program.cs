using System;
using System.Configuration;
using System.Data.SqlClient;
namespace _01_App_config
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                //Instrucciones para leer la cadena de conexion desde App.config
                string strConexion = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(strConexion))
                {
                    conexion.Open();
                    Console.WriteLine("CONEXION REALIZADA.");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error:\t" + ex.Message);
            }
            Console.ReadKey();

        }

    }
}
