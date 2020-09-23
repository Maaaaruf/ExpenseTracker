using ExpenseTracker.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Framework.UnitOfWorks
{
    public class ExpenseUnitOfWork : UnitOfWork
    {
        public ExpenseUnitOfWork(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
