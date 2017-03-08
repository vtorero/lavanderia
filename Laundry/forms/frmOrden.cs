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
               
            string id, detalle,defecto,colores;
            id = LblId.Text;
            detalle = txtNombrePrenda.Text;
            decimal cantidad, precio, total;
           
            cantidad = nroCantidad.Value;
            precio = Convert.ToDecimal(txtPrecio.Text);
            defecto = (cmbDefecto.Text.Equals("Seleccionar")) ? "Sin Defectos" : cmbDefecto.Text;
            colores = txtcolores.Text;
            total = cantidad * precio;


            dgvOrden.Rows.Add(i,id,detalle,cantidad,precio,total,defecto,colores);
            i = i + 1;
            totalOrden += Decimal.Round(total,2);
            txtTotal.Text = Convert.ToString(Decimal.Round(totalOrden,2));
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
            cmbDefecto.Text = "Seleccionar";
            txtcolores.Text = "";
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
            Pago pago = new Pago();
            int tipo_pago = 0;
            if (rdTotal.Checked) {
                tipo_pago = 1;
            }
            if (rdParcial.Checked) {
                tipo_pago = 2;
            }
           
            int status = 0;
            string s = dtFechaEntrega.Value.ToString("yyyy-MM-dd hh:mm:ss").Replace("/", "-").Substring(0,10);
            string h = dtHoraEntrega.Value.ToString("hh:mm:ss").Replace("a.m.", "").Replace("p.m.", "").Replace("/", "-");
            ord.idCliente = Convert.ToInt32(lblCodigoCliente.Text);
            ord.fechaEntrega =s+ " "+h ;
            ord.totalOrden = Convert.ToDecimal(txtPago.Text);
            ord.idUsuario = 1;
            ord.observacion = txtObservacion.Text;
            ord.estado = 0;
            ord.tipoPago = tipo_pago;
            status=OrdenDao.Agregar(ord);

            if (status > 0)
            {
                if (tipo_pago == 1) {

                    DateTime Hoy = DateTime.Now;
                    string fecha_actual = Hoy.ToString("yyyy-MM-dd hh:mm:ss");

                    pago.idOrden = status;
                    pago.Pago1 = Convert.ToDecimal(txtPago.Text);
                    pago.Pago2 = 0;
                    pago.PagoTotal = Convert.ToDecimal(txtPago.Text);
                    pago.TipoPago = tipo_pago;
                    pago.Estado = 0;
                    pago.fechaPago = fecha_actual;
                    pago.fechaActualizado = fecha_actual;
                    PagoDao.Agregar(pago);
            
                }

                if (tipo_pago == 2)
                {

                    DateTime Hoy = DateTime.Now;
                    string fecha_actual = Hoy.ToString("yyyy-MM-dd hh:mm:ss");

                    pago.idOrden = status;
                    pago.Pago1 = Convert.ToDecimal(txtPago.Text);
                    pago.Pago2 = Convert.ToDecimal(txtPendiente.Text); ;
                    pago.PagoTotal = Convert.ToDecimal(txtPago.Text);
                    pago.TipoPago = tipo_pago;
                    pago.Estado = 0;
                    pago.fechaPago = fecha_actual;
                    pago.fechaActualizado = fecha_actual;
                    PagoDao.Agregar(pago);

                }

                try
                {
                    foreach (DataGridViewRow data in dgvOrden.Rows)
                    {

                        OrdenLinea ordline = new OrdenLinea();
                        ordline.idOrden = status;
                        ordline.Item = Convert.ToInt32(data.Cells["clNumero"].Value);
                        ordline.idPrenda = Convert.ToInt32(data.Cells["clPrenda"].Value);
                        ordline.Descripcion = data.Cells["clDescripcion"].Value.ToString();
                        ordline.Cantidad = Convert.ToInt32(data.Cells["clCantidad"].Value);
                        ordline.Precio = Convert.ToDecimal(data.Cells["clPrecio"].Value);
                        ordline.Defecto = Convert.ToString(data.Cells["clDefecto"].Value);
                        ordline.Colores = Convert.ToString(data.Cells["clColores"].Value);
                        ordline.Total = Convert.ToDecimal(data.Cells["clTotal"].Value);
                        ordline.Estado = 0;

                        OrdenDao.AgregarLinea(ordline);
                         

                    }



                }
                catch (Exception )
                {
                   

                }

                MessageBox.Show(string.Format("Se grabó correctamente la orden con el número: {0} ", status), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                desHabilitaServicio();
               
            }
           

        }

        private void rdParcial_CheckedChanged(object sender, EventArgs e)
        {
            lblPendiente.Visible = true;
            lblSimbolopendiente.Visible = true;
            txtPendiente.Visible = true;
            txtPago.Enabled = true;
            txtObservacion.Enabled = true;
            txtPago.Text = "0.00";
            dtFechaEntrega.Enabled = true;
            dtHoraEntrega.Enabled = true;
            btnGuardar.Enabled = true;
        }

        private void rdTotal_Click(object sender, EventArgs e)
        {

            lblPendiente.Visible = false;
            txtPendiente.Visible = false;
            lblSimbolopendiente.Visible = false;
            txtPago.Text = Convert.ToString(totalOrden);
            txtObservacion.Enabled = true;
            dtFechaEntrega.Enabled = true;
            dtHoraEntrega.Enabled = true;
        }

        private void txtPago_TextChanged(object sender, EventArgs e)
        {
              if (!string.IsNullOrWhiteSpace(txtPago.Text)) {
     
            txtPendiente.Text = Convert.ToString(totalOrden - Convert.ToDecimal(txtPago.Text));
                 
              }
        }

      

        private void txtPago_KeyPress(object sender, KeyPressEventArgs e)
        {
          
v.soloNumeros(e);
        }

      

        private void txtNombreCliente_TextChanged(object sender, EventArgs e)
        {
            rdPrenda.Enabled = true;
            rdServicio.Enabled = true;
        }

        public void habilitaServicio() {
          
            btnAddPrenda.Enabled = true;
            nroCantidad.Enabled = true;
            cmbDefecto.Enabled = true;
            btnColor.Enabled = true;
            dgvOrden.Enabled = true;
            
        
        }

        public void desHabilitaServicio()
        {
            rdPrenda.Enabled = false;
            rdServicio.Enabled = false;
            btnAddPrenda.Enabled = false;
            nroCantidad.Enabled = false;
            cmbDefecto.Enabled = false;
            btnColor.Enabled = false;
            txtPendiente.Enabled = false;
            txtPago.Text = "";
            txtPago.Enabled = false;
            txtObservacion.Text = "";
            txtObservacion.Enabled = false;
            txtTotal.Text = "";
            dgvOrden.Rows.Clear();
            dgvOrden.Enabled = false;
            txtNombreCliente.Text = "";
            txtDni.Text = "";
            txtTelefono.Text = "";
            rdParcial.Checked = false;
            rdParcial.Enabled = false;
            rdTotal.Checked = false;
            rdTotal.Enabled = false;
            rdPrenda.Enabled = false;
            rdServicio.Enabled = false;
            dtFechaEntrega.Enabled = false;
            dtHoraEntrega.Enabled = false;
            txtPago.Enabled = false;
            lblPendiente.Visible = false;
            txtPendiente.Text = "0.00";
            txtPendiente.Visible = false;
            lblSimbolopendiente.Visible = false;
            txtObservacion.Enabled = false;
            btnQuitar.Enabled = false;
            btnGuardar.Enabled = false;
            

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

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            decimal totalDescontar=0;
            Int32 selectedRowCount = dgvOrden.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount > 0)
            {

                for (int i = 0; i < selectedRowCount; i++)
                {
                    totalDescontar += Convert.ToDecimal(dgvOrden.Rows[dgvOrden.SelectedRows[i].Index].Cells["clTotal"].Value.ToString());
                    dgvOrden.Rows.RemoveAt(dgvOrden.SelectedRows[i].Index); 
                }

            }
            totalOrden=(totalOrden - totalDescontar);         
            txtTotal.Text =  Convert.ToString(totalOrden);
            btnQuitar.Enabled = false;
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            rdParcial.Enabled = true;
            rdTotal.Enabled = true;
            chkFactura.Enabled = true;
          
        }

        private void txtPago_Leave(object sender, EventArgs e)
        {
            if ((totalOrden - Convert.ToDecimal(txtPago.Text)) > 0)
            {
                txtPendiente.Text = Convert.ToString(totalOrden - Convert.ToDecimal(txtPago.Text));
               
            }
            else
            {
                MessageBox.Show("El monto sobrepasa el total de la orden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPendiente.Text = "0.0"; 
                txtPago.Focus();
            }
        }

        private void rdPrenda_CheckedChanged(object sender, EventArgs e)
        {
            btnAddPrenda.Enabled = true;
        }

        private void rdServicio_CheckedChanged(object sender, EventArgs e)
        {
            btnAddPrenda.Enabled = true;
        }

        private void rdTotal_CheckedChanged(object sender, EventArgs e)
        {
            btnGuardar.Enabled = true;
        }

        private void chkFactura_CheckStateChanged(object sender, EventArgs e)
        {
            decimal tigv= Decimal.Round(totalOrden *(18/100),2);
             if (chkFactura.Checked)
            {
                txtIg.Visible = true;
                txtIg.Text = Convert.ToString(tigv);

                txtPago.Text = Convert.ToString(totalOrden + tigv);

            }
            else {
                txtIg.Visible = false;
                txtPago.Text = Convert.ToString(totalOrden - tigv);
                lbligv.Visible = false;
                TXTIGV.Visible = false;
                grpTotal.Left = 318;
                grpTotal.Width = 220;
                label9.Left = 15;
                txtTotal.Left = 106;
                txtTotal.Text = Convert.ToString(Decimal.Round(totalOrden, 2));

            
            }
        }
      
    }
}
