using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    public class RegistroPagoCuotaException : Exception
    {
        public RegistroPagoCuotaException(string message) : base(message)
        {
        }

        public RegistroPagoCuotaException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
