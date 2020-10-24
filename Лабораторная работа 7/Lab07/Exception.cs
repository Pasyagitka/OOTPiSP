using System;
using System.Collections.Generic;
using System.Text;

namespace Lab06
{
    public class WrongWeightException : Exception
    {
        public WrongWeightException(string message) :base (message)   {     }
    }

    public class ZeroException : Exception
    {
        public ZeroException(string message) : base(message) { }
    }
}
