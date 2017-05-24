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
using MySql.Data.MySqlClient;

namespace Lavanderia.forms
{
    public partial class frmReporteDetalle : Form
    {
        public frmReporteDetalle()
        {
            InitializeComponent();
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

        private void frmReporteDetalle_Load(object sender, EventArgs e)
        {
            fillSusursal();
        }

        private void btnSrcCliente_Click(object sender, EventArgs e)
        {

        }

        
    }
}
