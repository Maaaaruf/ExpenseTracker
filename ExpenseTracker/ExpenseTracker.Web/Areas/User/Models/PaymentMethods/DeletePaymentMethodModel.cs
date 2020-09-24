using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Web.Areas.User.Models.PaymentMethods
{
    public class DeletePaymentMethodModel : PaymentMethodBaseModel
    {
        public int Id { get; set; }

        public string delete(int id)
        {
            var item = _paymentMethodService.GetById(id);
            _paymentMethodService.Remove(item);
            return item.Name;
        }
    }
}
