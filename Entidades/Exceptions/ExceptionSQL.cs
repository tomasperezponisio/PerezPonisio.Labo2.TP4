using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    public class ExceptionSQL : Exception
    {
        public ExceptionSQL(string message) : base(message)
        {
        }

        public ExceptionSQL(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
