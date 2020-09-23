using ExpenseTracker.Framework.Entities;
using ExpenseTracker.Framework.Exceptions;
using ExpenseTracker.Framework.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Framework.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        public IExpenseUnitOfWork _expenseUnitOfWork { get; set; }

        public PaymentMethodService(IExpenseUnitOfWork expenseUnitOfWork)
        {
            _expenseUnitOfWork = expenseUnitOfWork;
        }

        public void Create(PaymentMethod paymentMethod)
        {
            int count = _expenseUnitOfWork.PaymentMethodRepository.GetCount(x=>x.Name == paymentMethod.Name);
            
            if (count > 0)
                throw new DuplicationException("Repeated item found", paymentMethod.Name);
            else
                _expenseUnitOfWork.PaymentMethodRepository.Add(paymentMethod);
        }

        public void Update(PaymentMethod paymentMethod)
        {
            throw new NotImplementedException();
        }

        public void Remove(PaymentMethod paymentMethod)
        {
            throw new NotImplementedException();
        }

        public void GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
