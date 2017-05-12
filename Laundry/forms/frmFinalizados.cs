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
using MySql.Data.MySqlClient;
using Lavanderia.util;

namespace Lavanderia.forms
{
    public partial class frmFinalizados : Form
    {
        int pos = 0;
        public frmFinalizados()
        {
            InitializeComponent();
           
        }

        private void btnSrcCliente_Click(object sender, EventArgs e)
        {
            llenarDatos();
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
            dgvOrdenes.Columns[3].Visible = false;
            dgvOrdenes.Columns[4].HeaderText = "Sucursal";
            dgvOrdenes.Columns[4].Width = 80;
            dgvOrdenes.Columns[5].HeaderText = "Fecha Orden";
            dgvOrdenes.Columns[5].Width = 150;
            dgvOrdenes.Columns[6].HeaderText = "Monto Orden";
            dgvOrdenes.Columns[6].DefaultCellStyle.Format = "C2";
            dgvOrdenes.Columns[6].Width = 100;
            dgvOrdenes.Columns[7].HeaderText = "Monto Pend.";
            dgvOrdenes.Columns[7].DefaultCellStyle.Format = "C2";
            dgvOrdenes.Columns[7].Visible = false;
            dgvOrdenes.Columns[7].Width = 100;
            dgvOrdenes.Columns[8].HeaderText = "Coutas";
           //dgvOrdenes.Columns[8].Visible = false;
       
        
        }

        private void dgvOrdenes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            pos = dgvOrdenes.CurrentRow.Index;
            llenarDetalles(Convert.ToInt32(dgvOrdenes[0, pos].Value));
            llenaPago(Convert.ToInt32(dgvOrdenes[0, pos].Value));
        }

        private void llenaPago(int id) {

            MySqlDataReader _reader = PagoDao.consultaPago(id);
            while (_reader.Read())
            {

                string idPago = _reader.GetString("idPago");
                string tipopago = _reader.GetString("tipoPago");
                string tipopago1= _reader.GetString("tipoPago1");
                string tipopago2 = _reader.GetString("tipoPago2");

                if (varGlobales.sessionUsuario.ToString().Equals("1")) {
                    btnCambiaModo.Enabled = true;
                    rdpago1E.Enabled = true;
                    rdpago1T.Enabled = true;
                    rdpago2E.Enabled = true;
                    rdpago2T.Enabled = true;
                
                }

                if (tipopago.Equals("2"))
                {
                    grpPago2.Visible = true;
                    rdpago2E.Visible = true;
                    rdpago2T.Visible = true;
                }
                else {

                    grpPago2.Visible = false;
                    rdpago2E.Visible = false;
                    rdpago2T.Visible = false;
                }

                /*pago 1*/
                if(tipopago1.Equals("0")){
                rdpago1E.Checked=true;
                }if (tipopago1.Equals("1"))
                {
                    rdpago1T.Checked = true;
                }

                /*pago 2*/
                if (tipopago2.Equals("0"))
                {
                    rdpago2E.Checked = true;
                } 
                if (tipopago2.Equals("1"))
                {
                    rdpago2T.Checked = true;
                }



                
            }

        }

     
    }
}