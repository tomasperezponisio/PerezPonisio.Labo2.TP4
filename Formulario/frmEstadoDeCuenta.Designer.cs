namespace Formulario
{
    partial class frmEstadoDeCuenta
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
            this.lstHistorialDePagos = new System.Windows.Forms.ListBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblDni = new System.Windows.Forms.Label();
            this.lblEstaAlDia = new System.Windows.Forms.Label();
            this.grbEstadoCuenta = new System.Windows.Forms.GroupBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.grbEstadoCuenta.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstHistorialDePagos
            // 
            this.lstHistorialDePagos.FormattingEnabled = true;
            this.lstHistorialDePagos.HorizontalScrollbar = true;
            this.lstHistorialDePagos.ItemHeight = 15;
            this.lstHistorialDePagos.Location = new System.Drawing.Point(238, 27);
            this.lstHistorialDePagos.Name = "lstHistorialDePagos";
            this.lstHistorialDePagos.Size = new System.Drawing.Size(765, 319);
            this.lstHistorialDePagos.TabIndex = 37;
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(6, 27);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(217, 23);
            this.txtNombre.TabIndex = 32;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(6, 9);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(51, 15);
            this.lblNombre.TabIndex = 29;
            this.lblNombre.Text = "Nombre";
            // 
            // txtDni
            // 
            this.txtDni.Enabled = false;
            this.txtDni.Location = new System.Drawing.Point(6, 127);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(217, 23);
            this.txtDni.TabIndex = 34;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(6, 58);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(51, 15);
            this.lblApellido.TabIndex = 30;
            this.lblApellido.Text = "Apellido";
            // 
            // txtApellido
            // 
            this.txtApellido.Enabled = false;
            this.txtApellido.Location = new System.Drawing.Point(6, 76);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(217, 23);
            this.txtApellido.TabIndex = 33;
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(6, 109);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(27, 15);
            this.lblDni.TabIndex = 31;
            this.lblDni.Text = "DNI";
            // 
            // lblEstaAlDia
            // 
            this.lblEstaAlDia.AutoSize = true;
            this.lblEstaAlDia.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEstaAlDia.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblEstaAlDia.Location = new System.Drawing.Point(51, 28);
            this.lblEstaAlDia.Name = "lblEstaAlDia";
            this.lblEstaAlDia.Size = new System.Drawing.Size(99, 25);
            this.lblEstaAlDia.TabIndex = 38;
            this.lblEstaAlDia.Text = "Esta al día";
            this.lblEstaAlDia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grbEstadoCuenta
            // 
            this.grbEstadoCuenta.Controls.Add(this.lblEstaAlDia);
            this.grbEstadoCuenta.Location = new System.Drawing.Point(6, 166);
            this.grbEstadoCuenta.Name = "grbEstadoCuenta";
            this.grbEstadoCuenta.Size = new System.Drawing.Size(217, 71);
            this.grbEstadoCuenta.TabIndex = 40;
            this.grbEstadoCuenta.TabStop = false;
            this.grbEstadoCuenta.Text = "Estado de Cuenta";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(6, 254);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(217, 23);
            this.btnImprimir.TabIndex = 41;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // frmEstadoDeCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 361);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.grbEstadoCuenta);
            this.Controls.Add(this.lstHistorialDePagos);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.lblDni);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEstadoDeCuenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estado De Cuenta";
            this.Load += new System.EventHandler(this.frmEstadoDeCuenta_Load);
            this.grbEstadoCuenta.ResumeLayout(false);
            this.grbEstadoCuenta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstHistorialDePagos;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Label lblEstaAlDia;
        private System.Windows.Forms.GroupBox grbEstadoCuenta;
        private System.Windows.Forms.Button btnImprimir;
    }
}