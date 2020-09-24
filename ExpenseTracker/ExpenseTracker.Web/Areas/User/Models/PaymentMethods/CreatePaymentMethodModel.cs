using ExpenseTracker.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Web.Areas.User.Models.PaymentMethods
{
    public class CreatePaymentMethodModel : PaymentMethodBaseModel
    {
        public string Name { get; set; }

        public void Create()
        {
            var paymentMethod = new PaymentMethod { Name = Name };
            _paymentMethodService.Create(paymentMethod);
        }
    }
}
