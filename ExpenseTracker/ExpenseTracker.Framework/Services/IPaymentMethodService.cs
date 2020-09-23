﻿using ExpenseTracker.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Framework.Services
{
    public interface IPaymentMethodService
    {
        void Create(PaymentMethod paymentMethod);
        void Update(PaymentMethod paymentMethod);
        void Remove(PaymentMethod paymentMethod);
        void GetAll();
        (IList<PaymentMethod> records, int total, int totalFiltered) GetPaymentMethods(int pageIndex, int pageSize, string searchText, string sortText);
    }
}
