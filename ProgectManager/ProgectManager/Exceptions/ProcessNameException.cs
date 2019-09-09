using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgectManager.Exceptions
{
    internal class ProcessNameException : Exception
    {
        public ProcessNameException(string message) : base(message)
        { }
    }
}
