﻿namespace Lavanderia.forms
{
    partial class frmCierre
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSrcCliente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtFechaFin
            // 
            this.dtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaFin.Location = new System.Drawing.Point(160, 93);
            this.dtFechaFin.Name = "dtFechaFin";
            this.dtFechaFin.Size = new System.Drawing.Size(109, 20);
            this.dtFechaFin.TabIndex = 14;
            this.dtFechaFin.ValueChanged += new System.EventHandler(this.dtFechaFin_ValueChanged);
            // 
            // dtFechaInicial
            // 
            this.dtFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaInicial.Location = new System.Drawing.Point(160, 34);
            this.dtFechaInicial.Name = "dtFechaInicial";
            this.dtFechaInicial.Size = new System.Drawing.Size(109, 20);
            this.dtFechaInicial.TabIndex = 13;
            this.dtFechaInicial.ValueChanged += new System.EventHandler(this.dtFechaInicial_ValueChanged);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(54, 34);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(67, 13);
            this.lblFecha.TabIndex = 15;
            this.lblFecha.Text = "Fecha inicio:";
            this.lblFecha.Click += new System.EventHandler(this.lblFecha_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Fecha fin:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnSrcCliente
            // 
            this.btnSrcCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSrcCliente.Image = global::Lavanderia.Properties.Resources.printer;
            this.btnSrcCliente.Location = new System.Drawing.Point(350, 55);
            this.btnSrcCliente.Margin = new System.Windows.Forms.Padding(4);
            this.btnSrcCliente.Name = "btnSrcCliente";
            this.btnSrcCliente.Size = new System.Drawing.Size(73, 64);
            this.btnSrcCliente.TabIndex = 12;
            this.btnSrcCliente.UseVisualStyleBackColor = true;
            this.btnSrcCliente.Click += new System.EventHandler(this.btnSrcCliente_Click);
            // 
            // frmCierre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 164);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.dtFechaFin);
            this.Controls.Add(this.btnSrcCliente);
            this.Controls.Add(this.dtFechaInicial);
            this.Name = "frmCierre";
            this.Text = "Cierre de  Caja";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtFechaFin;
        private System.Windows.Forms.Button btnSrcCliente;
        private System.Windows.Forms.DateTimePicker dtFechaInicial;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label label1;
    }
}