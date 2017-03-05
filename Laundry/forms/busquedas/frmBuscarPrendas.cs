﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lavanderia.Persistencia;

namespace Lavanderia.forms.busquedas
{
    public partial class frmBuscarPrendas : Form
    {
        public delegate void enviar(string id, string nombre, decimal precio);
        public event enviar enviado;
        public frmBuscarPrendas()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvPrendas.DataSource = PrendaDao.Buscar(txtNombres.Text);
            dgvPrendas.RowHeadersVisible = false;
            dgvPrendas.Columns[0].HeaderText = "Código";
            dgvPrendas.Columns[0].Width = 50;
            dgvPrendas.Columns[1].HeaderText = "Nombres";
            dgvPrendas.Columns[1].Width = 190;
            dgvPrendas.Columns[2].Visible = false;
            dgvPrendas.Columns[3].HeaderText = "Precio";
            dgvPrendas.Columns[3].DefaultCellStyle.Format = "C2";
            dgvPrendas.Columns[3].Width = 100;
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            enviaDatos();
        }

        private void enviaDatos() {

            int pos;
            pos = dgvPrendas.CurrentRow.Index;
            enviado(Convert.ToString(dgvPrendas[0, pos].Value), Convert.ToString(dgvPrendas[1, pos].Value), Convert.ToDecimal(dgvPrendas[3, pos].Value));
            this.Close();
        }

        private void dgvPrendas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            enviaDatos();
        }
    }
}