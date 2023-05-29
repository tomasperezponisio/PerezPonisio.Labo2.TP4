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
using Entidades.GestorSQL;
using System.Threading;

namespace Formulario
{
    public partial class frmInicio : Form
    {
        #region Atributos, delegados, eventos
        private Club club;
        private Serializer<List<Socio>> serializer = new Serializer<List<Socio>>(GestorDeArchivo.ETipo.XML);

        public delegate void CargandoBaseDeDatos(int tiempo);
        public delegate void FinCargaBaseDeDatos();

        public event CargandoBaseDeDatos InformeCargando;
        public event FinCargaBaseDeDatos FinDeCarga;
        #endregion

        #region Botones y eventos del form
        public frmInicio()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Al cargar el formulario se busca si ya existe un archivo xml con datos de socios existentes, si lo encuentra se lee
        /// y se crea un club con esa lista de socios encontrada. Si no hay archivo de datos se crea un club de cero.
        /// Se actualiza la vista de la listbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmInicio_Load(object sender, EventArgs e)
        {
            //this.lblCargando.Text = "";
            this.btnCargar.Enabled = false;
            this.btnModificar.Enabled = false;
            this.btnEstadoDeCuenta.Enabled = false;
            this.btnEliminar.Enabled = false;
            this.btnPagarCuota.Enabled = false;
            this.btnExportar.Enabled = false;

            this.club = new Club("Club Armenio");
        }
        /// <summary>
        /// Instancia un formulario de carga de socios enviandole el club creado en etse formulario principal,
        /// y al volver actualiza la vista de la lista de socios por si se agregó uno nuevo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCargar_Click(object sender, EventArgs e)
        {
            frmCarga frm = new frmCarga(this.club);
            frm.ShowDialog();
            this.ActualizaListaSocios();
        }
        /// <summary>
        /// Checkea si la listabox quedó vacía y en ese caso inahbilita los botones de interaccion con socios ya que no hay ninguno para interactuar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstPersonas.SelectedIndex == -1)
            {
                this.btnCargar.Enabled = false;
                this.btnModificar.Enabled = false;
                this.btnEstadoDeCuenta.Enabled = false;
                this.btnEliminar.Enabled = false;
                this.btnPagarCuota.Enabled = false;
            }
            else
            {
                this.btnCargar.Enabled = true;
                this.btnModificar.Enabled = true;
                this.btnEstadoDeCuenta.Enabled = true;
                this.btnEliminar.Enabled = true;
                this.btnPagarCuota.Enabled = true;
                this.btnExportar.Enabled = true;
            }
        }
        /// <summary>
        /// Si hay algun socio seleccionado en la lista, instancia un formulario para modificar los datos del socio seleccionado y al 
        /// regresar actualiza la lista de socios en caso que se haya realizado alguna modificación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            Socio socio;
            if (this.lstPersonas.SelectedIndex != -1)
            {
                socio = (Socio)this.lstPersonas.SelectedItem;
                frmModificar frm = new frmModificar(this.club, socio);
                frm.ShowDialog();
                this.ActualizaListaSocios();
            }
            else
            {
                MessageBox.Show("No hay ningún socio seleccionado", "Modificar socio", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Si hay algun socio seleccionado en la lista es eliminado de la lista de socios del club previa confirmación,
        /// y actualiza la lista de socios en caso que se haya confirmado la eliminación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Socio socio;
            try
            {
                if (this.lstPersonas.SelectedIndex != -1)
                {
                    if (MessageBox.Show("Esta seguro que desea eliminar al socio?", "Eliminar socio", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        socio = (Socio)this.lstPersonas.SelectedItem;
                        MessageBox.Show(this.club.EliminarSocio(socio), "Eliminar socio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GestorSQL.Borrar(socio.Dni);
                        this.ActualizaListaSocios();
                    }
                    else
                    {
                    }
                }
            }
            catch (ExceptionSQL ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar el socio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar el socio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Si hay algun socio seleccionado se instancia un formulario para agregar una cuota a la lista de cuotas del socio.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPagarCuota_Click(object sender, EventArgs e)
        {
            Socio socio;
            if (this.lstPersonas.SelectedIndex != -1)
            {
                socio = (Socio)this.lstPersonas.SelectedItem;
                frmPagarCuota frm = new frmPagarCuota(socio);
                frm.ShowDialog();
            }
        }
        /// <summary>
        /// Si hay algun socio seleccionado se instancia un formulario para ver el estado de cuenta del mismo, si esta
        /// al día con las cuotas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblEstadoDeCuenta_Click(object sender, EventArgs e)
        {
            Socio socio;
            if (this.lstPersonas.SelectedIndex != -1)
            {
                socio = (Socio)this.lstPersonas.SelectedItem;
                frmEstadoDeCuenta frm = new frmEstadoDeCuenta(socio);
                frm.ShowDialog();
            }
        }
        /// <summary>
        /// Exporta los datos de la lista de socios a un archivo "dataSocios.xml" en una carpeta llamada XML en el escritorio.
        /// Si el archivo ya existe lo sobreescribe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>                
        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                GestorSQL.LeerDatosClub(this.club);
                this.serializer.Escribir("dataSocios.xml", this.club.ListaSocios);
                MessageBox.Show($"Datos exportados con éxito.\nEl archivo dataSocios.xml se encuentra en: {this.serializer.RutaDeEscritura()}", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArchivoInvalidoException ex)
            {
                MessageBox.Show(ex.Message, "Error al escribir el archivo de datos de socios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExceptionSQL ex)
            {
                MessageBox.Show(ex.Message, "Error al ingresar al club", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Pide confirmación para cerrar el programa y avisa si quiere guardar los datos de la lista de socios.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmInicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea salir?\nExporte la los datos de la lista antes de salir.", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
            }
            else
            {
                e.Cancel = true;
            }

        }
        /// <summary>
        /// En un hilo paralelo lee la base de datos, trae la lista de socios y la carga en el listbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeerSql_Click(object sender, EventArgs e)
        {
            this.InformeCargando += CargandoBase;
            this.FinDeCarga += FinDeCargaBase;

            Task task = Task.Run(IniciarCarga);
        }
        #endregion
        
        #region Metodos
        /// <summary>
        /// Actualiza la listbox con los datos de la lista de socios del club
        /// </summary>
        private void ActualizaListaSocios()
        {
            try
            {
                this.club.ListaSocios = GestorSQL.LeerDatosSocio();
                this.club.ListaSocios.Sort((Socio s1, Socio s2) => string.Compare(s1.Nombre, s2.Nombre));
                this.lstPersonas.DataSource = null;
                this.lstPersonas.DataSource = club.ListaSocios;
            }
            catch (ExceptionSQL ex)
            {
                MessageBox.Show(ex.Message, "Error al ingresar al club", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al la base de datos SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// Metodo que invoca a los metodos que muestran el estado de la carga de la base de datos y del método
        /// que informa cuando la base de datos ya fue cargada
        /// </summary>
        public void IniciarCarga()
        {
            int contador = 5000;
            while (contador > 0)
            {
                contador -= 1000;
                if (this.InformeCargando is not null)
                {
                    this.InformeCargando.Invoke(contador);
                    Thread.Sleep(1000);
                }
            }
            if (this.FinDeCarga is not null)
            {
                this.FinDeCarga.Invoke();
            }
        }
        /// <summary>
        /// Informa el estado de la carga de la base de datos.
        /// </summary>
        /// <param name="tiempo"></param>
        private void CargandoBase(int tiempo)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(InformeCargando, new Object[] { tiempo });
            }
            else
            {
                this.lblCargando.ForeColor = Color.Red;
                this.lblCargando.Text = "Cargando base de datos en " + tiempo / 1000 + " segundos";
            }
        }
        /// <summary>
        /// Informa cuando la base de datos ya fue cargada.
        /// </summary>
        private void FinDeCargaBase()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(FinDeCarga);
            }
            else
            {
                this.ActualizaListaSocios();
                this.lblCargando.ForeColor = Color.Green;
                this.lblCargando.Text = "Base de datos cargada";
            }
        }
        
        #endregion
    }
}
