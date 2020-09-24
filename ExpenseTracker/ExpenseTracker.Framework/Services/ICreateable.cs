using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Framework.Services
{
    public interface ICreateable<T>
    {
        void Create(T entity);
    }
}
