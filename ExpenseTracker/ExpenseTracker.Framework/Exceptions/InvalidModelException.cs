using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Framework.Exceptions
{
    public class InvalidModelException : Exception
    {
        public InvalidModelException(string message)
            : base(message)
        {
            
        }
    }
}
