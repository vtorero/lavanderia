﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lavanderia.forms.busquedas;
using Lavanderia.Persistencia;

namespace Lavanderia.forms
{
    public partial class frmEntregas : Form
    {
        int pos;
        public frmEntregas()
        {
            InitializeComponent();
        }

        private void btnSrcCliente_Click(object sender, EventArgs e)

        {
           dgvOrdenes.DataSource = OrdenDao.buscarOrden("%"+txtCliente.Text+"%", txtDni.Text, dtFechaInicial.Value.ToString("yyyy-MM-dd") + " 00:00:00", dtFechaFin.Value.ToString("yyyy-MM-dd") + " 23:59:59");
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
           dgvOrdenes.Columns[7].HeaderText = "Tipo.";
           dgvOrdenes.Columns[7].Visible = false;
        }

        public void ejecutar(string id, string nombre, string dni, string telefono)
        {
            txtCliente.Text = nombre;
            txtDni.Text = dni;
            txtIdCliente.Text = id;
            
        }

        private void btnAddPrenda_Click(object sender, EventArgs e)
        {
            frmBuscarCliente childForm = new frmBuscarCliente();
            childForm.enviado += new frmBuscarCliente.enviar(ejecutar);
            childForm.ShowDialog();
        }

        private void dgvOrdenes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            pos = dgvOrdenes.CurrentRow.Index;
            
            txtMonto.Text = Convert.ToString(dgvOrdenes[5, pos].Value);
            if (Convert.ToInt32(dgvOrdenes[7, pos].Value) == 2)
            {
                txtDebe.Visible = true;
                txtDebe.Text = Convert.ToString(dgvOrdenes[6, pos].Value);
            }
            else {
                txtDebe.Visible = false;
                txtDebe.Text = Convert.ToString(0);
            }

           

        }
    }
}
