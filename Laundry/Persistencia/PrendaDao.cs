using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lavanderia.Models;
using System.Data;

namespace Lavanderia.Persistencia
{
    class PrendaDao
    {
        public static int Agregar(Prenda prenda)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("Insert into Prenda (NombrePrenda, DescripcionPrenda, precioServicio) values ('{0}','{1}',{2})",
                prenda.NombrePrenda, prenda.Descripcion, prenda.precioServicio), BdComun.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }


        public static int Modificar(Prenda prenda)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("UPDATE Prenda Set nombrePrenda='{0}',descripcionPrenda='{1}',precioServicio='{2}' where idPrenda='{3}'"
            , prenda.NombrePrenda, prenda.Descripcion, prenda.precioServicio, prenda.idPrenda), BdComun.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;


        }

        public static int Eliminar(int idprenda)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("DELETE FROM Prenda where idPrenda='{0}'", idprenda), BdComun.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static MySqlDataReader fillPrenda() {

            MySqlCommand _comando = new MySqlCommand("prendasAll",BdComun.ObtenerConexion());
            _comando.CommandType = CommandType.StoredProcedure;
            MySqlDataReader _reader = _comando.ExecuteReader(CommandBehavior.CloseConnection);
            return _reader;

        }

        public static MySqlDataReader fillMarca()
        {

            MySqlCommand _comando = new MySqlCommand("marcasAll", BdComun.ObtenerConexion());
            _comando.CommandType = CommandType.StoredProcedure;
            MySqlDataReader _reader = _comando.ExecuteReader(CommandBehavior.CloseConnection);
            return _reader;

        }


        public static int agregarMarca(string nombre)
        {

            MySqlCommand cmd = new MySqlCommand("insertaMarca", BdComun.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("nombre", nombre));
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return 1;
        }

        public static MySqlDataReader fillPrendaSearch(string criterio)
        {
            int id = 0;
            MySqlCommand _comando = new MySqlCommand("prendasSearch", BdComun.ObtenerConexion());
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.Add(new MySqlParameter("criterio", criterio));

            MySqlDataReader _reader = _comando.ExecuteReader();


            return _reader;
       
        }

        public static List<Prenda> Listar()
        {
            List<Prenda> _lista = new List<Prenda>();

            MySqlCommand _comando = new MySqlCommand(String.Format(
           "SELECT idPrenda, nombrePrenda , descripcionPrenda, precioServicio FROM Prenda order by idPrenda"), BdComun.ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
            
            while (_reader.Read())
            {
                Prenda prenda = new Prenda();
                prenda.idPrenda= _reader.GetInt32(0);
                prenda.NombrePrenda = _reader.GetString(1);
                prenda.Descripcion = _reader.GetString(2);
                prenda.precioServicio = _reader.GetDecimal(3);
                
         _lista.Add(prenda);
            }

            return _lista;
        }

        public static List<Prenda> Buscar(string nombre)
        {
            List<Prenda> _lista = new List<Prenda>();

            MySqlCommand _comando = new MySqlCommand(String.Format(
           "SELECT *  FROM Prenda where nombrePrenda like '%{0}%' ", nombre), BdComun.ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                Prenda prenda = new Prenda();
                prenda.idPrenda= _reader.GetInt32(0);
                prenda.NombrePrenda = _reader.GetString(1);
                prenda.precioServicio= _reader.GetDecimal(3);
                _lista.Add(prenda);
            }

            return _lista;
        }


    }
}
