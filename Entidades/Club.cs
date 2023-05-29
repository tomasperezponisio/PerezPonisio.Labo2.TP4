using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Club
    {        
        #region Atributos
        private List<Socio> listaSocios;        
        private string nombre;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad para asginar o traer el dato del atributo listaSocios
        /// </summary>
        public List<Socio> ListaSocios
        {
            get { return listaSocios; }
            set { listaSocios = value; }
        }
        #endregion

        #region Constructores
        public Club(string nombre)
        {
            this.nombre = nombre;
            this.listaSocios = new List<Socio>();            
        }
        public Club(string nombre, List<Socio> listaSocios)
        {
            this.nombre = nombre;
            this.listaSocios = listaSocios;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Sobrecarga del operador de igualdad entre un club y un socio, si el club tiene ese socio en la lista de socios que
        /// tiene como atrubuto, devuelve true, si el socio no se encuentra devuelve false
        /// </summary>
        /// <param name="c"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool operator ==(Club c, Socio s)
        {
            bool retorno = false;
            if (c is not null && s is not null)
            {
                foreach (Socio item in c.listaSocios)
                {
                    if (item == s)
                    {
                        retorno = true;
                    }
                }
            }
            return retorno;
        }
        public static bool operator !=(Club c, Socio s)
        {
            return !(c == s);
        }
        /// <summary>
        /// Sobrecarga del operador suma entre un club y un socio, si se quiere agregar un socio a la lista de socios del club y en
        /// ella se encuentra otro socio con el mismo dni (utilizando la sobrecarga del operador == de persona) retorna false, 
        /// si no, retorna true y agrega el socio a la lista del club        
        /// </summary>
        /// <param name="c"></param>
        /// <param name="s"></param>
        /// <returns>bool</returns>
        public static bool operator +(Club c, Socio s)
        {
            bool retorno = false;
            if (c is not null && s is not null)
            {
                if (c != s)
                {
                    c.listaSocios.Add(s);
                    retorno = true;
                }
            }
            return retorno;
        }
        /// <summary>
        /// obrecarga del operador resta entre un club y un socio, si se quiere remover un socio de la lista de socios del club y en ella no se encuentra dicho socio, retorna false,
        /// en cambio si el socio si esta en la lista, es removido y retorna true
        /// </summary>
        /// <param name="c"></param>
        /// <param name="s"></param>
        /// <returns>bool</returns>
        public static bool operator -(Club c, Socio s)
        {
            bool retorno = false;
            if (c is not null && s is not null)
            {
                if (c == s)
                {
                    c.listaSocios.Remove(s);
                    retorno = true;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Utilizando la sobrecarga del operador resta entre un club y un socio,
        /// remueve el socio que recibe como paramtero de la lista del club
        /// y retorna un mensaje en un string avisando si lo pudo remover o no
        /// </summary>
        /// <param name="socio"></param>
        /// <returns>string</returns>
        public string EliminarSocio(Socio socio)
        {
            string mensaje = "El socio no se ha encontrado";
            if (this - socio)
            {
                mensaje = "Socio eliminado con exito";
            }
            return mensaje;
        }
        /// <summary>
        /// Retorna en un string los datos de los socios que se encuentren en la lista de socios del club
        /// </summary>
        /// <returns>string</returns>
        public string ImprimirListaSocios()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Socio socio in this.listaSocios)
            {
                sb.AppendLine($"{socio.ToString()}");
            }            
            return sb.ToString();
        }
        #endregion        
    }
}
