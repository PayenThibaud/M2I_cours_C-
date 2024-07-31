using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo09Exceptions
{
    internal class AgeException : Exception
    {
        public AgeException(string message) : base(message)
        {
        }
    }
}
