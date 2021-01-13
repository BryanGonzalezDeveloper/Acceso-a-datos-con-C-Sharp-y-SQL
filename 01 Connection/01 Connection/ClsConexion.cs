using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
namespace _01_Connection
{
     static class ClsConexion
    {
       //Metodo que abre una conexion en caso de que esta se encuentre cerrada:
        public static SqlConnection AbrirConexion(this SqlConnection objConexion)
        {
            if (objConexion.State == ConnectionState.Closed)
                objConexion.Open();
            return objConexion;
        }
        //Metodo que cierra la conexion si esta se encuentra abierta:
        public static SqlConnection CerrarConexion(this SqlConnection objConexion)
        {
            if (objConexion.State == ConnectionState.Open)
                objConexion.Close();
            return objConexion;
        }
    }
}
