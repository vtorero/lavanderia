﻿using System;
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
            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO `Orden` (`idCliente`, `fechaEntrega`, `totalOrden`,`idUsuario`, `Observacion`, `estado`, `tipoPago`) VALUES ({0},'{1}',{2},{3},'{4}', {5}, {6});",
                orden.idCliente,orden.fechaEntrega,orden.totalOrden,orden.idUsuario,orden.observacion,orden.estado,orden.tipoPago), BdComun.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return ultimo_id();
            
        }


        public static int AgregarLinea(OrdenLinea ordenlinea)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO `OrdenLinea` (`idOrden`, `item`, `idPrenda`,`Descripcion`, `cantidad`, `precio`,`defecto`, `colorPrenda`, `total`,`estado`) VALUES ({0},{1},{2},'{3}',{4},{5},'{6}','{7}',{8},{9});",
              ordenlinea.idOrden, ordenlinea.Item, ordenlinea.idPrenda, ordenlinea.Descripcion,ordenlinea.Cantidad, ordenlinea.Precio, ordenlinea.Defecto,ordenlinea.Colores,ordenlinea.Total,ordenlinea.Estado), BdComun.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return ultimo_id();
        }




        public static int ultimo_id()
        {

            int id=0;
            MySqlCommand _comando = new MySqlCommand(String.Format(
           "SELECT max(idOrden)  FROM Orden"), BdComun.ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {

                id = _reader.GetInt32(0);
                
            }

            return id;
        }

    }
}
