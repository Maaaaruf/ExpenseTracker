using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
