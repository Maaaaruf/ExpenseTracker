using ExpenseTracker.Data;
using ExpenseTracker.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Framework.UnitOfWorks
{
    public interface IExpenseUnitOfWork : IUnitOfWork
    {
        IPaymentMethodRepository PaymentMethodRepository { get; set; }
    }
}
