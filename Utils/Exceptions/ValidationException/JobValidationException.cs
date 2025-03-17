using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Exceptions.ValidationException
{
    public class JobValidationException:Exception
    {
        public JobValidationException():base() { }

        public JobValidationException(string message):base(message) { }

        public JobValidationException(string message, Exception innerException):base(message, innerException) { }

    }
}
