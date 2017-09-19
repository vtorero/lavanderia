using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lavanderia.Models;
using System.Data;
using System.Windows.Forms;

namespace Lavanderia.Persistencia
{
    class PrendaDao
    {   
        
        public static int Agregar(Prenda prenda)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("Insert into Prenda (NombrePrenda, DescripcionPrenda, precioServicio,tipoPrenda) values ('{0}','{1}',{2},'{3}')",
                prenda.NombrePrenda, prenda.Descripcion, prenda.precioServicio,prenda.tipoPrenda), BdComun.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return retorno;
        }


        public static int Modificar(Prenda prenda)
        {
            ConexBD cnx = new ConexBD();
            cnx.Conectar();
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("UPDATE Prenda Set nombrePrenda='{0}',descripcionPrenda='{1}',precioServicio='{2}',tipoPrenda='{3}' where idPrenda='{4}'"
            , prenda.NombrePrenda, prenda.Descripcion, prenda.precioServicio,prenda.tipoPrenda, prenda.idPrenda), cnx.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            comando.Connection.Close();
            cnx.cerrarConexion();
            return retorno;


        }

        public static int Eliminar(int idprenda)
        {
          ConexBD cnx = new ConexBD();
            cnx.Conectar();
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("DELETE FROM Prenda where idPrenda='{0}'", idprenda),cnx.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            cnx.cerrarConexion();
            return retorno;
        }

        public static MySqlDataReader fillPrenda() {
            
            MySqlCommand _comando = new MySqlCommand("prendasAll",BdComun.ObtenerConexion());
            _comando.CommandType = CommandType.StoredProcedure;
            MySqlDataReader _reader = _comando.ExecuteReader(CommandBehavior.CloseConnection);
                 return _reader;
          
        }


          /* public static MySqlDataReader fillMarca()
        {
            ConexBD cnx = new ConexBD();
            cnx.Conectar();
                       MySqlCommand _comando = new MySqlCommand("marcasAll", cnx.ObtenerConexion());
            _comando.CommandType = CommandType.StoredProcedure;
            MySqlDataReader _reader = _comando.ExecuteReader(CommandBehavior.CloseConnection);
            return _reader;
           
            }
        */

        public static int agregarMarca(string nombre)
        {
            ConexBD cnx = new ConexBD();
            cnx.Conectar();
            MySqlCommand cmd = new MySqlCommand("insertaMarca", cnx.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("nombre", nombre));
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            cnx.cerrarConexion();
            return 1;
        }

        public static MySqlDataReader fillPrendaSearch(string criterio)
        {
            ConexBD cnx = new ConexBD();
            cnx.Conectar();
            MySqlCommand _comando = new MySqlCommand("prendasSearch", cnx.ObtenerConexion());
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.Add(new MySqlParameter("criterio", criterio));

            MySqlDataReader _reader = _comando.ExecuteReader();

            _comando.Connection.Close();
            cnx.cerrarConexion();
               return _reader;
       
        }

        public static List<Prenda> Listar()
        {

            List<Prenda> _lista = new List<Prenda>();
                ConexBD cnx = new ConexBD();
            cnx.Conectar();
            MySqlCommand _comando = new MySqlCommand(String.Format(
           "SELECT idPrenda, nombrePrenda , descripcionPrenda, precioServicio,tipoPrenda FROM Prenda order by idPrenda"),cnx.ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
            
            while (_reader.Read())
            {
                Prenda prenda = new Prenda();
                prenda.idPrenda= _reader.GetInt32(0);
                prenda.NombrePrenda = _reader.GetString(1);
                prenda.Descripcion = _reader.GetString(2);
                prenda.precioServicio = _reader.GetDecimal(3);
                prenda.tipoPrenda = _reader.GetString(4);
                
         _lista.Add(prenda);
            }
            _comando.Connection.Close();
            cnx.cerrarConexion();
            return _lista;
        }

        public static List<Prenda> Buscar(string nombre)
        {
            List<Prenda> _lista = new List<Prenda>();
            ConexBD cnx = new ConexBD();
            cnx.Conectar();
            MySqlCommand _comando = new MySqlCommand(String.Format(
           "SELECT *  FROM Prenda where nombrePrenda like '%{0}%' ", nombre), cnx.ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                Prenda prenda = new Prenda();
                prenda.idPrenda= _reader.GetInt32(0);
                prenda.NombrePrenda = _reader.GetString(1);
                prenda.Descripcion = _reader.GetString(2);
                prenda.precioServicio= _reader.GetDecimal(3);
                prenda.tipoPrenda = _reader.GetString(5);
                _lista.Add(prenda);
            }

            cnx.cerrarConexion();
            _comando.Connection.Close();
            return _lista;
        }


    }
}
