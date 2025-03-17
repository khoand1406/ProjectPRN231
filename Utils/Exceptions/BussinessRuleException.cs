using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Exceptions
{
    public class BussinessRuleException: Exception
    {
        public BussinessRuleException(): base() { }

        public BussinessRuleException(string message) : base(message) { }

        public BussinessRuleException(string message, Exception innerException) : base(message, innerException) { }
    }
}
