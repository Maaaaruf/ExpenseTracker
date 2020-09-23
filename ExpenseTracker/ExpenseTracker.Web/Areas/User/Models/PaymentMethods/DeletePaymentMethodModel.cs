using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Web.Areas.User.Models.PaymentMethods
{
    public class DeletePaymentMethodModel : PaymentMethodBaseModel
    {
        public void delete(int id)
        {
            _paymentMethodService.Remove(id);
        }
    }
}
