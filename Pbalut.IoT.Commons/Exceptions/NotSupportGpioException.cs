using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbalut.IoT.Commons.Exceptions
{
    public class NotSupportGpioException : Exception
    {
        public NotSupportGpioException(string message) 
            : base(message)
        {
        }
    }
}
