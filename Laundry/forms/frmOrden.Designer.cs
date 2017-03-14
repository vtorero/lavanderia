namespace Lavanderia.forms
{
    partial class frmOrden
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrden));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblCodigoCliente = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.btnSrcCliente = new System.Windows.Forms.Button();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.txtIg = new System.Windows.Forms.Label();
            this.lblSimbolopendiente = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chkFactura = new System.Windows.Forms.CheckBox();
            this.lblObs = new System.Windows.Forms.Label();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dtHoraEntrega = new System.Windows.Forms.DateTimePicker();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dtFechaEntrega = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPendiente = new System.Windows.Forms.TextBox();
            this.lblPendiente = new System.Windows.Forms.Label();
            this.txtPago = new System.Windows.Forms.TextBox();
            this.lblMontopagar = new System.Windows.Forms.Label();
            this.rdParcial = new System.Windows.Forms.RadioButton();
            this.rdTotal = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmbPrenda = new System.Windows.Forms.ComboBox();
            this.TXTIGV = new System.Windows.Forms.TextBox();
            this.lbligv = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.txtcolores = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbDefecto = new System.Windows.Forms.ComboBox();
            this.grpTotal = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.nroCantidad = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.LblId = new System.Windows.Forms.Label();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgvOrden = new System.Windows.Forms.DataGridView();
            this.clNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPrenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDefecto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clColores = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rdServicio = new System.Windows.Forms.RadioButton();
            this.rdPrenda = new System.Windows.Forms.RadioButton();
            this.btnAddPrenda = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.grpTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nroCantidad)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrden)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(15, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(484, 495);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblCodigoCliente);
            this.groupBox3.Controls.Add(this.txtTelefono);
            this.groupBox3.Controls.Add(this.txtNombreCliente);
            this.groupBox3.Controls.Add(this.btnSrcCliente);
            this.groupBox3.Controls.Add(this.txtDni);
            this.groupBox3.Controls.Add(this.lblCliente);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(7, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(460, 157);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos Cliente";
            // 
            // lblCodigoCliente
            // 
            this.lblCodigoCliente.AutoSize = true;
            this.lblCodigoCliente.Location = new System.Drawing.Point(212, 57);
            this.lblCodigoCliente.Name = "lblCodigoCliente";
            this.lblCodigoCliente.Size = new System.Drawing.Size(0, 16);
            this.lblCodigoCliente.TabIndex = 5;
            this.lblCodigoCliente.Visible = false;
            // 
            // txtTelefono
            // 
            this.txtTelefono.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTelefono.Enabled = false;
            this.txtTelefono.Location = new System.Drawing.Point(96, 88);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(134, 22);
            this.txtTelefono.TabIndex = 3;
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtNombreCliente.Enabled = false;
            this.txtNombreCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCliente.Location = new System.Drawing.Point(96, 22);
            this.txtNombreCliente.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(342, 22);
            this.txtNombreCliente.TabIndex = 3;
            this.txtNombreCliente.TextChanged += new System.EventHandler(this.txtNombreCliente_TextChanged);
            // 
            // btnSrcCliente
            // 
            this.btnSrcCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSrcCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnSrcCliente.Image")));
            this.btnSrcCliente.Location = new System.Drawing.Point(393, 81);
            this.btnSrcCliente.Margin = new System.Windows.Forms.Padding(4);
            this.btnSrcCliente.Name = "btnSrcCliente";
            this.btnSrcCliente.Size = new System.Drawing.Size(45, 28);
            this.btnSrcCliente.TabIndex = 1;
            this.btnSrcCliente.UseVisualStyleBackColor = true;
            this.btnSrcCliente.Click += new System.EventHandler(this.btnSrcCliente_Click);
            // 
            // txtDni
            // 
            this.txtDni.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDni.Enabled = false;
            this.txtDni.Location = new System.Drawing.Point(96, 54);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(110, 22);
            this.txtDni.TabIndex = 2;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(15, 25);
            this.lblCliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(61, 15);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "Nombres:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Teléfono:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "DNI:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnImprimir);
            this.groupBox2.Controls.Add(this.txtIg);
            this.groupBox2.Controls.Add(this.lblSimbolopendiente);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.chkFactura);
            this.groupBox2.Controls.Add(this.lblObs);
            this.groupBox2.Controls.Add(this.txtObservacion);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.dtHoraEntrega);
            this.groupBox2.Controls.Add(this.btnGuardar);
            this.groupBox2.Controls.Add(this.dtFechaEntrega);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtPendiente);
            this.groupBox2.Controls.Add(this.lblPendiente);
            this.groupBox2.Controls.Add(this.txtPago);
            this.groupBox2.Controls.Add(this.lblMontopagar);
            this.groupBox2.Controls.Add(this.rdParcial);
            this.groupBox2.Controls.Add(this.rdTotal);
            this.groupBox2.Location = new System.Drawing.Point(7, 186);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(460, 284);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalles de pago";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.Location = new System.Drawing.Point(354, 204);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(89, 54);
            this.btnImprimir.TabIndex = 27;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // txtIg
            // 
            this.txtIg.AutoSize = true;
            this.txtIg.Location = new System.Drawing.Point(351, 68);
            this.txtIg.Name = "txtIg";
            this.txtIg.Size = new System.Drawing.Size(0, 16);
            this.txtIg.TabIndex = 26;
            this.txtIg.Visible = false;
            // 
            // lblSimbolopendiente
            // 
            this.lblSimbolopendiente.AutoSize = true;
            this.lblSimbolopendiente.Location = new System.Drawing.Point(203, 104);
            this.lblSimbolopendiente.Name = "lblSimbolopendiente";
            this.lblSimbolopendiente.Size = new System.Drawing.Size(24, 16);
            this.lblSimbolopendiente.TabIndex = 14;
            this.lblSimbolopendiente.Text = "S/.";
            this.lblSimbolopendiente.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(203, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 16);
            this.label8.TabIndex = 13;
            this.label8.Text = "S/.";
            // 
            // chkFactura
            // 
            this.chkFactura.AutoSize = true;
            this.chkFactura.Enabled = false;
            this.chkFactura.Location = new System.Drawing.Point(354, 26);
            this.chkFactura.Name = "chkFactura";
            this.chkFactura.Size = new System.Drawing.Size(54, 20);
            this.chkFactura.TabIndex = 25;
            this.chkFactura.Text = "Visa";
            this.chkFactura.UseVisualStyleBackColor = true;
            this.chkFactura.CheckStateChanged += new System.EventHandler(this.chkFactura_CheckStateChanged);
            // 
            // lblObs
            // 
            this.lblObs.AutoSize = true;
            this.lblObs.Location = new System.Drawing.Point(68, 158);
            this.lblObs.Name = "lblObs";
            this.lblObs.Size = new System.Drawing.Size(36, 16);
            this.lblObs.TabIndex = 12;
            this.lblObs.Text = "Obs:";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Enabled = false;
            this.txtObservacion.Location = new System.Drawing.Point(115, 143);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(288, 43);
            this.txtObservacion.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 232);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 16);
            this.label12.TabIndex = 10;
            this.label12.Text = "Hora:";
            // 
            // dtHoraEntrega
            // 
            this.dtHoraEntrega.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtHoraEntrega.Enabled = false;
            this.dtHoraEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtHoraEntrega.Location = new System.Drawing.Point(139, 236);
            this.dtHoraEntrega.Name = "dtHoraEntrega";
            this.dtHoraEntrega.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtHoraEntrega.ShowUpDown = true;
            this.dtHoraEntrega.Size = new System.Drawing.Size(109, 22);
            this.dtHoraEntrega.TabIndex = 9;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Enabled = false;
            this.btnGuardar.Image = global::Lavanderia.Properties.Resources.Overlay_preferences;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Location = new System.Drawing.Point(254, 203);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(97, 55);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.button3_Click);
            // 
            // dtFechaEntrega
            // 
            this.dtFechaEntrega.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            this.dtFechaEntrega.Enabled = false;
            this.dtFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaEntrega.Location = new System.Drawing.Point(139, 204);
            this.dtFechaEntrega.Name = "dtFechaEntrega";
            this.dtFechaEntrega.Size = new System.Drawing.Size(109, 22);
            this.dtFechaEntrega.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 204);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(118, 16);
            this.label13.TabIndex = 6;
            this.label13.Text = "Fecha de Entrega:";
            // 
            // txtPendiente
            // 
            this.txtPendiente.Location = new System.Drawing.Point(232, 101);
            this.txtPendiente.Name = "txtPendiente";
            this.txtPendiente.Size = new System.Drawing.Size(100, 22);
            this.txtPendiente.TabIndex = 5;
            this.txtPendiente.Visible = false;
            // 
            // lblPendiente
            // 
            this.lblPendiente.AutoSize = true;
            this.lblPendiente.Location = new System.Drawing.Point(80, 104);
            this.lblPendiente.Name = "lblPendiente";
            this.lblPendiente.Size = new System.Drawing.Size(111, 16);
            this.lblPendiente.TabIndex = 4;
            this.lblPendiente.Text = "Monto pendiente:";
            this.lblPendiente.Visible = false;
            // 
            // txtPago
            // 
            this.txtPago.Enabled = false;
            this.txtPago.Location = new System.Drawing.Point(233, 65);
            this.txtPago.Name = "txtPago";
            this.txtPago.Size = new System.Drawing.Size(100, 22);
            this.txtPago.TabIndex = 3;
            this.txtPago.TextChanged += new System.EventHandler(this.txtPago_TextChanged);
            this.txtPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPago_KeyPress);
            this.txtPago.Leave += new System.EventHandler(this.txtPago_Leave);
            // 
            // lblMontopagar
            // 
            this.lblMontopagar.AutoSize = true;
            this.lblMontopagar.Location = new System.Drawing.Point(93, 71);
            this.lblMontopagar.Name = "lblMontopagar";
            this.lblMontopagar.Size = new System.Drawing.Size(98, 16);
            this.lblMontopagar.TabIndex = 2;
            this.lblMontopagar.Text = "Monto a pagar:";
            // 
            // rdParcial
            // 
            this.rdParcial.AutoSize = true;
            this.rdParcial.Enabled = false;
            this.rdParcial.Location = new System.Drawing.Point(233, 25);
            this.rdParcial.Name = "rdParcial";
            this.rdParcial.Size = new System.Drawing.Size(104, 20);
            this.rdParcial.TabIndex = 10;
            this.rdParcial.Text = "Pago Parcial";
            this.rdParcial.UseVisualStyleBackColor = true;
            this.rdParcial.CheckedChanged += new System.EventHandler(this.rdParcial_CheckedChanged);
            // 
            // rdTotal
            // 
            this.rdTotal.AutoSize = true;
            this.rdTotal.Enabled = false;
            this.rdTotal.Location = new System.Drawing.Point(95, 25);
            this.rdTotal.Name = "rdTotal";
            this.rdTotal.Size = new System.Drawing.Size(93, 20);
            this.rdTotal.TabIndex = 9;
            this.rdTotal.Text = "Pago Total";
            this.rdTotal.UseVisualStyleBackColor = true;
            this.rdTotal.CheckedChanged += new System.EventHandler(this.rdTotal_CheckedChanged);
            this.rdTotal.Click += new System.EventHandler(this.rdTotal_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmbPrenda);
            this.groupBox4.Controls.Add(this.TXTIGV);
            this.groupBox4.Controls.Add(this.lbligv);
            this.groupBox4.Controls.Add(this.btnColor);
            this.groupBox4.Controls.Add(this.txtcolores);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.cmbDefecto);
            this.groupBox4.Controls.Add(this.grpTotal);
            this.groupBox4.Controls.Add(this.nroCantidad);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.LblId);
            this.groupBox4.Controls.Add(this.btnQuitar);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.txtPrecio);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.rdServicio);
            this.groupBox4.Controls.Add(this.rdPrenda);
            this.groupBox4.Controls.Add(this.btnAddPrenda);
            this.groupBox4.Controls.Add(this.btnAdd);
            this.groupBox4.Controls.Add(this.statusStrip1);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(514, 15);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(725, 495);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            // 
            // cmbPrenda
            // 
            this.cmbPrenda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPrenda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbPrenda.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbPrenda.Enabled = false;
            this.cmbPrenda.FormattingEnabled = true;
            this.cmbPrenda.Location = new System.Drawing.Point(115, 51);
            this.cmbPrenda.Name = "cmbPrenda";
            this.cmbPrenda.Size = new System.Drawing.Size(279, 24);
            this.cmbPrenda.TabIndex = 4;
            this.cmbPrenda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbPrenda_KeyDown);
            this.cmbPrenda.Leave += new System.EventHandler(this.cmbPrenda_Leave);
            this.cmbPrenda.MouseLeave += new System.EventHandler(this.cmbPrenda_MouseLeave);
            // 
            // TXTIGV
            // 
            this.TXTIGV.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.TXTIGV.Enabled = false;
            this.TXTIGV.Location = new System.Drawing.Point(352, 415);
            this.TXTIGV.Name = "TXTIGV";
            this.TXTIGV.Size = new System.Drawing.Size(105, 22);
            this.TXTIGV.TabIndex = 27;
            this.TXTIGV.Visible = false;
            // 
            // lbligv
            // 
            this.lbligv.AutoSize = true;
            this.lbligv.Location = new System.Drawing.Point(293, 418);
            this.lbligv.Name = "lbligv";
            this.lbligv.Size = new System.Drawing.Size(39, 16);
            this.lbligv.TabIndex = 26;
            this.lbligv.Text = "I.G.V:";
            this.lbligv.Visible = false;
            // 
            // btnColor
            // 
            this.btnColor.Enabled = false;
            this.btnColor.Location = new System.Drawing.Point(372, 156);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(22, 23);
            this.btnColor.TabIndex = 24;
            this.btnColor.Text = "...";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtcolores
            // 
            this.txtcolores.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtcolores.Enabled = false;
            this.txtcolores.Location = new System.Drawing.Point(115, 157);
            this.txtcolores.Name = "txtcolores";
            this.txtcolores.Size = new System.Drawing.Size(251, 22);
            this.txtcolores.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(35, 157);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 16);
            this.label11.TabIndex = 22;
            this.label11.Text = "Colores:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(195, 126);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 16);
            this.label10.TabIndex = 21;
            this.label10.Text = "Defecto:";
            // 
            // cmbDefecto
            // 
            this.cmbDefecto.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbDefecto.Enabled = false;
            this.cmbDefecto.FormattingEnabled = true;
            this.cmbDefecto.Items.AddRange(new object[] {
            "Roto",
            "Manchado",
            "Descolorido",
            "Rasgado",
            "Gastado"});
            this.cmbDefecto.Location = new System.Drawing.Point(261, 121);
            this.cmbDefecto.Name = "cmbDefecto";
            this.cmbDefecto.Size = new System.Drawing.Size(133, 24);
            this.cmbDefecto.TabIndex = 6;
            this.cmbDefecto.Text = "Seleccionar";
            // 
            // grpTotal
            // 
            this.grpTotal.Controls.Add(this.label14);
            this.grpTotal.Controls.Add(this.txtTotal);
            this.grpTotal.Controls.Add(this.label9);
            this.grpTotal.Location = new System.Drawing.Point(482, 390);
            this.grpTotal.Name = "grpTotal";
            this.grpTotal.Size = new System.Drawing.Size(220, 57);
            this.grpTotal.TabIndex = 18;
            this.grpTotal.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(93, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 16);
            this.label14.TabIndex = 4;
            this.label14.Text = "S/.";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(120, 21);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(88, 22);
            this.txtTotal.TabIndex = 3;
            this.txtTotal.TextChanged += new System.EventHandler(this.txtTotal_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 16);
            this.label9.TabIndex = 1;
            this.label9.Text = "Total Orden:";
            // 
            // nroCantidad
            // 
            this.nroCantidad.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.nroCantidad.Enabled = false;
            this.nroCantidad.Location = new System.Drawing.Point(115, 122);
            this.nroCantidad.Name = "nroCantidad";
            this.nroCantidad.Size = new System.Drawing.Size(59, 22);
            this.nroCantidad.TabIndex = 5;
            this.nroCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "Cantidad:";
            // 
            // LblId
            // 
            this.LblId.AutoSize = true;
            this.LblId.BackColor = System.Drawing.SystemColors.Window;
            this.LblId.Location = new System.Drawing.Point(404, 54);
            this.LblId.Name = "LblId";
            this.LblId.Size = new System.Drawing.Size(31, 16);
            this.LblId.TabIndex = 15;
            this.LblId.Text = "cod";
            this.LblId.Visible = false;
            // 
            // btnQuitar
            // 
            this.btnQuitar.AutoSize = true;
            this.btnQuitar.Enabled = false;
            this.btnQuitar.Image = global::Lavanderia.Properties.Resources.Annotate_Disabled;
            this.btnQuitar.Location = new System.Drawing.Point(482, 132);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(49, 41);
            this.btnQuitar.TabIndex = 14;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dgvOrden);
            this.groupBox5.Location = new System.Drawing.Point(17, 209);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(691, 174);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Detalle";
            this.groupBox5.Enter += new System.EventHandler(this.groupBox5_Enter);
            // 
            // dgvOrden
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrden.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrden.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clNumero,
            this.clPrenda,
            this.clDescripcion,
            this.clCantidad,
            this.clPrecio,
            this.clTotal,
            this.clDefecto,
            this.clColores});
            this.dgvOrden.Enabled = false;
            this.dgvOrden.Location = new System.Drawing.Point(6, 34);
            this.dgvOrden.MultiSelect = false;
            this.dgvOrden.Name = "dgvOrden";
            this.dgvOrden.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvOrden.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvOrden.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrden.Size = new System.Drawing.Size(679, 134);
            this.dgvOrden.TabIndex = 0;
            this.dgvOrden.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvOrden_CellMouseClick);
            // 
            // clNumero
            // 
            this.clNumero.HeaderText = "Nro";
            this.clNumero.Name = "clNumero";
            this.clNumero.Width = 50;
            // 
            // clPrenda
            // 
            this.clPrenda.HeaderText = "Id";
            this.clPrenda.Name = "clPrenda";
            this.clPrenda.Width = 50;
            // 
            // clDescripcion
            // 
            this.clDescripcion.HeaderText = "Descripción";
            this.clDescripcion.Name = "clDescripcion";
            this.clDescripcion.Width = 180;
            // 
            // clCantidad
            // 
            this.clCantidad.HeaderText = "Cantidad";
            this.clCantidad.Name = "clCantidad";
            this.clCantidad.Width = 60;
            // 
            // clPrecio
            // 
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.clPrecio.DefaultCellStyle = dataGridViewCellStyle2;
            this.clPrecio.HeaderText = "Precio";
            this.clPrecio.Name = "clPrecio";
            this.clPrecio.Width = 55;
            // 
            // clTotal
            // 
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.clTotal.DefaultCellStyle = dataGridViewCellStyle3;
            this.clTotal.HeaderText = "Total";
            this.clTotal.Name = "clTotal";
            // 
            // clDefecto
            // 
            this.clDefecto.HeaderText = "Defecto";
            this.clDefecto.Name = "clDefecto";
            // 
            // clColores
            // 
            this.clColores.HeaderText = "Colores";
            this.clColores.Name = "clColores";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(85, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "S/.";
            // 
            // txtPrecio
            // 
            this.txtPrecio.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtPrecio.Enabled = false;
            this.txtPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(115, 87);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(59, 24);
            this.txtPrecio.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Precio:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Detalle:";
            // 
            // rdServicio
            // 
            this.rdServicio.AutoSize = true;
            this.rdServicio.Enabled = false;
            this.rdServicio.Location = new System.Drawing.Point(200, 21);
            this.rdServicio.Name = "rdServicio";
            this.rdServicio.Size = new System.Drawing.Size(132, 20);
            this.rdServicio.TabIndex = 3;
            this.rdServicio.Text = "Al Peso y promos";
            this.rdServicio.UseVisualStyleBackColor = true;
            this.rdServicio.CheckedChanged += new System.EventHandler(this.rdServicio_CheckedChanged);
            // 
            // rdPrenda
            // 
            this.rdPrenda.AutoSize = true;
            this.rdPrenda.Enabled = false;
            this.rdPrenda.Location = new System.Drawing.Point(117, 21);
            this.rdPrenda.Name = "rdPrenda";
            this.rdPrenda.Size = new System.Drawing.Size(73, 20);
            this.rdPrenda.TabIndex = 2;
            this.rdPrenda.Text = "Al Seco";
            this.rdPrenda.UseVisualStyleBackColor = true;
            this.rdPrenda.CheckedChanged += new System.EventHandler(this.rdPrenda_CheckedChanged);
            // 
            // btnAddPrenda
            // 
            this.btnAddPrenda.Enabled = false;
            this.btnAddPrenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPrenda.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPrenda.Image")));
            this.btnAddPrenda.Location = new System.Drawing.Point(396, 22);
            this.btnAddPrenda.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddPrenda.Name = "btnAddPrenda";
            this.btnAddPrenda.Size = new System.Drawing.Size(45, 24);
            this.btnAddPrenda.TabIndex = 6;
            this.btnAddPrenda.UseVisualStyleBackColor = true;
            this.btnAddPrenda.Visible = false;
            this.btnAddPrenda.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.Enabled = false;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = global::Lavanderia.Properties.Resources.plush;
            this.btnAdd.Location = new System.Drawing.Point(423, 132);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(52, 41);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(3, 470);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(719, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tipo:";
            // 
            // frmOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 741);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(10, 20);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmOrden";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmOrden";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmOrden_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.grpTotal.ResumeLayout(false);
            this.grpTotal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nroCantidad)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrden)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSrcCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.Label lblCodigoCliente;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.RadioButton rdServicio;
        private System.Windows.Forms.RadioButton rdPrenda;
        private System.Windows.Forms.Button btnAddPrenda;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgvOrden;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Label LblId;
        private System.Windows.Forms.NumericUpDown nroCantidad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grpTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbDefecto;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.TextBox txtcolores;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtFechaEntrega;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPendiente;
        private System.Windows.Forms.Label lblPendiente;
        private System.Windows.Forms.TextBox txtPago;
        private System.Windows.Forms.Label lblMontopagar;
        private System.Windows.Forms.RadioButton rdParcial;
        private System.Windows.Forms.RadioButton rdTotal;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DateTimePicker dtHoraEntrega;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPrenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDefecto;
        private System.Windows.Forms.DataGridViewTextBoxColumn clColores;
        private System.Windows.Forms.Label lblObs;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Label lblSimbolopendiente;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkFactura;
        private System.Windows.Forms.Label lbligv;
        private System.Windows.Forms.TextBox TXTIGV;
        private System.Windows.Forms.Label txtIg;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.ComboBox cmbPrenda;
    }
}