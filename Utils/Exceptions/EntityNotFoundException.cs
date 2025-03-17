using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Exceptions
{
    public class EntityNotFoundException:Exception
    {
        public EntityNotFoundException():base() { }

        public EntityNotFoundException(string entityname, int id ):base($"The entity {entityname} with {id} is not found") { }


    }
}
