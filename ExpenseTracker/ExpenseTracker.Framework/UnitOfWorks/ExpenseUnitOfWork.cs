using ExpenseTracker.Data;
using ExpenseTracker.Framework.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Framework.UnitOfWorks
{
    public class ExpenseUnitOfWork : UnitOfWork
    {
        public IPaymentMethodRepository PaymentMethodRepository { get; set; }
        public ExpenseUnitOfWork(DbContext dbContext,
           IPaymentMethodRepository paymentMethodRepository ) : base(dbContext)
        {
            PaymentMethodRepository = paymentMethodRepository;
        }
    }
}
