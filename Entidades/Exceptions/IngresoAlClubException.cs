using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    public class IngresoAlClubException : Exception
    {
        public IngresoAlClubException(string mensaje) : base(mensaje)
        {
        }

        public IngresoAlClubException(string mensaje, Exception inner) : base(mensaje, inner)
        {
        }
    }
}
