using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lavanderia.Models;
using System.Data;
using Lavanderia.util;
namespace Lavanderia.Persistencia
{
    class ClienteDao
    {
        public static int Agregar(Cliente cliente)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("Insert into Cliente (nombreCliente, dniCliente, correoCliente,direccionCliente,telefonoCliente,usuarioCreador) values ('{0}','{1}','{2}','{3}','{4}',{5})",
                cliente.Nombres, cliente.DNI, cliente.Email,cliente.Dirección,cliente.Teléfono,cliente.usuarioCreador), BdComun.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static int Modificar(Cliente cliente) {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("UPDATE Cliente Set nombreCliente='{0}',dniCliente='{1}',correoCliente='{2}',direccionCliente='{3}',telefonoCliente='{4}' where idCliente={5}"
            , cliente.Nombres, cliente.DNI, cliente.Email, cliente.Dirección, cliente.Teléfono, cliente.idCliente), BdComun.ObtenerConexion());
            retorno= comando.ExecuteNonQuery();
            return retorno;

        
        }

        public static int Eliminar(int idcliente) {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("DELETE FROM Cliente where idCliente='{0}'", idcliente),BdComun.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static List<Cliente> Listar()
        {
            List<Cliente> _lista = new List<Cliente>();

            MySqlCommand cmd= new MySqlCommand("clientesAll", BdComun.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("idUsuario", varGlobales.sessionUsuario));
            MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
           

            while (dr.Read())
            {
            Cliente cliente= new Cliente();
                cliente.idCliente = Convert.ToInt32(dr["idCliente"]);
                cliente.Nombres= Convert.ToString(dr["nombreCliente"]);
                cliente.DNI = Convert.ToString(dr["dniCliente"]);
                cliente.Email = Convert.ToString(dr["correoCliente"]);
                cliente.Dirección= Convert.ToString(dr["direccionCliente"]);
                cliente.Teléfono = Convert.ToString(dr["telefonoCliente"]);
                _lista.Add(cliente);
            }
            cmd.Connection.Close();
            return _lista;
        }

        public static List<Cliente> Buscar(string nombre,string dni,int usuarioCreador)
        {
            List<Cliente> _lista = new List<Cliente>();

            MySqlCommand _comando = new MySqlCommand(String.Format(
           "SELECT idCliente,nombreCliente,dniCliente,correoCliente,telefonoCliente FROM Cliente where nombreCliente like '%{0}%' and dniCliente like '%{1}%' and usuarioCreador={2}",nombre,dni,usuarioCreador), BdComun.ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
while (_reader.Read())
            {
                Cliente cliente = new Cliente();
                cliente.idCliente = _reader.GetInt32(0);
                cliente.Nombres = _reader.GetString(1);
                cliente.DNI = _reader.GetString(2);
                cliente.Email = _reader.GetString(3);
                cliente.Teléfono = _reader.GetString(4);
                _lista.Add(cliente);
            }

            return _lista;
        }

    }
}
