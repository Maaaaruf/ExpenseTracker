using System;

namespace ExpenseTracker.Data
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
