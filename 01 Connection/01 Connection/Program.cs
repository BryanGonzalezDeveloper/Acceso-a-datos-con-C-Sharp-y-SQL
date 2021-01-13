using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace _01_Connection
{
    class Program
    {
      static  SqlConnection con = new SqlConnection(@"Data Source=.; Database=Student; Integrated Security=true");
        static void Main(string[] args)
        {
            //Se abre la conexion:
            con.AbrirConexion();
            Console.WriteLine("CONEXION INICIADA CORRECTAMENTE.");
            //Se cierra la conexion:
            con.CerrarConexion();
            Console.WriteLine("CONEXION FINALIZADA.");

            Console.ReadKey();
        }
    }
}
