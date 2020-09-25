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
            if (paymentMethod == null)
                throw new EntityNullException<PaymentMethod>();

            int count = _expenseUnitOfWork.PaymentMethodRepository.GetCount(x=>x.Name == paymentMethod.Name);

            if (count > 0)
                throw new DuplicationException("Repeated item found", paymentMethod.Name);

            _expenseUnitOfWork.PaymentMethodRepository.Add(paymentMethod);
            _expenseUnitOfWork.Save();

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
            _expenseUnitOfWork.PaymentMethodRepository.Remove(paymentMethod);
            _expenseUnitOfWork.Save();
        }

        public (IList<PaymentMethod> records, int total, int totalFiltered) GetPaymentMethods(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var (data, total, totalFiltered) = _expenseUnitOfWork.PaymentMethodRepository.GetDynamic(x => x.Name.Contains(searchText), sortText, null, pageIndex, pageSize, true);
            return (data, total, totalFiltered);
        }

        public PaymentMethod GetById(int id)
        {
            return _expenseUnitOfWork.PaymentMethodRepository.GetById(id);
        }

        public void Remove(int id)
        {
            int count = _expenseUnitOfWork.PaymentMethodRepository.GetCount(x => x.Id == id);

            if (count > 0)
            {
                _expenseUnitOfWork.PaymentMethodRepository.Remove(id);
                _expenseUnitOfWork.Save();
            }
        }
    }
}
