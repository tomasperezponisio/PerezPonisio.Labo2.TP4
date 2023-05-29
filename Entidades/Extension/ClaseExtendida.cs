using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Extension
{
    public static class ClaseExtendida
    {
        /// <summary>
        /// Metodo que extiende la clase int, retorna la cantidad de digitos de un entero
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>un entero, la cantidad de digitos del numero</returns>
        public static int CantidadDeDigitos(this int numero)
        {
            return numero.ToString().Length;
        }
    }
}
