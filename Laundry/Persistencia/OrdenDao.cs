using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lavanderia.Models;
using MySql.Data.MySqlClient;
using System.Data;
using Lavanderia.util;

namespace Lavanderia.Persistencia
{
    class OrdenDao
    {

        public static int Agregar(Orden orden)
        {
 
      
            MySqlCommand cmd = new MySqlCommand("addOrden", BdComun.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("PidCliente", orden.idCliente));
            cmd.Parameters.Add(new MySqlParameter("PfechaEntrega", orden.fechaEntrega));
            cmd.Parameters.Add(new MySqlParameter("PtotalOrden", orden.totalOrden));
            cmd.Parameters.Add(new MySqlParameter("PidUsuario", orden.idUsuario));
            cmd.Parameters.Add(new MySqlParameter("Pobservacion", orden.observacion));
            cmd.Parameters.Add(new MySqlParameter("Pestado", orden.estado));
            cmd.Parameters.Add(new MySqlParameter("PtipoPago", orden.tipoPago));
            cmd.Parameters.Add(new MySqlParameter("Pdscto", orden.Descuento));
            cmd.Parameters.Add(new MySqlParameter("ultimoId", MySqlDbType.Int64));
            cmd.Parameters["ultimoId"].Direction = ParameterDirection.Output;
           
            try
        {

        cmd.ExecuteNonQuery(); // insert second row for update
            return  Convert.ToInt32(cmd.Parameters["ultimoId"].Value);
                }
                catch (MySqlException ex)
                {
                    return 0;
                }
                finally
                {
                     cmd.Connection.Close();
                }
            
          
          
        }


        public static int AgregarLinea(OrdenLinea ordenlinea)
        {
           
            MySqlCommand cmd = new MySqlCommand("addLineaOrden", BdComun.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("PidOrden", ordenlinea.idOrden));
            cmd.Parameters.Add(new MySqlParameter("Pitem", ordenlinea.Item));
            cmd.Parameters.Add(new MySqlParameter("PidPrenda", ordenlinea.idPrenda));
            cmd.Parameters.Add(new MySqlParameter("Pdescripcion", ordenlinea.Descripcion));
            cmd.Parameters.Add(new MySqlParameter("Pcantidad", ordenlinea.Cantidad));
            cmd.Parameters.Add(new MySqlParameter("Pprecio", ordenlinea.Precio));
            cmd.Parameters.Add(new MySqlParameter("Pdefecto", ordenlinea.Defecto));
            cmd.Parameters.Add(new MySqlParameter("Pcolor", ordenlinea.Colores));
            cmd.Parameters.Add(new MySqlParameter("Pmarca", ordenlinea.Marca));
            cmd.Parameters.Add(new MySqlParameter("Ptotal", ordenlinea.Total));
            cmd.Parameters.Add(new MySqlParameter("Ptipo", ordenlinea.TipoServicio));
            cmd.Parameters.Add(new MySqlParameter("Pestado", ordenlinea.Estado));
            
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return ultimo_id();
        }

        public static int entregaOrden(int id,int pago2,string obs) {
            int retorno=1;
            MySqlCommand cmd = new MySqlCommand("entregaOrden", BdComun.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("id", id));
            cmd.Parameters.Add(new MySqlParameter("tipopago2", pago2));
            cmd.Parameters.Add(new MySqlParameter("obs", obs));
            cmd.ExecuteReader();
            return retorno;
        }

        public static List<OrdenClientes> buscarOrden(string nombre,string dni, string fechainicio,string fechafin,int estado)
        {
            List<OrdenClientes> _lista = new List<OrdenClientes>();
            MySqlCommand cmd = new MySqlCommand("buscarOrdenes", BdComun.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("usuario", varGlobales.sessionUsuario));
            cmd.Parameters.Add(new MySqlParameter("nombreCliente", nombre));
            cmd.Parameters.Add(new MySqlParameter("dniCliente", dni));
            cmd.Parameters.Add(new MySqlParameter("fechaInicio", fechainicio));
            cmd.Parameters.Add(new MySqlParameter("fechaFin", fechafin));
            cmd.Parameters.Add(new MySqlParameter("estado", estado));
           
            MySqlDataReader dr = cmd.ExecuteReader();
           
            while (dr.Read())
            {
            OrdenClientes ordencliente= new OrdenClientes();
                ordencliente.idOrden= Convert.ToInt32(dr["idOrden"]);
                ordencliente.idCliente= Convert.ToInt32(dr["idCliente"]);
                ordencliente.nombreCliente= Convert.ToString(dr["nombreCliente"]);
                ordencliente.dniCliente = Convert.ToString(dr["dniCliente"]);
                ordencliente.fechaCreado = Convert.ToString(dr["fechaCreado"]);
                ordencliente.Monto= Convert.ToDecimal(dr["totalOrden"]);
                ordencliente.MontoPendiente= Convert.ToDecimal(dr["pago2"]);
                ordencliente.TipoPago = Convert.ToInt32(dr["tipoPago"]);
               _lista.Add(ordencliente);
            }
            cmd.Connection.Close();
           
            return _lista;
        }




        public static int ultimo_id()
        {

            int id=0;
            MySqlCommand cmd= new MySqlCommand("ultimoIdOrden", BdComun.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("usuario",varGlobales.sessionUsuario));
            MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
              while (dr.Read())
            {
                id = Convert.ToInt32(dr["ultimoid"]);
            }
              cmd.Connection.Close();
            return id;
        }

    }
}
