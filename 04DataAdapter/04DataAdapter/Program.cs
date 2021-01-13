using System;
using System.Data;
using System.Data.SqlClient;

namespace _04DataAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().leer();
            Console.ReadKey();
        }

        void leer()
        {
            try
            {
                using(SqlConnection con=new SqlConnection("data source=.;database=Student;integrated security=SSPI"))
                {
                    SqlCommand cmd = new SqlCommand("select * from tblStudent",con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    //Utilizando datatable:
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //Visualizando los resultados:
                    Console.WriteLine("RESULTADOS CON DATATABLE:");
                    foreach (DataRow fila in dt.Rows)
                        Console.WriteLine(fila[0]+", "+fila[1]+", "+fila[2]+", "+fila[3]);

                    //Utilizando dataset
                    DataSet ds = new DataSet();
                    da.Fill(ds, "tblStudent");
                    Console.WriteLine("\n\nRESULTADOS CON DATASET:");
                    foreach(DataRow fila in ds.Tables["tblStudent"].Rows)
                        Console.WriteLine(fila[0] + ", " + fila[1] + ", " + fila[2] + ", " + fila[3]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
