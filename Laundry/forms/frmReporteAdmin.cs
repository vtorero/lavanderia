using Lavanderia.Persistencia;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lavanderia.forms
{
    public partial class frmReporteAdmin : Form
    {
        public frmReporteAdmin()
        {
            InitializeComponent();
        }

        private void lblFecha_Click(object sender, EventArgs e)
        {

        }

        private void dtFechaInicial_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtFechaFin_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSrcCliente_Click(object sender, EventArgs e)
        {

        }

        private void fillSusursal()
        {
            chKSucursal.Items.Clear();
            MySqlDataReader _readerS = ServicioDao.fillSucursales();
            while (_readerS.Read())
            {
                string name = _readerS.GetString("sucursal");
                string id = _readerS.GetString("id");
                chKSucursal.Items.Add(name);
                chKSucursal.DisplayMember = name;
                chKSucursal.ValueMember = id;
            }

        }

        private void frmReporteAdmin_Load(object sender, EventArgs e)
        {
            fillSusursal();
        }
    }
}
