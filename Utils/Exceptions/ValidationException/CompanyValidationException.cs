using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Exceptions.ValidationException
{
    public class CompanyValidationException: Exception
    {
        public CompanyValidationException(): base() { }

        public CompanyValidationException(string message) : base(message) { }

        public CompanyValidationException(string message,  Exception innerException) : base(message, innerException) { }
    }
}
