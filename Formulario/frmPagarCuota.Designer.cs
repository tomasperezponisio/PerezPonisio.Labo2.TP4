namespace Formulario
{
    partial class frmPagarCuota
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
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cmbActividad = new System.Windows.Forms.ComboBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblActividad = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.lblImporte = new System.Windows.Forms.Label();
            this.dtpFechaCuota = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.cmbMetodoDePago = new System.Windows.Forms.ComboBox();
            this.lblMetodoDePago = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(12, 27);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(217, 23);
            this.txtNombre.TabIndex = 31;
            // 
            // cmbActividad
            // 
            this.cmbActividad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActividad.FormattingEnabled = true;
            this.cmbActividad.Items.AddRange(new object[] {
            "Basquet",
            "Futbol",
            "Natacion",
            "Voley"});
            this.cmbActividad.Location = new System.Drawing.Point(12, 173);
            this.cmbActividad.Name = "cmbActividad";
            this.cmbActividad.Size = new System.Drawing.Size(217, 23);
            this.cmbActividad.TabIndex = 35;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(12, 9);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(51, 15);
            this.lblNombre.TabIndex = 28;
            this.lblNombre.Text = "Nombre";
            // 
            // lblActividad
            // 
            this.lblActividad.AutoSize = true;
            this.lblActividad.Location = new System.Drawing.Point(12, 155);
            this.lblActividad.Name = "lblActividad";
            this.lblActividad.Size = new System.Drawing.Size(57, 15);
            this.lblActividad.TabIndex = 34;
            this.lblActividad.Text = "Actividad";
            // 
            // txtDni
            // 
            this.txtDni.Enabled = false;
            this.txtDni.Location = new System.Drawing.Point(12, 125);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(217, 23);
            this.txtDni.TabIndex = 33;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(12, 58);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(51, 15);
            this.lblApellido.TabIndex = 29;
            this.lblApellido.Text = "Apellido";
            // 
            // txtApellido
            // 
            this.txtApellido.Enabled = false;
            this.txtApellido.Location = new System.Drawing.Point(12, 76);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(217, 23);
            this.txtApellido.TabIndex = 32;
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(12, 107);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(27, 15);
            this.lblDni.TabIndex = 30;
            this.lblDni.Text = "DNI";
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(12, 221);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(217, 23);
            this.txtImporte.TabIndex = 37;
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.Location = new System.Drawing.Point(12, 203);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(49, 15);
            this.lblImporte.TabIndex = 36;
            this.lblImporte.Text = "Importe";
            // 
            // dtpFechaCuota
            // 
            this.dtpFechaCuota.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaCuota.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaCuota.Location = new System.Drawing.Point(12, 269);
            this.dtpFechaCuota.Name = "dtpFechaCuota";
            this.dtpFechaCuota.Size = new System.Drawing.Size(217, 23);
            this.dtpFechaCuota.TabIndex = 39;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(12, 251);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(38, 15);
            this.lblFecha.TabIndex = 38;
            this.lblFecha.Text = "Fecha";
            // 
            // cmbMetodoDePago
            // 
            this.cmbMetodoDePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetodoDePago.FormattingEnabled = true;
            this.cmbMetodoDePago.Items.AddRange(new object[] {
            "Efectivo",
            "Debito",
            "Credito",
            "MercadoPago"});
            this.cmbMetodoDePago.Location = new System.Drawing.Point(12, 319);
            this.cmbMetodoDePago.Name = "cmbMetodoDePago";
            this.cmbMetodoDePago.Size = new System.Drawing.Size(217, 23);
            this.cmbMetodoDePago.TabIndex = 41;
            // 
            // lblMetodoDePago
            // 
            this.lblMetodoDePago.AutoSize = true;
            this.lblMetodoDePago.Location = new System.Drawing.Point(12, 301);
            this.lblMetodoDePago.Name = "lblMetodoDePago";
            this.lblMetodoDePago.Size = new System.Drawing.Size(95, 15);
            this.lblMetodoDePago.TabIndex = 40;
            this.lblMetodoDePago.Text = "Metodo de Pago";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(12, 358);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(95, 23);
            this.btnAceptar.TabIndex = 42;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(134, 358);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(95, 23);
            this.btnCancelar.TabIndex = 43;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmPagarCuota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 397);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cmbMetodoDePago);
            this.Controls.Add(this.lblMetodoDePago);
            this.Controls.Add(this.dtpFechaCuota);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.txtImporte);
            this.Controls.Add(this.lblImporte);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.cmbActividad);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblActividad);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.lblDni);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPagarCuota";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagar Cuota";
            this.Load += new System.EventHandler(this.frmPagarCuota_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox cmbActividad;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblActividad;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.DateTimePicker dtpFechaCuota;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.ComboBox cmbMetodoDePago;
        private System.Windows.Forms.Label lblMetodoDePago;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}