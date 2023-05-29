using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Exceptions;

namespace Entidades
{    
    public sealed class Socio : Persona
    {
        #region Anidados
        public enum EActividad { Basquet, Futbol, Natacion, Voley }
        public enum ECategoria { Joven, Adulto, Mayor }
        #endregion

        #region Atributos
        private EActividad actividad;
        private ECategoria categoria;                                                                                               
        private List<Cuota> historialDePagos;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad para asginar o traer el dato del atributo actividad que es del tipo anidado EActividad
        /// </summary>
        public EActividad Actividad
        {
            get { return actividad; }
            set { actividad = value; }
        }
        /// <summary>
        /// Propiedad para asginar o traer el dato del atributo categoria que es del tipo anidado ECategoria
        /// </summary>
        public ECategoria Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }
        /// <summary>
        /// Propiedad para asginar o traer el dato del atributo historialDePagos que es una lista de objetos del tipo Cuota
        /// </summary>
        public List<Cuota> HistorialDePagos
        {
            get { return historialDePagos; }
            set { historialDePagos = value; }
        }
        #endregion

        #region Constructores        
        public Socio(string nombre, string apellido, int dni, DateTime fechaNacimiento, EActividad eActividad, ECategoria categoria)
            : base(nombre, apellido, dni, fechaNacimiento)
        {
            this.actividad = eActividad;
            this.categoria = categoria;
            this.historialDePagos = new List<Cuota>();
        }
        public Socio() : this(String.Empty, String.Empty, -1, DateTime.Now, EActividad.Natacion, ECategoria.Joven)
        {
            this.historialDePagos = new List<Cuota>();
        }
        #endregion

        #region Metodos        
        /// <summary>
        /// Sobrecarga del operador de igualdad entre un socio y una cuota, si el socio tiene esa cuota en la lista de cuotas que
        /// tiene como atrubuto, devuelve true, si la cuota no se encuentra devuelve false
        /// </summary>
        /// <param name="s"></param>
        /// <param name="c"></param>
        /// <returns>bool</returns>
        public static bool operator ==(Socio s, Cuota c)
        {
            bool retorno = false;
            if (s is not null && c is not null)
            {
                foreach (Cuota item in s.historialDePagos)
                {
                    if (item == c)
                    {
                        retorno = true;
                    }
                }
            }
            return retorno;
        }
        public static bool operator !=(Socio s, Cuota c)
        {
            return !(s == c);
        }
        /// <summary>
        /// Sobrecarga del operador suma entre un socio y una cuota, si el socio no tiene esa cuota en la lista de cuotas que
        /// tiene como atrubuto la cuota se agrega a la lista y devuelve true
        /// </summary>
        /// <param name="s"></param>
        /// <param name="c"></param>
        /// <returns>bool</returns>
        public static bool operator +(Socio s, Cuota c)
        {
            bool retorno = false;
            if (s is not null && c is not null)
            {
                if (s != c)
                {
                    s.historialDePagos.Add(c);
                    retorno = true;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Si se quiere agregar una cuota a la lista de cuotas del socio  y en ella se encuentra otra cuota con mismo mes y anio
        /// se arroja una exception del tipo RegistroPagoCuotaException
        /// </summary>
        /// <param name="socio"></param>
        /// <param name="cuota"></param>
        /// <returns>bool</returns>
        /// <exception cref="RegistroPagoCuotaException"></exception>
        public static bool RegistrarPago(Socio socio, Cuota cuota)
        {
            if (!(socio != cuota && socio + cuota))
            {
                throw new RegistroPagoCuotaException("Este mes ya esta pago");
            }
            return true;
        }
        /// <summary>
        /// Recorre la lista de cuotas del socio en busca de una cuota con el mismo mes y anio al momento de la consulta,
        /// retorna true si la encuentra
        /// </summary>
        /// <returns>bool</returns>
        public bool VerificarSiEstaAlDia()
        {
            bool retorno = false;

            string mesActual = DateTime.Now.ToString("MM");
            string anioActual = DateTime.Now.ToString("yyyy");

            foreach (Cuota cuota in this.historialDePagos)
            {
                if (cuota.MesCuota == mesActual && cuota.AnioCuota == anioActual)
                {
                    retorno = true;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Override del metodo ToString para la clase socio para retornar los datos del objeto instanciado
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{base.ToString()}  | ");
            sb.Append($"Actividad: {this.Actividad}  | ");
            sb.Append($"Categoria: {this.Categoria}");
            return sb.ToString();
        }
        /// <summary>
        /// Devuelve en un string los datos de la persona instanciada de un dato por linea y llamando al metodo para verificar si esta al dia
        /// modifica la linea de estado de cuenta
        /// </summary>
        /// <returns>string</returns>
        public override string Imprimir()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{base.Imprimir()}");
            sb.AppendLine($"Actividad:  {this.Actividad}");
            sb.AppendLine($"Categoria:  {this.Categoria}");
            sb.AppendLine($"------------------------------");
            sb.Append($"ESTADO DE CUENTA: ");
            if (this.VerificarSiEstaAlDia())
            {
                sb.AppendLine("ESTÁ AL DIA");
            }
            else
            {
                sb.AppendLine("DEUDOR");
            }
            sb.AppendLine($"------------------------------");
            sb.AppendLine($"Historial de pagos:");
            foreach (Cuota cuota in this.historialDePagos)
            {
                sb.AppendLine($"{cuota.ToString()}");
            }
            return sb.ToString();
        }
        #endregion        
    }
}
