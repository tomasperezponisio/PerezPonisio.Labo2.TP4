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
    public partial class frmModificar : Form
    {
        #region Atributos
        private Club club;
        private Socio socio;
        #endregion

        #region Botones y eventos del form        
        public frmModificar(Club club, Socio socio)
        {
            InitializeComponent();
            this.club = club;
            this.socio = socio;
        }
        /// <summary>
        /// Carga en los textbox correspondientes los datos del socio recibido como parametro en la instancia del form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmModificar_Load(object sender, EventArgs e)
        {
            this.txtNombre.Text = socio.Nombre;
            this.txtApellido.Text = socio.Apellido;
            this.txtDni.Text = socio.Dni.ToString();
            this.txtDni.Enabled = false;
            this.dtpFechaNacimiento.Value = socio.FechaNacimiento;
            this.cmbEnum1.DataSource = Enum.GetValues(typeof(Socio.ECategoria));
            this.cmbEnum2.DataSource = Enum.GetValues(typeof(Socio.EActividad));
            this.cmbEnum1.SelectedItem = socio.Categoria;
            this.cmbEnum2.SelectedItem = socio.Actividad;
        }
        /// <summary>
        /// Valida los campos y si estan OK modifica los datos del socio, si algun campo no esta ok, tira exception.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ValidarCampos();

                this.socio.Nombre = this.txtNombre.Text;
                this.socio.Apellido = this.txtApellido.Text;
                this.socio.FechaNacimiento = this.dtpFechaNacimiento.Value;
                this.socio.Categoria = (Socio.ECategoria)this.cmbEnum1.SelectedItem;
                this.socio.Actividad = (Socio.EActividad)this.cmbEnum2.SelectedItem;                
                GestorSQL.ModificarSocio(this.socio, this.socio.Dni);

                MessageBox.Show("Socio editado con éxito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (DniInvalidoException ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar los datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (CampoVacioException ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar los datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IngresoAlClubException ex)
            {
                MessageBox.Show(ex.Message, "Error al ingresar al club", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExceptionSQL ex)
            {
                MessageBox.Show(ex.Message, "Error al ingresar al club", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// Verifica que los campos no esten vacios, arroja exceptions en caso de no validar.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="CampoVacioException"></exception>
        /// <exception cref="DniInvalidoException"></exception>
        /// <exception cref="FechaNacimientoInvalidaException"></exception>
        private bool ValidarCampos()
        {
            if (this.txtNombre.Text == string.Empty || this.txtApellido.Text == string.Empty)
            {
                throw new CampoVacioException("Todos los campos deben estar completos");
            }            
            else if (this.dtpFechaNacimiento.Value >= DateTime.Now)
            {
                throw new FechaNacimientoInvalidaException("La Fecha de nacimiento debe ser menor a la fecha actual");
            }
            return true;
        } 
        #endregion
    }
}
