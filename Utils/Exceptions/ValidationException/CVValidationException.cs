using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Exceptions.ValidationException
{
    public class CVValidationException: Exception
    {
        public CVValidationException() : base(){ }

        public CVValidationException(string message) : base(message) { }

        public CVValidationException(string message,  Exception innerException) : base(message, innerException) { }

    }
}
