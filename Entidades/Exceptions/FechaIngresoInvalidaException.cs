using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    public class FechaIngresoInvalidaException : Exception
    {
        public FechaIngresoInvalidaException(string mensaje) : base(mensaje)
        {
        }

        public FechaIngresoInvalidaException(string mensaje, Exception inner) : base(mensaje, inner)
        {
        }
    }
}
