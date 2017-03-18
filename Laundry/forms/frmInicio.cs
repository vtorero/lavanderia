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
using Lavanderia.util;

namespace Lavanderia.forms
{
    public partial class frmInicio : Form
    {
        //private int childFormNumber = 0;

        public frmInicio()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new frmPrendas();
            childForm.MdiParent = this;
            childForm.Text = "Mantenimiento de Prendas :" + varGlobales.sessionUsuario;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            Form childForm = new frmServicio();
            childForm.MdiParent = this;
            childForm.Text = "Mantenimiento de Servicios";
            childForm.Show();
            
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Form childForm = new frmClientes();
            childForm.MdiParent = this;
            childForm.Text = "Mantenimiento de Clientes";
            childForm.Show();
        
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

      

    

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void fileMenu_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new frmColor();
            childForm.MdiParent = this;
            childForm.Text = "Mantenimiento de Colores";
            childForm.Show();
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void prendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportDocument cryrep = new ReportDocument();
            MySqlDataAdapter myadap = new MySqlDataAdapter(String.Format(
         "SELECT idPrenda, NombrePrenda, DescripcionPrenda, PrecioServicio FROM Prenda"), BdComun.ObtenerConexion());
            DataSet ds = new DataSet();
         
            myadap.Fill(ds, "Prendas");

            cryrep.Load(@"D:\lavanderia\Laundry\Reportes\crPrendas.rpt");

            cryrep.SetDataSource(ds);
            
            frmReporte rt = new frmReporte();
            rt.Text = "Reporte de prendas";
            rt.crystalReportViewer1.ReportSource = cryrep;
            rt.Show();﻿
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            frmOrden childForm = new frmOrden();
            childForm.MdiParent = this;
            childForm.Text = "Orden de Servicio";
            childForm.toolStripStatusLabel1.Text = this.searchToolStripMenuItem.Text;
            childForm.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form childForm = new frmEntregas();
            childForm.MdiParent = this;
            childForm.Text = "Entrega de Ordenes";
            childForm.Show();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportDocument cryrep = new ReportDocument();
            MySqlDataAdapter myadap = new MySqlDataAdapter(String.Format(
         "SELECT YEAR(o.`fechaCreado`) AS ano, MONTHNAME(o.`fechaCreado`) AS mes ,DAYOFMONTH(o.`fechaCreado`) AS dia ,SUM(o.`totalOrden`) AS total FROM Orden o GROUP BY 3 ORDER BY 2,3;"), BdComun.ObtenerConexion());
            DataSet ds = new DataSet();

            myadap.Fill(ds, "Ventas");

            cryrep.Load(@"D:\lavanderia\Laundry\Reportes\crVentas.rpt");

            cryrep.SetDataSource(ds);

            frmReporte rt = new frmReporte();
            rt.Text = "Reporte de Ventas";
            rt.crystalReportViewer1.ReportSource = cryrep;
            rt.Show();﻿
        }

     
        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void imprimirTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmImprimir childForm = new frmImprimir();
            childForm.MdiParent = this;
            childForm.Text = "Imprimir Ticket";
            childForm.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
                       Form childForm = new frmClientes();
            childForm.MdiParent = this;
            childForm.Text = "Mantenimiento de Clientes";
            childForm.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Form childForm = new frmFinalizados();
            childForm.MdiParent = this;
            childForm.Text = " Ordenes finalizadas";
            childForm.Show();
        }

    
   
    }
}
