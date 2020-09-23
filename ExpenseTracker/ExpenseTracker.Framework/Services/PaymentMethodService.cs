using ExpenseTracker.Framework.Entities;
using ExpenseTracker.Framework.Exceptions;
using ExpenseTracker.Framework.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpenseTracker.Framework.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        public IExpenseUnitOfWork _expenseUnitOfWork;

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
            {
                _expenseUnitOfWork.PaymentMethodRepository.Add(paymentMethod);
                _expenseUnitOfWork.Save();
            }
        }

        public void Update(PaymentMethod paymentMethod)
        {
            int count = _expenseUnitOfWork.PaymentMethodRepository.GetCount(x => x.Name == paymentMethod.Name);

            if (count > 0)
                throw new DuplicationException("Repeated item found", paymentMethod.Name);

             var existing = _expenseUnitOfWork.PaymentMethodRepository.GetById(paymentMethod.Id);
             existing.Name = paymentMethod.Name;
            _expenseUnitOfWork.Save();
        }

        public void Remove(PaymentMethod paymentMethod)
        {
            throw new NotImplementedException();
        }

        public void GetAll()
        {
            throw new NotImplementedException();
        }

        public (IList<PaymentMethod> records, int total, int totalFiltered) GetPaymentMethods(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var result = _expenseUnitOfWork.PaymentMethodRepository.GetAll().ToList();

            return (result, 0, 0);
        }

        public PaymentMethod GetById(int id)
        {
            return _expenseUnitOfWork.PaymentMethodRepository.GetById(id);
        }
    }
}
