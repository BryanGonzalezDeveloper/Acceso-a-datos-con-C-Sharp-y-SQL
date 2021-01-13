using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace _02_leer_registros
{
    class Program
    {
        static void Main(string[] args)
        {
            Program objMain = new Program();
            //Lee los registros:
            objMain.leer();

            Console.WriteLine("\n\nLa tabla: 'tblStudent' contiene: "+objMain.TotalRegistros()+" registros.");
            Console.ReadKey();
        }

        SqlConnection objCon = new SqlConnection(@"Data Source=.; Database=Student; Integrated Security=true");
        SqlCommand cmd = new SqlCommand();
        void leer()
        {
            try
            {
                //se crea la instruccion:
                cmd.CommandText = @"select * from tblStudent";
                cmd.Connection = objCon;
                objCon.Open();//abre la conexion
                SqlDataReader sdr = cmd.ExecuteReader();    //Lee los registros
                while (sdr.Read())
                {
                    Console.WriteLine(sdr[0]+","+sdr[1]+","+sdr[2]+","+sdr[3]);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("SE PRODUJO UN ERROR:\t"+ex.Message);
            }
            finally
            {
                objCon.Close();     
            }
        }
      
        int TotalRegistros()
        {
            int totalRegistros = new int();
            try
            {
                cmd.CommandText = "select count(ID) from tblStudent";
                cmd.Connection = objCon;
                objCon.Open();
                //Se ejecuta la consulta:
                 totalRegistros = (int)cmd.ExecuteScalar();
               
            }catch(Exception ex)
            {
                Console.WriteLine("Error inesperado\t"+ex.Message);
            }
            finally
            {
                objCon.Close();
                
            }
            return totalRegistros;
        }
    }
}
