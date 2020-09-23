using ExpenseTracker.Data;
using ExpenseTracker.Framework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Framework.Repositories
{
    public class PaymentMethodRepository : Repository<PaymentMethod, int, DbContext>, IPaymentMethodRepository
    {
        public PaymentMethodRepository(DbContext context) : base(context)
        {
        }
    }
}
