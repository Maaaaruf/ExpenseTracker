using ExpenseTracker.Data;
using ExpenseTracker.Framework.Contexts;
using ExpenseTracker.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Framework.Repositories
{
    public interface IPaymentMethodRepository : IRepository<PaymentMethod, int, FrameworkContext>
    {

    }
}
