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

namespace Lavanderia.forms
{
    public partial class frmOrden : Form
    {
        int i = 1;
        public frmOrden()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSrcCliente_Click(object sender, EventArgs e)
        {
            frmBuscarCliente childForm = new frmBuscarCliente();
           childForm.enviado+=new frmBuscarCliente.enviar(ejecutar);
              childForm.ShowDialog();
             
        }

        public void ejecutar(string id,string nombre,string dni,string telefono)
        {
            txtNombreCliente.Text = nombre;
            txtDni.Text = dni;
            lblCodigoCliente.Text = id;
            txtTelefono.Text=telefono;
            
        }

        public void ejecutar2(string id, string nombre, string precio)
        {
            txtNombrePrenda.Text = nombre;
            txtPrecio.Text =precio;
            

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string id, detalle;
            id = "1";
            detalle = "pantalon";
            float cantidad, precio, total;
            cantidad = 1;
            precio = 2;
            total = cantidad * precio;

            dgvOrden.Rows.Add(id,detalle,cantidad,precio,total);
            dgvOrden.RowHeadersVisible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmBuscarPrendas childForm = new frmBuscarPrendas();
            childForm.enviado += new frmBuscarPrendas.enviar(ejecutar2);
            childForm.ShowDialog();
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }
    }
}
