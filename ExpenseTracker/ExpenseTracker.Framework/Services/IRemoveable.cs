using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Framework.Services
{
    public interface IRemoveable<T>
    {
        void Remove(T entity);
    }
}
