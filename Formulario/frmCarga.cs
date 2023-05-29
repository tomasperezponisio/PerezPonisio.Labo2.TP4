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
using Entidades.Extension;
using Entidades.GestorSQL;

namespace Formulario
{
    public partial class frmCarga : Form
    {
        #region Atributos
        private Club club;
        #endregion

        #region Botones y eventos del form
        public frmCarga(Club club)
        {
            InitializeComponent();
            this.club = club;
        }
        /// <summary>
        /// al cargar el formulario cargo las opciones de los combo box con los datos de los anidados de socio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCarga_Load(object sender, EventArgs e)
        {
            this.cmbEnum1.DataSource = Enum.GetValues(typeof(Socio.ECategoria));
            this.cmbEnum2.DataSource = Enum.GetValues(typeof(Socio.EActividad));
        }
        
        /// <summary>
        /// Valida los campos y en especial el dni, si esta todo ok, se crea un socio con estos datos y se agrega al club que recibió
        /// como parametro al ser instanciado el formulario.
        /// Fallas en la validacion de los datos arrojaran las excepciones que correspondan.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ValidarCampos();
                this.ValidarDniExistente(int.Parse(this.txtDni.Text));

                string nombre = this.txtNombre.Text;
                string apellido = this.txtApellido.Text;
                int dni = int.Parse(this.txtDni.Text);
                DateTime fechaNacimiento = this.dtpFechaNacimiento.Value;
                Socio.ECategoria categoria = (Socio.ECategoria)this.cmbEnum1.SelectedItem;
                Socio.EActividad actividad = (Socio.EActividad)this.cmbEnum2.SelectedItem;

                Socio socio = new Socio(nombre, apellido, dni, fechaNacimiento, actividad, categoria);
                string mensaje = string.Empty;

                if (this.IngresarSocio(this.club, socio))
                {
                    GestorSQL.AltaSocio(socio);
                    MessageBox.Show("Socio agreado con éxito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
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
        /// Cancela la instancia del formulario de carga cerrandolo y volviendo al form principal
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
        /// Verifica que los campos no esten vacios y que el dni sea un numero valido, arroja exceptions en caso de no validar.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="CampoVacioException"></exception>
        /// <exception cref="DniInvalidoException"></exception>
        /// <exception cref="FechaNacimientoInvalidaException"></exception>
        private bool ValidarCampos()
        {
            if (this.txtNombre.Text == string.Empty || this.txtApellido.Text == string.Empty || this.txtDni.Text == string.Empty)
            {                
                throw new CampoVacioException("Todos los campos deben estar completos");
            }
            else if (!int.TryParse(this.txtDni.Text, out int dni))
            {
                throw new DniInvalidoException("El DNI debe ser un número");
            }
            else if (int.Parse(this.txtDni.Text) <= 0 || int.Parse(this.txtDni.Text) >= 99999999)
            {
                throw new DniInvalidoException("El DNI debe ser un número entre 0 y 99.999.999");
            }
            else if (int.Parse(this.txtDni.Text).CantidadDeDigitos() < 7 || int.Parse(this.txtDni.Text).CantidadDeDigitos() > 8)
            {
                throw new CantidadDeDigitosException("El DNI debe tener 7 u 8 dígitos");
            }
            else if (this.dtpFechaNacimiento.Value >= DateTime.Now)
            {
                throw new FechaNacimientoInvalidaException("La Fecha de nacimiento debe ser menor a la fecha actual");
            }
            return true;
        }
        /// <summary>
        /// Recibe un entero y verifica si algun socio de la lista de socios del club tiene el midmo numero de dni, si ya existe el dni en
        /// cuestión, arroja un exception
        /// </summary>
        /// <param name="dni"></param>
        /// <returns>bool</returns>
        /// <exception cref="DniInvalidoException"></exception>
        private bool ValidarDniExistente(int dni)
        {
            foreach (Socio socio in this.club.ListaSocios)
            {
                if (socio.Dni == dni)
                {
                    throw new DniInvalidoException("El DNI ya existe en la base de socios");
                }
            }
            return true;
        }
        /// <summary>
        /// Recibe un club y un socio como parametros e intenta agregar el socio a la lista de socios del club, si no se puede
        /// arroja una exception
        /// </summary>
        /// <param name="club"></param>
        /// <param name="socio"></param>
        /// <returns></returns>
        /// <exception cref="IngresoAlClubException"></exception>
        private bool IngresarSocio(Club club, Socio socio)
        {
            if (!(this.club != socio && club + socio))
            {
                throw new IngresoAlClubException("No se pudo agregar el socio");
            }
            return true;
        } 
        #endregion


    }
}
