using AspNetCore;
using ExpenseTracker.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Web.Areas.User.Models.PaymentMethods
{
    public class EditPaymentMethodModel : PaymentMethodBaseModel
    {
        public string Name { get; set; }
        public int Id { get; set; }


        public void Edit()
        {
            var paymentMethod = new PaymentMethod();
            paymentMethod.Name = Name;
            _paymentMethodService.Update(paymentMethod);
        }

        public void Load(int id)
        {
            PaymentMethod paymentMethod = _paymentMethodService.GetById(id);
            Name = paymentMethod.Name;
        }
    }
}
