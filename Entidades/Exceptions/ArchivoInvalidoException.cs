using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    public class ArchivoInvalidoException : Exception
    {
        public ArchivoInvalidoException(string message) : base(message)
        {
        }

        public ArchivoInvalidoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
