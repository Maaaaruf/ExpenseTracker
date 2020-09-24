using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Framework.Services
{
    public interface IUpdateable<T>
    {
        void Update(T entity);
    }
}
