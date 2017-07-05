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
    class OfertaDao
    {
        public static Oferta Buscar(int dia)
        {
            
            Oferta oferta = new Oferta();
            MySqlCommand cmd = new MySqlCommand("ofertasDelDia", BdComun.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("dia",dia));
            MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {
                
                oferta.idOferta= Convert.ToInt32(dr["id"]);
                oferta.Nombre= Convert.ToString(dr["nombre"]);
                oferta.Porcentaje = Convert.ToDecimal(dr["porcentaje"]);
               
            }
            cmd.Connection.Close();
            
            return oferta;
        }


    }
}