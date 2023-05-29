using System;
using System.Text;
using System.Threading;
using System.Globalization;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Socio)), XmlInclude(typeof(Cuota))]
    public class Persona
    {
        #region Atributos        
        protected string nombre;
        protected string apellido;
        protected int dni;
        protected DateTime fechaNacimiento;
        protected int edad;                         
        #endregion
                
        #region Propiedades
        /// <summary>
        /// Propiedad para asginar o traer el dato del atributo nombre
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }
        /// <summary>
        /// Propiedad para asginar o traer el dato del atributo apellido
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = value;
            }
        }
        /// <summary>
        /// Propiedad para asginar o traer el dato del atributo dni
        /// 
        /// </summary>
        public int Dni
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = value;               
            }
        }
        /// <summary>
        /// Propiedad para asginar o traer el dato del atributo fechaNacimiento
        /// 
        /// </summary>
        public DateTime FechaNacimiento
        {
            get
            {
                return this.fechaNacimiento;
            }
            set
            {
                this.fechaNacimiento = value;   
            }
        }
        /// <summary>
        /// Propiedad para traer el dato del atributo edad
        /// 
        /// </summary>
        public int Edad
        {
            get
            {
                return this.edad;
            }
        }
        #endregion

        #region Constructor
        public Persona()
        {
            
        }
        public Persona(string nombre, string apellido, int dni, DateTime fechaNacimiento)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
            this.FechaNacimiento = fechaNacimiento;
            this.edad = this.CalcularEdad();            
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Calcula la edad de la persona haciendo la diferencia de tiempo entre el dia actual y la fecha de nacimiento ingresada.
        /// Retorna un entero que representa la edad en años
        /// </summary>
        /// <returns>int</returns>
        private int CalcularEdad()
        {
            int edad = (int)((DateTime.Now - this.FechaNacimiento).TotalDays / 365.242199);
            return edad;
        }
        /// <summary>
        /// Sobrecarga del operador de igualdad entre dos personas, si tienen el mismo dni son la misma persona y retorna true
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns>bool</returns>
        public static bool operator ==(Persona s1, Persona s2)
        {
            bool retorno = false;
            if (s1 is not null && s2 is not null)
            {
                if (s1.Dni == s2.Dni)
                {
                    retorno = true;
                }
            }
            return retorno;
        }        
        public static bool operator !=(Persona s1, Persona s2)
        {
            return !(s1 == s2);
        }        
        /// <summary>
        /// Override del metodo ToString para la clase persona para retornar los datos del objeto instanciado
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()                
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-AR");
            StringBuilder sb = new StringBuilder();            
            sb.Append($"Nombre: {this.Nombre} | ");
            sb.Append($"Apellido: {this.Apellido} | ");
            sb.Append($"DNI: {this.Dni} | ");
            sb.Append($"Fecha Nac.: {this.FechaNacimiento.ToShortDateString()}");                     
            return sb.ToString();
        }
        /// <summary>
        /// Devuelve en un string los datos de la persona instanciada de un dato por linea
        /// </summary>
        /// <returns>string</returns>
        public virtual string Imprimir()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Tipo:       {this.GetType().Name}");
            sb.AppendLine($"Nombre:     {this.Nombre}");
            sb.AppendLine($"Apellido:   {this.Apellido}");
            sb.AppendLine($"DNI:        {this.Dni}");
            sb.AppendLine($"Fecha Nac.: {this.FechaNacimiento.ToShortDateString()}");                    
            return sb.ToString();
        }
        #endregion
    }
}
