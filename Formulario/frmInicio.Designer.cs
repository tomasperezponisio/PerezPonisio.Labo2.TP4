namespace Formulario
{
    partial class frmInicio
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.lstPersonas = new System.Windows.Forms.ListBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnPagarCuota = new System.Windows.Forms.Button();
            this.btnEstadoDeCuenta = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnLeerSql = new System.Windows.Forms.Button();
            this.lblCargando = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Formulario.Properties.Resources.escudo_de_armenia;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 122);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(12, 141);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(139, 23);
            this.btnCargar.TabIndex = 23;
            this.btnCargar.Text = "Cargar Socio";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // lstPersonas
            // 
            this.lstPersonas.FormattingEnabled = true;
            this.lstPersonas.HorizontalScrollbar = true;
            this.lstPersonas.ItemHeight = 15;
            this.lstPersonas.Location = new System.Drawing.Point(157, 12);
            this.lstPersonas.Name = "lstPersonas";
            this.lstPersonas.Size = new System.Drawing.Size(911, 304);
            this.lstPersonas.TabIndex = 28;
            this.lstPersonas.SelectedIndexChanged += new System.EventHandler(this.lstPersonas_SelectedIndexChanged);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(12, 170);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(139, 23);
            this.btnModificar.TabIndex = 31;
            this.btnModificar.Text = "Modificar Socio";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(12, 257);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(139, 23);
            this.btnEliminar.TabIndex = 32;
            this.btnEliminar.Text = "Eliminar Socio";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnPagarCuota
            // 
            this.btnPagarCuota.Location = new System.Drawing.Point(12, 228);
            this.btnPagarCuota.Name = "btnPagarCuota";
            this.btnPagarCuota.Size = new System.Drawing.Size(139, 23);
            this.btnPagarCuota.TabIndex = 33;
            this.btnPagarCuota.Text = "Pagar Cuota";
            this.btnPagarCuota.UseVisualStyleBackColor = true;
            this.btnPagarCuota.Click += new System.EventHandler(this.btnPagarCuota_Click);
            // 
            // btnEstadoDeCuenta
            // 
            this.btnEstadoDeCuenta.Location = new System.Drawing.Point(12, 199);
            this.btnEstadoDeCuenta.Name = "btnEstadoDeCuenta";
            this.btnEstadoDeCuenta.Size = new System.Drawing.Size(139, 23);
            this.btnEstadoDeCuenta.TabIndex = 34;
            this.btnEstadoDeCuenta.Text = "Estado de Cuenta";
            this.btnEstadoDeCuenta.UseVisualStyleBackColor = true;
            this.btnEstadoDeCuenta.Click += new System.EventHandler(this.lblEstadoDeCuenta_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(12, 286);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(139, 23);
            this.btnExportar.TabIndex = 35;
            this.btnExportar.Text = "Exportar Lista";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnLeerSql
            // 
            this.btnLeerSql.Location = new System.Drawing.Point(12, 315);
            this.btnLeerSql.Name = "btnLeerSql";
            this.btnLeerSql.Size = new System.Drawing.Size(139, 23);
            this.btnLeerSql.TabIndex = 36;
            this.btnLeerSql.Text = "Leer Base de Datos SQL";
            this.btnLeerSql.UseVisualStyleBackColor = true;
            this.btnLeerSql.Click += new System.EventHandler(this.btnLeerSql_Click);
            // 
            // lblCargando
            // 
            this.lblCargando.AutoSize = true;
            this.lblCargando.ForeColor = System.Drawing.Color.Red;
            this.lblCargando.Location = new System.Drawing.Point(157, 322);
            this.lblCargando.Name = "lblCargando";
            this.lblCargando.Size = new System.Drawing.Size(10, 15);
            this.lblCargando.TabIndex = 38;
            this.lblCargando.Text = " ";
            // 
            // frmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1084, 355);
            this.Controls.Add(this.lblCargando);
            this.Controls.Add(this.btnLeerSql);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnEstadoDeCuenta);
            this.Controls.Add(this.btnPagarCuota);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.lstPersonas);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCargar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UGAB";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInicio_FormClosing);
            this.Load += new System.EventHandler(this.frmInicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.ListBox lstPersonas;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnPagarCuota;
        private System.Windows.Forms.Button btnEstadoDeCuenta;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnLeerSql;
        private System.Windows.Forms.Label lblCargando;
    }
}
