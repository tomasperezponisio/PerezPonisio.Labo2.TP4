using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Entidades.Exceptions;
using System.IO;
using Entidades.GestorArchivos;
using System.Diagnostics;
using Entidades.GestorSQL;

namespace Formulario
{
    public partial class frmEstadoDeCuenta : Form
    {
        #region Atributos
        private Socio socio;
        #endregion

        #region Botones y eventos del form
        public frmEstadoDeCuenta(Socio socio)
        {
            InitializeComponent();
            this.socio = socio;
        }
        /// <summary>
        /// Carga los datos del socio en los campos, cargo la lista de cuotas del socio al lisbox y llamando a la funcion VerificarSiEstaAlDia()
        /// verifico si esta al dia con las cuotas y cambio el texto y el colo del label lblEstaAlDia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmEstadoDeCuenta_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtNombre.Text = socio.Nombre;
                this.txtApellido.Text = socio.Apellido;
                this.txtDni.Text = socio.Dni.ToString();
                socio.HistorialDePagos = GestorSQL.LeerCuotasDeSocio(this.socio);
                socio.HistorialDePagos.Sort((Cuota c1, Cuota c2) => string.Compare(c1.MesCuota, c2.MesCuota));
                this.lstHistorialDePagos.DataSource = socio.HistorialDePagos;

                if (socio.VerificarSiEstaAlDia())
                {
                    this.lblEstaAlDia.ForeColor = Color.Green;
                    this.lblEstaAlDia.Text = "Esta al día";
                }
                else
                {
                    this.lblEstaAlDia.ForeColor = Color.Red;
                    this.lblEstaAlDia.Text = "Debe";
                }
            }
            catch (ExceptionSQL ex)
            {
                MessageBox.Show(ex.Message, "Error al mostrar las cuotas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al mostrar las cuotas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Genera un documento de texto con los datos del socio, su historial de pago y si esta al dia con las cuotas o si debe el úlitmo mes.
        /// Se abre el documento generado y se informa donde esta guardado. Si hay algun problema se arroja la exception correspondiente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                ArchivoTexto archivo = new ArchivoTexto();
                string nombreDeArchivo;
                archivo.Escribir($"{socio.Nombre}{socio.Apellido}.txt", socio.Imprimir());
                nombreDeArchivo = $"{archivo.RutaDeEscritura()}{socio.Nombre}{socio.Apellido}.txt";
                ProcessStartInfo proceso = new ProcessStartInfo
                {
                    FileName = nombreDeArchivo,
                    UseShellExecute = true
                };
                Process.Start(proceso);
                MessageBox.Show($"Impresión exitosa.\nRecibo en: {archivo.RutaDeEscritura()}", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArchivoInvalidoException ex)
            {
                MessageBox.Show(ex.Message, "Error al escribir el archivo de texto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al escribir el archivo de texto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
