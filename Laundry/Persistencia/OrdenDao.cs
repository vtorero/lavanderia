﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lavanderia.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace Lavanderia.Persistencia
{
    class OrdenDao
    {

        public static int Agregar(Orden orden)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO `Orden` (`idCliente`, `fechaEntrega`, `totalOrden`,`idUsuario`, `Observacion`, `estado`, `tipoPago`) VALUES ({0},'{1}',{2},{3},'{4}', {5}, {6});",
                orden.idCliente,orden.fechaEntrega,orden.totalOrden,orden.idUsuario,orden.observacion,orden.estado,orden.tipoPago), BdComun.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return ultimo_id();
            
        }


        public static int AgregarLinea(OrdenLinea ordenlinea)
        {
           
            MySqlCommand cmd = new MySqlCommand("addLineaOrden", BdComun.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("PidOrden", ordenlinea.idOrden));
            cmd.Parameters.Add(new MySqlParameter("PidPrenda", ordenlinea.idPrenda));
            cmd.Parameters.Add(new MySqlParameter("Pitem", ordenlinea.Item));
            cmd.Parameters.Add(new MySqlParameter("Pdescripcion", ordenlinea.Descripcion));
            cmd.Parameters.Add(new MySqlParameter("Pcantidad", ordenlinea.Cantidad));
            cmd.Parameters.Add(new MySqlParameter("Pprecio", ordenlinea.Precio));
            cmd.Parameters.Add(new MySqlParameter("Pdefecto", ordenlinea.Defecto));
            cmd.Parameters.Add(new MySqlParameter("Pcolor", ordenlinea.Colores));
            cmd.Parameters.Add(new MySqlParameter("Ptotal", ordenlinea.Total));
            cmd.Parameters.Add(new MySqlParameter("Pestado", ordenlinea.Estado));
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return ultimo_id();
        }




        public static int ultimo_id()
        {

            int id=0;
            MySqlCommand cmd= new MySqlCommand("ultimoIdOrden", BdComun.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
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
