using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lavanderia.Models;
using MySql.Data.MySqlClient;

namespace Lavanderia.Persistencia
{
    class PagoDao
    {
        public static int Agregar(Pago pago)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("Insert into Pago (idOrden, pago1,pago2,pagoTotal,tipoPago,tipoPago1,tipoDocumento,igv,Estado,fechaPago,fechaActualizado) values ({0},{1},{2},{3},{4},{5},{6},{7},{8},'{9}','{10}')",
                pago.idOrden,pago.Pago1,pago.Pago2,pago.PagoTotal,pago.TipoPago,pago.TipoPago1,pago.TipoDocumento,pago.Igv,pago.Estado,pago.fechaPago,pago.fechaActualizado), BdComun.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }
    }
}
