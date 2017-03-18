using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lavanderia.Persistencia;
using Lavanderia.Models;

namespace Lavanderia.forms
{
    public partial class frmFinalizados : Form
    {
        public frmFinalizados()
        {
            InitializeComponent();
        }

        private void btnSrcCliente_Click(object sender, EventArgs e)
        {
            llenarDatos();
        }

        private void llenarDatos()
        {
            dgvOrdenes.DataSource = OrdenDao.buscarOrden("%" + txtCliente.Text + "%", txtDni.Text, dtFechaInicial.Value.ToString("yyyy-MM-dd") + " 00:00:00", dtFechaFin.Value.ToString("yyyy-MM-dd") + " 23:59:59", 1);
            dgvOrdenes.Columns[0].HeaderText = "Código";
            dgvOrdenes.Columns[0].Width = 100;
            dgvOrdenes.Columns[1].Visible = false;
            dgvOrdenes.Columns[2].HeaderText = "Nombre cliente";
            dgvOrdenes.Columns[2].Width = 250;
            dgvOrdenes.Columns[3].HeaderText = "DNI";
            dgvOrdenes.Columns[3].Width = 100;
            dgvOrdenes.Columns[4].HeaderText = "Fecha Orden";
            dgvOrdenes.Columns[4].Width = 200;
            dgvOrdenes.Columns[5].HeaderText = "Monto Orden";
            dgvOrdenes.Columns[5].DefaultCellStyle.Format = "C2";
            dgvOrdenes.Columns[5].Width = 50;
            dgvOrdenes.Columns[6].HeaderText = "Monto Pend.";
            dgvOrdenes.Columns[6].DefaultCellStyle.Format = "C2";
            dgvOrdenes.Columns[6].Width = 50;
            dgvOrdenes.Columns[7].HeaderText = "Tipo";
            dgvOrdenes.Columns[7].Visible = false;
        }
    }
}