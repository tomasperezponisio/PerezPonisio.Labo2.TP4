using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    public class ImporteInvalidoException : Exception
    {
        public ImporteInvalidoException(string message) : base(message)
        {
        }

        public ImporteInvalidoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
