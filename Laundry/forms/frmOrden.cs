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
         decimal igv = 18;
          decimal totalOrden = 0;
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

        public void ejecutar2(string id, string nombre, decimal precio)
        {
            LblId.Text = id;
            txtNombrePrenda.Text = nombre;
            txtPrecio.Text = Convert.ToString(Decimal.Round(precio,2));
            

        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            string id, detalle;
            id = LblId.Text;
            detalle = txtNombrePrenda.Text;
            decimal cantidad, precio, total;
           
            cantidad = nroCantidad.Value;
            precio = Convert.ToDecimal(txtPrecio.Text);
            total = cantidad * precio;

            dgvOrden.Rows.Add(i,id,detalle,cantidad,precio,total);
            i = i + 1;
            totalOrden += Decimal.Round(total,2);
            txtTotal.Text = "S/." + Convert.ToString(Decimal.Round(totalOrden,2));
            txtIgv.Text = "S/." + Convert.ToString(Decimal.Round((totalOrden *igv) / 100,2));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                frmBuscarPrendas childForm = new frmBuscarPrendas();
                childForm.enviado += new frmBuscarPrendas.enviar(ejecutar2);
                childForm.ShowDialog();
            }
            else if (radioButton2.Checked)
            {
                frmBuscarServicio childForm = new frmBuscarServicio();
                childForm.enviado += new frmBuscarServicio.enviar(ejecutar2);
                childForm.ShowDialog();
                
            }

            
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }
    }
}
