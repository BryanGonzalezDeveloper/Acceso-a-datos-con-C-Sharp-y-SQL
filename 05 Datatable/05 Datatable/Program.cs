using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace _05_Datatable
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().UsoDatatable();
            Console.ReadKey();
        }

        void UsoDatatable()
        {
            try
            {
                using(SqlConnection con=new SqlConnection("data source=.; database=Student; integrated security=SSPI"))
                {
                    SqlCommand cmd = new SqlCommand("select * from tblStudent", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dtOriginal = new DataTable();
                    da.Fill(dtOriginal);

                    //Mostrar resultado del datatable original:
                    Console.WriteLine("DATATABLE ORIGINAL:");
                    foreach (DataRow fila in dtOriginal.Rows)                    
                        Console.WriteLine(fila[0]+","+fila[1]+","+fila[2]+","+fila[3]);
                    DataTable dtCopia = dtOriginal.Copy();

                    //Mostrar resultado del datatable que es copia:
                    Console.WriteLine("DATATABLE COPIA:");
                    foreach (DataRow fila in dtCopia.Rows)
                        Console.WriteLine(fila[0] + "," + fila[1] + "," + fila[2] + "," + fila[3]);

                    //se agrega datos al datatable de copia:
                    dtCopia.Rows.Add(105, "ABI", "ABI@GMAIL.COM", new DateTime(1998, 7, 28));

                    //se vuelve a imprimir el datatable original y la copia:
                    //Mostrar resultado del datatable original:
                    Console.WriteLine("DATATABLE ORIGINAL:");
                    foreach (DataRow fila in dtOriginal.Rows)
                        Console.WriteLine(fila[0] + "," + fila[1] + "," + fila[2] + "," + fila[3]);              

                    //Mostrar resultado del datatable que es copia:
                    Console.WriteLine("DATATABLE COPIA:");
                    foreach (DataRow fila in dtCopia.Rows)
                        Console.WriteLine(fila[0] + "," + fila[1] + "," + fila[2] + "," + fila[3]);                   
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
