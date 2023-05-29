using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    public class CampoVacioException : Exception
    {
        public CampoVacioException(string mensaje) : base(mensaje)
        {
        }

        public CampoVacioException(string mensaje, Exception inner) : base(mensaje, inner)
        {
        }
    }
}
