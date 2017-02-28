using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lavanderia.Models;
using MySql.Data.MySqlClient;

namespace Lavanderia.Persistencia
{
    class OrdenDao
    {

        public static int Agregar(Orden orden)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO `cualesmi_lavanderia`.`Orden` (`idCliente`, `fechaEntrega`, `totalOrden`,`idUsuario`, `Observacion`, `estado`, `tipoPago`) VALUES ({0},'{1}',{2},{3},'{4}', {5}, {6});",
                orden.idCliente,orden.fechaEntrega,orden.totalOrden,orden.idUsuario,orden.observacion,orden.estado,orden.tipoPago), BdComun.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

    }
}
