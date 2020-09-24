using ExpenseTracker.Framework.Entities;
using ExpenseTracker.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Framework.Services
{
    public interface IPaymentMethodService : 
        ICreateable<PaymentMethod>, 
        IUpdateable<PaymentMethod>, 
        IRemoveable<PaymentMethod>
    {
        
        (IList<PaymentMethod> records, int total, int totalFiltered) GetPaymentMethods(int pageIndex, int pageSize, string searchText, string sortText);
        PaymentMethod GetById(int id);
    }
}
