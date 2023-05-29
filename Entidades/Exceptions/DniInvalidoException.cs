using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    public class DniInvalidoException : Exception
    {
        public DniInvalidoException(string mensaje) : base(mensaje)
        {
        }

        public DniInvalidoException(string mensaje, Exception inner) : base(mensaje, inner)
        {
        }
        
    }
}
