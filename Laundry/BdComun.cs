using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Lavanderia.util;

namespace Lavanderia
{
    public class BdComun
    {
        public static MySqlConnection ObtenerConexion()
        {
           
                MySqlConnection conectar = new MySqlConnection("server=cualesmiip.pe;database="+varGlobales.baseDeDatos+";Uid=cualesmi_web;pwd=vji2002;");
                conectar.Open();
                 return conectar;
       
        }
    }
}