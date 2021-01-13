using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;

namespace _01_App_config
{
    public static class ClsConexion
    {
        //Metodo que devuelve la cadena de conexion.
        //Recibe el nombre de la cadena de conexion (se pueden tener varias)
        public static string getCadenaConexion(string nombreConexion)
        {
            Configuration appconfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            ConnectionStringSettings connStringSettings = appconfig.ConnectionStrings.ConnectionStrings[nombreConexion];

            return connStringSettings.ConnectionString;
        }
        //cambia el nombre de una cadena de conexion el nombre antiguo, sera sustituido por el nombre nuevo.
        public static void CambiarNombreCadenaConexion(string nombreAntiguo, string nombreNuevo)
        {
            Configuration appconfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            appconfig.ConnectionStrings.ConnectionStrings[nombreAntiguo].ConnectionString = nombreNuevo;
            appconfig.Save();
        }
    }
}
