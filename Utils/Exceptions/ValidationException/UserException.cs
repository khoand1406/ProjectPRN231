using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Exceptions.User
{
    public class UserValidationException : Exception
    {
        public UserValidationException() : base() { }

        public UserValidationException(string message) : base(message) { }

        public UserValidationException(string message, Exception innerException) : base(message, innerException) { }
    }
}
