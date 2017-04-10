﻿using CrystalDecisions.CrystalReports.Engine;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lavanderia.util;

namespace Lavanderia.forms
{
    public partial class frmCierre : Form
    {
        public frmCierre()
        {
            InitializeComponent();
        }

        private void btnSrcCliente_Click(object sender, EventArgs e)
        {
ReportDocument cryrep = new ReportDocument();
            MySqlDataAdapter myadap = new MySqlDataAdapter(String.Format(
         "  (SELECT pg.idOrden,c.nombreCliente,o.fechaCreado,o.idUsuario, u.sucursal,pg.pago1 AS pago,IF(tipoPago1=0,'Efectivo','Visa') modoPago,IF(o.Estado=0,'Entrega','Recojo') Movimiento FROM (SELECT * FROM Pago WHERE fechaPago BETWEEN '" + dtFechaInicial.Value.ToString("yyyy-MM-dd") + " 00:00:00' AND '" + dtFechaFin.Value.ToString("yyyy-MM-dd") + " 23:00:00' "
         + " AND pago1>0) pg INNER JOIN Orden o ON o.idOrden=pg.idOrden AND o.tipoPago IN(1) AND o.`estado`=0 INNER JOIN usuario u ON o.idUsuario=u.id " +
          " INNER JOIN Cliente c ON o.idCliente=c.idCliente AND u.id="+varGlobales.sessionUsuario+" ORDER BY modoPago) UNION " +
"(SELECT pg.idOrden,c.nombreCliente,pg.fechaActualizado AS fechaCreado,o.idUsuario, u.sucursal,pg.pago2 AS pago,IF(tipoPago2=0,'Efectivo','Visa') modoPago,IF(o.Estado=0,'Entrega','Recojo') Movimiento FROM (SELECT * FROM Pago WHERE fechaActualizado BETWEEN '" + dtFechaInicial.Value.ToString("yyyy-MM-dd") + " 00:00:00' AND '" + dtFechaFin.Value.ToString("yyyy-MM-dd") + " 23:00:00' " +
" ) pg INNER JOIN Orden o ON o.idOrden=pg.idOrden AND o.tipoPago IN(1,2) AND o.`estado`=1 INNER JOIN usuario u ON o.idUsuario=u.id " +
" INNER JOIN Cliente c ON o.idCliente=c.idCliente AND u.id="+varGlobales.sessionUsuario+" ORDER BY modoPago) ORDER BY modopago,idOrden;"), BdComun.ObtenerConexion());
        DataSet ds = new DataSet();


          

            myadap.Fill(ds,"dsCierrePagos");


            cryrep.Load(@"D:\lavanderia\Laundry\Reportes\cierreDiario.rpt");

            cryrep.SetDataSource(ds);


            frmReporte rt = new frmReporte();
            rt.Text = "Reporte de Cierre";
            rt.crystalReportViewer1.ReportSource = cryrep;
            rt.Show();﻿

        }
    }
}