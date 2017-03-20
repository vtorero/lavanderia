using CrystalDecisions.CrystalReports.Engine;
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

namespace Lavanderia.forms
{
    public partial class frmImprimir : Form
    {
        public frmImprimir()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReportDocument cryrep = new ReportDocument();
            MySqlDataAdapter myadap = new MySqlDataAdapter(String.Format(
         "SELECT o.idOrden,c.dniCliente,c.nombreCliente,o.fechaCreado,o.fechaEntrega, o.totalOrden,l.cantidad,l.precio,l.descripcion,l.total,l.colorPrenda,l.marca,l.defecto,p.pago1,p.pago2 FROM Orden o inner join Cliente c on o.idCliente=c.idCliente inner join Pago p on o.idOrden=p.idOrden inner join OrdenLinea l on o.idOrden=l.idOrden where o.idOrden={0}", txtTicket.Text), BdComun.ObtenerConexion());
            DataSet ds = new DataSet();

            myadap.Fill(ds, "Ticket");

            cryrep.Load(@"D:\lavanderia\Laundry\Reportes\crTicket.rpt");

            cryrep.SetDataSource(ds);

            frmReporte rt = new frmReporte();
            rt.Text = "Ticket";
            rt.crystalReportViewer1.ReportSource = cryrep;
            rt.Show();﻿
        }
    }
}
