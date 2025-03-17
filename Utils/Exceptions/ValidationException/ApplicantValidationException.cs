using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Exceptions.ValidationException
{
    public class ApplicantValidationException : Exception
    {
        public ApplicantValidationException() : base() { }

        public ApplicantValidationException(string message) : base(message) { }

        public ApplicantValidationException(string mes, Exception innerexception) : base(mes, innerexception) { }
    }
}
