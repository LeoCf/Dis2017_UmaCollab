using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace umaCollabApp.entities.Exceptions
{
    public class MandatoryException : Exception
    {
        public MandatoryException(string message)
            : base(message) { }
     
    }
}
