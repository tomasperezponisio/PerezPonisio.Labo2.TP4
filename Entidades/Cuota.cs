using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cuota
    {
        #region Anidados
        public enum EMetodoDePago { Efectivo, Debito, Credito, MercadoPago }

        #endregion

        #region Atributos
        private EMetodoDePago metodoDePago;
        private Socio.EActividad actividad;
        private int importe;
        private DateTime fechaCuota;
        private string mesCuota;
        private string anioCuota;
        private int dniSocio;                // VA A SER MI FK EN LA BASE DE DATOS
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad para asginar o traer el dato del atributo metodoDePago
        /// </summary>
        public EMetodoDePago MetodoDePago
        {
            get { return metodoDePago; }
            set { metodoDePago = value; }
        }
        /// <summary>
        /// Propiedad para asginar o traer el dato del atributo importe
        /// </summary>
        public int Importe
        {
            get { return importe; }
            set { importe = value; }
        }
        /// <summary>
        /// Propiedad para asginar o traer el dato del atributo actividad que es del tipo anidado Socio.EActividad
        /// </summary>
        public Socio.EActividad Actividad
        {
            get { return actividad; }
            set { actividad = value; }
        }
        /// <summary>
        /// Propiedad para asginar o traer el dato del atributo fechaCuota
        /// </summary>
        public DateTime FechaCuota
        {
            get { return fechaCuota; }
            set { fechaCuota = value; }
        }
        /// <summary>
        /// Propiedad para asginar o traer el dato del atributo mesCuota
        /// </summary>
        public string MesCuota
        {
            get { return mesCuota; }
            set { mesCuota = value; }
        }
        /// <summary>
        // Propiedad para asginar o traer el dato del atributo anioCuota
        /// </summary>
        public string AnioCuota
        {
            get { return anioCuota; }
            set { anioCuota = value; }
        }
        /// <summary>
        // Propiedad para asginar o traer el dato del atributo anioCuota
        /// </summary>
        public int DniSocio
        {
            get { return dniSocio; }
            set { dniSocio = value; }
        }
        #endregion

        #region Constructor
        public Cuota()
        {
        }
        public Cuota(EMetodoDePago metodoDePago, int importe, Socio.EActividad actividad, DateTime fechaCuota, int dniSocio)
        {
            this.metodoDePago = metodoDePago;
            this.importe = importe;
            this.actividad = actividad;
            this.fechaCuota = fechaCuota;
            this.mesCuota = MesCuotaString(fechaCuota);
            this.anioCuota = AnioCuotaString(fechaCuota);
            this.dniSocio = dniSocio;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Extrae del atributo fechaCuota, que es del tipo DateTime, el mes y lo guarda como string
        /// </summary>
        /// <param name="fechaCuota"></param>
        /// <returns>string</returns>
        private string MesCuotaString(DateTime fechaCuota)
        {
            string mesCuota = string.Empty;
            mesCuota = fechaCuota.ToString("MM");
            return mesCuota;
        }
        /// <summary>
        /// Extrae del atributo fechaCuota, que es del tipo DateTime, el año y lo guarda como string
        /// </summary>
        /// <param name="fechaCuota"></param>
        /// <returns>string</returns>
        private string AnioCuotaString(DateTime fechaCuota)
        {
            string anioCuota = string.Empty;
            anioCuota = fechaCuota.ToString("yyyy");
            return anioCuota;
        }
        /// <summary>
        /// Sobrecarga del operador de igualdad dos cuotas, si las cuotas tienen iguales los atributos
        /// mesCuota y mesAnio, devuelve true 
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns>bool</returns>
        public static bool operator ==(Cuota c1, Cuota c2)
        {
            bool retorno = false;
            if (c1 is not null && c2 is not null)
            {
                if (c1.MesCuota == c2.MesCuota && c1.AnioCuota == c2.AnioCuota)
                {
                    retorno = true;
                }
            }
            return retorno;
        }
        public static bool operator !=(Cuota c1, Cuota c2)
        {
            return !(c1 == c2);
        }
        /// <summary>
        /// Override del metodo ToString para la clase cuota para retornar los datos del objeto instanciado
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Año: {this.AnioCuota} | Mes: {this.MesCuota} | Metodo de Pago: {this.MetodoDePago} | Actividad: {this.actividad} | Importe: ${this.Importe}";
        } 
        #endregion
    }
}
