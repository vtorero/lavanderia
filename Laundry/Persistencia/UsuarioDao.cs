using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lavanderia.Models;

namespace Lavanderia.Persistencia
{
    class UsuarioDao
    {
        public  static Usuario Consultar(string user,string pass)
        {
            ConexBD conec = new ConexBD();
            List<Usuario> _lista = new List<Usuario>();
            conec.Conectar();
            MySqlCommand _comando = new MySqlCommand(String.Format(
           "SELECT * FROM usuario where nombre='{0}' and password='{1}'",user,pass), conec.ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
            Usuario usuario = new Usuario();
            while (_reader.Read())
            {
                 usuario.idUsuario = _reader.GetInt32(0);
                usuario.nombreUsuario = _reader.GetString(1);
                usuario.apellidoUsuario = _reader.GetString(2);
                usuario.emailUsuario = _reader.GetString(3);
                usuario.sucursalUsuario = _reader.GetString(4);
                usuario.tipoUsuario = _reader.GetInt32(6);
                             
            }
            conec.cerrarConexion();
            return usuario;
        }

    }
}
