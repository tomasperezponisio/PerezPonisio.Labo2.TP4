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
using Entidades.GestorSQL;

namespace Formulario
{
    public partial class frmPagarCuota : Form
    {
        #region Atributos
        private Socio socio;
        #endregion

        #region Botones y eventos del form
        public frmPagarCuota(Socio socio)
        {
            InitializeComponent();
            this.socio = socio;
        }
        /// <summary>
        /// Carga los datos del socio que vino como parámetro en la instancia del form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPagarCuota_Load(object sender, EventArgs e)
        {
            this.txtNombre.Text = socio.Nombre;
            this.txtApellido.Text = socio.Apellido;
            this.txtDni.Text = socio.Dni.ToString();
            this.cmbActividad.DataSource = Enum.GetValues(typeof(Socio.EActividad));
            this.cmbMetodoDePago.DataSource = Enum.GetValues(typeof(Cuota.EMetodoDePago));
        }
        /// <summary>
        /// Valida los campos, si estan ok genero una nueva cuota con los datos ingresados y con el metodo RegistrarPago() de Socio
        /// agrego esta cuota a la lista de cuotas del socio, si esta todo ok se cierra el form y se vuelve al principal.
        /// Si algo salió mal se arrojara la exception que corresponda.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ValidarCampos();
                Cuota cuota;
                Cuota.EMetodoDePago metodoDePago = (Cuota.EMetodoDePago)this.cmbMetodoDePago.SelectedItem;
                int importe = int.Parse(this.txtImporte.Text);
                Socio.EActividad actividad = (Socio.EActividad)this.cmbActividad.SelectedItem;
                DateTime fechaCuota = this.dtpFechaCuota.Value;
                int dniSocio = socio.Dni;

                cuota = new Cuota(metodoDePago, importe, actividad, fechaCuota, dniSocio);
                
                Socio.RegistrarPago(this.socio, cuota);
                GestorSQL.AltaCuota(this.socio, cuota);
                this.Close();
            }
            catch (CampoVacioException ex)
            {
                MessageBox.Show(ex.Message, "Error al registrar el pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ImporteInvalidoException ex)
            {
                MessageBox.Show(ex.Message, "Error al registrar el pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
            catch (RegistroPagoCuotaException ex)
            {
                MessageBox.Show(ex.Message, "Error al registrar el pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al registrar el pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Cancela la instancia del formulario de modificar cerrandolo y volviendo al form principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Verifica que el importe sea un numero positivo, en caso contrario arrojará las exceptions correspondientes
        /// </summary>
        /// <returns></returns>
        /// <exception cref="CampoVacioException"></exception>
        /// <exception cref="ImporteInvalidoException"></exception>
        private bool ValidarCampos()
        {
            if (this.txtImporte.Text == string.Empty)
            {
                throw new CampoVacioException("EL importe no puede estar vacío");
            }
            else if (!int.TryParse(this.txtImporte.Text, out int importe))
            {
                throw new ImporteInvalidoException("El importe debe ser un número");
            }
            else if (int.Parse(this.txtImporte.Text) <= 0)
            {
                throw new ImporteInvalidoException("El importe debe ser mayor a cero");
            }
            return true;
        }
        #endregion        
    }
}
