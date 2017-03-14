﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lavanderia.Models;
using Lavanderia.Persistencia;
using Lavanderia.util;

namespace Lavanderia.forms
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            login();
        }


        private void login() {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (!string.IsNullOrWhiteSpace(txtUsuario.Text) && (!string.IsNullOrWhiteSpace(txtPassword.Text)))
            {
                Usuario result;

                result = UsuarioDao.Consultar(usuario, password);
                if (result.nombreUsuario != null)
                {
                    StatusBar mainStatusBar = new StatusBar();
                    frmInicio childForm = new frmInicio();
                    if (result.tipoUsuario == 1)
                    {
                        childForm.mnuAdmUsuarios.Visible = true;
                        childForm.optionsToolStripMenuItem.Visible = true;
                    }
                    childForm.searchToolStripMenuItem.Text = Convert.ToString(result.idUsuario);
                    
                    varGlobales.sessionUsuario = result.idUsuario;
                    mainStatusBar.Panels.Add("t_usuario");
                    mainStatusBar.Panels.Add("Usuario");
                    mainStatusBar.Panels.Add("t_sucursal");
                    mainStatusBar.Panels.Add("sucursal");
                    mainStatusBar.Panels.Add("Fecha");
                    mainStatusBar.Panels.Add("tipo");
                    mainStatusBar.Panels[0].Width = 50;
                    mainStatusBar.Panels[0].Text = "Usuario:";
                    mainStatusBar.Panels[1].Text = result.nombreUsuario + " " + result.apellidoUsuario;
                    mainStatusBar.Panels[2].Width = 60;
                    mainStatusBar.Panels[2].Text = "Sucursal:";
                    mainStatusBar.Panels[3].Text = result.sucursalUsuario;
                    mainStatusBar.Panels[4].Width = 200;
                    mainStatusBar.Panels[4].Text = Convert.ToString(DateTime.Now);

                    mainStatusBar.Panels[5].Text = (result.tipoUsuario == 1) ? "Admin" : "Normal";
                    mainStatusBar.ShowPanels = true;
                    childForm.Controls.Add(mainStatusBar);
                    childForm.Show();
                    this.Hide();
                }
                else
                {

                    MessageBox.Show("Usuario y/o Password incorrectos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            else
            {

                MessageBox.Show("Debe ingresar Usuario y Password", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {

            DialogResult x = MessageBox.Show("Desea salir del Sistema", "Programa", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
                Close();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) { login(); }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) { txtPassword.Focus(); }
        }

     
    }
}
