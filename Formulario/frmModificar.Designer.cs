namespace Formulario
{
    partial class frmModificar
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cmbEnum2 = new System.Windows.Forms.ComboBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.lblEnum2 = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.cmbEnum1 = new System.Windows.Forms.ComboBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblDni = new System.Windows.Forms.Label();
            this.lblEnum1 = new System.Windows.Forms.Label();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(133, 320);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(94, 23);
            this.btnCancelar.TabIndex = 55;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(10, 320);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(94, 23);
            this.btnAceptar.TabIndex = 54;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(10, 24);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(217, 23);
            this.txtNombre.TabIndex = 46;
            // 
            // cmbEnum2
            // 
            this.cmbEnum2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEnum2.FormattingEnabled = true;
            this.cmbEnum2.Items.AddRange(new object[] {
            "Basquet",
            "Futbol",
            "Natacion",
            "Voley"});
            this.cmbEnum2.Location = new System.Drawing.Point(10, 283);
            this.cmbEnum2.Name = "cmbEnum2";
            this.cmbEnum2.Size = new System.Drawing.Size(217, 23);
            this.cmbEnum2.TabIndex = 53;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(10, 6);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(51, 15);
            this.lblNombre.TabIndex = 42;
            this.lblNombre.Text = "Nombre";
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(10, 175);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(217, 23);
            this.dtpFechaNacimiento.TabIndex = 49;
            // 
            // lblEnum2
            // 
            this.lblEnum2.AutoSize = true;
            this.lblEnum2.Location = new System.Drawing.Point(10, 265);
            this.lblEnum2.Name = "lblEnum2";
            this.lblEnum2.Size = new System.Drawing.Size(57, 15);
            this.lblEnum2.TabIndex = 52;
            this.lblEnum2.Text = "Actividad";
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(10, 124);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(217, 23);
            this.txtDni.TabIndex = 48;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(10, 55);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(51, 15);
            this.lblApellido.TabIndex = 43;
            this.lblApellido.Text = "Apellido";
            // 
            // cmbEnum1
            // 
            this.cmbEnum1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEnum1.FormattingEnabled = true;
            this.cmbEnum1.Items.AddRange(new object[] {
            "Joven",
            "Adulto",
            "Mayor"});
            this.cmbEnum1.Location = new System.Drawing.Point(10, 228);
            this.cmbEnum1.Name = "cmbEnum1";
            this.cmbEnum1.Size = new System.Drawing.Size(217, 23);
            this.cmbEnum1.TabIndex = 50;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(10, 73);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(217, 23);
            this.txtApellido.TabIndex = 47;
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(10, 106);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(27, 15);
            this.lblDni.TabIndex = 44;
            this.lblDni.Text = "DNI";
            // 
            // lblEnum1
            // 
            this.lblEnum1.AutoSize = true;
            this.lblEnum1.Location = new System.Drawing.Point(10, 210);
            this.lblEnum1.Name = "lblEnum1";
            this.lblEnum1.Size = new System.Drawing.Size(58, 15);
            this.lblEnum1.TabIndex = 51;
            this.lblEnum1.Text = "Categoria";
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(10, 157);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(117, 15);
            this.lblFechaNacimiento.TabIndex = 45;
            this.lblFechaNacimiento.Text = "Fecha de nacimiento";
            // 
            // frmModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 373);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.cmbEnum2);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.dtpFechaNacimiento);
            this.Controls.Add(this.lblEnum2);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.cmbEnum1);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.lblDni);
            this.Controls.Add(this.lblEnum1);
            this.Controls.Add(this.lblFechaNacimiento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmModificar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Socio";
            this.Load += new System.EventHandler(this.frmModificar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox cmbEnum2;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Label lblEnum2;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.ComboBox cmbEnum1;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Label lblEnum1;
        private System.Windows.Forms.Label lblFechaNacimiento;
    }
}