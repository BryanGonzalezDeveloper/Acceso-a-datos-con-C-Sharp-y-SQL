using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace _03_Eliminar_y_actualizar_registros
{
    class Program
    {
        static void Main(string[] args)
        {
            Program objMain = new Program();
            objMain.actualizar();
            objMain.eliminar();
        }
        SqlCommand cmd = new SqlCommand();
        //Metodo de que muestra como se deberia actualizar un registro:
        void actualizar()
        {
            try
            {
                using(SqlConnection con=new SqlConnection(@"Data Source=.; Database=Student; Integrated Security=SSPI"))
                {
                        cmd.CommandText = "update tblStudent set email='gonzalezzbryan220@gmail.com' where ID=101";
                        cmd.Connection = con;
                        con.Open();
                    //se ejecuta la instruccion:
                    int RegistrosAfectados = cmd.ExecuteNonQuery();
                    Console.WriteLine(RegistrosAfectados+" registros fueron actualizados.");
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Error:\t"+e.Message);
            }
        }
        void eliminar()
        {
            try
            {
                using(SqlConnection con =new SqlConnection("Data Source=.; Database=Student; Integrated Security=SSPI"))
                {
                    cmd.CommandText = "delete tblStudent where ID=104";
                    cmd.Connection = con;
                    con.Open();
                    int RegistrosAfectados = cmd.ExecuteNonQuery();
                    Console.WriteLine(RegistrosAfectados+ " registros fueron eliminados.");
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Error:\t"+e.Message);
            }
        }

    }
}
