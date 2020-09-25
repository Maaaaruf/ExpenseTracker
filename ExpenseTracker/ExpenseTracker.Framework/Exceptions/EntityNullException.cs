using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Framework.Exceptions
{
    public class EntityNullException<T> : Exception
    {
        public Type Entitytype { get; set; }
        public EntityNullException()
            : base("Entity Null Exception for Entity " + typeof(T).FullName)
        {
            Entitytype = typeof(T);
        }
    }
}
