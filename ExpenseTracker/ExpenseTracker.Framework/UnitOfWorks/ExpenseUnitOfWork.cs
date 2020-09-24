using ExpenseTracker.Data;
using ExpenseTracker.Framework.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ExpenseTracker.Framework.Contexts;

namespace ExpenseTracker.Framework.UnitOfWorks
{
    public class ExpenseUnitOfWork : UnitOfWork, IExpenseUnitOfWork
    {
        public IPaymentMethodRepository PaymentMethodRepository { get; set; }
        public ExpenseUnitOfWork(FrameworkContext dbContext,
           IPaymentMethodRepository paymentMethodRepository ) : base(dbContext)
        {
            PaymentMethodRepository = paymentMethodRepository;
        }
    }
}
