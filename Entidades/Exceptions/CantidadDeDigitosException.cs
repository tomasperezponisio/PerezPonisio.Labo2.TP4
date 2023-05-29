using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    public class CantidadDeDigitosException : Exception
    {
        public CantidadDeDigitosException(string message) : base(message)
        {
        }

        public CantidadDeDigitosException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
