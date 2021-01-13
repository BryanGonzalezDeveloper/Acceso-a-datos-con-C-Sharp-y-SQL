using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace _01Conectar_base_de_datos
{
    class TestDB
    {
        static void Main(string[] args)
        {
            //Crear una tabla:
             TestDB.crearTabla();

            //Insertar un registro:
           // TestDB.Insertar();
            Console.ReadKey();
        }
       static void crearTabla()
        {
            SqlConnection conexion=null;
            try
            {
                //creacion de una conexion
                 conexion = new SqlConnection(@"Data Source=LAPTOP-6CKP0UE0; Database=Student; Integrated Security=SSPI");
                //creacion de la instruccion sql
                SqlCommand cmd = new SqlCommand
                    (
                    @"CREATE TABLE  tblStudent (ID int not null,name varchar(50),email varchar(100), join_Date date)",conexion
                    );
                //Se necesita abrir la conexion:
                conexion.Open();
                //Ejecucion de la sentencia sql:
                cmd.ExecuteNonQuery();
                Console.WriteLine("Tabla creada correctamente");

            }
            catch(Exception ex)
            {
                Console.WriteLine("Se produjo un error:\t"+ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

       static void Insertar()
        {
            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(@"Data Source=LAPTOP-6CKP0UE0; Database=Student; Integrated Security=SSPI");
                conexion.Open();

                string instruccion =@"INSERT INTO tblStuden (ID,name,email,join_Date) values (1,'BRYAN','gonzalezzbryan220@gmail.com','2001-01-02')";
                SqlCommand cmd=new SqlCommand(instruccion,conexion);
                cmd.ExecuteNonQuery();
                Console.WriteLine("REGISTRO INSERTADO CORRECTAMENTE");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se produjo un error:\t"+ex.Message);
               
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
