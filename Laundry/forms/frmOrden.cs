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
using System.Globalization;
using CrystalDecisions.CrystalReports.Engine;
using MySql.Data.MySqlClient;

namespace Lavanderia.forms
{
    public partial class frmOrden : Form
    {
        int i = 1;
        int idOrdenPrint = 0;
        decimal cantidadGeneral = 0;
        decimal cantidadGeneralcama = 0;
        string aplicaDescuento = "";
        Validacion v = new Validacion();
        decimal totalOrden = 0;
        decimal totalDescuento = 0;
        decimal totalOfertaRopa = 0;
        decimal totalOfertaCama = 0;
        int dscto = 0;
        public frmOrden()
        {
            InitializeComponent();
        }



        private void btnSrcCliente_Click(object sender, EventArgs e)
        {
            frmBuscarCliente childForm = new frmBuscarCliente();
            childForm.enviado += new frmBuscarCliente.enviar(ejecutar);
            childForm.ShowDialog();

        }

        public void ejecutar(string id, string nombre, string dni, string telefono)
        {
            txtNombreCliente.Text = nombre;
            txtDni.Text = dni;
            lblCodigoCliente.Text = id;
            txtTelefono.Text = telefono;

        }

        public void ejecutar2(string id, string nombre, decimal precio,string tipo)
        {
            LblId.Text = id;
            txtNombrePrenda.Text = nombre;
            txtPrecio.Text = Convert.ToString(Decimal.Round(precio, 2));
            txttipo.Text = tipo;
        }

        public void ejecutar3(string colores)
        {




        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (nroCantidad.Value > 0)
            {
               
                int tipoServ=0;
                string id, detalle, defecto, colores,marca, tipo;
                id = LblId.Text;
                detalle = (rdPrenda.Checked) ? txtNombrePrenda.Text : cmbServicios.Text;
                decimal cantidad, precio, total;
                total = 0;
           
                
                cantidad = nroCantidad.Value;
            
                marca = cmbMarca.Text;
                precio = Decimal.Round(Convert.ToDecimal(txtPrecio.Text), 2);
                
                defecto = "";
                colores = "";

                if (rdPrenda.Checked) { tipoServ = 1; }
                if (rdServicio.Checked) { tipoServ = 2; }
                int nrodia;
                DateTime Hoy = DateTime.Now;

                nrodia = (int)Hoy.DayOfWeek;
                aplicaDescuento = OrdenDao.consultaOferta(nrodia);

                if (tipoServ == 1 && aplicaDescuento.Equals("3 Prendas a mas"))
                {
                    cantidadGeneral += cantidad;
                    totalOfertaRopa+= Decimal.Round((cantidad * precio), 2);
                }
                else {
                    total = Decimal.Round((cantidad * precio), 2);
                
                }

                if (tipoServ == 1 && txttipo.Text == "Ropa de Cama" && aplicaDescuento.Equals("Ropa de Cama"))
                {
                    cantidadGeneralcama += cantidad;
                    totalOfertaCama+= Decimal.Round((cantidad * precio), 2);
                }
                else {
                    total = Decimal.Round((cantidad * precio), 2);
                }

                foreach (Object def in chkDefecto.CheckedItems)
                {
                    defecto += def.ToString() + ",";
                }

                colores = cmbColor.Text;
                /*foreach (Object col in chkColores.CheckedItems)
                {
                    colores += col.ToString() + ",";
                }*/

              

                if (chkDscto.Checked)
                {
                    total = (total - precio);
                    detalle = detalle + " Dscto + 5k";
                    dscto = 1;

                }
                dgvOrden.Rows.Add(i, id, detalle, cantidad, precio, total, defecto, colores,marca,tipoServ);
                 i = i + 1;
                totalOrden += Decimal.Round(total,2);
                PrendaDao.agregarMarca(cmbMarca.Text);
                txtTotal.Text = Convert.ToString(Decimal.Round(totalOrden, 2));
                //txtIgv.Text = "S/." + Convert.ToString(Decimal.Round((totalOrden *igv) / 100,2));
                restablecer();
                cantidad=0;
                chkDscto.Checked = false;
                
                total=0;

                if (cantidadGeneralcama >= 1)
                {

                    MessageBox.Show("Aplica el descuento Ropa de Cama: " + aplicaDescuento + " por la cantidad " + cantidadGeneralcama + " items "+ totalOfertaCama   , "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

                if(cantidadGeneral>=3 ){

                    MessageBox.Show("Aplica el descuento: " + aplicaDescuento  + " por la cantidad " + cantidadGeneral+ " items "+ totalOfertaRopa, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
                }
            }
            else
            {
                MessageBox.Show("Debe indicar el nro de prendas", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }

        public void restablecer()
        {

            txtNombrePrenda.Enabled = false;
            txtNombrePrenda.Text = "";
            btnBuscaprenda.Enabled = false;
            btnBuscaprenda.Visible = false;
            cmbServicios.Enabled = false;
            cmbMarca.Enabled = false;
            cmbMarca.Text = "";
            cmbColor.Enabled = false;
            cmbColor.Text = "";
            cmbPrenda.Text = "";
            cmbServicios.Text = "";
            rdPrenda.Checked = false;
            rdServicio.Checked = false;
            chkVisa.Checked = false;
            chkVisa.Enabled = false;
            chkDescuento.Checked = false;
            chkDescuento.Enabled = false;
            nroDscto.Enabled = false;
            nroDscto.Text = "0";
            txtPrecio.Text = "";
          nroCantidad.Value = nroCantidad.Minimum;
           
            foreach (int w in chkDefecto.CheckedIndices)
            {
                chkDefecto.SetItemCheckState(w, CheckState.Unchecked);
            }
            foreach (int e in chkColores.CheckedIndices)
            {
                chkColores.SetItemCheckState(e, CheckState.Unchecked);
            }


            btnAdd.Enabled = false;
            nroCantidad.Enabled = false;
            chkDefecto.Enabled = false;
            chkColores.Enabled = false;
            cmbColor.Enabled = false;
           
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
            int nrodia = 0;
            int tipo_pago1 = 0;
            int tipo_doc = 0;
            int tipo_descuento = 0;
            if (rdTotal.Checked)
            {
                tipo_pago = 1;
            }
            if (rdParcial.Checked)
            {
                tipo_pago = 2;
            }

            if (chkVisa.Checked)
            {
                tipo_pago1 = 1;
            }
      

            int status = 0;
            string s = dtFechaEntrega.Value.ToString("yyyy-MM-dd hh:mm:ss").Replace("/", "-").Substring(0, 10);
            string h = dtHoraEntrega.Value.ToString("hh:mm:ss").Replace("a.m.", "").Replace("p.m.", "").Replace("/", "-");
            ord.idCliente = Convert.ToInt32(lblCodigoCliente.Text);
            ord.fechaEntrega = s + " " + h;      
            ord.idUsuario = Convert.ToInt32(toolStripStatusLabel1.Text);
            ord.observacion = txtObservacion.Text;
            ord.estado = 0;
            ord.tipoPago = tipo_pago;
            ord.Descuento = tipo_descuento;
            ord.pDescuento = Convert.ToDecimal(nroDscto.Text);
           

            if (status > 0)
            {
                if (tipo_pago == 1)
                {

                    DateTime Hoy = DateTime.Now;
                    string fecha_actual = Hoy.ToString("yyyy-MM-dd hh:mm:ss");
                    nrodia = (int)Hoy.DayOfWeek;
                    Oferta of = OfertaDao.Buscar(nrodia);

                    if (chkVisa.Checked) {
                        of.Porcentaje = of.Porcentaje-5;
                    }

                    if (of.Porcentaje > 0)
                    {
                        if (of.Porcentaje > 0 && of.Nombre.Equals("Ropa de Cama"))
                        {
                            decimal nuevototal = Convert.ToDecimal(txtPago.Text) - (totalOfertaCama);
                            decimal descuento = totalOfertaCama * (of.Porcentaje / 100);
                            MessageBox.Show(descuento + " :Porcentate:" + of.Porcentaje, "aviso");
                            pago.PagoTotal = nuevototal + (totalOfertaCama - descuento);
                            ord.totalOrden = nuevototal + (totalOfertaCama - descuento);
                        }


                        if (of.Porcentaje > 0 && of.Nombre.Equals("3 Prendas a mas"))
                        {
                            decimal nuevototal = Convert.ToDecimal(txtPago.Text) - (totalOfertaRopa);
                            decimal descuento = totalOfertaRopa * (of.Porcentaje / 100);
                            MessageBox.Show(descuento + " :Porcentate:" + of.Porcentaje, "aviso");
                            pago.PagoTotal = nuevototal + (totalOfertaRopa - descuento);
                            ord.totalOrden = nuevototal + (totalOfertaRopa - descuento);
                        }
                    }
                    else {

                        pago.PagoTotal = Convert.ToDecimal(txtPago.Text);
                        ord.totalOrden = Convert.ToDecimal(txtPago.Text);
                    }
                    
                    status = OrdenDao.Agregar(ord);
                    pago.idOrden = status;
                    pago.Pago1 = Convert.ToDecimal(txtPago.Text);
                    pago.Pago2 = 0;
                    
                    pago.TipoPago = tipo_pago;
                    pago.TipoPago1 = tipo_pago1;
                    pago.TipoDocumento = tipo_doc;
                    //pago.Igv = Convert.ToDecimal(txtIg.Text);
                    pago.Estado = 0;
                    pago.fechaPago = fecha_actual;
                    pago.fechaActualizado = fecha_actual;
                    PagoDao.Agregar(pago);

                }

                if (tipo_pago == 2)
                {

                    DateTime Hoy = DateTime.Now;
                    string fecha_actual = Hoy.ToString("yyyy-MM-dd hh:mm:ss");
                    nrodia = (int) Hoy.DayOfWeek;

                    pago.idOrden = status;
                    pago.Pago1 = Convert.ToDecimal(txtPago.Text);
                    pago.Pago2 = Convert.ToDecimal(txtPendiente.Text); ;
                    pago.PagoTotal = (Convert.ToDecimal(txtPago.Text) + Convert.ToDecimal(txtPendiente.Text));
                    pago.TipoPago = tipo_pago;
                    pago.TipoPago1 = tipo_pago1;
                    pago.TipoDocumento = tipo_doc;
                    //pago.Igv = pago.Igv = Convert.ToDecimal(txtIg.Text);
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
                        ordline.Cantidad = Convert.ToDecimal(data.Cells["clCantidad"].Value);
                        ordline.Precio = Decimal.Round(Convert.ToDecimal(data.Cells["clPrecio"].Value.ToString()), 2);
                        ordline.Defecto = Convert.ToString(data.Cells["clDefecto"].Value);
                        ordline.Colores = Convert.ToString(data.Cells["clColores"].Value);
                        ordline.Total = Convert.ToDecimal(data.Cells["clTotal"].Value);
                        ordline.Marca = Convert.ToString(data.Cells["cLmarca"].Value);
                        ordline.TipoServicio = Convert.ToInt32(data.Cells["clTipo"].Value);
                        ordline.Estado = 0;

                        OrdenDao.AgregarLinea(ordline);

                    }

                }
                catch (Exception)
                {


                }

                MessageBox.Show(string.Format("Se grabó correctamente la orden con el número: {0}", status, nrodia), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                idOrdenPrint = status;
                desHabilitaServicio();
                btnImprimir.Enabled = true;
                dscto = 0;
                i = 1;

            }


        }

        private void rdParcial_CheckedChanged(object sender, EventArgs e)
        {
            lblMontopagar.Text = "Adelanto";
            lblPendiente.Visible = true;
            chkVisa.Enabled = true;
            lblSimbolopendiente.Visible = true;
            txtPendiente.Visible = true;
            txtPago.Enabled = true;
            txtObservacion.Enabled = true;
            txtPago.Text = "0.00";
            dtFechaEntrega.Enabled = true;
            dtHoraEntrega.Enabled = true;
            btnGuardar.Enabled = true;
            txtIg.Visible = false;
            chkDescuento.Enabled = false;
            chkDescuento.Visible = false;
            nroDscto.Visible = false;
            nroDscto.Enabled = false;



        }

        private void rdTotal_Click(object sender, EventArgs e)
        {
            lblMontopagar.Text = "Monto";
            lblPendiente.Visible = false;
            txtPendiente.Visible = false;
            lblSimbolopendiente.Visible = false;
            txtPago.Text = Convert.ToString(totalOrden);
            txtPago.Enabled = false;
            txtObservacion.Enabled = true;
            dtFechaEntrega.Enabled = true;
            dtHoraEntrega.Enabled = true;
            chkVisa.Enabled = true;
            /*chkDescuento.Enabled = true;
            chkDescuento.Visible = true;*/
            

        }

        private void txtPago_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPago.Text))
            {

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

        public void habilitaServicio()
        {


            nroCantidad.Enabled = true;
            chkDefecto.Enabled = true;
            chkColores.Enabled = true;
            cmbColor.Enabled = true;

            dgvOrden.Enabled = true;


        }

        public void desHabilitaServicio()
        {
            rdPrenda.Enabled = false;
            rdServicio.Enabled = false;
            nroCantidad.Enabled = false;
            chkDefecto.Enabled = false;
            chkColores.Enabled = false;
            cmbColor.Enabled = false;
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
            btnImprimir.Enabled = false;
            chkVisa.Checked = false;
            chkVisa.Enabled = false;
            chkDescuento.Checked = false;
            chkDescuento.Enabled = false;
            chkDescuento.Visible = false;
            nroDscto.Text = "0";
            nroDscto.Enabled = false;
            nroDscto.Visible = false;
            label11.Visible = false;
            totalOfertaCama = 0;
            totalOfertaRopa = 0;
            totalOrden =0;


        }


        private void txtNombrePrenda_TextChanged(object sender, EventArgs e)
        {
            habilitaServicio();
            //btnAdd.Enabled = true;

        }

        private void dgvOrden_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnQuitar.Enabled = true;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            decimal totalDescontar = 0;
            Int32 selectedRowCount = dgvOrden.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount > 0)
            {

                for (int i = 0; i < selectedRowCount; i++)
                {
                    totalDescontar += Convert.ToDecimal(dgvOrden.Rows[dgvOrden.SelectedRows[i].Index].Cells["clTotal"].Value.ToString());
                    dgvOrden.Rows.RemoveAt(dgvOrden.SelectedRows[i].Index);
                }

            }
            totalOrden = (totalOrden - totalDescontar);
            txtTotal.Text = Convert.ToString(totalOrden);
            btnQuitar.Enabled = false;
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            rdParcial.Enabled = true;
            rdTotal.Enabled = true;
            txtPago.Text = txtTotal.Text;


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

    
       

        private void rdTotal_CheckedChanged(object sender, EventArgs e)
        {
            btnGuardar.Enabled = true;
            //chkDescuento.Enabled = true;

            
        }
        /*
        private void chkFactura_CheckStateChanged(object sender, EventArgs e)
        {
            
             if (chkVisa.Checked)
            {
                decimal igv = Decimal.Round((totalOrden * 18) / 100, 2);    
                MessageBox.Show("" + igv);
                txtIg.Visible = true;
                txtIg.Text = Convert.ToString(igv);

                txtPago.Text = Convert.ToString(totalOrden + igv);

            }
            else {
                txtIg.Visible = false;
                decimal quitar = Convert.ToDecimal(txtIg.Text);
                decimal t = Convert.ToDecimal(txtPago.Text);
                txtPago.Text = Convert.ToString(t- quitar);
                lbligv.Visible = false;
                TXTIGV.Visible = false;
                grpTotal.Left = 318;
                grpTotal.Width = 220;
                label9.Left = 15;
                txtTotal.Left = 106;
                txtTotal.Text = Convert.ToString(Decimal.Round(totalOrden, 2));

            
            }
        }*/

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ReportDocument cryrep = new ReportDocument();
            MySqlDataAdapter myadap = new MySqlDataAdapter(String.Format(
         "SELECT o.idOrden,c.dniCliente,c.nombreCliente,o.fechaCreado,o.fechaEntrega, o.totalOrden,l.cantidad,l.precio,l.descripcion,l.total,l.colorPrenda,l.marca,l.defecto,p.pago1,p.pago2,u.direccion,u.telefono FROM Orden o INNER JOIN Cliente c ON o.idCliente=c.idCliente INNER JOIN Pago p ON o.idOrden=p.idOrden INNER JOIN OrdenLinea l ON o.idOrden=l.idOrden INNER JOIN usuario u ON u.id=o.idUsuario WHERE o.idOrden={0}", idOrdenPrint), BdComun.ObtenerConexion());
            DataSet ds = new DataSet();

            myadap.Fill(ds,"Ticket");

            cryrep.Load(@"D:\lavanderia\Laundry\Reportes\crTicket.rpt");

            cryrep.SetDataSource(ds);
            cryrep.PrintToPrinter(1, true, 0, 0);

            /*frmReporte rt = new frmReporte();
            rt.Text = "Ticket";
            rt.crystalReportViewer1.ReportSource = cryrep;
            rt.Show();﻿*/
        }


        private void fillMarcas() {

            MySqlDataReader _reader = PrendaDao.fillMarca();
            cmbMarca.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbMarca.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection datosM = new AutoCompleteStringCollection();
            while (_reader.Read())
            {
                string name = _reader.GetString("nombreMarca");
                datosM.Add(name);

            }
            cmbMarca.AutoCompleteCustomSource = datosM;
        
        }

        private void fillServicio() {
            cmbServicios.Items.Clear();
            MySqlDataReader _readerS = ServicioDao.fillServicio();
            while (_readerS.Read())
            {
                string name = _readerS.GetString("nombreServicio");
                string id = _readerS.GetString("idServicio");
                cmbServicios.Items.Add(name);
                cmbServicios.DisplayMember = name;
                cmbServicios.ValueMember = id;
            }
        
        }

        private void fillColores()
        {
            MySqlDataReader _reader = ColorDao.fillColor();
            cmbColor.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbColor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection datosM = new AutoCompleteStringCollection();
            while (_reader.Read())
            {
                string name = _reader.GetString("nombreColor");
                datosM.Add(name);

            }
            cmbColor.AutoCompleteCustomSource=datosM;

            /*MySqlDataReader _reader = PrendaDao.fillPrenda();
            cmbPrenda.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbPrenda.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
            while (_reader.Read())
            {
                string name = _reader.GetString("nombrePrenda");
                datos.Add(name);

            }
            cmbPrenda.AutoCompleteCustomSource = datos;
          
            MySqlDataReader _readerC = ColorDao.fillColor();
            while (_readerC.Read())
            {
                chkColores.Items.Add(_readerC.GetString("nombreColor"));

            }  */



        }

        private void frmOrden_Load(object sender, EventArgs e)
        {
            fillMarcas();
            fillColores();
            DateTime today = DateTime.Now;
            DateTime answer = today.AddDays(4);
            dtFechaEntrega.Value = answer;
            dtHoraEntrega.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 0, 0);
        }






  


        private void cmbPrenda_Leave(object sender, EventArgs e)
        {
            MySqlDataReader _reader = PrendaDao.fillPrendaSearch(cmbPrenda.Text);
            while (_reader.Read())
            {
                string name = _reader.GetString("idPrenda");
                txtPrecio.Text = Convert.ToString(Decimal.Round(_reader.GetDecimal("precioServicio"), 2));
                LblId.Text = name;
            }

            habilitaServicio();
            btnAdd.Enabled = true;
            fillMarcas();
        }

        private void cmbPrenda_MouseLeave(object sender, EventArgs e)
        {
            MySqlDataReader _reader = PrendaDao.fillPrendaSearch(cmbPrenda.Text);
            while (_reader.Read())
            {
                string name = _reader.GetString("idPrenda");

                LblId.Text = name;
            }
        }

        private void cmbPrenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbPrenda.Text.ToUpper();
                nroCantidad.Focus();
            }
        }

        private void cmbServicios_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            Object selectedItem = cmbServicios.SelectedItem;

            MySqlDataReader _reader = ServicioDao.fillServicioSearch(selectedItem.ToString());
            while (_reader.Read())
            {

                string name = _reader.GetString("idServicio");
                nroCantidad.Minimum = _reader.GetInt32("cantidadMinima");
                txtPrecio.Text = Convert.ToString(Decimal.Round(_reader.GetDecimal("precioServicio"), 2));
                LblId.Text = name;
            }
            habilitaServicio();
            btnAdd.Enabled = true;
            
        }

        private void nroCantidad_ValueChanged(object sender, EventArgs e)
        {
            if (rdServicio.Checked && nroCantidad.Value > 5)
            {
                labelOferta.Visible = true;
                chkDscto.Visible = true;
            }
            else {
                labelOferta.Visible = false;
                chkDscto.Visible = false;
            }
        }

        private void rdPrenda_Click(object sender, EventArgs e)
        {
            //cmbPrenda.Enabled = true;
            txtNombrePrenda.Visible = true;
           // btnBuscaprenda.Visible = true;
            btnBuscaprenda.Enabled = true;
            nroCantidad.Enabled = true;
            //cmbPrenda.Visible = true;
            cmbServicios.Visible = false;
            cmbMarca.Enabled = true;
            cmbColor.Enabled=true;
            labelCantidad.Text = "Cantidad";
            nroCantidad.Minimum = 1;
            nroCantidad.Value = 1;

            frmBuscarPrendas childForm = new frmBuscarPrendas();
            childForm.enviado += new frmBuscarPrendas.enviar(ejecutar2);
            childForm.ShowDialog();
             //fillPrendas();
        }

        private void rdServicio_Click(object sender, EventArgs e)
        {
            txtNombrePrenda.Visible = false;
            btnBuscaprenda.Visible = false;
            cmbServicios.Visible = true;
            cmbServicios.Enabled = true;
            cmbMarca.Enabled = false;
            nroCantidad.Value = 2;
            nroCantidad.Minimum = 2;
            nroCantidad.Enabled = true;
            labelCantidad.Text = "Peso";
            fillServicio();
        }

        private void cmbMarca_Leave(object sender, EventArgs e)
        {
            cmbMarca.Text.ToUpper();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            frmBuscarPrendas childForm = new frmBuscarPrendas();
            childForm.enviado += new frmBuscarPrendas.enviar(ejecutar2);
            childForm.ShowDialog();
        }

        private void txtNombrePrenda_TextChanged_1(object sender, EventArgs e)
        {
            habilitaServicio();
            btnAdd.Enabled = true;
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!nroDscto.Enabled)
            {
                nroDscto.Visible = false;
                nroDscto.Enabled = false;
                label11.Visible = false;
                txtPago.Text = Convert.ToString(totalOrden);
           
            }
            else {
                nroDscto.Visible = true;
                nroDscto.Enabled = true;
                label11.Visible = true;
                
            
            }

        }

    
        private void nroDscto_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }

        private void nroDscto_Leave(object sender, EventArgs e)
        {
            totalDescuento = Convert.ToDecimal(nroDscto.Text);
            if (!txtPago.Text.Equals(""))
            {
                decimal total = totalOrden;
                txtPago.Text = Convert.ToString(Decimal.Round(total - (Convert.ToDecimal(txtPago.Text) * totalDescuento) / 100, 2));
                //totalOrden = Decimal.Round(total - (Convert.ToDecimal(txtPago.Text) * Convert.ToDecimal(nroDscto.Text)) / 100, 2);
                //total = totalOrden;

            }
        }
    
        }
}
      
   

