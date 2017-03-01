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
using Lavanderia.Models;
using Lavanderia.util;

namespace Lavanderia.forms
{
    public partial class frmOrden : Form
    {
        int i = 1;
        Validacion v = new Validacion();
         //decimal igv = 18;
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

        public void ejecutar3(string colores)
        {
            
            txtcolores.Text = colores;
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(nroCantidad.Value>0){
               
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
            //txtIgv.Text = "S/." + Convert.ToString(Decimal.Round((totalOrden *igv) / 100,2));
            restablecer(); 
            }else{
            MessageBox.Show("Debe indicar el nro de prendas","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            
            }

        }

        public void restablecer() {
            txtNombrePrenda.Text = "";
            txtPrecio.Text = "";
            nroCantidad.Value = 0;
            cmbDefecto.Text = "Defecto";
            btnAdd.Enabled = false;
            nroCantidad.Enabled = false;
            cmbDefecto.Enabled = false;
            btnColor.Enabled = false;
                

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (rdPrenda.Checked)
            {
                frmBuscarPrendas childForm = new frmBuscarPrendas();
                childForm.enviado += new frmBuscarPrendas.enviar(ejecutar2);
                childForm.ShowDialog();
            }
            else if (rdServicio.Checked)
            {
                frmBuscarServicio childForm = new frmBuscarServicio();
                childForm.enviado += new frmBuscarServicio.enviar(ejecutar2);
                childForm.ShowDialog();
                
            }

            
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmBuscarColor childForm = new frmBuscarColor();
            childForm.enviad += new frmBuscarColor.enviar(ejecutar3);
            childForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Orden ord = new Orden();

            string s = dtFechaEntrega.Value.ToString("yyyy-MM-dd hh:mm:ss").Replace("/", "-").Substring(0,10);
            string h = dtHoraEntrega.Value.ToString("hh:mm:ss").Replace("a.m.", "").Replace("p.m.", "").Replace("/", "-");
            ord.idCliente = Convert.ToInt32(lblCodigoCliente.Text);
            ord.fechaEntrega =s+ " "+h ;
            ord.totalOrden = Convert.ToDecimal(txtPago.Text);
            ord.idUsuario = 1;
            ord.observacion = "Texto de prueba";
            ord.estado = 1;
            ord.tipoPago = 1;
            OrdenDao.Agregar(ord);

        }

        private void rdParcial_CheckedChanged(object sender, EventArgs e)
        {
            lblPendiente.Visible = true;
            txtPendiente.Visible = true;
            txtPago.Text = "";
        }

        private void rdTotal_Click(object sender, EventArgs e)
        {
            lblPendiente.Visible = false;
            txtPendiente.Visible = false;
            txtPago.Text = Convert.ToString(totalOrden);
        }

        private void txtPago_TextChanged(object sender, EventArgs e)
        {
              if (!string.IsNullOrWhiteSpace(txtPago.Text)) {
            txtPendiente.Text = Convert.ToString(totalOrden - Convert.ToDecimal(txtPago.Text));
              }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }

      

        private void txtNombreCliente_TextChanged(object sender, EventArgs e)
        {
            habilitaServicio();

        }

        public void habilitaServicio() {
            rdPrenda.Enabled = true;
            rdServicio.Enabled = true;
            btnAddPrenda.Enabled = true;
            nroCantidad.Enabled = true;
            cmbDefecto.Enabled = true;
            btnColor.Enabled = true;
        
        }

        private void txtNombrePrenda_TextChanged(object sender, EventArgs e)
        {
            habilitaServicio();
            btnAdd.Enabled = true;
        }

        private void dgvOrden_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnQuitar.Enabled = true;
        }
      
    }
}
