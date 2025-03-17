using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Exceptions
{
    public class AuthorizeException:Exception
    {
        public AuthorizeException(): base() { }

        public AuthorizeException(string message) : base(message) { }

    }
}
