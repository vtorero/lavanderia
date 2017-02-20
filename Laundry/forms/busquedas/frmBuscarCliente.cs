using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lavanderia.forms.busquedas
{
    public partial class frmBuscarCliente : Form
  {
        public delegate void enviar(string datos);
        public event enviar enviado;
        public frmBuscarCliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            enviado(textBox1.Text);
            this.Hide();

        }
    }
}
