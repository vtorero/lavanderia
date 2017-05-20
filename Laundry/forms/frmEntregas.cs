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
        int pos;
        public frmEntregas()
        {
            InitializeComponent();
        }

        private void btnSrcCliente_Click(object sender, EventArgs e)
        {
            if(txtNumero.Text.Equals("")) {
            llenarDatos();
            }else{
            
                llenarDatosId(Convert.ToInt32(txtNumero.Text));
            }
        }

        public void ejecutar(string id, string nombre, string dni, string telefono)
        {
            txtCliente.Text = nombre;
            txtDni.Text = dni;
            txtIdCliente.Text = id;

        }

        private void llenarDatosId(int id) { 
           
           dgvOrdenes.DataSource = OrdenDao.buscarOrdenId(id);
           dgvOrdenes.Columns[0].HeaderText = "Código";
           dgvOrdenes.Columns[0].Width = 50;
           dgvOrdenes.Columns[1].Visible = false;
           dgvOrdenes.Columns[2].HeaderText = "Nombre cliente";
           dgvOrdenes.Columns[2].Width = 110;
           dgvOrdenes.Columns[3].Visible = false;
           dgvOrdenes.Columns[4].HeaderText = "Sucursal";
           dgvOrdenes.Columns[4].Width =70;
           dgvOrdenes.Columns[5].HeaderText = "Fecha Orden";
           dgvOrdenes.Columns[5].Width = 150;
           dgvOrdenes.Columns[6].HeaderText = "Pago 1";
           dgvOrdenes.Columns[6].DefaultCellStyle.Format = "C2";
           dgvOrdenes.Columns[6].Width = 70;
           dgvOrdenes.Columns[7].HeaderText = "Pago 2";
           dgvOrdenes.Columns[7].DefaultCellStyle.Format = "C2";
           dgvOrdenes.Columns[7].Width = 70;
           dgvOrdenes.Columns[8].HeaderText = "Monto Orden";
           dgvOrdenes.Columns[8].DefaultCellStyle.Format = "C2";
           dgvOrdenes.Columns[8].Width = 70;
           dgvOrdenes.Columns[9].HeaderText = "Monto Pend.";
           dgvOrdenes.Columns[9].DefaultCellStyle.Format = "C2";
           dgvOrdenes.Columns[9].Width = 70;
           dgvOrdenes.Columns[10].HeaderText = "Cuotas";
        
        }


        private void llenarDatos() {
            dgvOrdenes.DataSource = OrdenDao.buscarOrden("%" + txtCliente.Text + "%", txtDni.Text, dtFechaInicial.Value.ToString("yyyy-MM-dd") + " 00:00:00", dtFechaFin.Value.ToString("yyyy-MM-dd") + " 23:59:59",0);
            dgvOrdenes.Columns[0].HeaderText = "Código";
            dgvOrdenes.Columns[0].Width = 50;
            dgvOrdenes.Columns[1].Visible = false;
            dgvOrdenes.Columns[2].HeaderText = "Nombre cliente";
            dgvOrdenes.Columns[2].Width = 120;
            dgvOrdenes.Columns[3].Visible = false;
            dgvOrdenes.Columns[4].HeaderText = "Sucursal";
            dgvOrdenes.Columns[4].Width = 100;
            dgvOrdenes.Columns[5].HeaderText = "Fecha Orden";
            dgvOrdenes.Columns[5].Width = 110;
            dgvOrdenes.Columns[6].HeaderText = "Pago 1";
            dgvOrdenes.Columns[6].DefaultCellStyle.Format = "C2";
            dgvOrdenes.Columns[6].Width = 70;
            dgvOrdenes.Columns[7].HeaderText = "Pago 2";
            dgvOrdenes.Columns[7].DefaultCellStyle.Format = "C2";
            dgvOrdenes.Columns[7].Width = 70;
            dgvOrdenes.Columns[8].HeaderText = "Monto Orden";
            dgvOrdenes.Columns[8].DefaultCellStyle.Format = "C2";
            dgvOrdenes.Columns[8].Width = 70;
            dgvOrdenes.Columns[9].HeaderText = "Monto Pend.";
            dgvOrdenes.Columns[9].DefaultCellStyle.Format = "C2";
            dgvOrdenes.Columns[9].Width = 70;
            dgvOrdenes.Columns[10].HeaderText = "Cuotas";
            
        }

        private void llenarDetalles(int id)
        {
            dgvDetalles.DataSource = OrdenDao.consultarOrden(id);
            dgvDetalles.Columns[0].HeaderText = "Código";
              dgvDetalles.Columns[2].Visible = false;
              dgvDetalles.Columns[5].DefaultCellStyle.Format = "C2";
              dgvDetalles.Columns[9].DefaultCellStyle.Format = "C2";
              dgvDetalles.Columns[10].Visible = false;
              dgvDetalles.Columns[11].Visible = false;
              
              /*dgvDetalles.Columns[2].HeaderText = "Nombre cliente";
              dgvDetalles.Columns[2].Width = 250;
              dgvDetalles.Columns[3].HeaderText = "DNI";
              dgvDetalles.Columns[3].Visible = false;
              dgvDetalles.Columns[4].HeaderText = "Fecha Orden";
              dgvDetalles.Columns[4].Width = 200;
              dgvDetalles.Columns[5].HeaderText = "Monto Orden";*/
            
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

            txtMonto.Text = Convert.ToString(dgvOrdenes[8, pos].Value);
            if (Convert.ToInt32(dgvOrdenes[10, pos].Value) == 2)
            {
                txtCodigo.Text = Convert.ToString(dgvOrdenes[0, pos].Value);
                txtDebe.Visible = true;
                lblDebe.Visible = true;
                lblsimdebe.Visible = true;
                txtDebe.Text = Convert.ToString(dgvOrdenes[9, pos].Value);
                chkVisa.Visible = true;
                llenarDetalles(Convert.ToInt32(dgvOrdenes[0, pos].Value));
            }
            else
            {
                txtCodigo.Text = Convert.ToString(dgvOrdenes[0, pos].Value);
                txtDebe.Visible = false;
                lblDebe.Visible = false;
                lblsimdebe.Visible = false;
                txtDebe.Text = Convert.ToString(0);
                chkVisa.Visible = false;
                llenarDetalles(Convert.ToInt32(dgvOrdenes[0,pos].Value));
            }



        }

        private void btnEntregar_Click(object sender, EventArgs e)
        {
            int pago2=0;
            if (chkVisa.Checked)
                pago2 = 1;
            int re = 0;
            re= OrdenDao.entregaOrden(Convert.ToInt32(txtCodigo.Text),pago2,txtObs.Text);
            llenarDatos();
            llenarDetalles(0);
            chkVisa.Visible = false;
            txtMonto.Text = "0.00";
            txtDebe.Text = "0.00";
            txtDebe.Visible = false;
            lblDebe.Visible = false;
            lblsimdebe.Visible = false;
            MessageBox.Show("Orden Nro: " + txtCodigo.Text + " actualizada correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {

                if (txtNumero.Text.Equals(""))
                {
                    llenarDatos();
                }
                else
                {

                    llenarDatosId(Convert.ToInt32(txtNumero.Text));
                }
            
            }
        }

       }
    }
    
