using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    public class FechaNacimientoInvalidaException : Exception
    {
        public FechaNacimientoInvalidaException(string mensaje) : base(mensaje)
        {
        }

        public FechaNacimientoInvalidaException(string mensaje, Exception inner) : base(mensaje, inner)
        {
        }
    }
}
