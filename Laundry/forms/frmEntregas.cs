using System;
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
        public frmEntregas()
        {
            InitializeComponent();
        }

        private void btnSrcCliente_Click(object sender, EventArgs e)
        {
            dgvOrdenes.DataSource = OrdenDao.buscarOrden(txtCliente.Text, txtDni.Text, dtFechaInicial.Value.ToString("yyyy-MM-dd") + " 00:00:00", dtFechaFin.Value.ToString("yyyy-MM-dd")+" 23:59:59");
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
    }
}
