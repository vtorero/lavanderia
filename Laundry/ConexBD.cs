using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lavanderia.util;
using System.Windows.Forms;

namespace Lavanderia
{
    public class ConexBD
    {
        MySqlConnection con;
        public void Conectar()
        {
            try
            {
            //string enlace ="Server=kvconsult.com; Port=3306 ;Database=kvconsul_lavan; uid=kvconsul_lavan; pwd=vji2002;";
            //string enlace = "Server=107.190.129.66; Port=3306 ;Database=" + varGlobales.baseDeDatos + "; uid=cualesmi_web; pwd=vji2002;";
            //string enlace = "Server=35.231.78.51; Port=3306 ;Database=dashboard; uid=marife; pwd=libido16;";
            //string enlace = "Server=35.231.78.51; Port=3306 ;Database=dashtest; uid=marife; pwd=libido16;";

            string enlace = "Server=localhost;Uid=marife;Database=dashboard;Pwd=libido16";
                this.con= new MySql.Data.MySqlClient.MySqlConnection(enlace);

                con.Open();
                //string enlace = "SERVER=127.0.0.1; Port=3306; DATABASE=dashboard; UID=root; PWD=";
            //this.con = new MySqlConnection(enlace);
            //this.con.Close();   
            //this.con.Open();
            }
            catch (MySqlException e)
            {
                 Console.WriteLine(e);
            }

        }

        public MySqlConnection ObtenerConexion()
        {
            return this.con;
        }

        public void cerrarConexion()
        {
            this.con.Close();
        }
    }
}
